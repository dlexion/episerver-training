using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "Article Page", GUID = "9e55ae33-5075-4901-8f94-418f9ea0e8c2", Description = "")]
    public class ArticlePage : BaseContentPage
    {
        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual XhtmlString MainBody { get; set; }
    }
}