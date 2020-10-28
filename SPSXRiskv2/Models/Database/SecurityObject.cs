using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSXRiskv2.Models.Database
{
    [Table("cfg_dl_seguridad_objeto")]
    public class SecurityObject
    {
        public string codigo { get; set; }
        public bool permitir { get; set; }
        public bool denegar { get; set; }
        public string permitidos { get; set; }
        public string denegados { get; set; }

    }
}
