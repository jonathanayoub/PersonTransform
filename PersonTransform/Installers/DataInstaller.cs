using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PersonTransform.Data.Interfaces;
using PersonTransform.Data.Json;

namespace PersonTransform.Installers
{
    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IImportPersonRepo>().ImplementedBy<JsonImportPersonRepo>(),
                Component.For<IExportPersonRepo>().ImplementedBy<JsonExportPersonRepo>(),
                Component.For<IJson>().ImplementedBy<JsonConverter>(),
                Component.For<IConfig>().ImplementedBy<XmlConfig>());
        }
    }
}
