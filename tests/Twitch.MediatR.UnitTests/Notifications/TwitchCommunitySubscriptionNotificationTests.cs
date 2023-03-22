using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchCommunitySubscriptionNotificationTests {
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();

        var rawIrcMessage =
            @"@badge-info=;badges=channel-subscriber/1,sub-gifter/1;color=#FF69B4;display-name=ExampleUser;emotes=;id=1234-abcd-5678-efgh-9012ijklmnop;login=example_user;mod=0;msg-id=submysterygift;msg-param-mass-gift-count=5;msg-param-sender-count=1;room-id=123456789;subscriber=1;system-msg=ExampleUser\\sjust\\ssubscribed\\swith\\san\\smystery\\ssub\\sgift!;tmi-sent-ts=1556721455111;user-id=123456;user-type= :tmi.twitch.tv USERNOTICE #example_channel";
        
        var channel = "testChannel";
        var communitySubscription = new CommunitySubscription(rawIrcMessage.ParseRawIrcMessage());
        
        var notification = new TwitchCommunitySubscriptionNotification(cLink.Object, communitySubscription, channel);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);

        notification.Channel.Should().NotBeNullOrEmpty();
        notification.Channel.Should().Be(channel);
        
        notification.CommunitySubscription.Should().NotBeNull();
        notification.CommunitySubscription.Equals(communitySubscription).Should().BeTrue();
    }
}