using Chatbot.API.DAL;
using Chatbot.API.Repository;
using Chatbot.Infrastructure.Dtto;
using Chatbot.Test.Chatbot.Mock;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Chatbot.Test.Chatbot.Infrastructure.Test.Get
{
    public class LoginRepositoryTest
    {
        private readonly LoginRepository _repository = new LoginRepository(new chatbotContext());

        //metodo que esta funcionando
        [Fact]
        public async Task BuscarTodosLoginViaEnpoint()
        {
            try
            {
                await using var application = new ChatbotConnection();

                await ChatbotMockDate.CreateDates(application, true);
                var url = "/api/v1/Login/login";

                var client = application.CreateClient();

                var result = await client.GetAsync(url);
                var dates = await client.GetFromJsonAsync<List<LoginDttoGet>>(url);
                Assert.True(dates?.Count > 0);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //metodo que ainda não esta funcionando
        [Fact]
        public async Task BuscarTodosLoginViaScript()
        {
            try
            {
                await using var application = new ChatbotConnection();
                await ChatbotMockDate.CreateDates(application, true);

                var result = await _repository.GetALl();
                Assert.True(result.Count > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
