using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchPrimePaidSubscriberNotification : TwitchNotification {
    public SubscriberBase Subscriber { get; }
    public string Channel { get; }

    public TwitchPrimePaidSubscriberNotification(
        ITwitchChannelLink channelLink,
        SubscriberBase subscriber,
        string channel)
        : base(channelLink) {
        Subscriber = subscriber;
        Channel = channel;
    }
}