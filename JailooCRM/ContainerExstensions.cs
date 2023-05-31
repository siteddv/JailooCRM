using JailooCRM.DAL;
using JailooCRM.DAL.Response;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace JailooCRM
{
    public static class ContainerExstensions 
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    using IServiceScope scopeService =  app.ApplicationServices.CreateScope();
                    ILogger? logger = scopeService?.ServiceProvider?.GetService<ILogger>();
                    logger?.LogError(contextFeature?.Error.Message);

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    
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
