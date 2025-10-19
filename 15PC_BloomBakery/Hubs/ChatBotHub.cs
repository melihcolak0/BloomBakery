using _15PC_BloomBakery.AIIntegration;
using Microsoft.AspNetCore.SignalR;

namespace _15PC_BloomBakery.Hubs
{
    public class ChatBotHub : Hub
    {
        private readonly RapidApiGPT4oIntegration _aiService;

        public ChatBotHub(RapidApiGPT4oIntegration aiService)
        {
            _aiService = aiService;
        }

        public async Task SendMessage(string user, string message)
        {      
            // Kullanıcının mesajını herkese yayınla
            await Clients.All.SendAsync("ReceiveMessage", user, message);

            // AI cevabını al
            var reply = await _aiService.GenerateTextAsync(message);

            // BloomBot cevabını gönder
            await Clients.All.SendAsync("ReceiveMessage", "BloomBot", reply);
        }
    }
}
