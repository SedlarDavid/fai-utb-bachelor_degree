using a5pwt_ctvrtek.Domain.Configuration;
using a5pwt_ctvrtek.Infrastructure.Configuration;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Application.Configuration
{
    public class ApplicationDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterModule<DomainDependencyModule>();
            builder.RegisterModule<InfrastructureDependencyModule>();
        }
    }
}
