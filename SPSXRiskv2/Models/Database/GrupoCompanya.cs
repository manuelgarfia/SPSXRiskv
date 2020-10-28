using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSXRiskv2.Models.Database
{
    [Table("zpos_grupocompanyia")]
    public class GrupoCompanya 
    {
        public string GRCGrupo { get; set; }

        public string GRCNiv { get; set; }
        public string GRCCodGRT { get; set; }
        public string GRCCodCIA { get; set; }
    }
}
