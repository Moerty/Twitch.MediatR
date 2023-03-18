namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchEmoteOnlyNotification : TwitchNotification {
    public string Message { get; }
    public string Channel { get; }

    public TwitchEmoteOnlyNotification(
        ITwitchChannelLink channelLink,
        string message,
        string channel)
        : base(channelLink) {
        Message = message;
        Channel = channel;
    }
}