using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer.Web.Mvc.Html;

namespace EpiserverSite.Business
{
    [ServiceConfiguration(typeof(ContentAreaRenderer))]
    public class MyContentAreaRenderer : ContentAreaRenderer
    {
        private readonly IContentAreaLoader _contentAreaLoader;
        private readonly IContentRenderer _contentRenderer;
        private readonly IContentAreaItemAttributeAssembler _attributeAssembler;

        public MyContentAreaRenderer(
            IContentAreaLoader contentAreaLoader,
            IContentRenderer contentRenderer,
            IContentAreaItemAttributeAssembler attributeAssembler)
        {
            _contentAreaLoader = contentAreaLoader;
            _contentRenderer = contentRenderer;
            _attributeAssembler = attributeAssembler;
        }

        protected override void RenderContentAreaItem(
            HtmlHelper htmlHelper,
            ContentAreaItem contentAreaItem,
            string templateTag,
            string htmlTag,
            string cssClass)
        {
            var renderSettings = new Dictionary<string, object>
            {
                ["childrencustomtagname"] = htmlTag,
                ["childrencssclass"] = cssClass,
                ["tag"] = templateTag
            };

            renderSettings = contentAreaItem.RenderSettings.Concat(
                from r in renderSettings
                where !contentAreaItem.RenderSettings.ContainsKey(r.Key)
                select r).ToDictionary(r => r.Key, r => r.Value);

            htmlHelper.ViewBag.RenderSettings = renderSettings;
            var content = _contentAreaLoader.Get(contentAreaItem);
            if (content == null)
            {
                return;
            }

            bool isInEditMode = IsInEditMode(htmlHelper);

            using (new ContentAreaContext(htmlHelper.ViewContext.RequestContext, content.ContentLink))
            {
                var templateModel = ResolveTemplate(htmlHelper, content, templateTag);
                if (templateModel != null || isInEditMode)
                {
                    bool renderWrappingElement = ShouldRenderWrappingElementForContentAreaItem(htmlHelper);

                    if (isInEditMode || renderWrappingElement)
                    {
                        var tagBuilder = new TagBuilder(htmlTag);
                        AddNonEmptyCssClass(tagBuilder, cssClass);
                        tagBuilder.MergeAttributes(_attributeAssembler.GetAttributes(
                            contentAreaItem,
                            isInEditMode,
                            templateModel != null));
                        BeforeRenderContentAreaItemStartTag(tagBuilder, contentAreaItem);
                        htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));
                        htmlHelper.RenderContentData(content, true, templateModel, _contentRenderer);
                        htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.EndTag));
                    }
                    else
                    {
                        htmlHelper.RenderContentData(content, true, templateModel, _contentRenderer);
                    }
                }
            }
        }

        private bool ShouldRenderWrappingElementForContentAreaItem(HtmlHelper htmlHelper)
        {
            bool? item = (bool?)htmlHelper.ViewContext.ViewData["haschildcontainers"];
            return item.HasValue && item.Value;
        }
    }
}