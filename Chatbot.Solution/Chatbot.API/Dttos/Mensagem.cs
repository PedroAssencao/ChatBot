using Chatbot.API.Migrations;
using Chatbot.API.Models;
using Chatbot.API.Repository;

namespace Chatbot.API.Dttos
{
    public class Mensagem
    {

        public int menId { get; set; }
        public string menDescricao { get; set; }
        public string menResposta { get; set; }
        public string menTitle { get; set; }
        public DateTime menData { get; set; }
        public string menTipo { get; set; }
        public Login log { get; set; }
        public Contato con { get; set; }

  
    }
}
