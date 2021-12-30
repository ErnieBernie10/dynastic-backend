using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynastic.Architecture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddArchitecture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DynasticContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DynasticConnection"));
            }).AddLogging();
            return services;
        }
    }
}
