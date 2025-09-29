using Optimizely002.Models.Pages;

namespace Optimizely002.Models.ViewModels
{
    public class XmlSitemapViewModel : PageViewModel<XmlSitemap>
    {
        public IEnumerable<SitePageData> Pages { get; set; }

        public XmlSitemapViewModel(XmlSitemap currentPage) : base(currentPage)
        {
        }
    }
}
