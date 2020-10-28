using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPSXRiskv2.Models.Database
{
    public class CNCSituacion
    {
        public string CNCGrupo { get; set; }
        public string CNCValorOrganizativo { get; set; }
        public string CNCCodCIA { get; set; }
        public string CNCCodCTA { get; set; }
        public string signo { get; set; }
        public int? CNCBancoNONum { get; set; }
        public double? CNCBancoNOImporte { get; set; }
        public int? CNCXRProvNum { get; set; }
        public double? CNCXRProvImporte { get; set; }
        public int? CNCXRContNum { get; set; }
        public double? CNCXRContImporte { get; set; }
    }
}
