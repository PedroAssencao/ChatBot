using Chatbot.Services.Extensions;
using Chatbot.Infrastructure.Extensions;
using Chatbot.Services.Meta.Extensions;
using Chatbot.Infrastructure.Meta.Extensions;
using Chatbot.Infrastrucutre.OpenAI.Extensions;
using Chatbot.API.Controllers;
using Microsoft.OpenApi.Models;

namespace Chatbot.API.Extensions
{
    public static class Startup
    {
        public static void StartConfiguration(this IServiceCollection services)
        {
            services.AddControllers();

            // Swagger configuration
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Chatbot API",
                    Version = "v1",
                    Description = "API para gerenciar o chatbot"
                });
            });

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
            // Habilitar Swagger para todos os ambientes (não só desenvolvimento)
            app.UseSwagger();

            // Configurar Swagger UI como página inicial
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Chatbot API v1");
                options.RoutePrefix = string.Empty; // Carregar Swagger na raiz "/"
            });

            app.UseCors("AllowAllOrigins");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
