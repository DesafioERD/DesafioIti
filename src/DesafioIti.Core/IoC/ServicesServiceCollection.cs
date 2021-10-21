using DesafioIti.Core.Services;
using DesafioIti.Core.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioIti.Core.IoC
{
    [ExcludeFromCodeCoverage]
    public static class ServicesServiceCollection
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<IHashService, HashService>();
        }
    }
}
