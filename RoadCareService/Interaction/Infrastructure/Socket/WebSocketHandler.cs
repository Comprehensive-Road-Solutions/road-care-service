using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace RoadCareService.Interaction.Infrastructure.Socket
{
    public class WebSocketHandler
    {
        private static readonly ConcurrentDictionary
            <string, List<WebSocket>> Rooms = new();

        public async Task HandleWebSocketAsync(HttpContext context)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                WebSocket webSocket = await context.WebSockets
                    .AcceptWebSocketAsync();

                string? room = context.Request.Query["room"];

                if (string.IsNullOrEmpty(room))
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus
                        .PolicyViolation, "Room name is required",
                        CancellationToken.None);

                    return;
                }

                Rooms.AddOrUpdate(room, [webSocket], (key, oldValue) =>
                {
                    oldValue.Add(webSocket);

                    return oldValue;
                });

                await ReceiveMessages(webSocket, room);

                Rooms[room].Remove(webSocket);

                await webSocket.CloseAsync(WebSocketCloseStatus
                    .NormalClosure, "Closed by the WebSocketHandler",
                    CancellationToken.None);
            }
            else context.Response.StatusCode = 400;
        }
        private async Task ReceiveMessages(WebSocket webSocket,
            string room)
        {
            var buffer = new byte[1024 * 4];

            WebSocketReceiveResult result = await webSocket
                .ReceiveAsync(new ArraySegment<byte>(buffer),
                CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                var message = Encoding.UTF8
                    .GetString(buffer, 0, result.Count);

                await BroadcastMessage(message, webSocket, room);

                result = await webSocket.ReceiveAsync
                    (new ArraySegment<byte>(buffer),
                    CancellationToken.None);
            }
        }
        private async Task BroadcastMessage(string message,
            WebSocket senderWebSocket, string room)
        {
            var messageBuffer = Encoding.UTF8.GetBytes(message);

            if (Rooms.TryGetValue(room, out var sockets))
                foreach (var socket in sockets)
                    if (socket != senderWebSocket &&
                        socket.State == WebSocketState.Open)
                        await socket.SendAsync(new ArraySegment<byte>
                            (messageBuffer), WebSocketMessageType.Text,
                            true, CancellationToken.None);
        }
    }
}