using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPSXRiskv2.Models.Database
{
    [Table("Contratos")]
    public class Contratos
    {
        public string ctacodcia { get; set; }
        public string ctacod { get; set; }
        public string ctadescripcion { get; set; }
        public string ctacoddiv { get; set; }
        public string ctacodtli { get; set; }
        public string ctafechavalidez { get; set; }


    }
}
