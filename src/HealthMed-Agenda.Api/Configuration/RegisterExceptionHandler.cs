using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed_Agenda.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class ExceptionHandlerConfig
    {
        public static void RegisterExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature is not null)
                    {
                        Console.WriteLine($"Error: {contextFeature.Error}");

                        app.Logger.LogError(contextFeature.Error, contextFeature.Error.Message);

                        await context.Response.WriteAsJsonAsync(new
                        {
                            context.Response.StatusCode,
                            Message = "Internal Server Error"
                        });
                    }
                });
            });
        }
    }
}
