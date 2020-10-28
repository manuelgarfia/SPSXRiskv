using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SPSXRiskv2.Models.Database
{
    [Table("AgrContrPart")]
    public class Agrupacion
    {
        public string ACPGrupo { get; set; }
        public string ACPNiv { get; set; }
        public string ACPCod { get; set; }
        public string ACPDescripcion { get; set; }


    }
}