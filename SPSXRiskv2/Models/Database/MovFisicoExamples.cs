using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SPSXRiskv2.Models.Database
{
    [Table("MovFisico_Examples")]
    public class MovFisicoExamples
    {
        public string MVFCodCIA { get; set; }
        public DateTime MVFFechOperac { get; set; }
        public string MVFDescripcion { get; set; }
        public double MVFRefXRisk { get; set; }

    }
}
