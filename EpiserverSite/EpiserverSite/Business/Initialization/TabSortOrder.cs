using EPiServer.DataAbstraction;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using System;
using System.Linq;

namespace EpiserverSite.Business.Initialization
{
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class TabSortOrder : IInitializableModule
    {
        private readonly Injected<ITabDefinitionRepository> _tabDefinitionRepository;

        public void Initialize(InitializationEngine context)
        {
            RegisterTabs();
        }

        private void RegisterTabs()
        {
            AddTabToList(new TabDefinition() { Name = "SEO", RequiredAccess = AccessLevel.Edit, SortIndex = 28 });

            AddTabToList(new TabDefinition() { Name = "Content", RequiredAccess = AccessLevel.Edit, SortIndex = 10000 });
        }

        private void AddTabToList(TabDefinition definition)
        {
            var existingTab = GetExistingTabDefinition(definition);

            if (existingTab != null)
            {
                definition.ID = existingTab.ID;
            }

            _tabDefinitionRepository.Service.Save(definition);
        }

        private TabDefinition GetExistingTabDefinition(TabDefinition definition)
        {
            return _tabDefinitionRepository.Service.List()
                   .FirstOrDefault(t => t.Name.Equals(definition.Name, StringComparison.InvariantCultureIgnoreCase));
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}