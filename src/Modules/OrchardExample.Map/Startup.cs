using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardExample.Map.Drivers;
using OrchardExample.Map.Models;
using OrchardCore.Modules;

namespace OrchardExample.Map
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
