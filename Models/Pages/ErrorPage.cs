using System.ComponentModel.DataAnnotations;

namespace Optimizely002.Models.Pages;


[ContentType(
    GUID = "220006A8-0B74-4A36-848F-5737EA22677A"
)]
public class ErrorPage : SitePageData
{
    [Display(
        GroupName = SystemTabNames.Content,
        Order = 10
        )]
    [CultureSpecific]
    public virtual string Header { get; set; }
}
