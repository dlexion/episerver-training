using System.ComponentModel.DataAnnotations;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors.SelectionFactories;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "Page List Block", GUID = "35b3536a-f04b-432d-84a7-4f43ecf4b58e", Description = "")]
    public class PageListBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Page Type",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [SelectOne(SelectionFactoryType = typeof(PageTypeSelectionFactory))]
        public virtual string PageType { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Root",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual ContentReference Root { get; set; }
    }
}