using AccommodationManagement.BFF.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// HTTP Client for Core API
builder.Services.AddHttpClient<ICoreApiService, CoreApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7002"); // Core API URL
    client.Timeout = TimeSpan.FromSeconds(30);
});

// CORS for MVC Frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("MVCPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:7000") // MVC URL
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("MVCPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
