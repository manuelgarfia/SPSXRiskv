using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSXRiskv2.Models.Database
{
    [Table("Certezas")]
    public class Certezas
    {
        public string grado { get; set; }
        public string descripcion { get; set; }

    }
}
