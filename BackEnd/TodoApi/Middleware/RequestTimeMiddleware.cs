using System.Diagnostics;

namespace Middleware;

public class RequestDurationMiddleware(RequestDelegate next, ILogger<RequestDurationMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<RequestDurationMiddleware> _logger = logger;

    public async Task Invoke(HttpContext context)
    {
        var watch = Stopwatch.StartNew();
        await _next.Invoke(context);
        watch.Stop();

        _logger.LogInformation("Request duration: {duration}ms", watch.ElapsedMilliseconds);
    }
}

public static class RequestDurationMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestDurationMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestDurationMiddleware>();
    }
}