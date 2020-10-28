using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 28/09/2020 12:07:03 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("Numerador")]
    public class Numerador
    {
        public int NUMUltApunBanco { get; set; }
        public int NUMUltAsignacion { get; set; }
        public int NUMUltCobertura { get; set; }
        public int NUMUltConciliacion { get; set; }
        public int NUMUltContable { get; set; }
        public int NUMUltMvto { get; set; }
        public int NUMUltOperaciones { get; set; }
        [Key]
        [Column(Order = 1)]
        public string NUMGrupo { get; set; }
        [Key]
        [Column(Order = 2)]
        public string NUMNiv { get; set; }

    }
}
