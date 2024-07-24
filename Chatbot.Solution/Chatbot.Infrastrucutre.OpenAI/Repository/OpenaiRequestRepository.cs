using Chatbot.Infrastrucutre.OpenAI.Repository.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Infrastrucutre.OpenAI.Repository
{
    public class OpenaiRequestRepository : IOpenaiRequest
    {
        private const string _baseurl = "https://api.openai.com/v1/chat";
        private readonly IOpenaiClientConfiguration _configurationClient;

        public OpenaiRequestRepository(IOpenaiClientConfiguration configurationClient)
        {
            _configurationClient = configurationClient;
        }

        public async Task<string> PostAsync(string authorization)
        {
            try
            {
                _configurationClient.InstanceClient("OpenAI-API");

                _configurationClient.AddHeaders(new Dictionary<string, string>
                {
                    {"Authorization", $"Bearer {authorization}"}
                });

                var requestBody = new
                {
                    model = "gpt-4",
                    messages = new[]
                    {
                        new { role = "system", content = "Você é um historiador brasileiro" },
                        new { role = "user", content = "Me fale um pouco sobre a hisotira do senai no brasil" }
                    },
                    max_tokens = 350,
                    temperature = 0.5
                };


                var httpContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                var response = await _configurationClient.PostAsync($"{_baseurl}/completions", httpContent);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while making the API request", ex);
            }
        }

    }
}
