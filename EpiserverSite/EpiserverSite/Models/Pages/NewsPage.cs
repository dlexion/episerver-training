using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EpiserverSite.Business.Interfaces;

namespace EpiserverSite.Models.Pages
{
    [AvailableContentTypes(Include = new[] { typeof(NewsItemPage) })]
    [ContentType(DisplayName = "News Page", GUID = "8ffdf267-72ef-4375-8379-e41fa90a4a4a", Description = "")]
    public class NewsPage : PageWithNavigation, IUseCategoryTreeIcon
    {
        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Title { get; set; }
    }
}