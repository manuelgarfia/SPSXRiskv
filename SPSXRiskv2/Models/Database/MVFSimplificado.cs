using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSXRiskv2.Models.Database
{
    [Table("ZPOS_MVFSimplificado")]
    public class MVFSimplificado
    {
        [Key]
        [Column(Order = 1)] 
        public int cabid { get; set; }
        public string ClavePrevision { get; set; }
        public string MVFCodCIA { get; set; }
        public double MVFRefXRisk { get; set; }
        public string MVFCodCta { get; set; }
        public string MVFRef1SisExt { get; set; }
        public string MVFAgrOpe { get; set; }
        public string MVFCodOPE { get; set; }
        public string MVFCodCPT { get; set; }
        public string MVFCuentaContableCPT { get; set; }
        public string MVFDescripcion { get; set; }
        public string MVFSisOrig { get; set; }
        public string MVFCodITFLIT { get; set; }
        public string MVFRefLoteLIT { get; set; }
        public string MVFCodUSR { get; set; }
        public DateTime MVFFechImp { get; set; }
        public DateTime MVFFechOperac { get; set; }
        public DateTime MVFFechValor { get; set; }
        public string MVFCodDIV { get; set; }
        public string MVFCodCPTDIV { get; set; }
        public int  MVFSigno { get; set; }
        public double MVFImporte { get; set; }
        public string MVFGradCert { get; set; }

    }
}
