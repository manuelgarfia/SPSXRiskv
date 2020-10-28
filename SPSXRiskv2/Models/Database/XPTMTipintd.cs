using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPSXRiskv2.Models.Database
{
    [Table("xptm_tipintd")]
    public class XPTMTipintd
    {
        [Key]
        public int linid { get; set; }
        public string codigo { get; set; }
        public string descri { get; set; }
        public int periodicidad { get; set; }
        public string user_created { get; set; }
        public DateTime date_created { get; set; }
        public string user_updated { get; set; }
        public DateTime date_updated { get; set; }


    }
}
