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
                options.AddPolicy("AllowLocalhost",
                    builder =>
                    {
                        //builder.WithOrigins("https://localhost:5173")
                        builder.WithOrigins("http://127.0.0.1:5500")
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials();
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
            app.UseCors("AllowLocalhost");

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();
            app.MapHub<ChatHub>("/chatHub");
        }

    }
}
