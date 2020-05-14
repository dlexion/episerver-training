using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiServer.Search;
using EPiServer.Search.Queries;
using EPiServer.Search.Queries.Lucene;
using EPiServer.Security;
using EPiServer.Web.Routing;
using EpiserverSite.Models;

namespace EpiserverSite.Business.Services
{
    public class SearchService
    {
        private readonly SearchHandler _searchHandler;
        private readonly ContentSearchHandler _contentSearchHandler;
        private readonly IUrlResolver _urlResolver;

        public SearchService(
            SearchHandler searchHandler,
            ContentSearchHandler contentSearchHandler,
            IUrlResolver urlResolver)
        {
            _searchHandler = searchHandler;
            _contentSearchHandler = contentSearchHandler;
            _urlResolver = urlResolver;
        }

        public IList<SearchResult> Search(string searchText, IEnumerable<ContentReference> searchRoots, HttpContextBase context, string languageBranch, int maxResults)
        {
            var query = CreateQuery(searchText, searchRoots, context, languageBranch);
            var result = _searchHandler
                .GetSearchResults(query, 1, maxResults).IndexResponseItems
                .Select(x => new SearchResult
                {
                    Name = x.Title,
                    Url = GetUrl(x),
                })
                .ToList();

            return result;
        }

        private IQueryExpression CreateQuery(string searchText, IEnumerable<ContentReference> searchRoots, HttpContextBase context, string languageBranch)
        {
            var query = new GroupQuery(LuceneOperator.AND);

            query.QueryExpressions.Add(new FieldQuery(searchText));

            var pageTypeQuery = new GroupQuery(LuceneOperator.AND);
            pageTypeQuery.QueryExpressions.Add(new ContentQuery<PageData>());
            pageTypeQuery.QueryExpressions.Add(new FieldQuery(languageBranch, Field.Culture));

            var contentTypeQuery = new GroupQuery(LuceneOperator.OR);
            contentTypeQuery.QueryExpressions.Add(new ContentQuery<MediaData>());
            contentTypeQuery.QueryExpressions.Add(pageTypeQuery);

            query.QueryExpressions.Add(contentTypeQuery);

            var typeQueries = new GroupQuery(LuceneOperator.OR);
            query.QueryExpressions.Add(typeQueries);

            foreach (var root in searchRoots)
            {
                var contentRootQuery = new VirtualPathQuery();
                contentRootQuery.AddContentNodes(root);
                typeQueries.QueryExpressions.Add(contentRootQuery);
            }

            var accessRightsQuery = new AccessControlListQuery();
            accessRightsQuery.AddAclForUser(PrincipalInfo.Current, context);
            query.QueryExpressions.Add(accessRightsQuery);

            return query;
        }

        private string GetUrl(IndexResponseItem item)
        {
            return _urlResolver.GetUrl(_contentSearchHandler.GetContent<IContent>(item).ContentLink);
        }
    }
}