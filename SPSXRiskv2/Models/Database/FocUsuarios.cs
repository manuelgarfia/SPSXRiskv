using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSXRiskv2.Models.Database
{
    public class FocUsuarios
    {
        public int cabid { get; set; }
        public string usuari { get; set; }
        public string usuariZoom { get; set; }
        public string paswrd { get; set; }
        public string nombre { get; set; }
        public string idioma { get; set; }
        public bool activo { get; set; }
    }
}
