using Optimizely002.Business;
using System.ComponentModel.DataAnnotations;

namespace Optimizely002.Models.Pages;

public class SitePageData : PageData
{
    [Display(
        GroupName = Globals.GroupNames.MetaData,
        Order = 100
        )]
    [CultureSpecific]
    public virtual string MetaDescription
    {
        get
        {
            var metaDescription = this.GetPropertyValue(p => p.MetaDescription);

            return !string.IsNullOrEmpty(metaDescription) ? metaDescription : PageName;
        }
        set => this.SetPropertyValue(p => p.MetaDescription, value);
    }












}
