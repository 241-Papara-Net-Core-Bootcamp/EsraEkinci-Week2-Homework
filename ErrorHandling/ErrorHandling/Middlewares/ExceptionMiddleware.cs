using ErrorHandling.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace ErrorHandling.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string message = "";
            try
            {
               await _next.Invoke(httpContext);    
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            if (!httpContext.Response.HasStarted)
            {
                httpContext.Response.ContentType = "application/json";
                var response = new ErrorModel(message);
                var json = JsonConvert.SerializeObject(response);
                await httpContext.Response.WriteAsync(json);
            }

        }
        
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
