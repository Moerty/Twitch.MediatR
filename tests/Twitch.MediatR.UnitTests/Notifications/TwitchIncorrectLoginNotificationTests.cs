using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Exceptions;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications {
    public class TwitchIncorrectLoginNotificationTests {
        [Test]
        public void PropertyTest() {
            var cLink = new Mock<ITwitchChannelLink>();

            var exception = new ErrorLoggingInException("ircData", "BenAbt");

            var notification = new TwitchIncorrectLoginNotification(cLink.Object, exception);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.Exception.Should().Be(exception);
        }
    }
}