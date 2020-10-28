using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSXRiskv2.Models.Database
{
    [Table("Contratos_Saldos")]
    public class ContratosSaldos
    {
        public string CTATipoFecha { get; set; }

        public string CTACodCIA { get; set; }

        public string CTACod { get; set; }

        public DateTime Fecha { get; set; }

        public double Saldo { get; set; }

    }

}