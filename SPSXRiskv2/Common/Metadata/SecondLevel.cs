using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Entities;

namespace SPSXRiskv2.Common.Metadata
{
    public class SecondLevel
    {
        #region Propiedades

        public String Name { get; set; }
        public String Route { get; set; }
        public String Icon { get; set; }

        #endregion

        #region Constructores

        public SecondLevel()
        {

        }// Constructor vacío

        public SecondLevel(String _Name, String _Route, String _Icon, List<XRSKcfg_menu_grups> _menu)
        {
            Name = _Name;
            Route = _Route;
            Icon = _Icon;
        }

        #endregion
    }
}
