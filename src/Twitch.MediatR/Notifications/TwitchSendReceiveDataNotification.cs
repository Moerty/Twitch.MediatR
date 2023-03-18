using TwitchLib.Client.Enums;

namespace BenjaminAbt.Twitch.MediatR.Notifications;

public class TwitchSendReceiveDataNotification : TwitchNotification {
    public string Data { get; }
    public SendReceiveDirection Direction { get; }

    public TwitchSendReceiveDataNotification(
        ITwitchChannelLink channelLink,
        string data,
        SendReceiveDirection direction)
        : base(channelLink) {
        Data = data;
        Direction = direction;
    }
}