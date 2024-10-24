using Chatbot.API.DAL;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Chatbot.Test.Chatbot.Mock
{
    public class ChatbotConnection : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                //services.RemoveAll(typeof(chatbotContext));
                services.RemoveAll(typeof(DbContextOptions<chatbotContext>));
                services.AddDbContext<chatbotContext>(options =>
                {
                    options.UseInMemoryDatabase("DataBase", root);

                    options.ConfigureWarnings(warnings =>
                    {
                        warnings.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning);
                    });
                });
            });

            return base.CreateHost(builder);
        }
    }
}