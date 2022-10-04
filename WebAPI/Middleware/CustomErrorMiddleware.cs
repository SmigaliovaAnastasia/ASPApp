using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Security.Principal;
using System.Web;

namespace ASPApp.WebAPI.Middleware
{
    public class CustomErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;

        public CustomErrorMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _loggerFactory = loggerFactory;
            _loggerFactory.AddFile($@"{Directory.GetCurrentDirectory()}\Common\Logs\log.txt", minimumLevel : LogLevel.Warning);
        }

        public async Task Invoke(HttpContext context)
        {
            var _logger = _loggerFactory.CreateLogger<CustomErrorMiddleware>();
            try
            {
                if (context.Request.Query.ContainsKey("throwException"))
                {
                    throw new Exception("Testing Exception");
                }

                await _next.Invoke(context);
                var statusCode = context.Response.StatusCode;
                if (statusCode >= 400)
                {
                   var exceptionDetails = new RequestExceptionDetails(statusCode);
                    context.Response.Redirect($"/Error/{exceptionDetails.StatusCode}?message={exceptionDetails.Message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.GetType());

                var exceptionDetails = new RequestExceptionDetails((int)HttpStatusCode.InternalServerError, ex.Message, ex.GetType().ToString());
                context.Response.Redirect($"/Error/{exceptionDetails.StatusCode}?message={exceptionDetails.Message}&type={exceptionDetails.ExceptionType}");
            }
        }
    }
}
