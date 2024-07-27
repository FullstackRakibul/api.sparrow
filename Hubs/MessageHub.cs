using api.sparrow.models;
using api.sparrow.models.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace api.sparrow.Hubs
{
    public class MessageHub : Hub<ISendMessage>
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.ReceiveMessage(user, message);
        }

        public async Task SendPrivateMessage(string toUser, string message)
        {
            var fromUser = Context.User.Identity.Name;
            await Clients.User(toUser).ReceivePrivateMessage(fromUser, message);
        }
        public async Task JoinRoom(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
        }

        public async Task LeaveRoom(string room)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, room);
        }

        public async Task SendMessageToRoom(string room, string user, string message)
        {
            await Clients.Group(room).ReceiveRoomMessage(room, user, message);
        }
    }
}
