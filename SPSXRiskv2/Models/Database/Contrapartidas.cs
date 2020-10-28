using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace SPSXRiskv2.Models.Entities
{
    [Table("ContrPart")]
    public class Contrapartidas
    {
        public string CPTGrupo { get; set; }
        public string CPTCod { get; set; }
        public string CPTDescripcion { get; set; }
    }
}
