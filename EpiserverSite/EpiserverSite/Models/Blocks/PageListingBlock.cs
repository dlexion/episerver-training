using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "Page Listing Block", GUID = "043c09ae-6f5c-4254-8ef7-7cb3b44de5dc", Description = "")]
    public class PageListingBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Root",
            Description = "",
            GroupName = "Navigation",
            Order = 100)]
        public virtual ContentReference Root { get; set; }
    }
}