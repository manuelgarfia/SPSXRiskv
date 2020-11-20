using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Entities;

namespace SPSXRiskv2.Common.Metadata
{
    public class ThirdMenuItem
    {
        #region Propiedades

        public String Name { get; set; }
        public String Route { get; set; }
        public String Icon { get; set; }
        public Boolean hasRouting { get; set; }
        public List<MenuItem> menuItem { get; set; }

        #endregion

        #region Constructores

        public ThirdMenuItem()
        {
            //menuItem = new List<MenuItem>();

        }// Constructor vacío

        public ThirdMenuItem(String _Name, String _Route, String _Icon, Boolean _hasRouting, List<MenuItem> _menu)
        {
            Name = _Name;
            Route = _Route;
            Icon = _Icon;
            hasRouting = _hasRouting;
            menuItem = _menu.ConvertAll(x => new MenuItem(x.Name, x.Route, x.Icon));

        }

        #endregion

    }
}
