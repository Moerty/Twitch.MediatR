using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchContinuedGiftedSubscriptionNotificationTests {
    // 
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();

        var rawIrcMessage =
            @"@badge-info=;badges=channel-subscriber/1;color=#0000FF;display-name=ExampleUser;emotes=;id=1234-abcd-5678-efgh-9012ijklmnop;login=example_user;mod=0;msg-id=giftpaidupgrade;msg-param-promo-gift-total=5;msg-param-promo-name=gift\\spromo\\sname;msg-param-recipient-display-name=ExampleRecipient;msg-param-recipient-id=123456789;msg-param-recipient-user-name=example_recipient;msg-param-sender-name=ExampleSender;msg-param-sub-plan=1000;msg-param-sub-plan-name=Channel\\sSubscription\\s(ExampleChannel);room-id=123456789;subscriber=1;system-msg=ExampleUser\\sgifted\\s1\\ssub\\sto\\sExampleRecipient!\\sThis\\sis\\sahuge\\ssupport\\sand\\sExampleRecipient\\sis\\snow\\sin\\sthe\\sExampleSender\\sfamily!;tmi-sent-ts=1556721455111;user-id=123456;user-type= :tmi.twitch.tv USERNOTICE #example_channel";
        
        var channel = "testChannel";
        var continuedGiftedSubscription = new ContinuedGiftedSubscription(rawIrcMessage.ParseRawIrcMessage());
        
        var notification = new TwitchContinuedGiftedSubscriptionNotification(cLink.Object, continuedGiftedSubscription, channel);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);

        notification.Channel.Should().NotBeNullOrEmpty();
        notification.Channel.Should().Be(channel);
        
        notification.ContinuedGiftedSubscription.Should().NotBeNull();
        notification.ContinuedGiftedSubscription.Equals(continuedGiftedSubscription).Should().BeTrue();
    }
}