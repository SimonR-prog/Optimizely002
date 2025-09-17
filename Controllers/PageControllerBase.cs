using Microsoft.AspNetCore.Mvc;

namespace Optimizely002.Controllers;

public class PageControllerBase<T> : PageController<T> where T : SitePageData
{
    public IActionResult Index()
    {
        return View();
    }
}
