﻿using MyFirstBackend.Configuration;
using MyFirstBackend.Core.Exeptions;
using Serilog;
using System.Net;

namespace MyFirstBackend.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _logger = Log.ForContext<ExceptionHandlingMiddleware>();
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ValidationException ex)
            {
                _logger.Error("Ошибка валидации {message}", ex.Message);
                await HandleValidationExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong:{ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleValidationExceptionAsync(HttpContext context, Exception exception)

        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
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

