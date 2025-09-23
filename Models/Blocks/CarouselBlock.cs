using Optimizely002.Business;
using Optimizely002.Models.Pages;
using System.ComponentModel.DataAnnotations;

namespace Optimizely002.Models.Blocks
{
    [ContentType(
        GUID = "F5BAE02A-0FFD-40FD-A247-F5D2B9344CFB",
        GroupName = Globals.GroupNames.Specialized,
        DisplayName = "Carousel",
        Description = "This is a carousel template"
    )]
    public class CarouselBlock : BlockData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        [AllowedTypes(typeof(CarouselPage))]
        public virtual ContentArea Carousel { get; set; }
    }
}
