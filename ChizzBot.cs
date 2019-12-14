using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
using TwitchLib.Api;
using Nito.AsyncEx.Synchronous;

namespace ChizzBot
{
    class ChizzBot
    {
        TwitchClient client;
        private static TwitchAPI api;

        Form1 form;
        public List<PlayableTrack> tracks = new List<PlayableTrack>();
        DateTime lastTrackCall = DateTime.Now.AddDays(-1);
        string channelId;
        string connectedChannel;
        public int volume;

        public ChizzBot(Form1 f)
        {
            form = f;
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            WebSocketClient customClient = new WebSocketClient(clientOptions);
            client = new TwitchClient(customClient);

            api = new TwitchAPI();
            api.Settings.ClientId = "vldrjznynoywd0i5pwavay8r3y4gho";
            api.Settings.AccessToken = "unjywk79kclwtndin8wop22alec7me";


            client.OnLog += Client_OnLog;
            client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnDisconnected += Client_OnDisconnected;
            client.OnChatCommandReceived += Client_OnChatCommandReceived;
            client.OnFailureToReceiveJoinConfirmation += Client_OnFailureToReceiveJoinConfirmation;
            client.OnMessageThrottled += Client_OnMessageThrottled;

        }

        private void Client_OnMessageThrottled(object sender, TwitchLib.Communication.Events.OnMessageThrottledEventArgs e)
        {
            form.AppendLogLine($"!!!!THROTTLED {e.Message}");
        }

        private void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {

            foreach (PlayableTrack track in tracks)
            {
                if (track.trackCommand == e.Command.CommandText.ToLower())
                {
                    if (DateTime.Compare(DateTime.Now, lastTrackCall.AddSeconds(Convert.ToDouble(form.numTimeout.Value))) > 0)
                    {

                        var task = Task.Run(async () => await api.V5.Users.UserFollowsChannelAsync(e.Command.ChatMessage.UserId, channelId));
                        var result = task.WaitAndUnwrapException();
                        if (result || e.Command.ChatMessage.IsMe || e.Command.ChatMessage.IsModerator || e.Command.ChatMessage.IsSubscriber)
                        {
                            lastTrackCall = DateTime.Now;
                            track.Play(volume);
                        }
                    }
                    else
                    {
                        string to = (lastTrackCall.AddSeconds(Convert.ToDouble(form.numTimeout.Value))- DateTime.Now).TotalSeconds.ToString("0");
                        client.SendMessage(connectedChannel,$"{e.Command.ChatMessage.DisplayName}, the command is on cooldown for {to} more seconds.");
                    }
                }
            }
        }

        public void Connect(string targetChannel)
        {
            ConnectionCredentials credentials = new ConnectionCredentials("the_chizz", "unjywk79kclwtndin8wop22alec7me");
            client.Initialize(credentials, targetChannel);
            client.Connect();
        }

        public void Disconnect()
        {
            form.AppendLogLine($"Disconnecting on demand");
            client.Disconnect();
            form.ModifyButton("Connect", true);
        }

        private void Client_OnDisconnected(object sender, TwitchLib.Communication.Events.OnDisconnectedEventArgs e)
        {
            form.AppendLogLine($"!!! Disconnected");
            form.LockControls(false);
            form.connectState = false;
            form.CreateBot();
        }

        private void Client_OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            form.AppendLogLine($"!!! Connection error. {e.Error.Message}");
            client.Disconnect();
        }

        private void Client_OnFailureToReceiveJoinConfirmation(object sender, OnFailureToReceiveJoinConfirmationArgs e)
        {
            form.AppendLogLine($"!!! Failed to recieve join confirmation from {e.Exception.Channel}.");
            client.Disconnect();
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            form.AppendLogLine($"Successfully connected to {e.Channel}! Happy streaming!");
            form.ModifyButton("Disconnect", true);
            form.connectState = true;
            connectedChannel = e.Channel;
            try
            {
                var u1t = Task.Run(async () => await api.V5.Users.GetUserByNameAsync(connectedChannel));
                var r1 = u1t.WaitAndUnwrapException();
                channelId = r1.Matches[0].Id;
            }
            catch
            {
                form.AppendLogLine($"API call failed");
            }
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            form.AppendLogLine($"{e.ChatMessage.DisplayName}: {e.ChatMessage.Message}");
        }

        private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            if (e.WhisperMessage.Username == "my_friend")
                client.SendWhisper(e.WhisperMessage.Username, "Hey! Whispers are so cool!!");
        }

        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            if (e.Subscriber.SubscriptionPlan == SubscriptionPlan.Prime)
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points! So kind of you to use your Twitch Prime on this channel!");
            else
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points!");
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            //IRC log here
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            //form.AppendLogLine($"Connected to {e.AutoJoinChannel}");
        }
    }
}
