using EPiServer.ServiceLocation;
using EPiServer.Web;
using Optimizely002.Models.Pages;
using Optimizely002.Models.ViewModels;

namespace Optimizely002.Business;

[ServiceConfiguration]
public class PageViewContextFactory
{
    private readonly IContentLoader _contentLoader;

    public PageViewContextFactory(IContentLoader contentLoader)
    {
        _contentLoader = contentLoader;
    }

    public virtual LayoutModel CreateLayoutModel(ContentReference contentReference, HttpContext httpContext)
    {
        var startPageContentLink = SiteDefinition.Current.StartPage;

        if (contentReference.CompareToIgnoreWorkID(startPageContentLink))
        {
            startPageContentLink = contentReference;
        }

        var startPage = _contentLoader.Get<StartPage>(startPageContentLink);

        return new LayoutModel
        {
            StartPage = startPage,
            SettingsPage = GetSettingsPage()
        };
    }

    private SettingsPage GetSettingsPage()
    {
        if (SiteDefinition.Current.StartPage != ContentReference.EmptyReference)
        {
            var settingsPage = _contentLoader.GetChildren<SettingsPage>
                (SiteDefinition.Current.StartPage).FirstOrDefault();

            if (settingsPage != null)
            {
                return settingsPage;
            }
            else
            {
                //insert log here.
            }
        }
        else
        {
            //insert log here.
        }
        return null;
    }
}