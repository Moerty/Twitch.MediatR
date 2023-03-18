using System.Collections.Generic;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Client.Models.Internal;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchAnnouncementNotificationNotification {
    public void PropertyTest() {
        var clink = new Mock<ITwitchChannelLink>();
        clink.SetupAllProperties();

        var onAnnouncementArgs = new Announcement(new IrcMessage("test")) {
            Badges = { new KeyValuePair<string, string>("", "") },
            BadgeInfo = { new KeyValuePair<string, string>("", "") }
        };
        
        var notification = new TwitchAnnouncementNotification(clink.Object, new OnAnnouncementArgs() {
            Channel = "test",
            Announcement = onAnnouncementArgs
        });

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(clink.Object);
        notification.OnAnnouncementNotification.Should().NotBeNull();
        onAnnouncementArgs.Equals(notification.OnAnnouncementNotification).Should().BeTrue();
    }
}