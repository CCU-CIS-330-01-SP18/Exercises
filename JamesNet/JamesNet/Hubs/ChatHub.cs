using Microsoft.AspNet.SignalR;

namespace JamesNet.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.receiveMessage(name, message);
        }
    }
}