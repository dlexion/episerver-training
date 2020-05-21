using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPiServer;
using EPiServer.Cms.Shell;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Business.Jobs
{
    [ScheduledPlugIn(
        DisplayName = "",
        Description = "",
        DefaultEnabled = true,
        IntervalType = ScheduledIntervalType.Months,
        IntervalLength = 1,
        InitialTime = "2:0:0",
        LanguagePath = "/plugin/job/UnpublishedPages")]
    public class GetUnpublishedPagesJob : ScheduledJobBase
    {
        private readonly IContentRepository _contentRepository;
        private bool _stopSignaled;

        public GetUnpublishedPagesJob(IContentRepository contentRepository)
        {
            IsStoppable = true;
            _contentRepository = contentRepository;
        }

        public override string Execute()
        {
            var unpublishedPages = GetUnpublishedPages();

            StringBuilder sb = new StringBuilder();
            sb.Append(unpublishedPages.Count).AppendLine(" unpublished page(s) was(were) found.");

            if (unpublishedPages.Count > 0)
            {
                sb.AppendLine("List of unpublished pages:");
                foreach (var unpublishedPage in unpublishedPages)
                {
                    if (_stopSignaled)
                    {
                        sb.AppendLine("The job was stopped.");
                        break;
                    }

                    sb.Append(" - ").AppendLine(unpublishedPage.PageName + "; language: " + unpublishedPage.LanguageBranch());
                }
            }

            return sb.ToString().Replace(Environment.NewLine, "<br/>");
        }

        public override void Stop()
        {
            _stopSignaled = true;
        }

        private List<BasePage> GetUnpublishedPages()
        {
            var unpublishedPages = new List<BasePage>();

            foreach (var descendent in _contentRepository.GetDescendents(ContentReference.StartPage))
            {
                foreach (var content in _contentRepository.GetLanguageBranches<IContent>(descendent).ToList())
                {
                    if (content is BasePage page && page.IsPendingPublish && !page.IsDeleted)
                    {
                        unpublishedPages.Add(page);
                    }
                }
            }

            return unpublishedPages;
        }
    }
}
