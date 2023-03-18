using System.Collections.Generic;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchModeratorsReceivedNotification : TwitchNotification {
    public IList<string> Moderators { get; }
    public string Channel { get; }

    public TwitchModeratorsReceivedNotification(
        ITwitchChannelLink channelLink,
        IList<string> moderators,
        string channel)
        : base(channelLink) {
        Moderators = moderators;
        Channel = channel;
    }
}