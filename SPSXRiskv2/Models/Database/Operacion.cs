using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSXRiskv2.Models.Database
{
    [Table("Operacion")]
    public class Operacion
    {
        public bool OPEAccesorios { get; set; }
        public bool OPECertif { get; set; }
        public string? OPECodAOP { get; set; }
        public string? OPECodCont { get; set; }
        public string? OPECodCPT { get; set; }
        public bool OPEComCambio { get; set; }
        public bool OPEComisiones { get; set; }
        public bool OPEContabil { get; set; }
        public string OPEContAgrup { get; set; }
        public bool? OPEContrapartida { get; set; }
        public string OPEDescripcion { get; set; }
        public string OPEDesMovDef { get; set; }
        public bool OPEDivisa { get; set; }
        public bool OPEFechaVto { get; set; }
        public bool OPEGastos { get; set; }
        public bool OPEIntereses { get; set; }
        public string? OPENivAOP { get; set; }
        public string? OPENivCPT { get; set; }
        public string? OPENomRefAgrup { get; set; }
        public string? OPENomRefExt { get; set; }
        public bool OPERefSist { get; set; }
        public Int16 OPESignoAcces { get; set; }
        public Int16 OPESignoOper { get; set; }
        public bool OPETipoInteres { get; set; }
        public string OPETipoOper { get; set; }
        [Key]
        [Column(Order = 1)]
        public string OPEGrupo { get; set; }
        [Key]
        [Column(Order = 2)]
        public string OPENiv { get; set; }
        [Key]
        [Column(Order = 3)]
        public string OPECod { get; set; }
        [Key]
        [Column(Order = 4)]
        public string OPENivTLI { get; set; }
        [Key]
        [Column(Order = 5)]
        public string OPECodTLI { get; set; }
    }
}
