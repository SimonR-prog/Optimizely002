using EPiServer.Web;
using Optimizely002.Business;
using System.ComponentModel.DataAnnotations;

namespace Optimizely002.Models.Pages
{



    [ContentType(
        GUID = "968E7F5C-470A-47A7-97EE-299B96C03A4B",
        GroupName = Globals.GroupNames.Specialized,
        DisplayName = "Carousel",
        Description = "This is a carousel template"
    )]
    public class CarouselPage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }
    }
}
