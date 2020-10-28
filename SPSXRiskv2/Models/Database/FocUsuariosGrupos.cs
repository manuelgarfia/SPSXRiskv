using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSXRiskv2.Models.Database
{
    public class FocUsuariosGrupos
    {
        public int cabid { get; set; }
        public string usuari { get; set; }
        public string grup { get; set; }
    }
}
