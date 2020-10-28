using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSXRiskv2.Models.Database
{
    [Table("ConComunCSB")]
    public class ConComun
    {
        public string CCCCod { get; set; }
        public string CCCNiv { get; set; }
        public string CCCDescripcion { get; set; }

    }
}
