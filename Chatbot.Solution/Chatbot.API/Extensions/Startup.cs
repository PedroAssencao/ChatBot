using Chatbot.Services.Extensions;
using Chatbot.Infrastructure.Extensions;
using Chatbot.Services.Meta.Extensions;
using Chatbot.Infrastructure.Meta.Extensions;
using Chatbot.Infrastrucutre.OpenAI.Extensions;
using Chatbot.Infrastructure.Meta.Repository.SignalRForChat;
namespace Chatbot.API.Extensions
{
    public static class Startup
    {
        public static void StartConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddSignalR();
            services.AddHostedService<VerificarAtendimentoService>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
        }

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.StartConfiguration();
            services.AddRepositoryStartUp(configuration);
            services.AddServicesSetup();
            services.ConfigureServicesMeta();
            services.ConfigureServicesOpenAi();
        }

        public static void ConfigureServicesMeta(this IServiceCollection services)
        {
            services.AddServicesMetaExtension();
            services.AddRepositoryMetaStartUp();
        }

        public static void ConfigureServicesOpenAi(this IServiceCollection services)
        {
            services.AddInfraOpenAiExtension();
        }

        public static void Configure(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAllOrigins");
            app.UseHttpsRedirection();

            // Adiciona o roteamento
            app.UseRouting(); // Adicione esta linha

            app.UseAuthorization();

            // Mapeia os controladores
            app.MapControllers();

            // Define os endpoints, incluindo o SignalR hub
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // Mapeia o SignalR hub
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }

    }
}
