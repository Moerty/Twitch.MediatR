using TwitchLib.Client.Events;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchWhisperSentNotification : TwitchNotification {
    public string Username { get; }
    public string Receiver { get; }
    public string Message { get; }

    public TwitchWhisperSentNotification(
        ITwitchChannelLink channelLink,
        string username,
        string receiver,
        string message)
        : base(channelLink) {
        Username = username;
        Receiver = receiver;
        Message = message;
    }
}