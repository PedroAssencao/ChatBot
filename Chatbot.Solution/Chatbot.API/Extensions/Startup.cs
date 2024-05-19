using Chatbot.Services.Extensions;
using Chatbot.Infrastructure.Extensions;
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
            services.AddServicesSetup();
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
