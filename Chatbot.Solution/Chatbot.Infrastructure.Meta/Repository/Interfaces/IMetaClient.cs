using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Meta.Repository.Interfaces
{
    public interface IMetaClient
    {
        public HttpClient ConfigurarClient(string token, string url);
        public Task<string> PostAsync(string url, string token, dynamic data);
        public Task<dynamic> MensagemInicial(string waId, string mensagem, string LoginWaId);
        public Task<dynamic> BotResposta(string waId, string descricaoDaMensagem, string LoginWaId);
        public Task<dynamic> TipoMetodo(JsonProperty Values);
    }
}
