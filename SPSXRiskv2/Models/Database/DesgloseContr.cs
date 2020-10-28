using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 14/09/2020 9:34:15 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("DesgloseContr")]
    public class DesgloseContr
    {
        public double? DCP_CPT_TRI_MN_Cb1 { get; set; }
        public double? DCP_CPT_TRI_MN_Cb2 { get; set; }
        public double? DCP_ImpTri_CPT_MN { get; set; }
        public double? DCP_ImpTri_PAR_CPT { get; set; }
        public double? DCP_ImpTri_PAR_MN { get; set; }
        public double? DCP_Par_TRI_CPT_Cb1 { get; set; }
        public double? DCP_Par_TRI_CPT_Cb2 { get; set; }
        public double? DCP_Par_TRI_MN_Cb1 { get; set; }
        public double? DCP_Par_TRI_MN_Cb2 { get; set; }
        public string DCPAgrupacionContrapartidaCPT { get; set; }
        public double? DCPBaseImponible { get; set; }
        public double? DCPCambioDivCptMn { get; set; }
        public double? DCPCambioDivisaCpt { get; set; }
        public string DCPCodCPT { get; set; }
        public bool DCPComisCambioCPT { get; set; }
        public bool DCPComisionCPT { get; set; }
        public bool DCPConceptoFicticioCPT { get; set; }
        public bool DCPContrapartCPT { get; set; }
        public string DCPCtaIVACPT { get; set; }
        public string DCPCuentaContableCPT { get; set; }
        public string DCPDescripcionCPT { get; set; }
        public bool DCPDiferenciasCPT { get; set; }
        public string DCPDivisa { get; set; }
        public string DCPDivisaCpt { get; set; }
        public string DCPGrupo { get; set; }
        public bool DCPGtosBancCPT { get; set; }
        public double? DCPImporte { get; set; }
        public double? DCPImporteCpt { get; set; }
        public double? DCPImporteCptMn { get; set; }
        public bool DCPInteresesCPT { get; set; }
        public bool DCPIVACPT { get; set; }
        public bool DCPLibre1CPT { get; set; }
        public bool DCPLibre2CPT { get; set; }
        public bool DCPLibre3CPT { get; set; }
        public bool DCPLibre4CPT { get; set; }
        public bool DCPLibre5CPT { get; set; }
        public bool DCPLibre6CPT { get; set; }
        public bool DCPLibre7CPT { get; set; }
        public bool DCPLibre8CPT { get; set; }
        public bool DCPMonedaCPT { get; set; }
        public double? DCPPorcentajeIVACPT { get; set; }
        public string DCPRefAnalitica1 { get; set; }
        public string DCPRefAnalitica2 { get; set; }
        public string DCPRefAnalitica3 { get; set; }
        public string DCPRefAnalitica4 { get; set; }
        public string DCPRefAnalitica5 { get; set; }
        public string DCPRefAnalitica6 { get; set; }
        public string DCPRefCont { get; set; }
        public Int16 DCPSignoCPT { get; set; }
        [Key]
        [Column(Order = 1)]
        public string DCPCodCIA { get; set; }
        [Key]
        [Column(Order = 2)]
        public string DCPValorOrganizativo { get; set; }
        [Key]
        [Column(Order = 3)]
        public double DCPRefXrisk { get; set; }
        [Key]
        [Column(Order = 4)]
        public int DCPContador { get; set; }


    }
}
