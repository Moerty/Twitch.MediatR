using System;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications {
    public class TwitchLogNotificationTests {
        [Test]
        public void PropertyTest() {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();

            DateTime dateTime = DateTime.Now;

            TwitchLogNotification
                notification = new TwitchLogNotification(cLink.Object, "SchwabenCode", "Data", dateTime);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.BotUsername.Should().Be("SchwabenCode");
            notification.Data.Should().Be("Data");
            notification.DateTime.Should().Be(dateTime);
        }
    }
}