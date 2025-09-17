using Microsoft.AspNetCore.Mvc;
using Optimizely002.Models.Pages;
using Optimizely002.Models.ViewModels;

namespace Optimizely002.Controllers;

public class StartPageController : PageControllerBase<StartPage>
{
    public IActionResult Index(StartPage currentPage)
    {
        var model = new StartPageViewModel(currentPage);

        return View(model);
    }
}
