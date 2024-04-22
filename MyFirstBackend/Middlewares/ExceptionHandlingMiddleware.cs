using MyFirstBackend.Core.Dtos;
using System.Data;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace MyFirstBackend.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.NotFound, ex.Message);
            }
        }
       private async Task HandleExceptionAsync(HttpContext context, string exMsg, HttpStatusCode httpStatusCode, string massege)

            {
                _logger.LogError(exMsg);
                HttpResponse response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)httpStatusCode;
                ErrorDto errorDto = new()
                {
                    Message = massege,
                    StatusCode = (int)httpStatusCode
                };
                string result = JsonSerializer.Serialize(errorDto);
                await response.WriteAsJsonAsync(result);
            }
        }
    }

