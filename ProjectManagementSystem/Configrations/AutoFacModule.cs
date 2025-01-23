

using Autofac;
using ProjectManagementSystem.Data;
using ProjectManagementSystem.Data.Repositories;

namespace ProjectManagementSystem.Configrations;

public class AutoFacModule: Module
{
    public AutoFacModule()
    {

    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Context>().InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            .Where(c => c.Name.EndsWith("Service") || c.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(typeof(Program).Assembly)
               .Where(c => c.Name.EndsWith("Mediator"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(Program).Assembly)
               .Where(c => c.Name.EndsWith("Accessor"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();
    }
}
