using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "ArticlePage", GUID = "9e55ae33-5075-4901-8f94-418f9ea0e8c2", Description = "")]
    public class ArticlePage : BasePage
    {
        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual XhtmlString MainBody { get; set; }
    }
}