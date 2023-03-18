using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchUserBannedNotification : TwitchNotification {
    public UserBan UserBan { get; }

    public TwitchUserBannedNotification(
        ITwitchChannelLink channelLink,
        UserBan userBan)
        : base(channelLink) {
        UserBan = userBan;
    }
}