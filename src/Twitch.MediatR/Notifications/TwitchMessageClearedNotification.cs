namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchMessageClearedNotification : TwitchNotification {
    public string TargetMessageId { get; }
    public string Channel { get; }
    public string Message { get; }
    public string TmiSentTs { get; }

    public TwitchMessageClearedNotification(
        ITwitchChannelLink channelLink,
        string targetMessageId,
        string channel,
        string message,
        string tmiSentTs)
        : base(channelLink) {
        TargetMessageId = targetMessageId;
        Channel = channel;
        Message = message;
        TmiSentTs = tmiSentTs;
    }
}