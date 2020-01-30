using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Business.Helpers
{
    public interface ILayoutHelper
    {
        LayoutViewModel GenerateLayout();
    }
}