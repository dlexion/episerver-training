using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite.Models
{
    public interface IUpdateModel
    {
        int CurrentPageId { get; set; }
    }
}