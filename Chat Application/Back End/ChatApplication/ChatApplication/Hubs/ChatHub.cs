using ChatApplication.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.Hubs
{
    public class ChatHub:Hub
    {
        private readonly IDictionary<string,UserConnection> _connections;

        public ChatHub(IDictionary<string,UserConnection> connection)
        {
            _connections=connection;
        }

        public async Task JoinRoom(UserConnection con)
        {
            await Groups
                .AddToGroupAsync(Context.ConnectionId, con.ChatRoom);

            _connections[Context.ConnectionId] = con;

            await Clients
                .Group(con.ChatRoom)
                .SendAsync("RecievedMessage", "admin", $"{con.Username} has joined the {con.ChatRoom}",DateTime.Now);

            await SendConnectedUser(con.ChatRoom);
        }
         //The client is associated with only one group
        public async Task SendMessage(string message)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out UserConnection connection)) 
            {
            await Clients.Group(connection.ChatRoom).SendAsync("RecievedMessage",connection.Username,message,DateTime.Now);
            }
        }

        public async Task SendConnectedUser(string room)
        {
            var users = _connections
                .Values
                .Where(u => u.ChatRoom == room)
                .Select(s => s.Username);
            await Clients.Group(room).SendAsync("ConnectedUser",users);
        }

        //when the connection is stoped this method will be called by default
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if(!_connections.TryGetValue(Context.ConnectionId,out UserConnection connection))
            {
                return base.OnDisconnectedAsync(exception);
            }
            Clients.Group(connection.ChatRoom)
                .SendAsync("ReceivedMessage", "admin", $"{connection.Username} has left the group",DateTime.Now);

            SendConnectedUser(connection.ChatRoom);

            //Groups.RemoveFromGroupAsync(Context.ConnectionId, connection.ChatRoom);

            //_connections.Remove(Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
