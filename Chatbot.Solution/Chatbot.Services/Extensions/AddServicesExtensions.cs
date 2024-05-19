using Chatbot.API.Repository;
using Chatbot.Infrastructure.Interfaces;
using Chatbot.Infrastructure.Repository.Interfaces;
using Chatbot.Infrastructure.Services;
using Chatbot.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatbot.Infrastructure.Extensions;

namespace Chatbot.Services.Extensions
{
    public static class AddServicesExtensions
    {
        public static void AddServicesSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IContatoInterfaceServices, ContatoServices>();
            //services.AddScoped<IContatosInterface, ContatoRepository>();
            //services.AddScoped<IMensagemInterface, MensagemRepository>();
            //services.AddScoped<IMenuInterface, menuRepository>();
            //services.AddScoped<IOptionsInterface, optionsRepository>();
            //services.AddScoped<IDepartamentoInterface, DepartamentoRepository>();
            //services.AddScoped<ILoginInterface, LoginRepository>();
            //services.AddScoped<IAtendeteInterface, atendentesRepostiroy>();
            //services.AddScoped<IAtendimentoInterface, AtendimentoRepository>();
        }
    }
}
