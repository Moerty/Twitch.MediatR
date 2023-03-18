using System.Collections.Generic;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications {
    public class TwitchExistingUsersDetectedNotificationTests {
        [Test]
        public void PropertyTest() {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();

            List<string> users = new List<string>();

            TwitchExistingUsersDetectedNotification
                notification = new TwitchExistingUsersDetectedNotification(cLink.Object, "BenAbt", users);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.Channel.Should().Be("BenAbt");
            notification.Users.Should().BeSameAs(users);
        }
    }
}