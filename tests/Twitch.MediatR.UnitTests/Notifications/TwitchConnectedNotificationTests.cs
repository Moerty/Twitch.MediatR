﻿using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications {
    public class TwitchConnectedNotificationTests {
        [Test]
        public void PropertyTest() {
            var cLink = new Mock<ITwitchChannelLink>();

            var notification = new TwitchConnectedNotification(cLink.Object, "SchwabenCode", "BenAbt");

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.BotUsername.Should().Be("SchwabenCode");
            notification.AutoJoinChannel.Should().Be("BenAbt");
            notification.BotUsername.Should().Be("SchwabenCode");
        }
    }
}