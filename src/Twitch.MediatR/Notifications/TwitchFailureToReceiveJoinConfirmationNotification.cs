using TwitchLib.Client.Exceptions;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchFailureToReceiveJoinConfirmationNotification : TwitchNotification {
    public FailureToReceiveJoinConfirmationException Exception { get; }

    public TwitchFailureToReceiveJoinConfirmationNotification(
        ITwitchChannelLink channelLink,
        FailureToReceiveJoinConfirmationException exception)
        : base(channelLink) {
        Exception = exception;
    }
}