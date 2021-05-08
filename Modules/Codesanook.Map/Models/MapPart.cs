using OrchardCore.ContentManagement;

namespace Codesanook.Map.Models
{
    public class MapPart : ContentPart
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}