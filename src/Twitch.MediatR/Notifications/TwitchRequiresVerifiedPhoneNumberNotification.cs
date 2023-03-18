namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchRequiresVerifiedPhoneNumberNotification : TwitchNotification {
    public string Message { get; }
    public string Channel { get; }

    public TwitchRequiresVerifiedPhoneNumberNotification(
        ITwitchChannelLink channelLink,
        string message,
        string channel)
        : base(channelLink) {
        Message = message;
        Channel = channel;
    }
}