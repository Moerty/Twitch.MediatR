using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchNoPermissionErrorNotificationTests {
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();

        var notification = new TwitchNoPermissionErrorNotification(cLink.Object);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);
    }
}