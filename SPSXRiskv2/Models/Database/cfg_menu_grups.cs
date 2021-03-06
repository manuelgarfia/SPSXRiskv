using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 26/10/2020 11:01:01 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("cfg_menu_grups")]
    public class cfg_menu_grups
    {
        public string descripcio { get; set; }
        public int ordre { get; set; }
        public string tipusmenu { get; set; }
        [Key]
        [Column(Order = 1)]
        public string grup { get; set; }
        [Key]
        [Column(Order = 2)]
        public string usuari { get; set; }
    }
}
