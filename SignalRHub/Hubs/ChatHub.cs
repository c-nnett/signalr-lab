using Microsoft.AspNetCore.SignalR;

namespace SignalRHub.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        Console.WriteLine("Usuário " + user + " enviou a mensagem: " + message);
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
