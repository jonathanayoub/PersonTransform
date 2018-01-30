using Castle.Windsor;
using Castle.Windsor.Installer;

namespace PersonTransform
{
    public static class Bootstrap
    {
        public static IWindsorContainer Configure()
        {
            var container = new WindsorContainer();
            container.Install(FromAssembly.This());
            return container;
        }
    }
}
