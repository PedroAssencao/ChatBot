using Chatbot.Infrastructure.Meta.Repository.Interfaces;
using Chatbot.Infrastructure.Services.Interfaces;
using Chatbot.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.SignalR;

namespace Chatbot.Infrastructure.Meta.Repository.SignalRForChat
{
    public class ChatHub : Hub
    {
        protected readonly IChatsInterfaceServices _ChatServices;
        protected readonly IMensagemInterfaceServices _MessageServices;
        protected readonly IMetaClient _metaClientServices;

        public ChatHub(IChatsInterfaceServices chatServices, IMensagemInterfaceServices messageServices, IMetaClient metaClientServices)
        {
            _ChatServices = chatServices;
            _MessageServices = messageServices;
            _metaClientServices = metaClientServices;
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.Features.Get<IHttpContextFeature>()?.HttpContext;
            var chatId = Convert.ToInt32(httpContext?.Request.Query["chatId"]);
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
            //talvez não precse fazer esse fetch inicial aqui vou me aprodundar mais para ver essa possibilidade
            var chat = await _ChatServices.GetPorId(chatId);

            foreach (var message in chat?.Mensagens)
            {
                await Clients.Caller.SendAsync("ReceiveMessage", message);
            }

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(int AteId, int ChatId, string message) => await _metaClientServices.SalvarMensagemAtendente(message, ChatId, AteId);


    }
}
