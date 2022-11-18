using Microsoft.AspNetCore.SignalR;

namespace SistemaDivisasAPI.Hubs
{
    public class EstadoHub : Hub
    {
        public async Task Mensaje(string jobId, string mensaje)
        {
            await Clients.All.SendAsync("ReceiveMessage", jobId, mensaje);
        }
    }
}
