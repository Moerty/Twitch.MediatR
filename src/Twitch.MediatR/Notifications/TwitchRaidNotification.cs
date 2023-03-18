using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchRaidNotification : TwitchNotification {
    public RaidNotification RaidNotification { get; }
    public string Channel { get; }

    public TwitchRaidNotification(
        ITwitchChannelLink channelLink,
        RaidNotification raidNotification,
        string channel)
        : base(channelLink) {
        RaidNotification = raidNotification;
        Channel = channel;
    }
}