using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 29/09/2020 13:11:57 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("Contratos_Renovacion")]
    public class Contratos_Renovacion
    {
        public double? CLQComisionnoDisp1 { get; set; }
        public double? CLQComisionnoDisp2 { get; set; }
        public double? CLQComisionnoDisp3 { get; set; }
        public DateTime? CLQFechaInicioLiq { get; set; }
        public DateTime? CLQFechaInicioRev { get; set; }
        public DateTime? CLQFechaInicioRevComNoDisp { get; set; }
        public string? CLQPeriodicidadComNoDisp { get; set; }
        public string? CLQPeriodicidadLiq { get; set; }
        public string? CLQPeriodicidadRev { get; set; }
        public string? CLQTipoPeriodLiquid { get; set; }
        public string? CLQTipoPeriodRevision { get; set; }
        public string? CLQTipoPeriodRevisionComNoDisp { get; set; }
        public double? CLQTramoComisionnoDisp1 { get; set; }
        public double? CLQTramoComisionnoDisp2 { get; set; }
        public double? CLQTramoComisionnoDisp3 { get; set; }
        public bool? CLQUltimoDiaLiq { get; set; }
        public bool? CLQUltimoDiaRev { get; set; }
        public bool? CLQUltimoDiaRevComNoDisp { get; set; }
        public string? CTACodIntAct1REF { get; set; }
        public string? CTACodIntAct2REF { get; set; }
        public string? CTACodIntAct3REF { get; set; }
        public string? CTACodIntAct4REF { get; set; }
        public string? CTACodIntActREF { get; set; }
        public string? CTACodIntExcedREF { get; set; }
        public string? CTACodIntPasREF { get; set; }
        public string? CTACodTLQ { get; set; }
        public Int16? CTADivisorActivo { get; set; }
        public Int16? CTADivisorPasivo { get; set; }
        public double? CTAEscActDiv1 { get; set; }
        public double? CTAEscActDiv2 { get; set; }
        public double? CTAEscActDiv3 { get; set; }
        public double? CTAEscActDiv4 { get; set; }
        public double? CTAEscActPts1 { get; set; }
        public double? CTAEscActPts2 { get; set; }
        public double? CTAEscActPts3 { get; set; }
        public double? CTAEscActPts4 { get; set; }
        public DateTime? CTAFechAvisoRenov { get; set; }
        public DateTime? CTAFechFinPer { get; set; }
        public double? CTAImpoPtsLimContr { get; set; }
        public double? CTAImporPtsExc { get; set; }
        public double? CTAImporPtsInfAvis { get; set; }
        public double? CTAImporPtsOper { get; set; }
        public double? CTAImporPtsSupAviso { get; set; }
        public bool CTAInteresAct1Fijo { get; set; }
        public bool CTAInteresAct2Fijo { get; set; }
        public bool CTAInteresAct3Fijo { get; set; }
        public bool CTAInteresAct4Fijo { get; set; }
        public bool CTAInteresExcedFijo { get; set; }
        public bool CTAInteresPasFijo { get; set; }
        public bool CTAInteresRestoFijo { get; set; }
        public Int16? CTAMultiplicActivo { get; set; }
        public Int16? CTAMultiplicPasivo { get; set; }
        public Int16? CTANumeros { get; set; }
        public double? CTARestoActivDiv { get; set; }
        public double? CTARestoActivPts { get; set; }
        public double? CTASpreadAct1 { get; set; }
        public double? CTASpreadAct2 { get; set; }
        public double? CTASpreadAct3 { get; set; }
        public double? CTASpreadAct4 { get; set; }
        public double? CTASpreadExced { get; set; }
        public double? CTASpreadPas { get; set; }
        public double? CTASpreadResto { get; set; }
        public double? CTATipInteresAct1 { get; set; }
        public double? CTATipInteresAct2 { get; set; }
        public double? CTATipInteresAct3 { get; set; }
        public double? CTATipInteresAct4 { get; set; }
        public double? CTATipInteresExced { get; set; }
        public double? CTATipInteresPas { get; set; }
        public double? CTATipInteresResto { get; set; }
        public double? DIASFIJACION { get; set; }
        [Key]
        [Column(Order = 1)]
        public string CTACod { get; set; }
        [Key]
        [Column(Order = 2)]
        public string CTACodCIA { get; set; }
        [Key]
        [Column(Order = 3)]
        public DateTime CTAFechIniPer { get; set; }

    }
}
