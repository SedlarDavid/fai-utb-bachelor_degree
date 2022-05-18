using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Infrastructure.Configuration
{
    public class InfrastructureDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
