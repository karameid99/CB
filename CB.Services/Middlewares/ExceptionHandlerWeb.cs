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
    public class ExceptionHandlerWeb
    {
        private readonly RequestDelegate _next;
        private readonly LogOption _logOption;

        public ExceptionHandlerWeb(
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
            var response = new WebAPIResponse();
            switch (exception)
            {
                case CBErrorException cBErrorException:
                    response.msg = "e: " + cBErrorException.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    break;

                default:
                    var logger = new ObeLogger(_logOption).GetLogger();
                    logger.LogException(exception, exception.Message);
                    response.msg = "e: " + MessageResource.GeneralError;
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    break;
            }
            response.status = 1;
            response.close = 2;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

    }
}
