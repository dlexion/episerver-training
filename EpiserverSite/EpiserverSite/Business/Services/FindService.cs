﻿using System.Collections.Generic;
using System.Linq;
using EPiServer.Core;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Web.Routing;
using EpiserverSite.Models;

namespace EpiserverSite.Business.Services
{
    public class FindService
    {
        private readonly IClient _client;
        private readonly IUrlResolver _urlResolver;

        public FindService(IClient client, IUrlResolver urlResolver)
        {
            _client = client;
            _urlResolver = urlResolver;
        }

        public IEnumerable<SearchResult> Search(string query, string languageBranch, int maxResults)
        {
            var foundPages = _client.Search<IContent>()
                .For(query)
                .InLanguageBranch(languageBranch)
                .FilterForVisitor()
                .Take(maxResults)
                .GetContentResult();

            var result = foundPages.Items
                    .Select(x => new SearchResult
                    {
                        Name = x.Name,
                        Url = _urlResolver.GetUrl(x.ContentLink),
                    });

            return result;
        }
    }
}