using Chatbot.API.DAL;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Chatbot.Test.Chatbot.Infrastructure.Mock
{
    public class ChatbotConnection : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<chatbotContext>));
                services.AddDbContext<chatbotContext>(options =>
                    options.UseInMemoryDatabase("DataBase", root));
            });


            return base.CreateHost(builder);
        }
    }
}
