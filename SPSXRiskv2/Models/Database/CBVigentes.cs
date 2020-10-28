
using SPSXRiskv2.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSXRiskv2.Models.Database
{

    public class CBVigentes
    {
        public int cabid { get; set; }
        public string CONCodACO { get; set; }
        public DateTime CONFechaDesde { get; set; }
        public DateTime CONFechaHasta { get; set; }
        public string CONCodCIA { get; set; }
        public string CONCodENT { get; set; }
        public string CONCodCTA { get; set; }
        public string CONCodOPE { get; set; }
        public int CONIdCPT { get; set; }
        public bool CONMovGastos { get; set; }
        public string CONCodGastosOPE { get; set; }
        public string CONCodCPT { get; set; }
        public double CONPorcentaje { get; set; }
        public double CONImpMin { get; set; }
        public double CONImpMax { get; set; }
        public double CONFijo { get; set; }
        public bool CONCosteXefecto { get; set; }
        public string CONTipoEfecto { get; set; }
        public bool? CONInteresesDto { get; set; }
        public double? CONPorcentajeInteresDto { get; set; }
        public bool? CONCalculoPorDivisa { get; set; }
        public bool? CONNuevaCPTIVA { get; set; }
        public string CONCodIVACPT { get; set; }
        public double? CONPorcentajeIVA { get; set; }
        public double? CONDesdeImporte { get; set; }

    }
}
