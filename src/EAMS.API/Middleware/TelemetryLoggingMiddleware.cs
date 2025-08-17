
using Microsoft.ApplicationInsights;

namespace EAMS.API.Middleware;
public class TelemetryLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly TelemetryClient _telemetryClient;
    private readonly ILogger<TelemetryLoggingMiddleware> _logger;

    public TelemetryLoggingMiddleware(RequestDelegate next, TelemetryClient telemetryClient, ILogger<TelemetryLoggingMiddleware> logger)
    {
        _next = next;
        _telemetryClient = telemetryClient;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        // Log an event at the start of the request.
        _telemetryClient.TrackEvent("RequestStart", new Dictionary<string, string>
        {
            ["Path"] = context.Request.Path,
            ["Method"] = context.Request.Method
        });

        _logger.LogInformation("Starting request for {Path}", context.Request.Path);

        try
        {
            await _next(context);

            // Log an event at the end of the successful request.
            _telemetryClient.TrackEvent("RequestEnd", new Dictionary<string, string>
            {
                ["Path"] = context.Request.Path,
                ["Method"] = context.Request.Method,
                ["StatusCode"] = context.Response.StatusCode.ToString()
            });

            _logger.LogInformation("Finished request for {Path} with status code {StatusCode}", context.Request.Path, context.Response.StatusCode);
        }
        catch (Exception ex)
        {
            // Log the exception using both ILogger and TelemetryClient.
            _logger.LogError(ex, "An unhandled exception occurred during the request for {Path}", context.Request.Path);

            _telemetryClient.TrackException(ex, new Dictionary<string, string>
            {
                ["Path"] = context.Request.Path,
                ["Method"] = context.Request.Method
            });

            throw; // Re-throw the exception to allow other middleware to handle it (e.g., UseExceptionHandler).
        }
    }
}