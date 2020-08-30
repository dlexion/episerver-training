using System.Collections.Generic;

namespace EpiserverSite.Models
{
    public class MenuItem
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public IList<MenuItem> SubItems { get; set; }

        public MenuItem()
        {
            SubItems = new List<MenuItem>();
        }
    }
}