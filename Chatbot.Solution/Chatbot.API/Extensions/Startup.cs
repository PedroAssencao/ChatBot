using Chatbot.Services.Extensions;
using Chatbot.Infrastructure.Extensions;
using Chatbot.Services.Meta.Extensions;
using Chatbot.Infrastructure.Meta.Extensions;
namespace Chatbot.API.Extensions
{
    public static class Startup
    {
        public static void StartConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.StartConfiguration();
            services.AddRepositoryStartUp(configuration);
            services.ConfigureServicesMeta();
            services.AddServicesSetup();
        }

        public static void ConfigureServicesMeta(this IServiceCollection services)
        {
            services.AddServicesMetaExtension();
            services.AddRepositoryMetaStartUp();
        }

        public static void Configure(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
