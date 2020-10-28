using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 16/10/2020 11:52:10 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("xptm_movimientos")]
    public class xptm_movimientos
    {
        public string? certificacion { get; set; }
        public string? codescenario { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
        public string docser { get; set; }
        public DateTime? feccontab { get; set; }
        public DateTime? fecoperacion { get; set; }
        public DateTime? fecvalor { get; set; }
        public decimal importe { get; set; }
        public decimal? importeprev { get; set; }
        public string? mvfcodcia { get; set; }
        public double? mvfrefxrisk { get; set; }
        public int? numcuota { get; set; }
        public decimal pctinteres { get; set; }
        public string realsimulado { get; set; }
        public string refmvto { get; set; }
        public string simulacion { get; set; }
        public string tipcta { get; set; }
        public string tipmvto { get; set; }
        public string tipoconciliacion { get; set; }
        public string user_created { get; set; }
        public string user_updated { get; set; }
        [Key]
        [Column(Order = 1)]
        public int serid { get; set; }

    }
}
