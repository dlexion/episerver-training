using EPiServer.Cms.Shell;
using EPiServer.Core;
using EPiServer.Find;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Business.Extensions
{
    public static class FilterForPageAndMedia
    {
        public static ITypeSearch<TSource> FilterForPagesAndMedia<TSource>(this ITypeSearch<TSource> search, string language)
            where TSource : class
        {
            var filterBuilder = new FilterBuilder<TSource>(search.Client);

            filterBuilder = filterBuilder.And(x => (x.MatchTypeHierarchy(typeof(BasePage))
                                                   & ((IContent)x).LanguageBranch().Match(language)));

            filterBuilder = filterBuilder.Or(x => x.MatchTypeHierarchy(typeof(MediaData)));

            return search.Filter(filterBuilder);
        }
    }
}