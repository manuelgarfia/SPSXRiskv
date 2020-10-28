using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSXRiskv2.Models.Database
{
    [Table("Companyias")]
    public class Companyia
    {
        [Key]
        [Column(Order = 1)] 
        public string CIACod { get; set; }
        public string CIADescripcion { get; set; }
		public string CIAGrupo { get; set; }
		public string CIANiv { get; set; }
		public Int16 CIANOrganizativo { get; set; }
		public string CIAValorOrganizativo { get; set; }
		public string CIADesred { get; set; }
		public string? CIARazonSocial { get; set; }
		public string? CIADireccion { get; set; }
		public string? CIACP { get; set; }
		public string? CIAPoblacion { get; set; }
		public string? CIANIF { get; set; }
		public string? CIACodCont { get; set; }
		public string? CIADivisa { get; set; }
		public string? CIATelefono { get; set; }
		public string? CIAFAX { get; set; }
		public string? CIAEmail { get; set; }
		public string? CIAWeb { get; set; }
		public string? CIAPais { get; set; }
		public string? CIASistemaERP { get; set; }
		public bool? CIACotizada { get; set; }
		public string? CIAUnidadPublica { get; set; }
		public string? CIAISIN { get; set; }
		public string? CIACNAE { get; set; }
		public string? CIAClaveProvincia { get; set; }
		public string? CIAProvincia { get; set; }
		public string? CIAClavePais { get; set; }
		public bool? CIADeclaraBDE { get; set; }

		[ForeignKey("MVFCodCIA")]
        public List<MovimientoFisico> MovimientoFisicos { get; set; }

        [ForeignKey("ABCCodCIA")]
        public List<ApunteBancario> ApunteBancario { get; set; }
    }
}
