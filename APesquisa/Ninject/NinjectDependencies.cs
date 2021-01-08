using APesquisa.Service;
using Ninject;
using System.Web.Mvc;

namespace APesquisa.Ninject
{
    public static class NinjectDependencies
    {
        public static void ConfigureDependencies()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<UnitOfWork.IUnitOfWork>().To<UnitOfWork.UnitOfWork>();
            kernel.Bind<IFormulaAnalysisService>().To<FormulaAnalysisService>();
            kernel.Bind<ISendMailService>().To<SendMailService>();

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}