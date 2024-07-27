using api.sparrow.models;
using api.sparrow.models.DTOs;

namespace api.sparrow.Hubs
{
    public interface ISendMessage
    {
        Task SendMessage(string user, string message);
        Task ReceiveMessage(string user, string message);
        Task ReceivePrivateMessage(string fromUser, string message);
        Task ReceiveRoomMessage(string room, string user, string message);
    }
}
