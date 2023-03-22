using System.Threading.Tasks;

namespace BenjaminAbt.Twitch.MediatR {
    public static class TwitchChannelLinkExtensions {
        public static void SendMessage(this ITwitchChannelLink channelLink, string message, string channel, bool dryRun = false) {
            channelLink.Client.SendMessage(channel, message, dryRun);
        }
    }
}