using Microsoft.AspNetCore.Mvc;
using Optimizely002.Models.Pages;
using Optimizely002.Models.ViewModels;

namespace Optimizely002.Controllers;

public class ErrorPageController : PageControllerBase<ErrorPage>
{
    public IActionResult Index(ErrorPage currentPage)
    {
        var model = new ErrorPageViewModel(currentPage);

        return View(model);
    }
}
