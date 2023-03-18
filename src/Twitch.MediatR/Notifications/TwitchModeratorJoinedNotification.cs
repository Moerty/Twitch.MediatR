namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchModeratorJoinedNotification : TwitchNotification {
    public string Username { get; }
    public string Channel { get; }

    public TwitchModeratorJoinedNotification(
        ITwitchChannelLink channelLink,
        string Username,
        string Channel)
        : base(channelLink) {
        this.Username = Username;
        this.Channel = Channel;
    }
}