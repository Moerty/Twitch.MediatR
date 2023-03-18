namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchSuspendedNotification : TwitchNotification {
    public string Message { get; }
    public string Channel { get; }

    public TwitchSuspendedNotification(
        ITwitchChannelLink channelLink,
        string message,
        string channel) : base(channelLink) {
        Message = message;
        Channel = channel;
    }
}