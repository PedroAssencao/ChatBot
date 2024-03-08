using System.Text;
using System.Text.Json;

namespace Chatbot.API.HttpMethods
{
    public class MethodsPost
    {
        private readonly IConfiguration _configuration;

        public MethodsPost(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> HookMethod(JsonDocument requestBody)
        {
           
                var Values = requestBody.RootElement;
                var mensagem = Values
    .GetProperty("entry")[0]
    .GetProperty("changes")[0]
    .GetProperty("value")
    .GetProperty("messages")[0]
    .GetProperty("text")
    .GetProperty("body")
    .GetString();
                if (mensagem != null)
                {

                    string accessToken = _configuration.GetSection("security").GetSection("AccessToken").Value;

                    // URL para fazer um post em uma timeline
                    string url = $"https://graph.facebook.com/v18.0/194454180428439/messages?access_token={accessToken}";

                    // Dados que você deseja postar
                    string dadosJson = @"
{
    ""messaging_product"": ""whatsapp"",
    ""recipient_type"": ""individual"",
    ""to"": ""5579988132044"",
    ""type"": ""template"",
    ""template"": {
        ""name"": ""boas_vindas_5"",
        ""language"": {
            ""code"": ""pt_BR""
        },
        ""components"": [
            {
                ""type"": ""body"",
                ""parameters"": [
                    {
                        ""type"": ""text"",
                        ""text"": ""Pedro""
                    },
                    {
                        ""type"": ""text"",
                        ""text"": ""Teclado""
                    }
                ]
            },
            {
                ""type"": ""header"",
                ""parameters"": [
                    {
                        ""type"": ""text"",
                        ""text"": ""Margi""
                    }
                ]
            }
        ]
    }
}";


                    using (var httpClient = new HttpClient())
                    {
                        // Serializa os dados para formato JSON
                        var conteudo = new StringContent(dadosJson, Encoding.UTF8, "application/json");

                        // Adiciona o token de acesso aos cabeçalhos da requisição

                        // Envia a requisição POST
                        var resposta = await httpClient.PostAsync(url, conteudo);

                        // Verifica se a requisição foi bem-sucedida (código de status 2xx)
                        if (resposta.IsSuccessStatusCode)
                        {
                            Console.WriteLine("POST na Graph API bem-sucedido!");
                        }
                        else
                        {
                            Console.WriteLine($"Erro no POST. Código de status: {resposta.StatusCode}");
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
        }
    }
}
