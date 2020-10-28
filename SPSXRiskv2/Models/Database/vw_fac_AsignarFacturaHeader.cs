using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 14/09/2020 13:21:33 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    public class vw_fac_AsignarFacturaHeader
    {
        public string ABCCodCIA { get; set; }
        public string ABCCodCTA { get; set; }
        public string ABCComple { get; set; }
        public DateTime? ABCFechOper { get; set; }
        public DateTime? ABCFechVal { get; set; }
        public decimal? ABCImporteSigno { get; set; }
        public double ABCNumerador { get; set; }
        public string CodDiv { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public double MVFrefXrisk { get; set; }

    }
}
