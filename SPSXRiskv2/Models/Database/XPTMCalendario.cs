using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SPSXRiskv2.Models.Database
{
    [Table("xptm_calendario ")]
    public class XPTMCalendario
    {
        [Key]
        public int cabid { get; set; }
        public string codser { get; set; }
        public string descripcion { get; set; }
        public bool flunes { get; set; }
        public bool fmartes { get; set; }
        public bool fmiercoles { get; set; }
        public bool fjueves { get; set; }
        public bool fviernes { get; set; }
        public bool fsabado { get; set; }
        public bool fdomingo { get; set; }
        public string user_created { get; set; }
        public DateTime date_created { get; set; }
        public string user_updated { get; set; }
        public DateTime date_updated { get; set; }
    }

}