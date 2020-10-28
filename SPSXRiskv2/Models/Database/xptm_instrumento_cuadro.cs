using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 16/10/2020 10:06:38 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("xptm_instrumento_cuadro")]
    public class xptm_instrumento_cuadro
    {
        public decimal? amoiva { get; set; }
        public string cantot { get; set; }
        public decimal cappen { get; set; }
        public string codescenario { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
        public string docser { get; set; }
        public DateTime fecha { get; set; }
        public decimal? gastos { get; set; }
        public decimal impamo { get; set; }
        public decimal impcuo { get; set; }
        public decimal? impcuototal { get; set; }
        public decimal impint { get; set; }
        public decimal? impiva { get; set; }
        public decimal? intiva { get; set; }
        public string lstdel { get; set; }
        public Int16 numcuo { get; set; }
        public int numdias { get; set; }
        public decimal porint { get; set; }
        public decimal? poriva { get; set; }
        public string realsimulado { get; set; }
        public string simulacion { get; set; }
        public string user_created { get; set; }
        public string user_updated { get; set; }
        [Key]
        [Column(Order = 1)]
        public int linid { get; set; }

    }
}
