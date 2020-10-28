using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SPSXRiskv2.Models.Database
{
    [Table("MovFisico")]
    public class MovimientoFisico
    {
        public string MVFGrupo { get; set; }
        public string MVFCodCIA { get; set; }
        public string MVFDescripcion { get; set; }
        public string MVFValorOrganizativo { get; set; }
        public double MVFRefXRisk { get; set; }
        public string MVFCodGEN { get; set; }
        public string MVFCodENT { get; set; }
        public string MVFCodTLI { get; set; }
        public string MVFCodCTA { get; set; }
        public string MVFRef1SisExt { get; set; }
        public string MVFAgrOpe { get; set; }
        public string MVFCodCPT { get; set; }
        public string MVFCodOPE { get; set; }
        public string MVFCodDIV {get;set;}
        public string MVFTipoOPE { get; set; }
        public string MVFContAgrOPE { get; set; }
        public bool MVFContrapartidaOPE { get; set; }
        public double MVFImBrDivisa { get; set; }
        public Int16 MVFSigImpNet { get; set; }
        public double MVFImNetDiv { get; set; }
        public DateTime MVFFechOperac { get; set; }
        public DateTime? MVFFechValor { get; set; }
        public string MVFGradCert { get; set; }
        public string MVFConciliado { get; set; }
        public DateTime? MVFFechIncor { get; set; }
        public int? MVFRefIncor { get; set; }
        public DateTime? MVFFechCert { get; set; }
        public int? MVFRefCert { get; set; }
        public double? MVFImpNetDivMN { get; set; }
        public double? MVFCamBrImpu { get; set; }
        public double? MVFImBrPtas { get; set; }
        public double? MVFCamNetCptMn { get; set; }
        public string MVFCodCPTDIV { get; set; }

        //2n tab
        public DateTime? MVFFechConc { get; set; }
        public int? MVFRefConc { get; set; }
        public DateTime? MVFFechCont { get; set; }

        public double? MVFRefCont { get; set; }

        //3r tab
        public int? MVFCodTIntREF { get; set; }
        public DateTime? MVFFechVto { get; set; } 
        public double? MVFSpread { get; set; }
        public double? MVFTipInt { get; set; }

        //4T TAB
        public string MVFCodAOP { get; set; }
        public string MVFCodGFL { get; set; }
        public string MVFCodFLU { get; set; }
        public string MVFCodACP { get; set; }
        public DateTime? MVFFechImp { get; set; }
        public string MVFSisOrig { get; set; }
        public string MVFCodIrcREF { get; set; }
        public DateTime MVFFechEstimada { get; set; }
        public string MVFCodUSR { get; set; }
        public DateTime? MVFFechaRealConc { get; set; }

        //Relaciones
        public Companyia Companyia { get; set; }

        // Propiedades relacionadas
    }
}