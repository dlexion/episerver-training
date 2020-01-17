using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EpiserverSite.Business.CreatePage;
using EpiserverSite.Business.UpdatePage;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;
using StructureMap;

namespace EpiserverSite.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class StructureMapSetUp : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.StructureMap().Configure(ConfigureContainer);
        }

        private static void ConfigureContainer(ConfigurationExpression container)
        {
            container.For(typeof(ICreatePageService<ArticlePage>)).Use(typeof(CreateArticlePageService));
            container.For(typeof(IUpdatePageService<AddUpdateArticlePageViewModel, ArticlePage>)).Use(typeof(UpdateArticlePageService));
        }
    }
}