using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchUserIntroNotification : TwitchNotification {
    public ChatMessage ChatMessage { get; }

    public TwitchUserIntroNotification(
        ITwitchChannelLink channelLink,
        ChatMessage chatMessage)
        : base(channelLink) {
        ChatMessage = chatMessage;
    }
}