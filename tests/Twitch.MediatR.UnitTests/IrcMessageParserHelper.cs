using System;
using System.Reflection;
using TwitchLib.Client.Models.Internal;

namespace BenjaminAbt.Twitch.MediatR.UnitTests; 

internal static class IrcMessageParserHelper {
    public static IrcMessage ParseRawIrcMessage(this string rawIrcMessage) {
        var assembly = typeof(TwitchLib.Client.TwitchClient).Assembly.GetType("TwitchLib.Client.Internal.Parsing.IrcParser");

        var createdObject = Activator.CreateInstance(assembly);
        
        var method = assembly.GetMethod(
            "ParseIrcMessage",
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Default | BindingFlags.Public,
            null,
            new Type[] { typeof(string)},
            null);
        
       return (IrcMessage)method.Invoke(createdObject, new[] { rawIrcMessage });
    }
}