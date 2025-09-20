using EPiServer.Web;
using Optimizely002.Business;
using System.ComponentModel.DataAnnotations;

namespace Optimizely002.Models.Pages;

[ContentType(
    GUID = "623CEBCD-6DD4-47F2-B454-1C7E578AF466",
    GroupName = Globals.GroupNames.Specialized
    )]

[ImageUrl("/pages/CMS-icon-page-02.png")]
public class StartPage : SitePageData
{


    [Display(
        GroupName = SystemTabNames.Content,
        Order = 10
        )]
    [CultureSpecific]
    public virtual string Heading { get; set; } = string.Empty;



    [Display(
        GroupName = SystemTabNames.Content,
        Order = 20
        )]
    [CultureSpecific]
    [UIHint(UIHint.Textarea)]
    public virtual string Preamble { get; set; } = string.Empty;



    [Display(
        GroupName = SystemTabNames.Content,
        Order = 30
        )]
    [CultureSpecific]
    public virtual XhtmlString MainBody { get; set; }



    [Display(
        GroupName = SystemTabNames.Content,
        Order = 40
        )]
    [UIHint(UIHint.Image)]
    public virtual ContentReference Image { get; set; }
}
