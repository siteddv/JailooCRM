using JailooCRM.DAL;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace JailooCRM
{
    public static class TSHuinyaExceptionHandler 
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response
                            .WriteAsync(new Response(
                                context.Response.StatusCode,
                                contextFeature.Error.Message,
                                false)
                            .ToString());

                    }
                });
            });
        }
    }
}
