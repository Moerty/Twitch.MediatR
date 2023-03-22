using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.Twitch.MediatR;
using BenjaminAbt.Twitch.MediatR.Notifications;

namespace BenjaminAbt.TwitchChatBot.WebApp.Handlers {
    public class TwitchChannelMessageNotificationHandler : INotificationHandler<TwitchChannelMessageNotification> {
        public Task Handle(TwitchChannelMessageNotification request, CancellationToken cancellationToken = default) {
            var channel = request.ChatMessage.Channel;
            var response = $"Echo: {request.ChatMessage.Message}";

            request.ChannelLink.SendMessage(channel, response);

            return Task.CompletedTask;
        }
    }
}