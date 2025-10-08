using Microsoft.AspNetCore.Mvc;
using Optimizely002.Models.Pages;
using Optimizely002.Models.ViewModels;
using Optimizely002.Services.Interfaces;

namespace Optimizely002.Controllers;

public class FindPageController : PageControllerBase<FindPage>
{
    private readonly IFindService _findService;

    public FindPageController(IFindService findService)
    {
        _findService = findService;
    }

    public IActionResult Index(FindPage currentPage)
    {
        var model = new FindPageViewModel(currentPage);

        return View(model);
    }

    [HttpPost]
    public IActionResult FindContent(FindPage currentPage, string query)
    {
        var cultureInfo = currentPage.Language;

        var model = new FindPageViewModel(currentPage)
        {
            Query = query,
            Results = _findService.FindAsync(query, cultureInfo)
        };

        return View("~7views/FindPage/Index.cshtml", model);
    }
}