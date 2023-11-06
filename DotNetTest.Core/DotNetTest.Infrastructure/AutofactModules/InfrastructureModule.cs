using System.ComponentModel;
using Autofac;
using DotNetTest.Domain.AggregatesModel.ClientAggregate;
using DotNetTest.Domain.AggregatesModel.ProductAggregate;
using DotNetTest.Infrastructure.Finder;
using DotNetTest.Infrastructure.Finder.Client;
using DotNetTest.Infrastructure.Finder.Product;

namespace DotNetTest.Infrastructure.AutofactModules;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductFinder>()
            .As<IProductFinder>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<ClientFinder>()
            .As<IClientFinder>()
            .InstancePerLifetimeScope();
    }
}