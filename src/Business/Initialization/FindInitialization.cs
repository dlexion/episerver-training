using EPiServer.Core;
using EPiServer.Find.Cms;
using EPiServer.Find.Cms.Conventions;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace EpiserverSite.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class FindInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            ContentIndexer.Instance.Conventions.ForInstancesOf<IContent>().ShouldIndex(_ => false);
            ContentIndexer.Instance.Conventions.ForInstancesOf<PageData>().ShouldIndex(ShouldIndexPage);
            ContentIndexer.Instance.Conventions.ForInstancesOf<MediaData>().ShouldIndex(ShouldIndexMedia);
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        private bool ShouldIndexPage(PageData page)
        {
            return page.CheckPublishedStatus(PagePublishedStatus.Published);
        }

        private bool ShouldIndexMedia(MediaData media)
        {
            return media.Status == VersionStatus.Published;
        }
    }
}