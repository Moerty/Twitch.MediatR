using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchMessageClearedNotificationTests {
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();


        var message = "testMessage";
        var channel = "testChannel";
        var messageId = "1";
        var tmiSentTs = "tmi";
        var notification = new TwitchMessageClearedNotification(cLink.Object, messageId, channel, message, tmiSentTs);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);

        notification.Channel.Should().NotBeNullOrEmpty();
        notification.Channel.Should().Be(channel);
        
        notification.Message.Should().NotBeNullOrEmpty();
        notification.Message.Should().Be(message);
        
        notification.TmiSentTs.Should().NotBeNullOrEmpty();
        notification.TmiSentTs.Should().Be(tmiSentTs);
        
        notification.TargetMessageId.Should().NotBeNullOrEmpty();
        notification.TargetMessageId.Should().Be(messageId);
    }
}