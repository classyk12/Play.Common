
using System.Reflection;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Play.Common.Settings;

namespace Play.Common.MassTransit
{
    public static class Extensions
    {
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumers(Assembly.GetCallingAssembly());

                x.UsingRabbitMq((context, cfg) =>
                {
                    var rabbitSettings = context.GetRequiredService<IConfiguration>()
                    .GetSection(nameof(RabbitMqSettings))
                    .Get<RabbitMqSettings>();

                    var prefix = context.GetRequiredService<IConfiguration>().GetSection(nameof(RabbitMqSettings)).Get<ServiceSettings>()?.Name;

                    cfg.Host(rabbitSettings!.Host!);
                    cfg.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(prefix: prefix));
                });
            });

            return services;
        }
    }
}