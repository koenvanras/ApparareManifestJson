using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace ApparareManifestJson.Models.Rdbms
{
    [TableName("ApparareManifestJson_Domains")]
    [PrimaryKey("id")]
    [ExplicitColumns]
    public class ManifestJsonDto
    {
        [Column("Id")]
        [PrimaryKeyColumn()]
        public int Id { get; set; }

        [Column("NodeId")]
        public int NodeId { get; set; }

        [Column("Version")]
        public string Version { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("ShortName")]
        public string ShortName { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("ThemeColor")]
        public string ThemeColor { get; set; }

        [Column("BackgroundColor")]
        public string BackgroundColor { get; set; }
    }
}
