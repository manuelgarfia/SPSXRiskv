using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 14/09/2020 11:48:55 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("ApunBancCSB_PSD2")]
    public class ApunBancCSB_PSD2
    {
        public string ABCBanco { get; set; }
        public string ABCClaOfiOri { get; set; }
        public string ABCCodCTA { get; set; }
        public string ABCCodUSR { get; set; }
        public string ABCComple1 { get; set; }
        public string ABCComple10 { get; set; }
        public string ABCComple2 { get; set; }
        public string ABCComple3 { get; set; }
        public string ABCComple4 { get; set; }
        public string ABCComple5 { get; set; }
        public string ABCComple6 { get; set; }
        public string ABCComple7 { get; set; }
        public string ABCComple8 { get; set; }
        public string ABCComple9 { get; set; }
        public string ABCConCom { get; set; }
        public string ABCConPro { get; set; }
        public string ABCCuenta { get; set; }
        public string ABCDocumento { get; set; }
        public DateTime? ABCFechaRealConc { get; set; }
        public DateTime? ABCFechConcil { get; set; }
        public DateTime? ABCFechIntro { get; set; }
        public DateTime? ABCFechOper { get; set; }
        public DateTime? ABCFechVal { get; set; }
        public string ABCFichEnt { get; set; }
        public string ABCGrupo { get; set; }
        public bool? ABCHistorif { get; set; }
        public decimal? ABCImporte { get; set; }
        public bool ABCIncorporado { get; set; }
        public bool? ABCLibreLogico1 { get; set; }
        public bool? ABCLibreLogico2 { get; set; }
        public bool? ABCLibreLogico3 { get; set; }
        public string ABCLibreTexto1 { get; set; }
        public string ABCLibreTexto2 { get; set; }
        public string ABCLibreTexto3 { get; set; }
        public string ABCOficina { get; set; }
        public string ABCRef1 { get; set; }
        public string ABCRef2 { get; set; }
        public double? ABCRefConcil { get; set; }
        public string ABCSigno { get; set; }
        public string ABCTipConcil { get; set; }
        public string ABCValorOrganizativo { get; set; }
        [Key]
        [Column(Order = 1)]
        public double ABCNumerador { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ABCCodCIA { get; set; }


    }
}
