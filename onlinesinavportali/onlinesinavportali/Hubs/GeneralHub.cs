using Microsoft.AspNetCore.SignalR;

namespace onlinesinavportali.Hubs
{
    public class GeneralHub : Hub
    {
        // Genel mesaj göndermek için kullanılan metod
        public async Task SendMessage(string user, string message)
        {
            // Clients.All: Tüm bağlanmış kullanıcılara mesaj gönderir
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        // Belirli bir gruba mesaj göndermek
        public async Task SendMessageToGroup(string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveGroupMessage", message);
        }

        // Kullanıcıyı bir gruba ekleme
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        // Kullanıcıyı bir gruptan çıkarma
        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
