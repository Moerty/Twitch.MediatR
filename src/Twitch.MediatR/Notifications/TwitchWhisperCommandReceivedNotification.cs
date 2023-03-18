using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchWhisperCommandReceivedNotification : TwitchNotification {
    public WhisperCommand WhisperCommand { get; }

    public TwitchWhisperCommandReceivedNotification(
        ITwitchChannelLink channelLink,
        WhisperCommand whisperCommand)
        : base(channelLink) {
        WhisperCommand = whisperCommand;
    }
}