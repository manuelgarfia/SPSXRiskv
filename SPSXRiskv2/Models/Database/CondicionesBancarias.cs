using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPSXRiskv2.Models.Database
{
    [Table("CondicionesBancarias")]
    public class CondicionesBancarias
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cabid { get; set; }
        public string CONCodACO { get; set; }
        public DateTime? CONFechaDesde { get; set; }
        public DateTime? CONFechaHasta { get; set; }
        public string CONCodCIA { get; set; }
        [Required]
        public string CONCodENT { get; set; }
        [Required]
        public string CONCodCTA { get; set; }
        [Required]
        public string CONCodOPE { get; set; }
        [Required]
        public int CONIdCPT { get; set; }
        public bool CONMovGastos { get; set; }
        public string CONCodGastosOPE { get; set; }
        [Required]
        public string CONCodCPT { get; set; }
        [Required]
        public double CONPorcentaje { get; set; }
        [Required]
        public double CONImpMin { get; set; }
        [Required]
        public double CONImpMax { get; set; }
        [Required]
        public double CONFijo { get; set; }
        [Required]
        public bool CONCosteXefecto { get; set; }
        [Required]
        public string CONTipoEfecto { get; set; }
        public bool? CONInteresesDto { get; set; }
        public double? CONPorcentajeInteresDto { get; set; }
        [Required]
        public bool? CONCalculoPorDivisa { get; set; }
        [Required]
        public bool? CONNuevaCPTIVA { get; set; }
        public string CONCodIVACPT { get; set; }
        [Required]
        public double? CONPorcentajeIVA { get; set; }
        [Required]
        public double? CONDesdeImporte { get; set; }
    }
}
