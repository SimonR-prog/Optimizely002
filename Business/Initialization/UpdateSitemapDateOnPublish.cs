using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Optimizely002.Models.Pages;

namespace Optimizely002.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class UpdateSitemapDateOnPublish : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var events = ServiceLocator.Current.GetInstance<IContentEvents>();
            events.PublishingContent += OnPublishingContent;
        }

        private void OnPublishingContent(object sender, ContentEventArgs e)
        {
            if (e.Content is SitePageData page)
            {
                page.XmlSitemapDate = DateTime.Now;
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
