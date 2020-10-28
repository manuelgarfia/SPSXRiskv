using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace SPSXRiskv2.Models.Database
{
    [Table("zpos_clavesprevisiones")]
    public class ClavesPrevisiones
    { 
        public string PRVGrupoTes { get; set; }
        public string PRVClave { get; set; }
        public string PRVCodOPE { get; set; }
        public string PRVCodCPT { get; set; }
        public int PRVSigno { get; set; }
        public bool? PRVEnlaceERP { get; set; }
        public bool? PRVRemanente { get; set; }

    }
}
