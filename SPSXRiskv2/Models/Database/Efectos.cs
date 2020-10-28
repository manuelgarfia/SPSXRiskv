using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 15/09/2020 10:54:28 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("Efectos")]
    public class Efectos
    {
        public double? abcnumerador { get; set; }
        public string Asiento { get; set; }
        public string AsientoContable { get; set; }
        public decimal Cambio { get; set; }
        public string? ClaseEfecto { get; set; }
        public string CodigoCliente { get; set; }
        public string? CuentaContable { get; set; }
        public string? CuentaFinanciera { get; set; }
        public string empresa { get; set; }
        public bool? Enviado { get; set; }
        public string? Error { get; set; }
        public string EstadoEfecto { get; set; }
        public string? Factura { get; set; }
        public DateTime? FechaFactura { get; set; }
        public DateTime? FechaVto { get; set; }
        public string? Iban { get; set; }
        public DateTime? idProcesoCarga { get; set; }
        public double? Importe { get; set; }
        public double? ImporteDivisa { get; set; }
        public string? Lote { get; set; }
        public string? Moneda { get; set; }
        public string? mvfcodcia { get; set; }
        public double? mvfrefxrisk { get; set; }
        public string? NombreCliente { get; set; }
        public string? notas { get; set; }
        public string? Recibo { get; set; }
        public string? Remesa { get; set; }
        public string TipoEfecto { get; set; }
        public bool traspasado { get; set; }
        [Key]
        [Column(Order = 1)]
        public int id { get; set; }

    }
}
