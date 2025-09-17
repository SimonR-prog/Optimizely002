using Optimizely002.Models.Pages;

namespace Optimizely002.Models.ViewModels;

public interface IPageViewModel<out T> where T : SitePageData
{
    T CurrentPage { get; }

    LayoutModel Layout { get; set; }
}
