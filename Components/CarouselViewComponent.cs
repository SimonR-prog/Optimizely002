

using EPiServer.Web;
using Microsoft.AspNetCore.Mvc;
using Optimizely002.Models.Pages;
using Optimizely002.Models.ViewModels;

namespace Optimizely002.Components
{
    public class CarouselViewComponent : ViewComponent
    {
        private readonly IContentLoader _contentLoader;

        public CarouselViewComponent(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }


        public IViewComponentResult Invoke(IContentLoader contentLoader)
        {
            var startPage = _contentLoader.Get<StartPage>(SiteDefinition.Current.StartPage);
            var model = new CarouselViewModel();

            if(startPage.Carousel != null)
            {
                foreach (var items in startPage.Carousel.FilteredItems.Select(x => x.LoadContent()))
                {
                    if (items is CarouselPage page)
                    {
                        model.Pages.Add(page);
                    }
                }
            }
            return View("~/views/shared/carousel.cshtml", model);
        }
    }
}
