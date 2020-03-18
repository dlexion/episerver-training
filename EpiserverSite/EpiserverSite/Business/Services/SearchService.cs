using System.Collections.Generic;
using System.Web;
using EPiServer;
using EPiServer.Core;
using EPiServer.Search;
using EPiServer.Search.Queries;
using EPiServer.Search.Queries.Lucene;
using EPiServer.Security;
using EPiServer.ServiceLocation;

namespace EpiserverSite.Business.Services
{
    public class SearchService
    {
        private readonly SearchHandler _searchHandler;
        private readonly IContentLoader _contentLoader;

        public SearchService(SearchHandler searchHandler, IContentLoader contentLoader)
        {
            _searchHandler = searchHandler;
            _contentLoader = contentLoader;
        }

        public virtual bool IsActive
        {
            get { return ServiceLocator.Current.GetInstance<SearchOptions>().Active; }
        }

        public virtual SearchResults Search(string searchText, IEnumerable<ContentReference> searchRoots, HttpContextBase context, string languageBranch, int maxResults)
        {
            var query = CreateQuery(searchText, searchRoots, context, languageBranch);
            return _searchHandler.GetSearchResults(query, 1, maxResults);
        }

        private IQueryExpression CreateQuery(string searchText, IEnumerable<ContentReference> searchRoots, HttpContextBase context, string languageBranch)
        {
            //Main query which groups other queries. Each query added
            //must match in order for a page or file to be returned.
            var query = new GroupQuery(LuceneOperator.AND);

            //Add free text query to the main query
            query.QueryExpressions.Add(new FieldQuery(searchText));

            //Search for pages using the provided language
            var pageTypeQuery = new GroupQuery(LuceneOperator.AND);
            pageTypeQuery.QueryExpressions.Add(new ContentQuery<PageData>());
            pageTypeQuery.QueryExpressions.Add(new FieldQuery(languageBranch, Field.Culture));

            //Search for media without languages
            var contentTypeQuery = new GroupQuery(LuceneOperator.OR);
            contentTypeQuery.QueryExpressions.Add(new ContentQuery<MediaData>());
            contentTypeQuery.QueryExpressions.Add(pageTypeQuery);

            query.QueryExpressions.Add(contentTypeQuery);

            //Create and add query which groups type conditions using OR
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

        //public IEnumerable<string> FindFiles(string searchQuery, /*VersioningDirectory searchRoot,*/ int pagingNumber, int pagingSize)
        //{
        //    // The group query is needed to combine the different criteria
        //    GroupQuery groupQuery = new GroupQuery(LuceneOperator.AND);

        //    // The unified file query makes sure we only get hits that are files
        //    groupQuery.QueryExpressions.Add(new UnifiedFileQuery());

        //    // The field query contains the search phrase
        //    groupQuery.QueryExpressions.Add(new FieldQuery(searchQuery));

        //    // The virtual path query makes sure that we only get hits for children of the specified search root
        //    VirtualPathQuery pathQuery = new VirtualPathQuery();
        //    //pathQuery.AddDirectoryNodes(searchRoot);
        //    groupQuery.QueryExpressions.Add(pathQuery);

        //    // The access control list query will remove any files the user doesn't have read access to
        //    AccessControlListQuery aclQuery = new AccessControlListQuery();
        //    aclQuery.AddAclForUser(PrincipalInfo.Current, HttpContext.Current);
        //    groupQuery.QueryExpressions.Add(aclQuery);

        //    var searchHandler = ServiceLocator.Current.GetInstance<SearchHandler>();
        //    SearchResults results = searchHandler.GetSearchResults(groupQuery, pagingNumber, pagingSize);

        //    foreach (var hit in results.IndexResponseItems)
        //    {
        //        // Return the virtual path for each matching file.
        //        yield return hit.Uri.ToString();
        //    }
        //}
    }
}