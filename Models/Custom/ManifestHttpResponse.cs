using ManifestJsonPlugin.Models.Rdbms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManifestJsonPlugin.Models.Custom
{
    public class ManifestHttpResponse
    {
        public string status { get; set; }
        public ManifestJsonDto result { get; set; }
    }
}
