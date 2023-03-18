namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchModeratorLeftNotification : TwitchNotification {
    public string Username { get; }
    public string Channel { get; }

    public TwitchModeratorLeftNotification(
        ITwitchChannelLink channelLink,
        string username,
        string channel)
        : base(channelLink) {
        Username = username;
        Channel = channel;
    }
}