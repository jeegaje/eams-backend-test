using EAMS.API.Configurations;

namespace EAMS.API.Middleware;

public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;
    private const string CorrelationIdHeaderName = "X-Correlation-ID";

    public CorrelationIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ICorrelationIdGenerator correlationIdGenerator)
    {
        if (context.Request.Headers.TryGetValue(CorrelationIdHeaderName, out var correlationIdValue))
        {
            correlationIdGenerator.Set(correlationIdValue.ToString());
        }
        else
        {
            context.Response.Headers.Add(CorrelationIdHeaderName, correlationIdGenerator.Get());
        }

        await _next(context);
    }
}
