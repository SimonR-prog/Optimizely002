
using Optimizely002.Business;
using System.ComponentModel.DataAnnotations;

namespace Optimizely002.Models.Pages;


[ContentType(
        GUID = "4D9CEECB-9391-4033-AA23-3749CC48B2A9",
        GroupName = Globals.GroupNames.Specialized
    )]
[ImageUrl("/pages/CMS-icon-page-16.png")]
public class SettingsPage : SitePageData
{
    [Display(
        GroupName = SystemTabNames.Content
    )]
    public virtual PageReference LinkToMovies { get; set; }
}
