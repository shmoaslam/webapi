using BusinessServices;
using Microsoft.Practices.Unity;

namespace Core.IOC
{
    public static class UnityConfig
    {
        public static UnityContainer RegisterType()
        {
            var container = new UnityContainer();
            container.RegisterType<IProductServices, ProductServices>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}
