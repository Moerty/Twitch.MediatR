namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchReconnectedNotification : TwitchNotification {
    public TwitchReconnectedNotification(
        ITwitchChannelLink channelLink) : base(channelLink) { }
}