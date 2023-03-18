namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchSubsOnlyNotification : TwitchNotification {
    public string Channel { get; }
    public string Message { get; }

    public TwitchSubsOnlyNotification(
        ITwitchChannelLink channelLink,
        string channel,
        string message)
        : base(channelLink) {
        Channel = channel;
        Message = message;
    }
}