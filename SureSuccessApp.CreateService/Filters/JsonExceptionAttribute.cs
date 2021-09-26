using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;

namespace SureSuccessApp.CreateService.Filters
{
    public class JsonExceptionAttribute : TypeFilterAttribute
    {
        public JsonExceptionAttribute() : base(typeof
            (HttpCustomExceptionFilterImpl))
        {
        }

        private class HttpCustomExceptionFilterImpl : IExceptionFilter
        {
            private readonly IWebHostEnvironment _env;
            private readonly Microsoft.Extensions.Logging.ILogger<HttpCustomExceptionFilterImpl> _logger;

            public HttpCustomExceptionFilterImpl(IWebHostEnvironment env, Microsoft.Extensions.Logging.ILogger<HttpCustomExceptionFilterImpl> logger)
            {
                _env = env;
                _logger = logger;
            }

            public void OnException(ExceptionContext context)
            {
                var eventId = new EventId(context.Exception.HResult);

                _logger.LogError(eventId,
                    context.Exception,
                    context.Exception.Message);

                var json = new JsonErrorPayload
                {
                    EventId = eventId.Id
                };

                if (_env.IsDevelopment()) json.DetailedMessage = context.Exception;

                var exceptionObject = new ObjectResult(json) { StatusCode = 500 };

                context.Result = exceptionObject;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}