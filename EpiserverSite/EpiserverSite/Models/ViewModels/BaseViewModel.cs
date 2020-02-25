using EPiServer.Core;

namespace EpiserverSite.Models.ViewModels
{
    public class BaseViewModel<T> : IPageViewModel<T> where T : PageData
    {
        public BaseViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }

        public T CurrentPage { get; }

        public LayoutViewModel Layout { get; set; }
    }
}