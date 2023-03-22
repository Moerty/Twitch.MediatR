using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Exceptions;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchFailureToReceiveJoinConfirmationNotificationTests {
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();


        var details = "detailMessage";
        var channel = "testChannel";
        var arg = new FailureToReceiveJoinConfirmationException(channel, details);
        var notification = new TwitchFailureToReceiveJoinConfirmationNotification(cLink.Object, arg);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);

        notification.Exception.Should().NotBeNull();
        notification.Exception.Equals(arg);
    }
}