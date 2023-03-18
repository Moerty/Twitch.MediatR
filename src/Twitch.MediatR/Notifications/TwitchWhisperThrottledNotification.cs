using System;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchWhisperThrottledNotification : TwitchNotification {
    public string Message { get; }
    public int AllowedInPeriod { get; }
    public TimeSpan Period { get; }
    public int SentWhisperCount { get; }

    public TwitchWhisperThrottledNotification(
        ITwitchChannelLink channelLink,
        string message,
        int allowedInPeriod,
        TimeSpan period,
        int sentWhisperCount)
        : base(channelLink) {
        Message = message;
        AllowedInPeriod = allowedInPeriod;
        Period = period;
        SentWhisperCount = sentWhisperCount;
    }
}