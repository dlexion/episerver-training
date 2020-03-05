using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "Content Page", GUID = "d68ffc79-0893-4aa6-96c8-0417ab981386", Description = "")]
    public class ContentPage : BaseContentPage
    {
        [Display(
            Name = "Page Title",
            Description = "Page Title",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        [CultureSpecific]
        public virtual string PageTitle { get; set; }

        [Display(
            Name = "Main Content Area",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual ContentArea MainContentArea { get; set; }
    }
}