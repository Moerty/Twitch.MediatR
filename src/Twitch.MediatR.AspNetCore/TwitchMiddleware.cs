using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BenjaminAbt.Twitch.MediatR.AspNetCore {
    public static class TwitchRegister {
        public static IApplicationBuilder UseTwitch(this IApplicationBuilder app) {
            // get application to dispose and close connections on shutdown
            var life = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            var twitchChannelLinkProvider = app.ApplicationServices.GetRequiredService<ITwitchChannelLinkProvider>();

            // handle life time jobs
            life.ApplicationStarted.Register(twitchChannelLinkProvider.Start);
            life.ApplicationStopping.Register(twitchChannelLinkProvider.Stop);

            return app;
        }
    }
}