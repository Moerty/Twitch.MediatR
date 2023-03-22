namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchSubsOnlyNotification : TwitchNotification {
    public string Channel { get; }
    public string Message { get; }

    public TwitchSubsOnlyNotification(
        ITwitchChannelLink channelLink,
        string message,
        string channel)
        : base(channelLink) {
        Channel = channel;
        Message = message;
    }
}