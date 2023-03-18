using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications {
    public class TwitchLeftChannelNotificationTests {
        [Test]
        public void PropertyTest() {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();

            TwitchLeftChannelNotification
                notification = new TwitchLeftChannelNotification(cLink.Object, "BenAbt", "SchwabenCode");

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.Channel.Should().Be("BenAbt");
            notification.BotUsername.Should().Be("SchwabenCode");
        }
    }
}