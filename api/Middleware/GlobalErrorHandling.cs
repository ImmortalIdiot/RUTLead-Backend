

using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace api.Middleware
{
    public class GlobalErrorHandling : IMiddleware
    {
        private readonly ILogger<GlobalErrorHandling> _logger;

        public GlobalErrorHandling(ILogger<GlobalErrorHandling> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                var details = new ProblemDetails()
                {
                    Detail = "Bad request",
                    Instance = "Error",
                    Status = 400,
                    Title = "Client Error",
                    Type = "Error"
                };

                var response = JsonSerializer.Serialize(details);

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "app/json";
                await context.Response.WriteAsync(response);
            }
        }
    }
}
