using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.ViewModels;

/// <summary>
/// Code generated 26/10/2020 11:01:01 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKcfg_menu_grups : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("descripcio")]
        public string descripcio { get; set; }
        [JsonProperty("ordre")]
        public int ordre { get; set; }
        [JsonProperty("tipusmenu")]
        public string tipusmenu { get; set; }
        [JsonProperty("grup")]
        public string grup { get; set; }
        [JsonProperty("usuari")]
        public string usuari { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKcfg_menu_grups()
        {
        }

        public XRSKcfg_menu_grups(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKcfg_menu_grups(cfg_menu_grups item)
        {
            TOXRSKcfg_menu_grups(item);
        }

        public XRSKcfg_menu_grups(cfg_menu_grups item, XRSKDataContext db)
        {
            TOXRSKcfg_menu_grups(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKcfg_menu_grups(cfg_menu_grups item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKcfg_menu_grups(item, db);
        }

        private void TOXRSKcfg_menu_grups(cfg_menu_grups item, XRSKDataContext db)
        {
            descripcio = item.descripcio;
            ordre = item.ordre;
            tipusmenu = item.tipusmenu;
            grup = item.grup;
            usuari = item.usuari;


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKcfg_menu_grups> TOXRSKcfg_menu_grups(List<cfg_menu_grups> items)
        {
            List<XRSKcfg_menu_grups> elemList = new List<XRSKcfg_menu_grups>();
            foreach (cfg_menu_grups item in items)
            {
                elemList.Add(new XRSKcfg_menu_grups(item));
            }

            return elemList;
        }

        private IQueryable<cfg_menu_grups> aplicarSeguridad(IQueryable<cfg_menu_grups> query)
        {
            if (Usuario.Grupos != null)
            {
                foreach (XRSKFocUsuariosGrupos grupo in Usuario.Grupos)
                {
                    if (grupo.BasesDatos != null)
                    {
                        foreach (XSRKBasesDatosGrupo bd in grupo.BasesDatos)
                        {
                            // Security sample, uncomment and change it at your own if your consider
                            //query = query.Where(x => bd.companies.Contains(x.MVFCodCIA));
                        }
                    }
                }
            }
            return query;
        }

        private IQueryable<cfg_menu_grups> aplicarFiltro(IQueryable<cfg_menu_grups> query, FilterModel filter)
        {
            foreach (FilterDetailModel detail in filter.detail)
            {
                // Filtering sample, uncomment and change it at your own if your consider
                // if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_DATE))
                // {
                // switch (detail.subtype)
                // {
                // case XRSKConstantes.FILTER_SUBTYPE_RANGE:
                // if (detail.entity.Equals("MVFFechOperac"))
                // {
                // query = query.Where(x => x.MVFFechOperac >= detail.from && x.MVFFechOperac <= detail.to);
                // }
                // break;
                // }
                // }

                // if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_NUMBER))
                // {
                // switch (detail.subtype)
                // {
                // case XRSKConstantes.FILTER_SUBTYPE_GREATER_EQUAL:
                // if (detail.entity.Equals("MVFImBrDivisa"))
                // {
                // query = query.Where(x => x.MVFImBrDivisa >= (Double)detail.decValue);
                // }
                // break;
                // case XRSKConstantes.FILTER_SUBTYPE_LESS_EQUAL:
                // if (detail.entity.Equals("MVFImBrDivisa"))
                // {
                // query = query.Where(x => x.MVFImBrDivisa <= (Double)detail.decValue);
                // }
                // break;
                // case XRSKConstantes.FILTER_SUBTYPE_RANGE:
                // if (detail.entity.Equals("MVFImBrDivisa"))
                // {
                // query = query.Where(x => x.MVFImBrDivisa >= (Double)detail.decValue && x.MVFImBrDivisa <= (Double)detail.importMax);
                // }
                // break;
                // }
                // }

                // if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_STRING) && detail.charValue != XRSKConstantes.FILTER_VALUE_EMPTY)
                // {
                // switch (detail.subtype)
                // {
                // case XRSKConstantes.FILTER_SUBTYPE_CONTAINS:
                // if (detail.entity.Equals("MVFRefXRisk"))
                // {
                // query = query.Where(x => x.MVFRefXRisk.ToString().Contains(detail.charValue));
                // }
                // break;
                // case XRSKConstantes.FILTER_SUBTYPE_STARTS:
                // if (detail.entity.Equals("MVFRefXRisk"))
                // {
                // query = query.Where(x => x.MVFRefXRisk.ToString().StartsWith("P"));
                // }
                // break;
                // case XRSKConstantes.FILTER_SUBTYPE_ENDS:
                // if (detail.entity.Equals("MVFRefXRisk"))
                // {
                // query = query.Where(x => x.MVFRefXRisk.ToString().Contains(detail.charValue));
                // }
                // break;
                // }
                // }

                // Elementos
                // if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_ITEMS) && detail.values != null && detail.values.Length != 0)
                // {
                // if (detail.entity.Equals("MVFCodCIA"))
                // {
                // if (detail.values.Length.Equals(1))
                // {
                // query = query.Where(x => x.MVFCodCIA.Equals(detail.values[0]));
                // }
                // else
                // {
                // query = query.Where(x => detail.values.Contains(x.MVFCodCIA));
                // }
                // }
                // }
            }

            return query;
        }
        #endregion

        #region Public Methods
        public List<XRSKcfg_menu_grups> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create cfg_menu_grups entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<cfg_menu_grups> items = db.cfg_menu_grups.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKcfg_menu_grups(items);
        }

        public List<XRSKcfg_menu_grups> GetSecondLevelList(string tipusmenu, string user)
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create cfg_menu_grups entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<cfg_menu_grups> items = db.cfg_menu_grups.
                Where(x => x.tipusmenu == tipusmenu && x.usuari == user).
                ToList();
            return TOXRSKcfg_menu_grups(items);
        }

        public List<XRSKcfg_menu_grups> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.cfg_menu_grups//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKcfg_menu_grups(query.ToList());
        }

        public XRSKcfg_menu_grups Find(string grup, string usuari)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(grup, usuari, db);
        }// end Find method

        public XRSKcfg_menu_grups Find(string grup, string usuari, XRSKDataContext db)
        {
            cfg_menu_grups item = db.cfg_menu_grups.Find(grup, usuari);
            TOXRSKcfg_menu_grups(item);
            return this;
        }
        #endregion

        #region Persistencia
        private cfg_menu_grups before_insert(XRSKDataContext db, cfg_menu_grups next)
        {
            return next;
        }// end before_insert method

        private cfg_menu_grups before_update(XRSKDataContext db, cfg_menu_grups prev, cfg_menu_grups next)
        {
            return next;
        }// end before_update method

        private cfg_menu_grups before_delete(XRSKDataContext db, cfg_menu_grups prev)
        {
            return prev;
        }// end before_delete method

        private cfg_menu_grups after_insert(XRSKDataContext db, cfg_menu_grups next)
        {
            return next;
        }// end after_insert method

        private cfg_menu_grups after_update(XRSKDataContext db, cfg_menu_grups prev, cfg_menu_grups next)
        {
            return next;
        }// end after_update method

        public XRSKcfg_menu_grups save()
        {
            XRSKDataContext db = new XRSKDataContext();

            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    save(db);
                    // Commit Transaction
                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    throw e;
                }//end try-catch
            }// end dbContextTransacion

            return this;
        }// end save method

        public XRSKcfg_menu_grups save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            cfg_menu_grups item = db.cfg_menu_grups.Find(grup, usuari);
            cfg_menu_grups previous = new cfg_menu_grups();
            // Change data
            if (item == null)
            {
                item = new cfg_menu_grups();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.descripcio = descripcio;
            item.ordre = ordre;
            item.tipusmenu = tipusmenu;
            item.grup = grup;
            item.usuari = usuari;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.cfg_menu_grups.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKcfg_menu_grups(item, db);

            if (isInsert)
            {
                after_insert(db, item);
                db.SaveChanges();
            }
            else
            {
                after_update(db, previous, item);
                // Update Context
                db.SaveChanges();
            }

            return this;
        }// end save method with context

        public XRSKcfg_menu_grups save(XRSKDataContext db, List<XRSKcfg_menu_grups> elemsList)
        {
            foreach (XRSKcfg_menu_grups currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKcfg_menu_grups delete()
        {
            XRSKDataContext db = new XRSKDataContext();

            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    delete(db);
                    // Commit Transaction
                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    throw e;
                }//end try-catch
            }// end dbContextTransacion

            return this;
        }// end delete method

        public XRSKcfg_menu_grups delete(XRSKDataContext db)
        {
            // Get Entity
            cfg_menu_grups item = db.cfg_menu_grups.Find(grup, usuari);
            // Before_Delete call
            item = before_delete(db, item);

            db.cfg_menu_grups.Remove(item);
            db.SaveChanges();

            // Change data
            item.descripcio = null;
            item.ordre = 0;
            item.tipusmenu = null;
            item.grup = null;
            item.usuari = null;


            return this;
        }// end delete method with method
        #endregion
    }
}
