using System.Collections.Generic;
using System.Reflection;
using Autofac;
using NYourCodeAsCrimeScene.Core;
using NYourCodeAsCrimeScene.Core.Interfaces;
using NYourCodeAsCrimeScene.Infrastructure.Data;
using NYourCodeAsCrimeScene.SharedKernel.Interfaces;
using MediatR;
using MediatR.Pipeline;
using NYourCodeAsCrimeScene.Core.Services;
using Module = Autofac.Module;

namespace NYourCodeAsCrimeScene.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private bool _isDevelopment = false;
        private List<Assembly> _assemblies = new List<Assembly>();

        public DefaultInfrastructureModule(bool isDevelopment, Assembly callingAssembly =  null)
        {
            _isDevelopment = isDevelopment;
            var coreAssembly = Assembly.GetAssembly(typeof(DatabasePopulator));
            var infrastructureAssembly = Assembly.GetAssembly(typeof(EfRepository));
            _assemblies.Add(coreAssembly);
            _assemblies.Add(infrastructureAssembly);
            if (callingAssembly != null)
            {
                _assemblies.Add(callingAssembly);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }
            RegisterCommonDependencies(builder);
        }

        private void RegisterCommonDependencies(ContainerBuilder builder)
        {
            builder
                .RegisterType<EfRepository>()
                .As<IRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<UpdaterService>()
                .As<IUpdaterService>()
                .InstancePerLifetimeScope();
            
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionAction<,>),
                typeof(INotificationHandler<>),
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                .RegisterAssemblyTypes(_assemblies.ToArray())
                .AsClosedTypesOf(mediatrOpenType)
                .AsImplementedInterfaces();
            }

            builder
                .RegisterType<EmailSender>()
                .As<IEmailSender>()
                .InstancePerLifetimeScope();
        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add development only services
        }

        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add production only services
        }

    }
}
