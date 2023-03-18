using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchUserStateChangedNotification : TwitchNotification {
    public UserState UserState { get; }

    public TwitchUserStateChangedNotification(
        ITwitchChannelLink channelLink,
        UserState userState)
        : base(channelLink) {
        UserState = userState;
    }
}