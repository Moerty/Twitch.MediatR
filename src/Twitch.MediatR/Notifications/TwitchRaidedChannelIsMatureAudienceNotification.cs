namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchRaidedChannelIsMatureAudienceNotification : TwitchNotification {
    public TwitchRaidedChannelIsMatureAudienceNotification(ITwitchChannelLink channelLink) : base(channelLink) { }
}