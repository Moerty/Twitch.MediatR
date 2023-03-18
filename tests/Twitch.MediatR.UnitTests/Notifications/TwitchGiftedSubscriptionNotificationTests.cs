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
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();


            GiftedSubscription giftedSubscription = new GiftedSubscription(
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

            TwitchGiftedSubscriptionNotification
                notification = new TwitchGiftedSubscriptionNotification(cLink.Object, "BenAbt", giftedSubscription);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.Channel.Should().Be("BenAbt");
            notification.GiftedSubscription.Should().Be(giftedSubscription);
        }
    }
}
/*
public GiftedSubscription(
      List<KeyValuePair<string, string>> badges,
      List<KeyValuePair<string, string>> badgeInfo,
      string color,
      string displayName,
      string emotes,
      string id,
      string login,
      bool isModerator,
      string msgId,
      string msgParamMonths,
      string msgParamRecipientDisplayName,
      string msgParamRecipientId,
      string msgParamRecipientUserName,
      string msgParamSubPlanName,
      string msgMultiMonthDuration,
      SubscriptionPlan msgParamSubPlan,
      string roomId,
      bool isSubscriber,
      string systemMsg,
      string systemMsgParsed,
      string tmiSentTs,
      bool isTurbo,
      UserType userType,
      string userId)
      */