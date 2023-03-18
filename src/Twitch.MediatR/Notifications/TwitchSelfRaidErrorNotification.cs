namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchSelfRaidErrorNotification : TwitchNotification {
    public TwitchSelfRaidErrorNotification(ITwitchChannelLink channelLink) : base(channelLink) { }
}