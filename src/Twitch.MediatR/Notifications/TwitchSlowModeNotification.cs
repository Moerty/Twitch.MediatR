namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchSlowModeNotification : TwitchNotification {
    public string Message { get; }
    public string Channel { get; }

    public TwitchSlowModeNotification(
        ITwitchChannelLink channelLink,
        string message,
        string channel)
        : base(channelLink) {
        Message = message;
        Channel = channel;
    }
}