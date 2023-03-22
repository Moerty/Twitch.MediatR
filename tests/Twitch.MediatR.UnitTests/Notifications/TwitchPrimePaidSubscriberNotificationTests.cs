using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Models;
using TwitchLib.Client.Models.Builders;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchPrimePaidSubscriberNotificationTests {
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();

        var rawIrcMessage =
            @"@badge-info=;badges=channel-subscriber/1;color=#FF0000;display-name=ExampleUser;emotes=;id=1234-abcd-5678-efgh-9012ijklmnop;login=example_user;mod=0;msg-id=sub;msg-param-cumulative-months=3;msg-param-months=0;msg-param-should-share-streak=1;msg-param-sub-plan-name=Channel\\sSubscription\\s(ExampleChannel);msg-param-sub-plan=1000;room-id=123456789;subscriber=1;system-msg=ExampleUser\\ssubscribed\\sat\\sTier\\s1.\\sThey've\\ssubscribed\\sfor\\s3\\smo\\ns!;tmi-sent-ts=1556721455111;user-id=123456;user-type= :tmi.twitch.tv USERNOTICE #example_channel";

        var channel = "testChannel";

        var sub = SubscriberBuilder.Create().BuildFromIrcMessage(new FromIrcMessageBuilderDataObject() {
            Message = rawIrcMessage.ParseRawIrcMessage(),
            AditionalData = null
        });
        
        var notification = new TwitchPrimePaidSubscriberNotification(cLink.Object, (SubscriberBase)sub, channel);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);
    }
}