using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverSite.Models.Pages
{
    public abstract class BaseContentPage : BasePage
    {
        [CultureSpecific]
        [Display(
            Name = "Open Graph Title",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string OpenGraphTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Open Graph Media",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual ContentReference OpenGraphMedia { get; set; }
    }
}