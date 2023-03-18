namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchFollowersOnlyNotification : TwitchNotification {
    public string Message { get; }
    public string Channel { get; }

    public TwitchFollowersOnlyNotification(
        ITwitchChannelLink channelLink,
        string message,
        string channel) : base(channelLink) {
        Message = message;
        Channel = channel;
    }
}