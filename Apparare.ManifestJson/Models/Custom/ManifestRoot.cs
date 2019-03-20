using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApparareManifestJson.Models.Custom
{
    public class ManifestRoot
    {
        public string name { get; set; }
        public string short_name { get; set; }
        public string description { get; set; }
        public int manifest_version => 2;
        public string version { get; set; }
        public List<ManifestIcon> icons { get; set; }
        public string theme_color { get; set; }
        public string background_color { get; set; }
        public string display => "standalone";
        public string start_url => ".";
    }
}
