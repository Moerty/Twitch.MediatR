using System.Drawing;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications {
    public class TwitchChatCommandReceivedNotificationTests {
        [Test]
        public void PropertyTest() {
            var cLink = new Mock<ITwitchChannelLink>();

            var emoteSet = new EmoteSet("0:2-1", "Hello World");

            var chatMessage = new ChatMessage("SchwabenCode", "123", "BenAbt", "Benjamin Abt", "001122",
                Color.Black, emoteSet,
                "Hello World", UserType.Admin, "BenAbt", "1", true, 1, "123", true, true, true, true, true, true, true, Noisy.True,
                "Hello Irc World", ":-)", null, new CheerBadge(1), 1, 1);

            var chatCommand = new ChatCommand(chatMessage);

            var notification = new TwitchChatCommandReceivedNotification(cLink.Object, chatCommand);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.Command.Should().Be(chatCommand);
        }
    }
}