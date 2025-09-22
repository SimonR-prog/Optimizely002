using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Optimizely002.Models.Pages;
using Optimizely002.Models.ViewModels;

namespace Optimizely002.Business;

public class PageContextActionFilter : IActionFilter
{
    private readonly PageViewContextFactory _contextFactory;

    public PageContextActionFilter(PageViewContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var controller = context.Controller as Controller;
        var viewModel = controller?.ViewData.Model;

        if (viewModel is IPageViewModel<SitePageData> model)
        {
            var currentContentLink = context.HttpContext.GetContentLink();
            var layoutModel = model.Layout ?? _contextFactory.CreateLayoutModel(currentContentLink, context.HttpContext);

            if (context.Controller is IModifyLayout layoutController)
            {
                layoutController.ModifyLayout(layoutModel);
            }

            model.Layout = layoutModel;
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

}
