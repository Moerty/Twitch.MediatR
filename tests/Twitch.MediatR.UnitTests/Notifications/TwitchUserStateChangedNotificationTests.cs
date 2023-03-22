using System;
using System.Reflection;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Client.Models.Internal;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchUserStateChangedNotificationTests {
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();
        
        var msg =
            @"@badge-info=;badges=staff/1;color=#0D4200;display-name=ronni;emote-sets=0,33,50,237,793,2126,3517,4578,5569,9400,10337,12239;mod=1;subscriber=1;turbo=1;user-type=staff :tmi.twitch.tv USERSTATE #dallas";
        
        var userState = new UserState(msg.ParseRawIrcMessage());

        var notification = new TwitchUserStateChangedNotification(cLink.Object, userState);
        
        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);
        
        notification.UserState.Should().NotBeNull();
        userState.Equals(notification.UserState).Should().BeTrue();
    }
}