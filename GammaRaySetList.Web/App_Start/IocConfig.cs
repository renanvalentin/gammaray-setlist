using GammaRaySetList.Data;
using GammaRaySetList.Data.Contracts;
using Ninject;
using System.Web.Http;

namespace GammaRaySetList.Web.App_Start
{
    public class IocConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            config.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}