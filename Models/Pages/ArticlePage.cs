using Optimizely002.Business;
using System.ComponentModel.DataAnnotations;

namespace Optimizely002.Models.Pages
{
    [ContentType(
    GUID = "AAE76A1F-C82F-4EB7-87A7-ED24083369B1",
    GroupName = Globals.GroupNames.Specialized
    )]
    public class ArticlePage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
            )]
        [CultureSpecific]
        public virtual string Heading { get; set; } = string.Empty;
    }
}
