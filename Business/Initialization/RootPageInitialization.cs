using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Initialization;
using EPiServer.ServiceLocation;
using Optimizely002.Models.Pages;

namespace Optimizely002.Business.Initialization;

[InitializableModule]
[ModuleDependency(typeof(CmsCoreInitialization))]
public class RootPageInitialization : IInitializableModule
{
    public void Initialize(InitializationEngine context)
    {
        var contentTypeRepository = context.Locate.Advanced.GetInstance<IContentTypeRepository>();
        var sysRoot = contentTypeRepository.Load("SysRoot") as PageType;
        var setting = new AvailableSetting { Availability = Availability.Specific };

        setting.AllowedContentTypeNames.Add(contentTypeRepository.Load<StartPage>().Name);

        var avaliableSettingsRepository = context.Locate.Advanced.GetInstance<IAvailableSettingsRepository>();
        avaliableSettingsRepository.RegisterSetting(sysRoot, setting);
    }

    public void Uninitialize(InitializationEngine context)
    {
    }
}
