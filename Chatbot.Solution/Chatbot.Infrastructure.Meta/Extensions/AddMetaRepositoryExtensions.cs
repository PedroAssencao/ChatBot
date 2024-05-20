using Chatbot.Infrastructure.Meta.Repository;
using Chatbot.Infrastructure.Meta.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Meta.Extensions
{

    public static class AddMetaRepositoryExtensions
    {
        public static void AddRepositoryMetaStartUp(this IServiceCollection services)
        {
            services.AddScoped<IMetodoCheck,MetodoCheckRepository>();
        }
    }

}
