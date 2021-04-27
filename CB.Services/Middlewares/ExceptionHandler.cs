using System.Net;
using System.Threading.Tasks;
using CB.Infrastructure.Logger;
using CB.Models.Exceptions;
using CB.Models.Models;
using CB.Models.Resources;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CB.Infrastructure.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly LogOption _logOption;

        public ExceptionHandler(
            RequestDelegate next,
            IOptions<LogOption> logOption)
        {
            _next = next;
            _logOption = logOption.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature.Error;
            var response = new APIResponseError();
            switch (exception)
            {
                case CBErrorException cBErrorException:
                    response.Message = cBErrorException.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                default:
                  var logger = new ObeLogger(_logOption).GetLogger();
                    logger.LogException(exception, exception.Message);
                    response.Message = MessageResource.GeneralError;
                    response.Error = exception;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

    }
}
