namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchBannedNotification : TwitchNotification {
    public string Message { get; }
    public string Channel { get; }

    public TwitchBannedNotification(
        ITwitchChannelLink channelLink,
        string message,
        string channel)
        : base(channelLink) {
        Message = message;
        Channel = channel;
    }
}