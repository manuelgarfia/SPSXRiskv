using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 29/09/2020 13:11:41 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("exch_bancos_cuentapoliza")]
    public class exch_bancos_cuentapoliza
    {
        public bool abierto { get; set; }
        public string banco { get; set; }
        public string? calendario { get; set; }
        public string? clavepais { get; set; }
        public string codigo { get; set; }
        public string? codproveedor { get; set; }
        public string? convfechas { get; set; }
        public string? ctactble { get; set; }
        public string? ctafinanciacion { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
        public string? descripcion { get; set; }
        public int? diasfijacion { get; set; }
        public string divisa { get; set; }
        public string? divisaCSB { get; set; }
        public int divisoractivo { get; set; }
        public int divisorpasivo { get; set; }
        public string empresa { get; set; }
        public DateTime? fechaaltacontrato { get; set; }
        public DateTime? fechabaja { get; set; }
        public DateTime? fechaproxrenovacion { get; set; }
        public DateTime? fecharenovacion { get; set; }
        public DateTime? fechaultimoextracto { get; set; }
        public DateTime? fechaultliquid { get; set; }
        public DateTime? fechaultrevision { get; set; }
        public DateTime? fechavencimiento { get; set; }
        public string? formulaliquid { get; set; }
        public string iban { get; set; }
        public decimal? limitedivisa { get; set; }
        public decimal? limitemn { get; set; }
        public bool? multidivisa { get; set; }
        public string numcuenta { get; set; }
        public string oficina { get; set; }
        public string? oficinaalt { get; set; }
        public double? pctcomapertura { get; set; }
        public double? pctcomnodisp { get; set; }
        public decimal? pcttiporefactivofijado { get; set; }
        public decimal? pcttiporefexcedfijado { get; set; }
        public decimal? pcttiporefpasivofijado { get; set; }
        public int? periodicidadliquid { get; set; }
        public int? periodicidadrevision { get; set; }
        public decimal? saldoultimoextr { get; set; }
        public int? signosaldoultextr { get; set; }
        public decimal? spreadactivo { get; set; }
        public double? spreadexced { get; set; }
        public decimal? spreadpasivo { get; set; }
        public string tipolinea { get; set; }
        public string tipoperiodliquid { get; set; }
        public string tipoperiodrevision { get; set; }
        public string? tiporefactivo { get; set; }
        public bool? tiporefactivofijado { get; set; }
        public string? tiporefexced { get; set; }
        public bool? tiporefexcedfijado { get; set; }
        public string? tiporefpasivo { get; set; }
        public bool? tiporefpasivofijado { get; set; }
        public bool? ultimodiafechaliq { get; set; }
        public bool? ultimodiarevision { get; set; }
        public string user_created { get; set; }
        public string user_updated { get; set; }
        [Key]
        [Column(Order = 1)]
        public int cabid { get; set; }

    }
}
