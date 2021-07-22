using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lockstep.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            var userIdentity = Context.User;
            //var @object = new { Id = 1, Name = "Jack" };
            // await Clients.Caller.SendAsync("jsEvent", @object);
            //await Clients.Client(Context.ConnectionId).SendAsync("jsEvent", @object);
            //await Clients.Group("lobby").SendAsync("jsEvent");
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            //Clients.Group("lobby").SendAsync();
        }

        public override async Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                await Clients.Caller.SendAsync("promo");
            }
            await Groups.AddToGroupAsync(Context.ConnectionId, "lobby");
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (exception is null)
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, "lobby");
        }
    }
}
