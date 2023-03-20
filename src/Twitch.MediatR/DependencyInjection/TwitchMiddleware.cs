using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.Twitch.MediatR.DependencyInjection {
    public static class TwitchRegister {
        public static IServiceCollection AddTwitch(this IServiceCollection services, Action<TwitchConfiguration> twitchOptions, params Assembly[] mediatrAssemblies) {
            services.Configure(twitchOptions);

            services.AddScoped<ITwitchEventProxy, TwitchEventProxy>();
            services.AddSingleton<ITwitchChannelLinkProvider, TwitchChannelLinkProvider>();
            services.AddTransient<ITwitchChannelLink, TwitchChannelLink>();

            services.AddMediatR(config => {
                config.RegisterServicesFromAssemblies(mediatrAssemblies);
            });
            return services;
        }
    }
}