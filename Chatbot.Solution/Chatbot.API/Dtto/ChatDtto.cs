using Chatbot.API.Models;

namespace Chatbot.API.Dtto
{
    public class ChatDttoGet
    {
        public int cha_id { get; set; }
        public Contato? Contato { get; set; }
        public Atendente? Atendente { get; set; }
        public List<Mensagen>? Mensagens { get; set; }
    }
}
