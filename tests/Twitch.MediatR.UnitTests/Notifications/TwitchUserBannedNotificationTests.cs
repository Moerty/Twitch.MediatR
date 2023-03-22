using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchUserBannedNotificationTests {
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();

        var channel = "testChannel";
        var username = "testUser";
        var banReason = "testBanReason";
        var roomId = "1";
        var targetUserId = "123456";

        var userBan = new UserBan(
            channel,
            username,
            banReason,
            roomId,
            targetUserId);
        
        var notification = new TwitchUserBannedNotification(cLink.Object, userBan);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);

        notification.UserBan.Should().NotBeNull();
        notification.UserBan.Equals(userBan).Should().BeTrue();
    }
}