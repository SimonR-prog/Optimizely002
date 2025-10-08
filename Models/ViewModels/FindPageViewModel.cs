using EPiServer.Find.UnifiedSearch;
using Optimizely002.Models.Pages;

namespace Optimizely002.Models.ViewModels;

public class FindPageViewModel : PageViewModel<FindPage>
{
    public FindPageViewModel(FindPage currentPage) : base(currentPage)
    {
    }

    public string Query { get; set; }

    public Task<UnifiedSearchResults> Results { get; set; }
}
