using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 14/09/2020 12:15:26 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("fac_clientes")]
    public class fac_clientes
    {
        public string? CodigoPostal { get; set; }
        public string? CuentaContable { get; set; }
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public string Empresa { get; set; }
        public string? FormaPago { get; set; }
        public string? NIF { get; set; }
        public string? Nombre { get; set; }
        public string? Pais { get; set; }
        public string? Poblacion { get; set; }
        public string? Provincia { get; set; }
        public string? Telefono { get; set; }
        [Key]
        [Column(Order = 1)]
        public string Codigo { get; set; }

    }
}
