using Chatbot.Infrastructure.Meta.Repository;
using Chatbot.Infrastructure.Meta.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Meta.Services
{
    internal class MetaClientServices : IMetaClientServices
    {
        protected readonly MetaRepository _metaRepository;

        public MetaClientServices(MetaRepository metaRepository)
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
