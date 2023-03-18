using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchCommunitySubscriptionNotification : TwitchNotification {
    public CommunitySubscription CommunitySubscription { get; }
    public string Channel { get; }

    public TwitchCommunitySubscriptionNotification(
        ITwitchChannelLink channelLink,
        CommunitySubscription communitySubscription,
        string channel) : base(channelLink) {
        CommunitySubscription = communitySubscription;
        Channel = channel;
    }
}