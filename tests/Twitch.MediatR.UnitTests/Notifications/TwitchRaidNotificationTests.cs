using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Models;
using TwitchLib.Client.Models.Builders;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchRaidNotificationTests {
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();

        var rawIrcMessage =
            "@badge-info=;badges=;color=;display-name=Raiders;emotes=;flags=;id=12345678-abcd-90ef-ghij-1234567890kl;login=raiduser;mod=0;msg-id=raid;room-id=123456789;subscriber=0;system-msg=123 raiders from raiduser have joined!;tmi-sent-ts=1556721496528;user-id=123456789;user-type=staff :tmi.twitch.tv USERNOTICE #example_channel";

        var channel = "testChannel";

        var raidNotification = new RaidNotification(rawIrcMessage.ParseRawIrcMessage());
        
        var notification = new TwitchRaidNotification(cLink.Object, raidNotification, channel);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);

        notification.Channel.Should().NotBeNullOrEmpty();
        notification.Channel.Should().Be(channel);

        notification.RaidNotification.Should().NotBeNull();
        notification.RaidNotification.Equals(raidNotification).Should().BeTrue();
    }
}