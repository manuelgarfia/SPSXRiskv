using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Code generated 26/10/2020 11:07:17 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Database
{
    [Table("vw_cfg_menu_usuari")]
    public class vw_cfg_menu_usuari
    {
        public string categoria { get; set; }
        public string? descripcioNivell1 { get; set; }
        public string descripcioNivell2 { get; set; }
        public string? descripcioObjecte { get; set; }
        public string grup { get; set; }
        public string? idioma { get; set; }
        public string objecte { get; set; }
        public int ordreNivell1 { get; set; }
        public int ordreNivell2 { get; set; }
        public int ordreNivell3 { get; set; }
        public string? seguretat { get; set; }
        public string tipusmenu { get; set; }
        public string tipusObjecte { get; set; }
        public string? titolObjecte { get; set; }
        public string? url { get; set; }
        public string usuari { get; set; }

    }
}
