using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.Web;
using Optimizely002.Models.Pages;
using Optimizely002.Services.Interfaces;

namespace Optimizely002.Business.Scheduledjobs
{
    [ScheduledPlugIn(
        GUID = "1F0271BE-48FD-4F6B-B752-7BF2F2ED55EB",
        DisplayName = "Delete unpublished carousel pages",
        Description = "Deletes unpublished carousel pages.")]
    public class DeleteUnpublishedCarouselPages : ScheduledJobBase
    {
        private readonly IContentLoader _contentLoader;
        private ISiteDefinitionRepository _siteDefinitionRepository;
        private bool _stopSignaled;
        private readonly IDescendantService _descendantService;
        private readonly IContentRepository _contentRepository;

        public DeleteUnpublishedCarouselPages(IContentLoader contentLoader, ISiteDefinitionRepository siteDefinitionRepository, bool stopSignaled, IContentRepository contentRepository, IDescendantService descendantService)
        {
            _contentLoader = contentLoader;
            _siteDefinitionRepository = siteDefinitionRepository;
            _stopSignaled = stopSignaled;
            _contentRepository = contentRepository;
            _descendantService = descendantService;
        }

        public override void Stop()
        {
            _stopSignaled = true;
        }

        public override string Execute()
        {
            var carouselPages = GetCarouselPages();
            var status = 0;

            foreach (var item in carouselPages)
            {
                if (item.StopPublish != null)
                {
                    _contentRepository.Delete(item.ContentLink, true, EPiServer.Security.AccessLevel.NoAccess);

                    status++;
                }
            }
            if (_stopSignaled)
            {
                return $"The job has been cancelled.";
            }
            return $"Unpublished carousel pages deleted: {status}";
        }

        private IEnumerable<CarouselPage> GetCarouselPages()
        {
            var contentReference = _siteDefinitionRepository.List().FirstOrDefault().StartPage;
            var startPage = _contentLoader.Get<StartPage>(contentReference);
            var carouselPages = _descendantService.GetDescendantsOfType<CarouselPage>(startPage).ToList();

            return carouselPages;
        }
    }
}
