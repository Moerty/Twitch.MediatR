using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchUserTimedoutNotification : TwitchNotification {
    public UserTimeout UserTimeout { get; }

    public TwitchUserTimedoutNotification(
        ITwitchChannelLink channelLink,
        UserTimeout userTimeout)
        : base(channelLink) {
        UserTimeout = userTimeout;
    }
}