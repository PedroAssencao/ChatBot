using Chatbot.API.DAL;
using Chatbot.API.Repository;
using Chatbot.Infrastructure.Interfaces;
using Chatbot.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Extensions
{
    public static class AddRepositoryExtensions
    {
        public static void AddRepositoryStartUp(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<chatbotContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Chinook"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddTransient<IMensagemInterface, MensagemRepository>();
            //services.AddTransient<IChatsInterface, ChatRepository>();
            services.AddTransient<IContatosInterface, ContatoRepository>();
            services.AddTransient<ILoginInterface, LoginRepository>();
            //services.AddTransient<IAtendimentoInterface, AtendimentoRepository>();
            services.AddTransient<IAtendeteInterface, atendentesRepostiroy>();
            services.AddTransient<IDepartamentoInterface, DepartamentoRepository>();
            services.AddTransient<IOptionsInterface, optionsRepository>();
            //services.AddTransient<IChatsInterface, ChatRepository>();
            services.AddTransient<IMenuInterface, menuRepository>();
        }
    }
}
