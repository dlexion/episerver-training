using EPiServer.Cms.TinyMce.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Business.Initialization
{
    [ModuleDependency(typeof(TinyMceInitialization))]
    public class CustomTinyMceInitialization : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Configure<TinyMceConfiguration>(config =>
            {
                config.For<ArticlePage>(t => t.MainBody)
                    .AddPlugin("code")
                    .Toolbar("undo redo | styleselect formatselect | bold italic | bullist numlist outdent indent | code")
                    .StyleFormats(
                        new { title = "bold-text", inline = "strong" },
                        new { title = "red-text", inline = "span", styles = new { color = "#ff0000" } },
                        new { title = "red-header", block = "h1", styles = new { color = "#ff0000" } }
                    )
                    .BlockFormats("paragraph=p;header1=h1;header2=h2;header3=h3");
            });
        }
    }
}