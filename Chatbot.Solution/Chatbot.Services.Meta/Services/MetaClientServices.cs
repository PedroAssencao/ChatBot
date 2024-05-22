using Chatbot.Infrastructure.Meta.Repository;
using Chatbot.Infrastructure.Meta.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Meta.Services
{
    public class MetaClientServices : IMetaClientServices
    {
        protected readonly IMetaClient _metaRepository;

        public MetaClientServices(IMetaClient metaRepository)
        {
            _metaRepository = metaRepository;
        }

        public HttpClient ConfigurarClientServices(string token, string url)
        {
            try
            {
                return _metaRepository.ConfigurarClient(token, url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<dynamic> MAIN(JsonElement Values) => await _metaRepository.ChamarMetodo(Values);

        public Task<string> PostAsyncServices(string url, string token, dynamic data)
        {
            try
            {
                return _metaRepository.PostAsync(token, url, data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
