using System.Collections.Generic;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications; 

public class TwitchWhisperCommandReceivedNotificationTests {
    [Test]
    public void PropertyTest() {
        var cLink = new Mock<ITwitchChannelLink>();
        cLink.SetupAllProperties();

        var message = new WhisperMessage("PRIVMSG #jtv :/w username message".ParseRawIrcMessage(), "botUsername");
        var command = new WhisperCommand(message, "commandText", "args", new List<string>() { "args" }, '!');
        
        var notification = new TwitchWhisperCommandReceivedNotification(cLink.Object, command);

        notification.ChannelLink.Should().NotBeNull();
        notification.ChannelLink.Should().Be(cLink.Object);
        

        notification.WhisperCommand.Should().NotBeNull();
        notification.WhisperCommand.Equals(command).Should().BeTrue();
        
        notification.WhisperCommand.WhisperMessage.Should().NotBeNull();
        notification.WhisperCommand.WhisperMessage.Equals(message).Should().BeTrue();
    }
}