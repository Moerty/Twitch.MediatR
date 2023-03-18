using TwitchLib.Client.Events;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchVIPsReceivedNotification : TwitchNotification {
    public OnVIPsReceivedArgs ViPsReceivedNotification { get; }

    public TwitchVIPsReceivedNotification(
        ITwitchChannelLink channelLink,
        OnVIPsReceivedArgs args)
        : base(channelLink) {
        ViPsReceivedNotification = args;
    }
}