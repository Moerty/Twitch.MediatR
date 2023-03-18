namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchUnaccountedForNotification : TwitchNotification {
    public TwitchUnaccountedForNotification(ITwitchChannelLink channelLink) : base(channelLink) { }
}