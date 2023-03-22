using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Enums;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchSendReceiveDataNotificationTests {
    [Test]
    [TestCase("testDataReceive", SendReceiveDirection.Received)]
    [TestCase("testDataSent", SendReceiveDirection.Sent)]
    public void PropertyTest(string data, SendReceiveDirection direction) {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();

        var notification = new TwitchSendReceiveDataNotification(cLink.Object, data, direction);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);

        notification.Data.Should().NotBeNullOrEmpty();
        notification.Data.Should().Be(data);

        notification.Direction.Equals(direction).Should().BeTrue();
    }
}