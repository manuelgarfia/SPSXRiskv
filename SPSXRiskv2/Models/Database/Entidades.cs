using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSXRiskv2.Models.Database
{
    [Table("Entidad")]
    public class Entidades
    {
        public string ENTCod { get; set; }
        public string ENTDescripcion { get; set; }

    }
}
