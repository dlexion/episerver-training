using System.Linq;
using System.Reflection;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Shell;
using EpiserverSite.Business.Interfaces;

namespace EpiserverSite.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class NewsPageUIDescriptorModule : IInitializableModule
    {
        private const string categoryIconClass = "epi-iconCategory";

        public void Initialize(InitializationEngine context)
        {
            SetIcons(context.Locate.Advanced.GetInstance<UIDescriptorRegistry>());
        }

        private static void SetIcons(UIDescriptorRegistry uiDescriptorRegistry)
        {
            var instances =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => t.GetInterfaces().Contains(typeof(IUseCategoryTreeIcon)));

            var descriptors = uiDescriptorRegistry.UIDescriptors.ToList();

            foreach (var instance in instances)
            {
                var descriptor = descriptors.FirstOrDefault(x => x.ForType.FullName == instance.ToString());

                if (descriptor != null)
                    descriptor.IconClass = categoryIconClass;

            }
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}