using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications; 

public class TwitchContinuedGiftedSubscriptionNotification : TwitchNotification {
    public ContinuedGiftedSubscription ContinuedGiftedSubscription { get; }
    public string Channel { get; }

    public TwitchContinuedGiftedSubscriptionNotification(
        ITwitchChannelLink channelLink,
        ContinuedGiftedSubscription continuedGiftedSubscription,
        string channel)
        : base(channelLink) {
        ContinuedGiftedSubscription = continuedGiftedSubscription;
        Channel = channel;
    }
}