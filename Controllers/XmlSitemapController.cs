using Microsoft.AspNetCore.Mvc;
using Optimizely002.Models.Pages;
using Optimizely002.Models.ViewModels;
using Optimizely002.Services.Interfaces;

namespace Optimizely002.Controllers
{
    public class XmlSitemapController(IXmlSitemapService xmlSitemapService) : PageControllerBase<XmlSitemap>
    {
        private readonly IXmlSitemapService _xmlSitemapService = xmlSitemapService;

        public IActionResult Index(XmlSitemap currentPage)
        {
            var model = new XmlSitemapViewModel(currentPage)
            {
                Pages = _xmlSitemapService.GetPages(currentPage)
            };

            return View(model);
        }
    }
}
