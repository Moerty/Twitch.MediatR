using System;
using System.Collections.Generic;
using System.Reflection;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Enums.Internal;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Client.Models.Builders;
using TwitchLib.Client.Models.Internal;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchAnnouncementNotificationNotification {
    [Test]
    public void PropertyTest() {
        var clink = new Mock<ITwitchChannelLink>();
        clink.SetupAllProperties();

        var rawIrcMessage =
            @"@badge-info=;badges=broadcaster/1,ambassador/1;color=#033700;display-name=BarryCarlyon;emotes=;flags=;id=d2c97aaa-b921-45ca-b1f5-df6bbcedb289;login=barrycarlyon;mod=0;msg-id=announcement;msg-param-color=PRIMARY;room-id=15185913;subscriber=0;system-msg=;tmi-sent-ts=1665265341857;user-id=15185913;user-type= :tmi.twitch.tv USERNOTICE #barrycarlyon :test";


        var ircMessage = rawIrcMessage.ParseRawIrcMessage();
        
        
        var announcement = new Announcement(ircMessage);

        var announcementArgs = new OnAnnouncementArgs() {
            Channel = "test",
            Announcement = announcement
        };
        
        var notification = new TwitchAnnouncementNotification(clink.Object, announcementArgs);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(clink.Object);
        notification.OnAnnouncementNotification.Should().NotBeNull();

        announcementArgs.Equals(notification.OnAnnouncementNotification).Should().BeTrue();
        announcement.Equals(notification.OnAnnouncementNotification.Announcement).Should().BeTrue();
    }
}