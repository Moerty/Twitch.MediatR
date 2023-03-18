using System;
using System.Reflection;
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
        public void HandlerResolveTests() {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();


            IServiceCollection services = new ServiceCollection();

            // Register required services
            services.AddMediatR(config => {
                config.RegisterServicesFromAssembly(Assembly.GetCallingAssembly());
            });

            // Build provider
            IServiceProvider provider = services.BuildServiceProvider();

            // get handler
            IMediator mediatR = provider.GetRequiredService<IMediator>();
            mediatR.Publish(new TwitchChannelMessageNotification(cLink.Object, null));

        }
    }
}