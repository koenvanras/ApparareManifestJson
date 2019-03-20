using ManifestJsonPlugin.Controllers;
using ManifestJsonPlugin.Models.Rdbms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using Umbraco.Core.Scoping;
using Umbraco.Web;
using Umbraco.Core;
using ManifestJsonPlugin.Models.Custom;
using Umbraco.Core.Composing;

namespace ManifestJsonPlugin.Handlers.HttpHandlers
{
    public class ManifestJsonHandler : IHttpHandler
    {
        public bool IsReusable => false;
        
        public void ProcessRequest(HttpContext context)
        {
            ManifestRoot manifest = new ManifestRoot();

            using (var scope = Current.ScopeProvider.CreateScope())
            {
               var result = scope.Database.Query<ManifestJsonDto>().Where(x => x.NodeId == 1053).FirstOrDefault();

                scope.Complete();

                manifest.name = result.Name;
                manifest.short_name = result.ShortName;
                manifest.description = result.Description;
                manifest.theme_color = result.ThemeColor;
                manifest.background_color = result.BackgroundColor;
                manifest.version = result.Version;

                string manifestJson = JToken.Parse(JsonConvert.SerializeObject(manifest)).ToString(Formatting.Indented);

                context.Response.ContentType = "application/json";
                if (manifestJson != null)
                {
                    context.Response.Write(manifestJson);
                }
            }
        }
    }
}
