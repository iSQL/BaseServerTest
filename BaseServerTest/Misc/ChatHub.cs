using BaseServerTest.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
namespace BaseServerTest.Misc;
public class ChatHub : Hub
{
    private readonly ApplicationDbContext _context;

    public ChatHub(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        var recentMessages = await _context.ChatMessages
            .Where(m => m.GroupName == groupName)
            .OrderByDescending(m => m.Timestamp)
            .Take(50)
            .ToListAsync();
        await Clients.Caller.SendAsync("ReceiveRecentMessages", recentMessages);
    }

    public async Task LeaveGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
    }

    public async Task SendMessageToGroup(string groupName, string user, string message)
    {
        var chatMessage = new ChatMessage
        {
            GroupName = groupName,
            UserName = user,
            Content = message,
            Timestamp = DateTime.UtcNow
        };

        _context.ChatMessages.Add(chatMessage);
        await _context.SaveChangesAsync();

        await Clients.Group(groupName).SendAsync("ReceiveMessage", user, message);
    }
}