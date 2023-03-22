using System;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications {
    public class TwitchMessageThrottledNotificationTests {
        [Test]
        public void PropertyTest() {
            var cLink = new Mock<ITwitchChannelLink>();

            var timeSpan = new TimeSpan(1, 2, 3, 4);

            var notification = new TwitchMessageThrottledNotification(cLink.Object, "Hello World", 999, timeSpan, 1);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.Message.Should().Be("Hello World");
            notification.AllowedInPeriod.Should().Be(999);
            notification.Period.Should().Be(timeSpan);
            notification.SentMessageCount.Should().Be(1);
        }
    }
}