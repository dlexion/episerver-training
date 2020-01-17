using EPiServer.Core;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Business.CreatePage
{
    public interface ICreatePageService<T> where T : BasePage
    {
        bool TryCreate(string pageName, ContentReference parent, out T newPage);
    }
}