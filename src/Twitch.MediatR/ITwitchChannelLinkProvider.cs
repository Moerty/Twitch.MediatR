using System;
using System.Threading.Tasks;

namespace BenjaminAbt.Twitch.MediatR {
    public interface ITwitchChannelLinkProvider : IAsyncDisposable {
        Task StartAsync();
        Task StopAsync();
    }
}