using System.Net;
using System.Text.Json;
using Utils;

namespace ProductAPI
{
    public class ApiMiddleware : IMiddleware
    {
        private readonly ILogger<ApiMiddleware> _logger;

        public ApiMiddleware(ILogger<ApiMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);

                await HandleException(context, exception);
            }
        }

        private static async Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var apiException = new ApiException { StatusCode = context.Response.StatusCode.ToString(), Message = exception.Message };

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(apiException, options);

            await context.Response.WriteAsync(json);
        }
    }
}
