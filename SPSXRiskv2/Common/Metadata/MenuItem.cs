using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Entities;

namespace SPSXRiskv2.Common.Metadata
{
    public class MenuItem
    {

        #region Propiedades

        public String Name { get; set; }
        public String Route { get; set; }
        public String Icon { get; set; }

        #endregion

        #region Constructores

        public MenuItem()
        {

        }// Constructor vacío

        //public MenuItem(XRSKcfg_menu_objectes item)
        //{
        //    TOXRSKMenuItem(item);
        //}


        public MenuItem(String _Name, String _Route, String _Icon)
        {
            Name = _Name;
            Route = _Route;
            Icon = _Icon;
        }

        #endregion

        #region Private Methods

        //private void TOXRSKMenuItem(XRSKcfg_menu_objectes item)
        //{
        //    XRSKDataContext db = new XRSKDataContext();
        //    TOXRSKMenuItem(item, db);
        //}

        //private void TOXRSKMenuItem(XRSKcfg_menu_objectes item, XRSKDataContext db)
        //{
        //    Name = item.objecte;
        //    Route = "";
        //    Icon = "angle-double-right";

        //}
            #endregion
        }
}
