using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 16/10/2020 10:05:18 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("xptm_prestamos")]
    public class xptm_prestamos
    {
        public decimal? amortfija { get; set; }
        public int basedias { get; set; }
        public decimal bonificacion { get; set; }
        public decimal broker { get; set; }
        public string calendario { get; set; }
        public int carencia { get; set; }
        public string centrocoste { get; set; }
        public string codser { get; set; }
        public decimal comapertura { get; set; }
        public decimal comcancpromotor { get; set; }
        public decimal comcanparcial { get; set; }
        public decimal comcantotal { get; set; }
        public decimal comdemora { get; set; }
        public decimal comestudio { get; set; }
        public decimal comreclamacion { get; set; }
        public decimal comsubrogacion { get; set; }
        public string convFechas { get; set; }
        public decimal correo { get; set; }
        public string ctafinanciera { get; set; }
        public string ctamovimientos { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
        public string descripcion { get; set; }
        public int diapago { get; set; }
        public int diarevision { get; set; }
        public int diasfixingdate { get; set; }
        public decimal diferencial { get; set; }
        public string difsubrogacion { get; set; }
        public string docser { get; set; }
        public string empresa { get; set; }
        public string entidad { get; set; }
        public string estado { get; set; }
        public DateTime? fecha1cuota { get; set; }
        public DateTime? fecha1liq { get; set; }
        public DateTime? fecha1revision { get; set; }
        public DateTime? fechacontabauto { get; set; }
        public DateTime? fechacontrato { get; set; }
        public DateTime? fechadispinicial { get; set; }
        public DateTime fechaestado { get; set; }
        public DateTime? fechavto { get; set; }
        public string formula { get; set; }
        public int fredondeo { get; set; }
        public bool hay1liq { get; set; }
        public decimal? interesini { get; set; }
        public bool mesescomerciales { get; set; }
        public decimal? nominal { get; set; }
        public int numpagos { get; set; }
        public decimal pctinteres { get; set; }
        public decimal? pctsubvencionado { get; set; }
        public int peramo { get; set; }
        public int perliq { get; set; }
        public int perliqcarencia { get; set; }
        public int perrevision { get; set; }
        public string refcot { get; set; }
        public string tipo { get; set; }
        public string user_created { get; set; }
        public string user_updated { get; set; }
        [Key]
        [Column(Order = 1)]
        public int cabid { get; set; }

    }
}
