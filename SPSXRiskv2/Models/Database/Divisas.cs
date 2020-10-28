using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 14/08/2020 11:09:09 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("Divisas")]
    public class Divisas
    {
        public string DIVDescripcion { get; set; }
        public Int16? DIVDifHora { get; set; }
        public bool DIVFesDomingo { get; set; }
        public bool DIVFesJueves { get; set; }
        public bool DIVFesLunes { get; set; }
        public bool DIVFesMartes { get; set; }
        public bool DIVFesMiercoles { get; set; }
        public bool DIVFesSabado { get; set; }
        public bool DIVFesViernes { get; set; }
        public string DIVGenero { get; set; }
        public string DIVGrupo { get; set; }
        public DateTime? DIVHoraFin { get; set; }
        public DateTime? DIVHoraInicio { get; set; }
        public Int16 DIVNumDecPres { get; set; }
        public Int16 DIVNumEnterPres { get; set; }
        public string? DIVPais { get; set; }
        public string? DIVRelCodCsb { get; set; }
        [Key]
        [Column(Order = 1)]
        public string DIVNiv { get; set; }
        [Key]
        [Column(Order = 2)]
        public string DIVCod { get; set; }

    }
}
