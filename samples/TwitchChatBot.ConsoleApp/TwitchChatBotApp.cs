using System;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.Twitch.MediatR;
using Microsoft.Extensions.Hosting;

namespace BenjaminAbt.TwitchChatBot.ConsoleApp {
    public class TwitchChatBotApp : IHostedService, IDisposable {
        private ITwitchChannelLinkProvider _twitchChannelLinkProvider;

        public TwitchChatBotApp(ITwitchChannelLinkProvider twitchChannelLinkProvider) {
            _twitchChannelLinkProvider = twitchChannelLinkProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken) {
            _twitchChannelLinkProvider.Start();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) {
            _twitchChannelLinkProvider.Stop();

            return Task.CompletedTask;
        }
        
        public void Dispose() {
            if (_twitchChannelLinkProvider == null) return;

            _twitchChannelLinkProvider.Dispose();
            _twitchChannelLinkProvider = null;
        }
    }
}