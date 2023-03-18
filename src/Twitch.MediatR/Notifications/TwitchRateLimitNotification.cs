namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchRateLimitNotification : TwitchNotification {
    public string Message { get; }
    public string Channel { get; }

    public TwitchRateLimitNotification(
        ITwitchChannelLink channelLink,
        string message,
        string channel) : base(channelLink) {
        Message = message;
        Channel = channel;
    }
}