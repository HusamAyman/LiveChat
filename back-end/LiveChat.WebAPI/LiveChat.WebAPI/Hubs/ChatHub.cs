using LiveChat.Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace LiveChat.WebAPI.Hubs;

public interface IChatClient
{
    Task ReceivePrivateMessage(PrivateMessageDto message);
}

public interface IChatHub
{
    Task SendPrivateMessage(PrivateMessageDto message);
}

[Authorize]
public class ChatHub : Hub<IChatClient>, IChatHub
{
    public async Task SendPrivateMessage(PrivateMessageDto message)
    {
        var senderId = Context.UserIdentifier;
        await Clients.User(message.ReceiverId.ToString()).ReceivePrivateMessage(new PrivateMessageDto
        {
            ReceiverId = message.ReceiverId,
            Message = message.Message
        });
    }

    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"User {Context.UserIdentifier} has joined");
        await base.OnConnectedAsync();
    }
}