using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Models;
using NUnit.Framework;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications {
    public class TwitchMessageSentNotificationTests {
        [Test]
        public void PropertyTest() {
            var cLink = new Mock<ITwitchChannelLink>();

            var message = new SentMessage(new UserState(null, null, "",
                "Benjamin Abt", "", "", "", true, true, UserType.Admin), "Hello World");

            var notification = new TwitchMessageSentNotification(cLink.Object, message);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.SentMessage.Should().Be(message);
        }
    }
}