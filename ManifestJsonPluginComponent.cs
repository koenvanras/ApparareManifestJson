using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Composing;
using Umbraco.Core.Models;
using Umbraco.Core.Models.ContentEditing;
using Umbraco.Core.Models.Membership;

namespace Umbraco.Web.UI
{
    public class ManifestJsonPluginComponent : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.ContentApps().Append<ManifestJsonPlugin>();
        }
    }

    public class ManifestJsonPlugin : IContentAppFactory
    {
        public ContentApp GetContentAppFor(object source, IEnumerable<IReadOnlyUserGroup> userGroups)
        {
            if (userGroups.Any(x => x.Alias.ToLowerInvariant() == "admin") == false)
                return null;

            var manifestJsonPlugin = new ContentApp
            {
                Alias = "manifestJsonPlugin",
                Name = "Manifest",
                Icon = "icon-diploma-alt",
                View = "/App_Plugins/ManifestJsonPlugin/manifestjsonplugin.html",
                Weight = 0
            };
            return manifestJsonPlugin;
        }
    }
}