using EpiserverSite.Business.UpdatePage;
using EpiserverSite.Models;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Business
{
    public abstract class UpdatePageService<TUpdateModel, TUpdatedPage>
        : IUpdatePageService<TUpdateModel, TUpdatedPage>
        where TUpdateModel : IUpdateModel
        where TUpdatedPage : BasePage
    {
        public abstract bool TryUpdate(TUpdateModel updateModel, out TUpdatedPage updatedPage);
    }
}