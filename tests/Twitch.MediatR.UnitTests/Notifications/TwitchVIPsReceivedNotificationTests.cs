using System.Collections.Generic;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Events;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchVIPsReceivedNotificationTests {
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();

        var args = new OnVIPsReceivedArgs() {
            Channel = "test",
            VIPs = new List<string>() { "test", "test2" }
        };
        

        var notification = new TwitchVIPsReceivedNotification(cLink.Object, args);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);
        notification.ViPsReceivedNotification.Should().NotBeNull();
        args.Equals(notification.ViPsReceivedNotification).Should().BeTrue();
    }
}