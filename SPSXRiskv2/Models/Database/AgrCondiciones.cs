using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSXRiskv2.Models.Database
{
    [Table("AgrCondiciones")]
    public class AgrCondiciones
    {
        public string ACOGrupo { get; set; }
        public string ACONiv { get; set; }
        public string ACOCod { get; set; }
        public string ACODescripcion { get; set; }
        public string ACOTipo { get; set; }
    }
}
