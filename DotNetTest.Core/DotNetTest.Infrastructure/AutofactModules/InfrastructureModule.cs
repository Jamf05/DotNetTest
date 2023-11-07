using System.ComponentModel;
using Autofac;
using DotNetTest.Domain.AggregatesModel.ClientAggregate;
using DotNetTest.Domain.AggregatesModel.InvoiceAggregate;
using DotNetTest.Domain.AggregatesModel.ProductAggregate;
using DotNetTest.Infrastructure.Finder;
using DotNetTest.Infrastructure.Finder.Client;
using DotNetTest.Infrastructure.Finder.Invoice;
using DotNetTest.Infrastructure.Finder.Product;
using DotNetTest.Infrastructure.Repository;

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

        builder.RegisterType<InvoiceFinder>()
            .As<IInvoiceFinder>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<InvoiceRepository>()
            .As<IInvoiceRepository>()
            .InstancePerLifetimeScope();
    }
}