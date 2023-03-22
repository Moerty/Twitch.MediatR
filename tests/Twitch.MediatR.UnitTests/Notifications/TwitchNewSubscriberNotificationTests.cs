using System.Drawing;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Models;
using NUnit.Framework;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications {
    public class TwitchNewSubscriberNotificationTests {
        [Test]
        public void PropertyTest() {
            var cLink = new Mock<ITwitchChannelLink>();

            var subscriber = new Subscriber(null, null, "", Color.Black, "Benjamin Abt",
                "", "", "", "", "", "", "", true, "", "", SubscriptionPlan.Prime,
                "", "", "", true, true, true, true, "", UserType.Admin, "", "");

            var notification = new TwitchNewSubscriberNotification(cLink.Object, "BenAbt", subscriber);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.Channel.Should().Be("BenAbt");
            notification.Subscriber.Should().Be(subscriber);
        }
    }
}