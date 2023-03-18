using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Communication.Events;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications {
    public class TwitchDisconnectedNotificationTests {
        [Test]
        public void PropertyTest() {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();

            OnDisconnectedEventArgs eventArgs = new OnDisconnectedEventArgs();

            TwitchDisconnectedNotification
                notification = new TwitchDisconnectedNotification(cLink.Object, eventArgs);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.DisconnectedEventArgs.Should().Be(eventArgs);
        }
    }
}