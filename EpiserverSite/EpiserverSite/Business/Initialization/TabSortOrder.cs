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
        private Injected<ITabDefinitionRepository> _tabDefinitionRepository;

        public void Initialize(InitializationEngine context)
        {
            RegisterTabs();
        }

        private void RegisterTabs()
        {
            AddTabToList(_tabDefinitionRepository.Service,
                new TabDefinition() { Name = "SEO", RequiredAccess = AccessLevel.Edit, SortIndex = 28 });

            AddTabToList(_tabDefinitionRepository.Service,
                new TabDefinition() { Name = "Content", RequiredAccess = AccessLevel.Edit, SortIndex = 10000 });
        }

        private void AddTabToList(ITabDefinitionRepository tabDefinitionRepository, TabDefinition definition)
        {
            TabDefinition existingTab = GetExistingTabDefinition(tabDefinitionRepository, definition);

            if (existingTab != null)
            {
                definition.ID = existingTab.ID;
            }

            tabDefinitionRepository.Save(definition);
        }

        private static TabDefinition GetExistingTabDefinition(ITabDefinitionRepository tabDefinitionRepository, TabDefinition definition)
        {
            return tabDefinitionRepository.List()
                   .FirstOrDefault(t => t.Name.Equals(definition.Name, StringComparison.InvariantCultureIgnoreCase));
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}