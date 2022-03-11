using BE.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace BE.WebApi.Filters
{
    public class HandleCommonExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public HandleCommonExceptionFilter(ILogger<HandleCommonExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
#if !DEBUG
            _logger.LogError(context.Exception, context.Exception.Message);
#endif

            ApiError apiError = null;

            if (context.Exception is KeyNotFoundException)
            {
                apiError = new ApiError(context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else if (context.Exception is ArgumentException
                  || context.Exception is ArgumentNullException
                  || context.Exception is InvalidOperationException)
            {
                apiError = new ApiError(context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Exception is DbUpdateException
                  || context.Exception is DbUpdateConcurrencyException)
            {
                apiError = new ApiError(Common.ErrorMessages.DBUpdateError);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                apiError = new ApiError(context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                // Unhandled errors
#if DEBUG
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace;

#else
                var msg = "An unhandled error occurred.";                
                string stack = null;
#endif

                apiError = new ApiError(msg);
                apiError.Detail = stack;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.Result = new JsonResult(apiError);
            base.OnException(context);
        }
    }

    public class ApiError
    {
        public string Message { get; set; }
        public string Detail { get; set; }
        public List<string> errors { get; set; }

        public ApiError(string message)
        {
            this.Message = message;
        }
    }
}
