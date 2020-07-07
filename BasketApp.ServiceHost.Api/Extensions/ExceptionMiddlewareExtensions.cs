using BasketApp.Core.Models.Exceptions;
using BasketApp.ServiceHost.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace BasketApp.ServiceHost.Api.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = contextFeature.Error;

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var response = new HttpServiceResponseBase();

                    switch (exception)
                    {
                        case ApiException apiException:
                            response.Error = new ErrorModel
                            {
                                Code = apiException.ErrorCode,
                                Message = apiException.ErrorMessage,
                                Exception = apiException.ErrorMessage
                            };
                            break;
                        default:
                            response.Error = new ErrorModel
                            {
                                Code = HttpStatusCode.InternalServerError,
                                Message = "Oops!",
                                Exception = exception.Message
                            };
                            break; ;
                    }

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));

                });
            });
        }
    }
}
