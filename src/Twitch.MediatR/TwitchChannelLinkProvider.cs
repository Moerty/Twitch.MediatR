using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BenjaminAbt.Twitch.MediatR {
    public class TwitchChannelLinkProvider : ITwitchChannelLinkProvider {
        private Dictionary<ITwitchChannelLink, IServiceScope> _links = new Dictionary<ITwitchChannelLink, IServiceScope>();

        public TwitchChannelLinkProvider(ITwitchEventProxy eventProxy, IOptions<TwitchConfiguration> twitchOptions, IServiceProvider services) {
            var config = twitchOptions.Value;

            foreach (var channel in config.Channels) {
                // we need an own scope for each link
                var scope = services.CreateScope();
                var channelLink = new TwitchChannelLink(eventProxy, config.UserName, config.AccessToken, channel);


                _links.Add(channelLink, scope);
            }
        }

        /// <summary>
        /// Connects to channel links on application start
        /// </summary>
        public async Task StartAsync() {
            foreach (var link in _links.Select(entry => entry.Key)) {
                await link.ConnectAsync();
            }
        }

        /// <summary>
        /// Disconnects channel links on application shutdown
        /// </summary>
        public async Task StopAsync() {
            foreach (var link in _links.Select(entry => entry.Key)) {
                await link.DisconnectAsync();
            }
        }

        public async ValueTask DisposeAsync() {
            if (_links != null) {
                await StopAsync();

                foreach (var scope in _links.Values) {
                    scope.Dispose();
                }

                _links = null;
            }
        }
    }
}