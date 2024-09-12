using Chatbot.Infrastructure.Services.Interfaces;
using Chatbot.Services.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Chatbot.Infrastructure.Meta.Repository.SignalRForChat
{
    public class ChatHub : Hub
    {
        protected readonly IChatsInterfaceServices _ChatServices;
        protected readonly IMensagemInterfaceServices _MessageServices;

        public ChatHub(IChatsInterfaceServices chatServices, IMensagemInterfaceServices messageServices)
        {
            _ChatServices = chatServices;
            _MessageServices = messageServices;
        }

        public override async Task OnConnectedAsync()
        {
            var IdDoChat = 1; // Identifique o chat atual

            // Suponha que você tenha um método para obter mensagens entre dois usuários
            var chat = await _ChatServices.GetPorId(1);

            foreach (var message in chat.Mensagens)
            {
                await Clients.Caller.SendAsync("ReceiveMessage", message.Descricao);
            }

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string receiverId, string message)
        {
            var senderId = Context.UserIdentifier;

            // Armazenar a mensagem no banco de dados

            //lembrar de colocar o metodo para salvar no webhook tambem para as mensagens ficarem dinamicas
            //await _MessageServices.AdicionarPost();
            // Enviar a mensagem para os dois usuários
            await Clients.User(receiverId).SendAsync("ReceiveMessage", message);
            await Clients.User(senderId).SendAsync("ReceiveMessage", message);
        }

    }
}
