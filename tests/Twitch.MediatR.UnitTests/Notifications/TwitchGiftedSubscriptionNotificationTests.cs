using System.Collections.Generic;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Models;
using UserType = TwitchLib.Client.Enums.UserType;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications {
    public class TwitchGiftedSubscriptionNotificationTests {
        [Test]
        public void PropertyTest() {
            var cLink = new Mock<ITwitchChannelLink>();


            var giftedSubscription = new GiftedSubscription(
                new List<KeyValuePair<string, string>>(),
                new List<KeyValuePair<string, string>>(),
                "color",
                "Benjamin Abt",
                "emotes",
                "1",
                "login",
                true,
                "msgId",
                "",
                "",
                "",
                "",
                "",
                "",
                SubscriptionPlan.NotSet,
                "roomId",
                true,
                "",
                "",
                "",
                false,
                UserType.Admin,
                "1");

            var notification = new TwitchGiftedSubscriptionNotification(cLink.Object, "BenAbt", giftedSubscription);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.Channel.Should().Be("BenAbt");
            notification.GiftedSubscription.Should().Be(giftedSubscription);
        }
    }
}