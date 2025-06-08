using System;
using System.Threading.Tasks;
using LocalMindApi.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace LocalMindApi.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

        public GlobalErrorHandlingMiddleware(
            RequestDelegate next,
            ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext contex)
        {
            try
            {
                await _next(contex);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);

                int statusCode = exception switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    ValidationException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError
                };

                string errorMessage = exception switch
                {
                    NotFoundException => exception.Message,
                    ValidationException => exception.Message,
                    _ => "An unexpected error occurred."
                };

                contex.Response.StatusCode = statusCode;
                contex.Response.ContentType = "application/json";

                await contex.Response.WriteAsJsonAsync(new
                {
                    StatusCode = statusCode,
                    ErrorMessage = errorMessage
                });
            }
        }
    }
}
