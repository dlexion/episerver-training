using System.Collections.Generic;

namespace EpiserverSite.Models.ViewModels
{
    public class LayoutViewModel
    {
        public LayoutViewModel()
        {
            MenuItems = new List<MenuItem>();
        }

        public IList<MenuItem> MenuItems { get; set; }
    }
}