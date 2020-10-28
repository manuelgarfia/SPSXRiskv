using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SPSXRiskv2.Models.Database
{
    [Table("xptm_escenario_detalle")]
    public class XPTMEscenarioDetalle
    {
        [Key]
        public int linid { get; set; }
        public DateTime fecha { get; set; }
        public string codtipoint { get; set; }
        public string escenario { get; set; }
        public decimal pctinteres { get; set; }
        public string user_created { get; set; }
        public DateTime date_created { get; set; }
        public string user_updated { get; set; }
        public DateTime date_updated { get; set; }
    }
}