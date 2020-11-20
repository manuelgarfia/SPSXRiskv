using SPSXRiskv2.Models;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SPSXRiskv2.Common.Metadata
{
    public class PanelItem
    {

        #region Propiedades

        public String Name { get; set; }
        public String Icon { get; set; }
        public List<ThirdMenuItem> menu { get; set; }

        #endregion

        #region Constructores

        public PanelItem()
        {
            menu = new List<ThirdMenuItem>();

        }// Constructor por defecto

        public PanelItem(String _Name, String _Icon, List<ThirdMenuItem> _menu)
        {
            Name = _Name;
            Icon = _Icon;
            menu = _menu.ConvertAll(x=> new ThirdMenuItem(x.Name,x.Route,x.Icon, x.hasRouting ,x.menuItem));
        }

        #endregion

        #region Métodos Públicos

        public List<PanelItem> getPaneles(ClaimsPrincipal _User)
        {
            Claim userIDClaim = _User.Claims.Where(x => x.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault();

            XRSKFocUsuarios empleado = new XRSKFocUsuarios();
            empleado.Find(userIDClaim.Value.ToString());


            List<PanelItem> paneles = new List<PanelItem>();
            //Creem una llista buida pels panels que no tenen subPanels
            List<MenuItem> emptyMenu = new List<MenuItem>();

            foreach (Claim claim in _User.Claims.Where(x => x.Type.Equals(ClaimTypes.Role)))
            {

                switch (claim.Value)
                {
                    case "admin":
                        XRSKDataContext db = new XRSKDataContext();
                        string user = "portal";

                        //Get the first level list
                        XRSKcfg_menu_tipus firstLevel = new XRSKcfg_menu_tipus();
                        List<XRSKcfg_menu_tipus> firstLevelList = new List<XRSKcfg_menu_tipus>();
                        firstLevelList = firstLevel.GetPanelsList(user);

                        //Get the second level list
                        XRSKcfg_menu_grups secondLevel = new XRSKcfg_menu_grups();
                        List<XRSKcfg_menu_grups> secondLevelList = new List<XRSKcfg_menu_grups>();

                        //Get third level list
                        XRSKcfg_menu_objectes thirdLevel = new XRSKcfg_menu_objectes();
                        List<XRSKcfg_menu_objectes> thirdLevelList = new List<XRSKcfg_menu_objectes>();

                        List<MenuItem> thirdMenu = new List<MenuItem>();
                        List<ThirdMenuItem> secondMenu = new List<ThirdMenuItem>();
                        //Etiquetes
                        XRSKcfg_dl_etiquetas etiquetes = new XRSKcfg_dl_etiquetas();
                        XRSKcfg_dl_etiquetas itemEtiquetes = new XRSKcfg_dl_etiquetas();
                        XRSKcfg_obj_cataleg_obj objCataleg = new XRSKcfg_obj_cataleg_obj();
                        XRSKcfg_obj_cataleg_obj itemCataleg = new XRSKcfg_obj_cataleg_obj();

                        XRSKvw_cfg_menu_usuari menuUser = new XRSKvw_cfg_menu_usuari();
                        XRSKvw_cfg_menu_usuari stringSecondLevel = new XRSKvw_cfg_menu_usuari();
                        XRSKvw_cfg_menu_usuari stringThirdLevel = new XRSKvw_cfg_menu_usuari();

                        string itemFirstLevel;

                        foreach (XRSKcfg_menu_tipus item in firstLevelList)
                        {
                            //Obtenim l'etiqueta pel primer nivell
                            string tipusmenu = item.tipusmenu;
                            itemFirstLevel = menuUser.GetPrimerNivell(tipusmenu);

                            //Get the second level list depending on the user
                            secondLevelList.Clear();
                            secondLevelList = secondLevel.GetSecondLevelList(tipusmenu, user);

                            foreach (XRSKcfg_menu_grups itemSecond in secondLevelList)
                            {
                                //Get labels for the second list
                                string secondItemString = itemSecond.grup;
                                stringSecondLevel = menuUser.GetDescripcio(secondItemString);

                                //Search the thirdLevel
                                thirdLevelList.Clear();
                                thirdLevelList = thirdLevel.GetThirdLevelList(secondItemString, user);

                               foreach (XRSKcfg_menu_objectes itemThird in thirdLevelList)
                                {
                                    if (itemThird.objecte != null)
                                    {
                                        //Get labels for the third level
                                        stringThirdLevel = menuUser.GetObj(itemThird.objecte);
                                        MenuItem menuItem = new MenuItem(stringThirdLevel.descripcioObjecte, stringThirdLevel.url, "angle-double-right");

                                        thirdMenu.Add(menuItem);
                                    }
                                }

                                //Pertany al segon menu
                                secondMenu.Add(new ThirdMenuItem(stringSecondLevel.descripcioNivell2, "", "angle-double-right", false, thirdMenu));
                                thirdMenu.Clear();
                            }

                            paneles.Add(new PanelItem(itemFirstLevel, "angle-double-right", secondMenu));
                            secondMenu.Clear();


                        }


                        //// Incluimos el tercer nivel de Préstamos
                        //List<MenuItem> prestamosMenu = new List<MenuItem>();
                        //prestamosMenu.Add(new MenuItem("Portal Préstamos", "prestamos", "angle-double-right"));
                        //prestamosMenu.Add(new MenuItem("Préstamos2", "prestamos", "angle-double-right"));
                        //prestamosMenu.Add(new MenuItem("Préstamos3", "prestamos", "angle-double-right"));

                        //Incluimos Segundo Nivel Deuda
                        List<ThirdMenuItem> globalMenu = new List<ThirdMenuItem>();
                        globalMenu.Add(new ThirdMenuItem("Portales Procesos", "procesos", "angle-double-right", true, emptyMenu));
                        globalMenu.Add(new ThirdMenuItem("Portales Deuda", "prestamos", "angle-double-right",true, emptyMenu));
                        paneles.Add(new PanelItem("Global", "angle-double-right", globalMenu));

                        break;

                    case "users":

                        //Incluimos la parte de Tesoreria
                        List<ThirdMenuItem> tesoreriaMenu = new List<ThirdMenuItem>();
                        tesoreriaMenu.Add(new ThirdMenuItem("Movimiento Físico", "xrskmovimientofisico", "angle-double-right", true, emptyMenu));
                        tesoreriaMenu.Add(new ThirdMenuItem("Movimiento Simplificado", "xrskmvfsimplificado", "angle-double-right", true, emptyMenu));
                        tesoreriaMenu.Add(new ThirdMenuItem("Apuntes Bancarios", "ApuntesBancarios", "angle-double-right", true, emptyMenu));
                        tesoreriaMenu.Add(new ThirdMenuItem("Situación de conciliación", "cncsituacion", "angle-double-right", true, emptyMenu));
                        tesoreriaMenu.Add(new ThirdMenuItem("Cartera Efectos", "carteraEfectos", "angle-double-right", true, emptyMenu));
                        tesoreriaMenu.Add(new ThirdMenuItem("Cuéntas de Crédito", "polizas", "angle-double-right", true, emptyMenu));
                        tesoreriaMenu.Add(new ThirdMenuItem("Escenarios", "jesus", "angle-double-right", true, emptyMenu));
                        tesoreriaMenu.Add(new ThirdMenuItem("Escenarios navegables", "jesus-navega", "angle-double-right", true, emptyMenu));

                        paneles.Add(new PanelItem("Tesoreria", "tools", tesoreriaMenu));

                        // Incluimos la parte de Reporting
                        List<ThirdMenuItem> reportingMenu = new List<ThirdMenuItem>();
                        reportingMenu.Add(new ThirdMenuItem("Reporting", "reporting", "angle-double-right", true, emptyMenu));

                        paneles.Add(new PanelItem("Reporting", "tools", reportingMenu));

                        // Incluimos la parte de Maestros
                        List<ThirdMenuItem> maestrosMenu = new List<ThirdMenuItem>();
                        maestrosMenu.Add(new ThirdMenuItem("Agrupación Contrapartida", "xrskagrupacion", "file-alt", true, emptyMenu));
                        maestrosMenu.Add(new ThirdMenuItem("Condiciones Bancarias", "georgina", "file-alt", true, emptyMenu));
                        maestrosMenu.Add(new ThirdMenuItem("Calendario Festivos", "xrskcalendario", "file-alt", true, emptyMenu));
                        maestrosMenu.Add(new ThirdMenuItem("Contratos Saldos Charts", "graphic", "file-alt", true, emptyMenu));

                        paneles.Add(new PanelItem("Maestros", "globe", maestrosMenu));

                        // Incluimos la parte de Resumen Actividad
                        List<ThirdMenuItem> resumenActividad = new List<ThirdMenuItem>();
                        resumenActividad.Add(new ThirdMenuItem("Resumen", "ActivitySummary", "file-alt", true, emptyMenu));

                        paneles.Add(new PanelItem("Resumen", "globe", resumenActividad));

                        // Incluimos la parte de Seguridad
                        List<ThirdMenuItem> seguridadMenu = new List<ThirdMenuItem>();
                        seguridadMenu.Add(new ThirdMenuItem("Usuarios", "users", "file-alt", true, emptyMenu));
                        seguridadMenu.Add(new ThirdMenuItem("Grupos de Usuarios", "usersGroups", "file-alt", true, emptyMenu));
                        seguridadMenu.Add(new ThirdMenuItem("Seguridad Objetos", "securityObjects", "file-alt", true, emptyMenu));

                        paneles.Add(new PanelItem("Seguridad", "lock", seguridadMenu));

                        break;
                }
            }



            return paneles;
        }

        #endregion
    }
}
