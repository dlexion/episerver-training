using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverSite.Models.Pages
{
    public abstract class BasePage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Robots",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Robots { get; set; }

        [Display(GroupName = SystemTabNames.Content)]
        public override CategoryList Category { get => base.Category; set => base.Category = value; }
    }
}