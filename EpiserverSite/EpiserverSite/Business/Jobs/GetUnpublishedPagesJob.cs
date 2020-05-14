using System;
using System.Linq;
using System.Text;
using EPiServer;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Business.Jobs
{
    [ScheduledPlugIn(DisplayName = "List of unpublished pages")]
    public class GetUnpublishedPagesJob : ScheduledJobBase
    {
        private readonly IContentLoader _contentLoader;

        public GetUnpublishedPagesJob(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public override string Execute()
        {
            var descendents = _contentLoader.GetDescendents(ContentReference.RootPage);
            var unpublishedPages = _contentLoader
                .GetItems(descendents, new LoaderOptions { LanguageLoaderOption.FallbackWithMaster() })
                .OfType<BasePage>()
                .Where(x => x.IsPendingPublish && !x.IsDeleted)
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append(unpublishedPages.Count).AppendLine(" unpublished page(s) was(were) found.");

            if (unpublishedPages.Count > 0)
            {
                sb.AppendLine("List of unpublished pages:");
                foreach (var unpublishedPage in unpublishedPages)
                {
                    sb.Append(" - ").AppendLine(unpublishedPage.PageName);
                }
            }

            return sb.ToString().Replace(Environment.NewLine, "<br/>"); ;
        }
    }
}
