namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchBannedEmailAliasNotification : TwitchNotification {
    public string Message { get; }
    public string Channel { get; }

    public TwitchBannedEmailAliasNotification(
        ITwitchChannelLink channelLink,
        string message,
        string channel)
        : base(channelLink) {
        Message = message;
        Channel = channel;
    }
}