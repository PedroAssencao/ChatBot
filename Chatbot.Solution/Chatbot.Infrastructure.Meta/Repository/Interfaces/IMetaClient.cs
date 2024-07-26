using Chatbot.Domain.Models.JsonMetaApi;
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
        public Task<dynamic> MensagemInicial(DataAndType Model);
        public Task<dynamic> BotResposta(DataAndType Model);
        public Task<dynamic> ChamarMetodo(dynamic Values);
        void CompararData();
    }
}
