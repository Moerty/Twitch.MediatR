namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchNoPermissionErrorNotification : TwitchNotification {
    public TwitchNoPermissionErrorNotification(ITwitchChannelLink channelLink) : base(channelLink) { }
}