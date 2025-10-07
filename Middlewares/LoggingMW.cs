using System.Diagnostics;

namespace WebApplication1.Middlewares
{
    public class LoggingMW
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMW> _logger;

        public LoggingMW(RequestDelegate next, ILogger<LoggingMW> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            // Log the incoming request
            _logger.LogInformation("Incoming Request: {method} {url} at {time}",
                context.Request.Method,
                context.Request.Path,
                DateTime.Now);

            try
            {
                await _next(context);
            }
            finally
            {
                stopwatch.Stop();


                _logger.LogInformation("Response: {statusCode} for {method} {url} - took {duration} ms",
                    context.Response.StatusCode,
                    context.Request.Method,
                    context.Request.Path,
                    stopwatch.ElapsedMilliseconds);
            }
        }
    }
}