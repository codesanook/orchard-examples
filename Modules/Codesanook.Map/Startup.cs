using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using Codesanook.Map.Drivers;
using Codesanook.Map.Models;
using OrchardCore.Modules;

namespace Codesanook.Map
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<MapPart>().UseDisplayDriver<MapPartDisplayDriver>();
            services.AddScoped<IDataMigration, Migrations>();
        }
    }
}