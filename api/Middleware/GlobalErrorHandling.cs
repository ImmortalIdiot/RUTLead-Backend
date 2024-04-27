using api.Exceptions;

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
                context.Response.StatusCode = (int)ExceptionCodesDictionary.GetExceptionStatusCode(e);
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}
