using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Optimizely002.Models.Blocks;
using Optimizely002.Models.Pages;
using Optimizely002.Models.ViewModels;

namespace Optimizely002.Blocks.Carousel
{
    public class CarouselBlockComponent : AsyncBlockComponent<CarouselBlock>
    {
        protected override async Task<IViewComponentResult> InvokeComponentAsync(CarouselBlock currentContent)
        {
            var model = new CarouselViewModel();

            if (currentContent.Carousel != null)
            {
                foreach (var item in currentContent.Carousel.FilteredItems.Select(x => x.LoadContent()))
                {
                    if (item is CarouselPage page)
                    {
                        model.Pages.Add(page);
                    }
                }
            }
            return await Task.FromResult(View("~/views/shared/carousel.cshtml", model));
        }
    }
}
