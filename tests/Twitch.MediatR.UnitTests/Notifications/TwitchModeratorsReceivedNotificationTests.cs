using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchModeratorsReceivedNotificationTests {
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();


        var moderators = new[] {
            "test1",
            "test2"
        };
        var channel = "testChannel";
        var notification = new TwitchModeratorsReceivedNotification(cLink.Object, moderators, channel);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);

        notification.Channel.Should().NotBeNullOrEmpty();
        notification.Channel.Should().Be(channel);
        
        notification.Moderators.Should().NotBeNullOrEmpty();
        notification.Moderators.Equals(moderators).Should().BeTrue();
    }
}