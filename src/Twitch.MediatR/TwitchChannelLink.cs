using System;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using BenjaminAbt.Twitch.MediatR.Notifications;
using TwitchLib.Client.Interfaces;
using TwitchLib.Communication.Events;

namespace BenjaminAbt.Twitch.MediatR {
    public interface ITwitchChannelLink {
        Task ConnectAsync();
        Task DisconnectAsync();
        TwitchClient Client { get; }
    }

    public class TwitchChannelLink : ITwitchChannelLink {
        private readonly ITwitchEventProxy _eventProxy;
        public TwitchClient Client { get; }

        public Task ConnectAsync() {
            Client.Connect();
            return Task.CompletedTask;
        }

        public Task DisconnectAsync() {
            Client.Disconnect();
            return Task.CompletedTask;
        }

        public TwitchChannelLink(ITwitchEventProxy eventProxy, string userName, string accessToken, string channel) {
            _eventProxy = eventProxy;
            Client = new TwitchClient();

            Client.OnAnnouncement += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchAnnouncementNotification(this, e));

            Client.OnConnected += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchConnectedNotification(this, e.BotUsername, e.AutoJoinChannel));

            Client.OnChannelStateChanged += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchChannelStateChangedNotification(this, e.Channel, e.ChannelState));

            Client.OnChatCleared += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchChatClearedNotification(this, e.Channel));

            Client.OnChatColorChanged += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchChatColorChangedNotification(this, e.Channel));

            Client.OnChatCommandReceived += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchChatCommandReceivedNotification(this, e.Command));

            Client.OnConnectionError += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchConnectionErrorNotification(this, e.BotUsername, e.Error));

            Client.OnDisconnected += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchDisconnectedNotification(this, e));

            Client.OnExistingUsersDetected += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchExistingUsersDetectedNotification(this, e.Channel, e.Users));

            Client.OnGiftedSubscription += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchGiftedSubscriptionNotification(this, e.Channel, e.GiftedSubscription));

            Client.OnIncorrectLogin += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchIncorrectLoginNotification(this, e.Exception));

            Client.OnJoinedChannel += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchJoinedChannelNotification(this, e.Channel, e.BotUsername));

            Client.OnLeftChannel += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchLeftChannelNotification(this, e.Channel, e.BotUsername));

            Client.OnLog += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchLogNotification(this, e.BotUsername, e.Data, e.DateTime));

            Client.OnMessageSent += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchMessageSentNotification(this, e.SentMessage));

            Client.OnMessageThrottled += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchMessageThrottledNotification(this, e.Message, e.AllowedInPeriod, e.Period, e.SentMessageCount));

            Client.OnMessageReceived += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchChannelMessageNotification(this, e.ChatMessage));

            Client.OnWhisperReceived += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchWhisperMessageNotification(this, e.WhisperMessage));

            Client.OnNewSubscriber += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchNewSubscriberNotification(this, e.Channel, e.Subscriber));

            Client.OnError += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchErrorNotification(this, e.Exception));

            Client.OnVIPsReceived += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchVIPsReceivedNotification(this, e));

            Client.OnUserStateChanged += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchUserStateChangedNotification(this, e.UserState));

            Client.OnWhisperSent += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchWhisperSentNotification(this, e.Username, e.Receiver, e.Message));

            Client.OnWhisperCommandReceived += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchWhisperCommandReceivedNotification(this, e.Command));

            Client.OnUserJoined += async (s, e) =>
                await _eventProxy.PublishAsync(new TwitchUserJoinedNotification(this, e.Username, e.Channel));

            Client.OnWhisperThrottled += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchWhisperThrottledNotification(this, e.Message, e.AllowedInPeriod, e.Period, e.SentWhisperCount));

            Client.OnContinuedGiftedSubscription += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchContinuedGiftedSubscriptionNotification(this, e.ContinuedGiftedSubscription, e.Channel));

            Client.OnCommunitySubscription += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchCommunitySubscriptionNotification(this, e.GiftedSubscription, e.Channel));

            Client.OnRaidNotification += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchRaidNotification(this, e.RaidNotification, e.Channel));

            Client.OnSendReceiveData += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchSendReceiveDataNotification(this, e.Data, e.Direction));

            Client.OnUserBanned += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchUserBannedNotification(this, e.UserBan));

            Client.OnModeratorsReceived += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchModeratorsReceivedNotification(this, e.Moderators, e.Channel));

            Client.OnUserTimedout += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchUserTimedoutNotification(this, e.UserTimeout));

            Client.OnPrimePaidSubscriber += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchPrimePaidSubscriberNotification(this, e.PrimePaidSubscriber, e.Channel));

            Client.OnReSubscriber += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchReSubscriberNotification(this, e.ReSubscriber, e.Channel));

            Client.OnModeratorJoined += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchModeratorJoinedNotification(this, e.Username, e.Channel));

            Client.OnModeratorLeft += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchModeratorLeftNotification(this, e.Username, e.Channel));

            Client.OnMessageCleared += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchMessageClearedNotification(this, e.TargetMessageId, e.Channel, e.Message, e.TmiSentTs));

            Client.OnReconnected += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchReconnectedNotification(this));

            Client.OnRequiresVerifiedEmail += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchRequiresVerifiedEmailNotification(this, e.Message, e.Channel));

            Client.OnRequiresVerifiedPhoneNumber += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchRequiresVerifiedPhoneNumberNotification(this, e.Message, e.Channel));

            Client.OnRateLimit += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchRateLimitNotification(this, e.Message, e.Channel));

            Client.OnDuplicate += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchDuplicateNotification(this, e.Message, e.Channel));

            Client.OnBannedEmailAlias += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchBannedEmailAliasNotification(this, e.Message, e.Channel));

            Client.OnSelfRaidError += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchSelfRaidErrorNotification(this));

            Client.OnNoPermissionError += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchNoPermissionErrorNotification(this));

            Client.OnRaidedChannelIsMatureAudience += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchRaidedChannelIsMatureAudienceNotification(this));

            Client.OnFailureToReceiveJoinConfirmation += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchFailureToReceiveJoinConfirmationNotification(this, e.Exception));

            Client.OnFollowersOnly += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchFollowersOnlyNotification(this, e.Message, e.Channel));

            Client.OnSubsOnly += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchSubsOnlyNotification(this, e.Channel, e.Message));

            Client.OnEmoteOnly += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchEmoteOnlyNotification(this, e.Message, e.Channel));

            Client.OnSuspended += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchSuspendedNotification(this, e.Message, e.Channel));

            Client.OnBanned += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchBannedNotification(this, e.Message, e.Channel));

            Client.OnSlowMode += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchSlowModeNotification(this, e.Message, e.Channel));

            Client.OnR9kMode += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchR9kModeNotification(this, e.Message, e.Channel));

            Client.OnUserIntro += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchUserIntroNotification(this, e.ChatMessage));

            Client.OnUnaccountedFor += async (s, e)
                => await _eventProxy.PublishAsync(new TwitchUnaccountedForNotification(this));


            // Token by https://github.com/swiftyspiffy/twitch-token-generator
            ConnectionCredentials credentials = new ConnectionCredentials(userName, accessToken);
            Client.Initialize(credentials, channel);
        }
    }
}