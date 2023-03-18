namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchDuplicateNotification : TwitchNotification {
    public string Message { get; }
    public string Channel { get; }

    public TwitchDuplicateNotification(
        ITwitchChannelLink channelLink,
        string message,
        string channel)
        : base(channelLink) {
        Message = message;
        Channel = channel;
    }
}