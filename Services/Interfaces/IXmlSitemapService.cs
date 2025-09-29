using Optimizely002.Models.Pages;

namespace Optimizely002.Services.Interfaces
{
    public interface IXmlSitemapService
    {
        IEnumerable<SitePageData> GetPages(XmlSitemap currentPage);
    }
}
