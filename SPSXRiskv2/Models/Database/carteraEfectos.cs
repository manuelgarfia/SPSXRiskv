using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPSXRiskv2.Models.Database
{
    
    public class carteraEfectos
    {
       
        public string codigocliente { get; set; }
       
        public string nombrecliente { get; set; }
        public int Num { get; set; }
        public double? importe { get; set; }

     
    }
}
