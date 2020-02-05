using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EpiserverSite.Models.Blocks;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "Start Page", GUID = "51c59175-13e2-4835-b3b7-d26869c7461c", Description = "")]
    public class StartPage : BasePage
    {
        [CultureSpecific]
        [Display(
            Name = "Content",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual ContentArea Content { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Right Align Content",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual ContentArea RightAlignContext { get; set; }

        [Display(
            Name = "Teaser Block",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 60)]
        public virtual TeaserBlock TeaserBlock { get; set; }
    }
}