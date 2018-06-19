using System.Reflection;
using System.Web;
using System.Web.Mvc;
using CqrsMvc5.Infra.IoC;
using CqrsMvc5.UI.Site;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Lifestyles;



namespace CqrsMvc5.UI.Site
{
    public class SimpleInjectorInitializer
    {
        private static Container _container;

        public static void Initialize(Container container)
        {
            _container = container;

            InitializeContainer();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(_container));
        }

        private static void InitializeContainer()
        {
            CqrsMvc5Bootstrapper.Register(_container);
        }
    }
}