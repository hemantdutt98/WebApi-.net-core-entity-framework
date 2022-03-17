using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace StudentApi.GlobalException
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public CustomExceptionHandlerMiddleware(RequestDelegate requestDelegate, 
            ILogger<CustomExceptionHandlerMiddleware> logger,
            IHostEnvironment env)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try 
            {
                await _requestDelegate(context);    
            } 
            catch (Exception ex)
            {
                Error error;
                HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
                if(_env.IsDevelopment())
                {
                    error = new Error((int)statusCode, ex.Message, ex.StackTrace.ToString());
                }
                else
                {
                    error = new Error((int)statusCode, ex.Message);
                }
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(error.ToString());
            }
        }
    }
}
