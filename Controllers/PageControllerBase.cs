using EPiServer.Web.Mvc;
using Optimizely002.Models.Pages;

namespace Optimizely002.Controllers;

public abstract class PageControllerBase<T> : PageController<T> where T : SitePageData
{
}
