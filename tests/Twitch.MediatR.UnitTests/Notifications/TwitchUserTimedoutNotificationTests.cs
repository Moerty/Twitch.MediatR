using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchUserTimedoutNotificationTests {
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();

        var channel = "testChannel";
        var username = "username";
        var targetUserId = "123456";
        var reason = "testReason";
        var duration = 100;

        var timedOut = new UserTimeout(channel, username, targetUserId, duration, reason);
        
        var notification = new TwitchUserTimedoutNotification(cLink.Object, timedOut);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);
        
        notification.UserTimeout.Should().NotBeNull();
        notification.UserTimeout.Equals(timedOut).Should().BeTrue();
    }
}