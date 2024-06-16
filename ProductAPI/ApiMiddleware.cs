using Microsoft.AspNetCore.Http.Features;
using Repositories.IManager;
using System.Net;
using System.Text.Json;
using Utils.CustomAttributes;
using Utils.Exceptions;

namespace ProductAPI
{
    public class ApiMiddleware : IMiddleware
    {
        private readonly ILogger<ApiMiddleware> _logger;
        private readonly ITransactionManager _transactionManager;

        public ApiMiddleware(ILogger<ApiMiddleware> logger, ITransactionManager transactionManager)
        {
            _logger = logger;
            _transactionManager = transactionManager;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var requiredTransaction = context.Features.Get<IEndpointFeature>()?.Endpoint?.Metadata.GetMetadata<TransactionRequired>();

            try
            {
                if (requiredTransaction != null)
                {
                    await _transactionManager.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted);

                    await next.Invoke(context);

                    await _transactionManager.CommitTransactionAsync();
                }
                else
                {
                    await next.Invoke(context);
                }

            }
            catch (Exception exception)
            {
                if (requiredTransaction != null)
                    await _transactionManager.RollbackTransactionAsync();

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
