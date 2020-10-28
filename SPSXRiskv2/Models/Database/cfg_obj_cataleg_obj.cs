using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 26/10/2020 11:04:36 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("cfg_obj_cataleg_obj")]
    public class cfg_obj_cataleg_obj
    {
        public string categoria { get; set; }
        public string descripcio { get; set; }
        public string seguretat { get; set; }
        public string target { get; set; }
        public string tipusObjecte { get; set; }
        public string? titol { get; set; }
        public string url { get; set; }
        [Key]
        [Column(Order = 1)]
        public string objecte { get; set; }

    }
}
