using TwitchLib.Client.Events;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchAnnouncementNotification : TwitchNotification {
    public OnAnnouncementArgs OnAnnouncementNotification { get; }

    public TwitchAnnouncementNotification(
        ITwitchChannelLink channelLink,
        OnAnnouncementArgs onAnnouncementArgs)
        : base(channelLink) {
        OnAnnouncementNotification = onAnnouncementArgs;
    }
}