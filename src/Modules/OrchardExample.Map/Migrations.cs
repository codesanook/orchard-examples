using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data.Migration;
using OrchardExample.Map.Models;
using OrchardCore.ContentManagement;
using OrchardCore.Layers.Models;
using System.Threading.Tasks;
using OrchardCore.Html.Models;

namespace OrchardExample.Map
{
    public class Migrations : DataMigration
    {
        IContentDefinitionManager _contentDefinitionManager;
        private readonly IContentManager _contentManager;

        public Migrations(
            IContentDefinitionManager contentDefinitionManager,
            IContentManager contentManager
        )
        {
            _contentDefinitionManager = contentDefinitionManager;
            _contentManager = contentManager;
        }

        public async Task<int> CreateAsync()
        {
            _contentDefinitionManager.AlterPartDefinition(
                nameof(MapPart),
                part => part
                    .Attachable()
                    .WithDescription("Provide a map part for a content item")
            );

            const string widgetName = "MapWidget";
            _contentDefinitionManager.AlterTypeDefinition(
                widgetName,
                type => type
                    .WithPart(nameof(MapPart), part => part.WithPosition("0"))
                    .WithPart(nameof(HtmlBodyPart), part => part.WithEditor("Wysiwyg").WithPosition("1"))
                    .Stereotype("Widget")
            );

            // Create a new content item, not save to database yet.
            var contentItem = await _contentManager.NewAsync(widgetName);
            contentItem.DisplayText = widgetName;

            var mapPart = contentItem.As<MapPart>();
            mapPart.Latitude = -25.344;
            mapPart.Longitude = 131.036;

            var bodyPart = contentItem.As<HtmlBodyPart>();
            bodyPart.Html = "<h3>Some HTML content</h3>";

            var layerMetaData = contentItem.As<LayerMetadata>();
            layerMetaData = new LayerMetadata()
            {
                RenderTitle = false,
                Zone = "Content",
                Layer = "Homepage",
                Position = 1.0
            };

            // Attach Layer Meta data to a widget content item.
            contentItem.Weld(layerMetaData);

            // Save a content type to a database.
            // await _contentManager.CreateAsync(contentItem);
            //await _contentManager.PublishAsync(contentItem);
            await _contentManager.CreateAsync(contentItem, VersionOptions.Published);
            return 1;
        }
    }
}
