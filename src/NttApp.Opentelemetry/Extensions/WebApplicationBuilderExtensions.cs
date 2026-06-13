using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;

namespace NttApp.OpenTelemetry.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder UseOpenTelemetry(
        this WebApplicationBuilder builder,
        string applicationName)
    {
        builder.Logging.AddOpenTelemetry(options =>
        {
            options
                .SetResourceBuilder(
                    ResourceBuilder.CreateDefault()
                        .AddService(applicationName))
                .AddConsoleExporter();
        });

        return builder;
    }
}