namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchUserJoinedNotification : TwitchNotification {
    public string Username { get; }
    public string Channel { get; }

    public TwitchUserJoinedNotification(
        ITwitchChannelLink channelLink,
        string username,
        string channel)
        : base(channelLink) {
        Username = username;
        Channel = channel;
    }
}