using System;
using System.Reflection;
using System.Threading.Tasks;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.AspNetCore.UnitTests {
    public class TwitchMiddlewareTests {
        [Test]
        public async Task HandlerResolveTests() {
            var cLink = new Mock<ITwitchChannelLink>();


            var services = new ServiceCollection();

            // Register required services
            services.AddMediatR(config => {
                config.RegisterServicesFromAssembly(Assembly.GetCallingAssembly());
            });

            // Build provider
            var provider = services.BuildServiceProvider();

            // get handler
            var mediatR = provider.GetRequiredService<IMediator>();
            await mediatR.Publish(new TwitchChannelMessageNotification(cLink.Object, null));
        }
    }
}