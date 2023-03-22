using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchDuplicateNotificationTests {
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();


        var message = "testMessage";
        var channel = "testChannel";
        var notification = new TwitchDuplicateNotification(cLink.Object, message, channel);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);

        notification.Channel.Should().NotBeNullOrEmpty();
        notification.Channel.Should().Be(channel);
        
        notification.Message.Should().NotBeNullOrEmpty();
        notification.Message.Should().Be(message);
    }
}