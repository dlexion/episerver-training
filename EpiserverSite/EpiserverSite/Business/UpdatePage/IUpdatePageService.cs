using EpiserverSite.Models;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Business.UpdatePage
{
    public interface IUpdatePageService<in TUpdateModel, TUpdatedPage>
        where TUpdateModel : IUpdateModel
        where TUpdatedPage : BasePage
    {
        bool TryUpdate(TUpdateModel updateModel, out TUpdatedPage updatedPage);
    }
}
