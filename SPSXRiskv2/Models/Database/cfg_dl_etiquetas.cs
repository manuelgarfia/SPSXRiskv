using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Code generated 26/10/2020 11:05:11 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("cfg_dl_etiquetas")]
    public class cfg_dl_etiquetas
    {
        public int? id { get; set; }
        public string valor { get; set; }
        [Key]
        [Column(Order = 1)]
        public string etiqueta { get; set; }
        [Key]
        [Column(Order = 2)]
        public string idioma { get; set; }

    }
}
