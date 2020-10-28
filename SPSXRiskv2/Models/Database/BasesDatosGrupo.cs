using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPSXRiskv2.Models.Database
{
    public class BasesDatosGrupo
    {
        public int linid { get; set; }
        public string grup { get; set; }
        public string nombd { get; set; }
        public int prioritat { get; set; }
        public string perfmenu { get; set; }
        public string perfobj { get; set; }
        public string perfsql { get; set; }
        public string iniPage { get; set; }
        public string perfseg { get; set; }
    }
}
