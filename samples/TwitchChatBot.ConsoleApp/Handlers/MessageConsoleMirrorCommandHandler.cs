using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.Twitch.MediatR.Notifications;
using MediatR;

namespace BenjaminAbt.TwitchChatBot.ConsoleApp.Handlers {
    public class MessageConsoleMirrorCommandHandler : INotificationHandler<TwitchChannelMessageNotification> {
        private readonly TextWriter _output;

        public MessageConsoleMirrorCommandHandler(TextWriter output) {
            _output = output;
        }

        public async Task Handle(TwitchChannelMessageNotification request, CancellationToken cancellationToken = default) {
            var channel = request.ChatMessage.Channel;
            var user = request.ChatMessage.Username;
            var message = request.ChatMessage.Message;

            await _output.WriteLineAsync($"#{channel}: [{user}] {message}"); // string parameter does not support cancellation
        }
    }
}