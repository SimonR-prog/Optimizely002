using Optimizely002.Business;
using System.ComponentModel.DataAnnotations;

namespace Optimizely002.Models.Pages;

    [ContentType(
        GUID = "623CEBCD-6DD4-47F2-B454-1C7E578AF466",
        GroupName = Globals.GroupNames.Specialized
        )]

    public class StartPage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
            )]
        [CultureSpecific]

        public virtual string Heading { get; set; } = string.Empty;
    }
