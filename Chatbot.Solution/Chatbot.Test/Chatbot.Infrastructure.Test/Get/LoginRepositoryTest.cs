using Chatbot.API.DAL;
using Chatbot.API.Repository;
using Chatbot.Test.Chatbot.Mock;

namespace Chatbot.Test.Chatbot.Infrastructure.Test.Get
{
    public class LoginRepositoryTest
    {
        private readonly LoginRepository _repository = new LoginRepository(new chatbotContext());

        [Fact]
        public async Task BuscarTodosLogin()
        {
            try
            {
                await using var application = new ChatbotConnection();

                await ChatbotMockDate.CreateDates(application, true);

                var result = await _repository.GetAll();
                Assert.True(result.Count > 0);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
