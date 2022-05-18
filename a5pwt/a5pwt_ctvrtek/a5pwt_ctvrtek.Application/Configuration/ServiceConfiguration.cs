using a5pwt_ctvrtek.Infrastructure.Configuration;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace a5pwt_ctvrtek.Application.Configuration
{
    public class ServiceConfiguration
    {
        public static void Load(IServiceCollection services, IHostingEnvironment environment)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(ServiceConfiguration)));
            services.AddSingleton(environment);
            InfrastructureServiceConfiguration.Load(services, environment);
        }
    }
}
