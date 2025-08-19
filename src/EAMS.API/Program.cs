using EAMS.API.Configurations;
using EAMS.API.Middleware;
using EAMS.Infrastructure.Data;
using EAMS.Infrastructure.Repositories;
using EAMS.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddScoped<ICorrelationIdGenerator, CorrelationIdGenerator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "EAMS API", Version = "v1" });
    // OAuth2 authorization
    var tenantId = builder.Configuration["AzureAd:TenantId"];
    var authUrl = new Uri($"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/authorize");
    var tokenUrl = new Uri($"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token");
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = authUrl,
                TokenUrl = tokenUrl,
                Scopes = new Dictionary<string, string>
                {
                    {builder.Configuration["SwaggerOAuth:Scopes"]!, "Access as user"}
                }
            }
        }
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "oauth2"
                }
            },
            new[] { builder.Configuration["SwaggerOAuth:Scopes"]! }
        }
    });
});
builder.Services.AddDbContext<EamsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAccommodationRepository, AccommodationRepository>();

builder.Logging.AddApplicationInsights(
        configureTelemetryConfiguration: (config) =>
            config.ConnectionString = builder.Configuration.GetConnectionString("APPLICATIONINSIGHTS_CONNECTION_STRING"),
            configureApplicationInsightsLoggerOptions: (options) => { }
    );
builder.Services.AddApplicationInsightsTelemetry();

builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>("your-category", LogLevel.Trace);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EAMS API");
        c.OAuthClientId(builder.Configuration["SwaggerOAuth:ClientId"]!);
        c.OAuthUsePkce();
        c.OAuthScopeSeparator(" ");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

app.MapControllers();
app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<TelemetryLoggingMiddleware>();

app.Run();
