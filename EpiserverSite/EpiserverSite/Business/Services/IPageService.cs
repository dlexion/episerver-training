using EPiServer.Core;
using EpiserverSite.Models;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Business.Services
{
    public interface IPageService<T, TUpdateModel>
        where T : BasePage
        where TUpdateModel : IUpdateBasePageModel
    {
        bool TryCreate(ContentReference parent, TUpdateModel updateModel, out T newPage);

        bool TryUpdate(TUpdateModel updateModel, out T updatedPage);
    }
}