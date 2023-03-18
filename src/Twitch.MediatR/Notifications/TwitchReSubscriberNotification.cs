using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchReSubscriberNotification : TwitchNotification {
    public ReSubscriber ReSubscriber { get; }
    public string Channel { get; }

    public TwitchReSubscriberNotification(
        ITwitchChannelLink channelLink,
        ReSubscriber reSubscriber,
        string channel) : base(channelLink) {
        ReSubscriber = reSubscriber;
        Channel = channel;
    }
}