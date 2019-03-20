using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Composing;
using Umbraco.Core.Models;
using Umbraco.Core.Models.ContentEditing;
using Umbraco.Core.Models.Membership;

namespace Umbraco.Web.UI
{
    public class ApparareManifestJsonComponent : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.ContentApps().Append<ApparareManifestJson>();
        }
    }

    public class ApparareManifestJson : IContentAppFactory
    {
        public ContentApp GetContentAppFor(object source, IEnumerable<IReadOnlyUserGroup> userGroups)
        {
            if (userGroups.Any(x => x.Alias.ToLowerInvariant() == "admin") == false)
                return null;

            var apparareManifestJson = new ContentApp
            {
                Alias = "apparareManifestJson",
                Name = "Manifest",
                Icon = "icon-diploma-alt",
                View = "/App_Plugins/ApparareManifestJson/appararemanifestjson.html",
                Weight = 0
            };
            return apparareManifestJson;
        }
    }
}