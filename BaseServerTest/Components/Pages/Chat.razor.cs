using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;

// Todo, configure persistency - https://claude.ai/chat/08030c33-eead-4aee-8c2c-a09aa013575c
namespace BaseServerTest.Components.Pages
{
    public partial class Chat
    {
        private HubConnection? hubConnection;
        private List<string> messages = new List<string>();
        private string? messageInput;
        private string? groupName;
        private string? userName = "User";

        protected override async Task OnInitializedAsync()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
                .Build();

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var encodedMsg = $"{user}: {message}";
                messages.Add(encodedMsg);
                InvokeAsync(StateHasChanged);
            });

            await hubConnection.StartAsync(); 
            messages.Add("Debug: SignalR connection started");
            StateHasChanged();
        }

        private async Task JoinGroup()
        {
            if (hubConnection is not null && !string.IsNullOrEmpty(groupName))
            {
                await hubConnection.SendAsync("JoinGroup", groupName);
                messages.Add($"Joined group: {groupName}");
                StateHasChanged();

            }
        }

        private async Task LeaveGroup()
        {
            if (hubConnection is not null && !string.IsNullOrEmpty(groupName))
            {
                await hubConnection.SendAsync("LeaveGroup", groupName);
                messages.Add($"Left group: {groupName}");
            }
        }

        private async Task SendMessage()
        {
            if (hubConnection is not null && !string.IsNullOrEmpty(messageInput) && !string.IsNullOrEmpty(groupName))
            {
                try
                {
                    await hubConnection.SendAsync("SendMessageToGroup", groupName, userName, messageInput);
                    messages.Add($"Debug: Sent message: {messageInput}");
                    messageInput = string.Empty;
                }
                catch (Exception ex)
                {
                    messages.Add($"Error sending message: {ex.Message}");
                }
                StateHasChanged();
            }
            else
            {
                messages.Add("Debug: Cannot send message. Check connection, group name, and message.");
                StateHasChanged();
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
