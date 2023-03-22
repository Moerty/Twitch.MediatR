using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchModeratorJoinedNotificationTests {
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();


        var username = "testUsername";
        var channel = "testChannel";
        var notification = new TwitchModeratorJoinedNotification(cLink.Object, username, channel);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);

        notification.Channel.Should().NotBeNullOrEmpty();
        notification.Channel.Should().Be(channel);
        
        notification.Username.Should().NotBeNullOrEmpty();
        notification.Username.Should().Be(username);
    }
}