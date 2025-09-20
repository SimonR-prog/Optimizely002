using Microsoft.AspNetCore.Mvc;
using Optimizely002.Models.Pages;
using Optimizely002.Models.ViewModels;

namespace Optimizely002.Controllers;

public class ArticlePageController : PageControllerBase<ArticlePage>
{
    public IActionResult Index(ArticlePage currentPage)
    {
        var model = new ArticlePageViewModel(currentPage);

        return View(model);
    }
}