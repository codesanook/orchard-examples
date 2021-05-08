using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;
using Codesanook.Map.Models;

namespace Codesanook.Map.ViewModels
{
    public class MapPartViewModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [BindNever]
        public ContentItem ContentItem { get; set; }

        [BindNever]
        public MapPart MapPart { get; set; }
    }
}