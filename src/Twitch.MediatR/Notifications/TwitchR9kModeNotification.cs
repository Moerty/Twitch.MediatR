namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchR9kModeNotification : TwitchNotification {
    public string Message { get; }
    public string Username { get; }

    public TwitchR9kModeNotification(
        ITwitchChannelLink channelLink,
        string message,
        string username) : base(channelLink) {
        Message = message;
        Username = username;
    }
}