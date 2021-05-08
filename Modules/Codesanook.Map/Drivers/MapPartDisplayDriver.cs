using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using Codesanook.Map.Models;
using Codesanook.Map.Settings;
using Codesanook.Map.ViewModels;

namespace Codesanook.Map.Drivers
{
    public class MapPartDisplayDriver : ContentPartDisplayDriver<MapPart>
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public MapPartDisplayDriver(IContentDefinitionManager contentDefinitionManager) =>
            _contentDefinitionManager = contentDefinitionManager;

        public override IDisplayResult Display(MapPart part, BuildPartDisplayContext context)
        {
            return Initialize<MapPartViewModel>(
                    GetDisplayShapeType(context),
                    m => BuildViewModel(m, part)
                )
                .Location("Detail", "Content:10")
                .Location("Summary", "Content:10");
        }

        public override IDisplayResult Edit(MapPart part, BuildPartEditorContext context)
        {
            return Initialize<MapPartViewModel>(
                GetEditorShapeType(context), 
                m => BuildViewModel(m, part)
            );
        }

        public override async Task<IDisplayResult> UpdateAsync(MapPart model, IUpdateModel updater)
        {
            await updater.TryUpdateModelAsync(
                model, 
                Prefix, 
                t => t.Latitude,
                t => t.Longitude
            );
            return Edit(model);
        }

        private void BuildViewModel(MapPartViewModel model, MapPart part)
        {
            model.Latitude = part.Latitude;
            model.Longitude = part.Longitude;
            model.MapPart = part;
            model.ContentItem = part.ContentItem;
        }
    }
}
