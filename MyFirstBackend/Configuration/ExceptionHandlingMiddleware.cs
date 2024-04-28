using MyFirstBackend.Configuration;
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
        private readonly Serilog.ILogger _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, Serilog.ILogger logger)
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
                _logger.Error($"Something went wrong:{ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
       private async Task HandleExceptionAsync(HttpContext context, Exception exception)

            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
            }
        }
    }

