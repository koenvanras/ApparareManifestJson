using ManifestJsonPlugin.Models;
using ManifestJsonPlugin.Models.Rdbms;
using NPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Umbraco.Core.Scoping;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;
using Umbraco.Core.Persistence;
using System.Collections;
using System.IO;
using System.Xml;
using ManifestJsonPlugin.Models.Custom;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ManifestJsonPlugin.Controllers
{
    [PluginController("ManifestJsonPlugin")]
    public class BackofficeApiController : UmbracoAuthorizedJsonController
    {
        private readonly IScopeProvider _scopeProvider;

        public BackofficeApiController(IScopeProvider scopeProvider)
        {
            _scopeProvider = scopeProvider;
        }

        [HttpGet]
        public IHttpActionResult GetDbData(int nodeId)
        {
            ManifestJsonDto dbResult = GetManifestDbData(nodeId);

            if (dbResult != null)
            {
                return Ok(dbResult);
            }

            return BadRequest(string.Format("Failed to get database data for NodeId: {0}", nodeId));
        }

        [HttpPost]
        public IHttpActionResult CreateDbData(ManifestJsonDto manifest)
        {
            ManifestJsonDto dbResult = GetManifestDbData(manifest.NodeId);
            ManifestHttpResponse mResponse = new ManifestHttpResponse();
            var changed = false;

            using (var scope = _scopeProvider.CreateScope())
            {
                if (dbResult != null)
                {
                    if (manifest.Name != dbResult.Name)
                    {
                        dbResult.Name = manifest.Name;
                        changed = true;
                    }

                    if (manifest.ShortName != dbResult.ShortName)
                    {
                        dbResult.ShortName = manifest.ShortName;
                        changed = true;
                    }

                    if (manifest.Description != dbResult.Description)
                    {
                        dbResult.Description = manifest.Description;
                        changed = true;
                    }

                    if (manifest.BackgroundColor != dbResult.BackgroundColor)
                    {
                        dbResult.BackgroundColor = manifest.BackgroundColor;
                        changed = true;
                    }

                    if (manifest.ThemeColor != dbResult.ThemeColor)
                    {
                        dbResult.ThemeColor = manifest.ThemeColor;
                        changed = true;
                    }

                    if (changed)
                    {
                        dbResult.Version = (Convert.ToDecimal(dbResult.Version) + 0.1m).ToString();
                        scope.Database.Update(dbResult);
                        scope.Complete();

                        mResponse.status = "data_updated";
                        mResponse.result = dbResult;

                        return Ok(mResponse);
                    }

                    mResponse.status = "data_unchanged";
                    mResponse.result = dbResult;

                    return Ok(mResponse);
                }
                else
                {
                    dbResult = new ManifestJsonDto();
                    dbResult.NodeId = manifest.NodeId;
                    dbResult.Version = "0.1";

                    if (manifest.Name != dbResult.Name)
                        dbResult.Name = manifest.Name;
                    if (manifest.ShortName != dbResult.ShortName)
                        dbResult.ShortName = manifest.ShortName;
                    if (manifest.Description != dbResult.Description)
                        dbResult.Description = manifest.Description;
                    if (manifest.BackgroundColor != dbResult.BackgroundColor)
                        dbResult.BackgroundColor = manifest.BackgroundColor;
                    if (manifest.ThemeColor != dbResult.ThemeColor)
                        dbResult.ThemeColor = manifest.ThemeColor;
                    
                    scope.Database.Insert<ManifestJsonDto>(dbResult);
                    scope.Complete();

                    mResponse.status = "data_created";
                    mResponse.result = dbResult;

                    return Ok(mResponse);
                }
            }
        }

        public ManifestJsonDto GetManifestDbData(int m)
        {
            ManifestJsonDto result;

            using (var scope = _scopeProvider.CreateScope())
            {
                result = scope.Database.Query<ManifestJsonDto>().Where(x => x.NodeId == m).FirstOrDefault();

                scope.Complete();
            }

            return result;
        }
    }
}
