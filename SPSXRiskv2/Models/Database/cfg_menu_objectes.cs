using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Code generated 26/10/2020 11:04:27 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("cfg_menu_objectes")]
    public class cfg_menu_objectes
    {
        public int ordre { get; set; }
        [Key]
        [Column(Order = 1)]
        public string usuari { get; set; }
        [Key]
        [Column(Order = 2)]
        public string grup { get; set; }
        [Key]
        [Column(Order = 3)]
        public string objecte { get; set; }

    }
}
