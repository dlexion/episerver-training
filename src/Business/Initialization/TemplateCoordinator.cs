using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EpiserverSite.Models.Blocks;

namespace EpiserverSite.Business.Initialization
{
    [ServiceConfiguration(typeof(IViewTemplateModelRegistrator))]
    public class TemplateCoordinator : IViewTemplateModelRegistrator
    {
        public const string BlockFolder = "~/Views/Shared/Blocks/";

        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            viewTemplateModelRegistrator.Add(typeof(TeaserBlock), new TemplateModel
            {
                Name = "Teaser Block",
                AvailableWithoutTag = true,
                Inherit = false,
                Path = BlockPath("TeaserBlock.cshtml")
            });
        }

        public static string BlockPath(string fileName)
        {
            return BlockFolder + fileName;
        }
    }
}