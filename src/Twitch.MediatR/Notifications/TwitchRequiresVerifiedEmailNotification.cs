namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchRequiresVerifiedEmailNotification : TwitchNotification {
    public string Message { get; }
    public string Channel { get; }

    public TwitchRequiresVerifiedEmailNotification(
        ITwitchChannelLink channelLink,
        string message,
        string channel)
        : base(channelLink) {
        Message = message;
        Channel = channel;
    }
}