using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchReSubscriberNotificationTests {
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();

        var rawIrcMessage =
            @"@badges=subscriber/1,turbo/1;color=#2B119C;display-name=JustFunkIt;emotes=;id=9dasn-asdibas-asdba-as8as;login=justfunkit;mod=0;msg-id=resub;msg-param-months=2;room-id=44338537;subscriber=1;system-msg=JustFunkIt\\ssubscribed\\sfor\\s2\\smonths\\sin\\sa\\srow!;turbo=1;user-id=26526370;user-type= :tmi.twitch.tv USERNOTICE #burkeblack :AVAST YEE SCURVY DOG";

        var channel = "testChannel";

        var reSubscriber = new ReSubscriber(rawIrcMessage.ParseRawIrcMessage());
        
        var notification = new TwitchReSubscriberNotification(cLink.Object, reSubscriber, channel);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);

        notification.Channel.Should().NotBeNullOrEmpty();
        notification.Channel.Should().Be(channel);
        notification.ReSubscriber.Equals(reSubscriber).Should().BeTrue();
    }
}