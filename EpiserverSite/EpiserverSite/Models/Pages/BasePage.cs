using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "Base Page", GUID = "29161a88-5823-453c-b4f8-c8826d27fee8", Description = "")]
    public abstract class BasePage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Robots",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Robots { get; set; }

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