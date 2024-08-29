using BaseServerTest.Data;
using BaseServerTest.Shared.Domain.Chat;
using BaseServerTest.State;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;

// Todo, configure persistency - https://claude.ai/chat/08030c33-eead-4aee-8c2c-a09aa013575c
namespace BaseServerTest.Components.Pages
{
    public partial class Chat
    {
        [Inject]
        ApplicationState ApplicationState { get; set; }
        private HubConnection? hubConnection;
        private List<ChatMessage> messages = new List<ChatMessage>();
        private string? messageInput;
        private string? groupName;
        private string userName;
        public string HeaderClass = "text-primary";

        protected override async Task OnInitializedAsync()
        {
            userName = ApplicationState.CurrentUser.ToString();
            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
                .Build();

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var newMessage = new ChatMessage
                {
                    UserName = user,
                    Content = message,
                    Timestamp = DateTime.UtcNow
                };
                //messages.Add(newMessage);
                messages.Insert(0, newMessage); // Add new message to top
                InvokeAsync(StateHasChanged);
            });

            hubConnection.On<List<ChatMessage>>("ReceiveRecentMessages", (recentMessages) =>
            {
                //recentMessages.Reverse();
                messages.InsertRange(0, recentMessages);
                InvokeAsync(StateHasChanged);
            });

            await hubConnection.StartAsync();
        }


        private async Task JoinGroup()
        {
            HeaderClass = "text-success";
            if (hubConnection is not null && !string.IsNullOrEmpty(groupName))
            {
                await hubConnection.SendAsync("JoinGroup", groupName);
                await hubConnection.SendAsync("SendMessageToGroup", groupName, userName, "Ja dos'o");
                messages.Clear(); // Clear existing messages when joining a new group
            }
        }

        private async Task LeaveGroup()
        {
            HeaderClass = "text-primary";
            if (hubConnection is not null && !string.IsNullOrEmpty(groupName))
            {
                await hubConnection.SendAsync("SendMessageToGroup", groupName, userName, "Odo' ja");
                messageInput = string.Empty;
                await hubConnection.SendAsync("LeaveGroup", groupName);
                messages.Clear();
            }
        }

        private async Task SendMessage()
        {
            if (hubConnection is not null && !string.IsNullOrEmpty(messageInput) && !string.IsNullOrEmpty(groupName))
            {
                await hubConnection.SendAsync("SendMessageToGroup", groupName, userName, messageInput);

                messageInput = string.Empty;
            }
        }

        public bool IsConnected => hubConnection?.State == HubConnectionState.Connected;

        private async Task HandleKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await SendMessage();
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (hubConnection is not null)
            {
                await hubConnection.DisposeAsync();
            }
        }
    }
}
