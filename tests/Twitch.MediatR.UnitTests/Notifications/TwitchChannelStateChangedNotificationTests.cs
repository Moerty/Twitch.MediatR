using System;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications {
    public class TwitchChannelStateChangedNotificationTests {
        [Test]
        public void PropertyTest() {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();

            ChannelState channelState = new ChannelState(true, true, true, 1, true, "de", "BenAbt", TimeSpan.Zero, true, "123");
            TwitchChannelStateChangedNotification notification = new TwitchChannelStateChangedNotification(cLink.Object, "BenAbt", channelState);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.Channel.Should().Be("BenAbt");
            notification.ChannelState.Should().Be(channelState);
        }
    }
}