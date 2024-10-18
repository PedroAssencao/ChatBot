
using Chatbot.API.Repository;
using Chatbot.Domain.Models;
using Chatbot.Infrastructure.Repository.Interfaces;
using Chatbot.Test.Chatbot.Infrastructure.Mock;
using Microsoft.Extensions.DependencyInjection;

namespace Chatbot.Test.Chatbot.Infrastructure.Get.Contatos
{
    public class ContatosInfraTest
    {
        protected readonly IContatosInterface _repository;

        public ContatosInfraTest(IContatosInterface repository)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IContatosInterface, ContatoRepository>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            _repository = serviceProvider.GetRequiredService<IContatosInterface>();
        }

        [Fact]
        public async Task BuscarTodosContatos()
        {
            await using var application = new ChatbotConnection();

            await ChatbotMockDate.CreateDates(application, true);

            List<Contato> dates = await _repository.GetALl();

            Assert.True(dates.Count > 0);
        }
    }
}
