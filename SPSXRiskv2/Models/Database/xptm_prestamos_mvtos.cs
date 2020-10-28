using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 16/10/2020 10:06:55 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("xptm_prestamos_mvtos")]
    public class xptm_prestamos_mvtos
    {
        public string codser { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
        public string? descripcio { get; set; }
        public bool esreal { get; set; }
        public DateTime fecha { get; set; }
        public decimal importe { get; set; }
        public string tipomvto { get; set; }
        public string user_created { get; set; }
        public string user_updated { get; set; }
        [Key]
        [Column(Order = 1)]
        public int cabid { get; set; }

    }
}
