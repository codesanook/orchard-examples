using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data.Migration;
using Codesanook.Map.Models;

namespace Codesanook.Map
{
    public class Migrations : DataMigration
    {
        IContentDefinitionManager _contentDefinitionManager;
        public Migrations(IContentDefinitionManager contentDefinitionManager) =>
          _contentDefinitionManager = contentDefinitionManager;

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition(
                nameof(MapPart),
                part => part
                    .Attachable()
                    .WithDescription("Provide a map part for a content item")
            );

            return 1;
        }
    }
}