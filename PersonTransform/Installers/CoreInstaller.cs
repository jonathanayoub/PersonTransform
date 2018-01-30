using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PersonTransform.Core;

namespace PersonTransform.Installers
{
    public class CoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IPersonTransform>().ImplementedBy<Core.PersonTransform>(),
                Component.For<IExportPersonListFactory>().ImplementedBy<MappingExportPersonListFactory>(),
                Component.For<ExportPersonFactory>());
        }
    }
}
