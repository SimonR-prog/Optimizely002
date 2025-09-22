using Microsoft.AspNetCore.Mvc;
using Optimizely002.Models.Pages;
using Optimizely002.Models.ViewModels;

namespace Optimizely002.Controllers;

public class SettingsPageController : PageControllerBase<SettingsPage> 
{
    public IActionResult Index(SettingsPage currentPage)
    {
        var model = new SettingsPageViewModel(currentPage);

        return View(model);
    }
}