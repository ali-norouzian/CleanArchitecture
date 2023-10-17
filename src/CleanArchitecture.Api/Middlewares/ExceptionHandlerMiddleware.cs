using Infrastructure.Exceptions;
using Infrastructure;
using System.Net;
using System.Reflection;

namespace Presentation.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _logFilePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\log.txt";
        private readonly string _generalErrorMessage = "خطایی در سامانه رخ داد";
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
            // Log.Logger = new LoggerConfiguration().WriteTo.File(_logFilePath).WriteTo.Console().CreateLogger();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BusinessLogicException ex)
            {
                ConfigureResponse(httpContext, HttpStatusCode.OK, ex.Message);
            }
            //catch (Exception ex)
            //{
            //  //  Log.Error(ex, "There is an error");
            //    ConfigureResponse(httpContext, HttpStatusCode.OK, _generalErrorMessage);
            //}

        }


        private static async Task ConfigureResponse(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(ResponseMessage.Error(message).ToString());
        }
    }
}
