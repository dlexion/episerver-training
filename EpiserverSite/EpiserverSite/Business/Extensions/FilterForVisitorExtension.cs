using System;
using EPiServer.Core;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Helpers;

namespace EpiserverSite.Business.Extensions
{
    public static class FilterForVisitorExtension
    {
        public static ITypeSearch<TSource> CustomFilterForVisitor<TSource>(this ITypeSearch<TSource> search)
            where TSource : class
        {
            var now = DateTime.Now.NormalizeToMinutes();
            var filterBuilder = new FilterBuilder<TSource>(search.Client);

            filterBuilder = filterBuilder.And(x => !x.MatchTypeHierarchy(typeof(IContent))
                                                   | ((IContent)x).IsDeleted.Match(false));

            filterBuilder = filterBuilder.And(x => !x.MatchTypeHierarchy(typeof(IVersionable))
                                                   | (((IVersionable)x).Status.Match(VersionStatus.Published)
                                                   & !((IVersionable)x).StopPublish.Exists()) | ((IVersionable)x).StopPublish.GreaterThan(now)
                                                   & ((IVersionable)x).StartPublishedNormalized().InRange(DateTime.MinValue, now, true, true));

            return search.Filter(filterBuilder);
        }
    }
}