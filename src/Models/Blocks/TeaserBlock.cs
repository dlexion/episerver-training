using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EpiserverSite.Business.Interfaces;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "Teaser Block", GUID = "8d17c72e-37d1-4433-8dc7-3312ff3e25d6", Description = "")]
    public class TeaserBlock : BlockData, IPreviewableBlock
    {
        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Description",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string Description { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Image",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual ContentReference Image { get; set; }

    }
}