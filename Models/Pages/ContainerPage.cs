using Optimizely002.Business;
using Optimizely002.Models.Interfaces;

namespace Optimizely002.Models.Pages
{

    [ContentType(
        GUID = "49589D80-3E68-4C9A-B654-F076CE9F004A",
        GroupName = Globals.GroupNames.Specialized,
        DisplayName = "Container"
    )]
    [AvailableContentTypes(
        Availability.Specific,
        Include = [typeof(CarouselPage)] 
    )]
    [ImageUrl("/pages/container.png")]
    public class ContainerPage : PageData, IContainerPage
    {
    }
}
