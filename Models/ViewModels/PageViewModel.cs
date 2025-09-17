using Optimizely002.Models.Pages;

namespace Optimizely002.Models.ViewModels;

public class PageViewModel<T> : IPageViewModel<T> where T : SitePageData
{
    public PageViewModel(T currentPage)
    {
        currentPage = currentPage;
    }
    public T CurrentPage { get; set; }

    public LayoutModel Layout {  get; set; }
}

public static class PageViewModel
{
    public static PageViewModel<T> Create<T>(T page) where T : SitePageData => new(page);
}
