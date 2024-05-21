using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Meta.Repository.Interfaces
{
    public interface IMetaClientServices
    {
        public Task<dynamic> MAIN(JsonElement Values);
        public HttpClient ConfigurarClientServices(string token, string url);
        public Task<string> PostAsyncServices(string url, string token, dynamic data);
    }
}
