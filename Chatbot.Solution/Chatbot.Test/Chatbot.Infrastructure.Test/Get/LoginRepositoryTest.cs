using Chatbot.Infrastructure.Repository.Interfaces;
using Chatbot.Test.Chatbot.Mock;
using Microsoft.Extensions.DependencyInjection;

namespace Chatbot.Test.Chatbot.Infrastructure.Test.Get
{
    public class LoginRepositoryTest : IClassFixture<ChatbotConnection>
    {
        private readonly ILoginInterface _repository;

        public LoginRepositoryTest(ChatbotConnection application)
        {
            ChatbotMockDate.CreateDates(application, true).Wait();
            var scope = application.Services.CreateScope();
            _repository = scope.ServiceProvider.GetRequiredService<ILoginInterface>();
        }

        [Fact]
        public async Task BuscarTodosLogin()
        {
            try
            {
                var result = await _repository.GetALl();
                Assert.True(result.Count > 0);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um error ao tentar Executar o Teste BuscarTodosLogin, error: " + ex.Message);
            }
        }
    }
}
