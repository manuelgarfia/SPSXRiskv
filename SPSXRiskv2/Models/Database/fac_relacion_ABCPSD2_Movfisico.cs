using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 14/09/2020 11:54:07 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("fac_relacion_ABCPSD2_Movfisico")]
    public class fac_relacion_ABCPSD2_Movfisico
    {
        public string ABCCodCIA { get; set; }
        public double ABCNumerador { get; set; }
        public string? CodigoCliente { get; set; }
        public double MVFrefXrisk { get; set; }
        [Key]
        [Column(Order = 1)]
        public int cabid { get; set; }

    }
}
