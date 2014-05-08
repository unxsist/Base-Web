[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Base.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Base.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Base.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                //GlobalConfiguration.Configuration.DependencyResolver = new Ninject.Web.WebApi.NinjectDependencyResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<Data.Infrastructure.IUnitOfWork>().To<Data.Infrastructure.UnitOfWork>().InRequestScope();
            kernel.Bind<Data.Infrastructure.IDatabaseFactory>().To<Data.Infrastructure.DatabaseFactory>().InRequestScope();
            
            //Repositories
            kernel.Bind<Data.Repository.ISampleRepository>().To<Data.Repository.SampleRepository>();

            //Services
            kernel.Bind<Services.ISampleService>().To<Services.SampleService>();
        }        
    }
}
