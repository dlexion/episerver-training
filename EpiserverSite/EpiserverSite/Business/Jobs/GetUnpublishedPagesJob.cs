using System;
using System.Linq;
using System.Text;
using EPiServer;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;

namespace EpiserverSite.Business.Jobs
{
    [ScheduledPlugIn(DisplayName = "List of unpublished pages")]
    public class GetUnpublishedPagesJob : ScheduledJobBase
    {
        private readonly IPageCriteriaQueryService _pageCriteriaQueryService;

        public GetUnpublishedPagesJob(IPageCriteriaQueryService pageCriteriaQueryService)
        {
            _pageCriteriaQueryService = pageCriteriaQueryService;
        }

        public override string Execute()
        {
            var unpublishedPages = DataFactory.Instance.GetDescendents(ContentReference.RootPage)
                .Select(DataFactory.Instance.Get<PageData>)
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
