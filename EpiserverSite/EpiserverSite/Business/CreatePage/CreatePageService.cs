using EPiServer.Core;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Business.CreatePage
{
    public abstract class CreatePageService<T> : ICreatePageService<T> where T : BasePage
    {
        public abstract bool TryCreate(string pageName, ContentReference parent, out T newPage);
    }
}