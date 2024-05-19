using Chatbot.Services.Extensions;
using Chatbot.Infrastructure.Extensions;
namespace Chatbot.API.Extensions
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositoryStartUp(configuration);
            services.AddServicesSetup(configuration);
        }

    }
}
