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
/// Code generated 26/10/2020 11:04:36 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKcfg_obj_cataleg_obj : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("categoria")]
        public string categoria { get; set; }
        [JsonProperty("descripcio")]
        public string descripcio { get; set; }
        [JsonProperty("seguretat")]
        public string seguretat { get; set; }
        [JsonProperty("target")]
        public string target { get; set; }
        [JsonProperty("tipusObjecte")]
        public string tipusObjecte { get; set; }
        [JsonProperty("titol")]
        public string titol { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("objecte")]
        public string objecte { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKcfg_obj_cataleg_obj()
        {
        }

        public XRSKcfg_obj_cataleg_obj(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKcfg_obj_cataleg_obj(cfg_obj_cataleg_obj item)
        {
            TOXRSKcfg_obj_cataleg_obj(item);
        }

        public XRSKcfg_obj_cataleg_obj(cfg_obj_cataleg_obj item, XRSKDataContext db)
        {
            TOXRSKcfg_obj_cataleg_obj(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKcfg_obj_cataleg_obj(cfg_obj_cataleg_obj item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKcfg_obj_cataleg_obj(item, db);
        }

        private void TOXRSKcfg_obj_cataleg_obj(cfg_obj_cataleg_obj item, XRSKDataContext db)
        {
            categoria = item.categoria;
            descripcio = item.descripcio;
            seguretat = item.seguretat;
            target = item.target;
            tipusObjecte = item.tipusObjecte;
            titol = item.titol;
            url = item.url;
            objecte = item.objecte;


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKcfg_obj_cataleg_obj> TOXRSKcfg_obj_cataleg_obj(List<cfg_obj_cataleg_obj> items)
        {
            List<XRSKcfg_obj_cataleg_obj> elemList = new List<XRSKcfg_obj_cataleg_obj>();
            foreach (cfg_obj_cataleg_obj item in items)
            {
                elemList.Add(new XRSKcfg_obj_cataleg_obj(item));
            }

            return elemList;
        }

        private IQueryable<cfg_obj_cataleg_obj> aplicarSeguridad(IQueryable<cfg_obj_cataleg_obj> query)
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

        private IQueryable<cfg_obj_cataleg_obj> aplicarFiltro(IQueryable<cfg_obj_cataleg_obj> query, FilterModel filter)
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
        public List<XRSKcfg_obj_cataleg_obj> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create cfg_obj_cataleg_obj entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<cfg_obj_cataleg_obj> items = db.cfg_obj_cataleg_obj.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKcfg_obj_cataleg_obj(items);
        }

        public XRSKcfg_obj_cataleg_obj GetObj(string objecte)
        {
            XRSKDataContext db = new XRSKDataContext();
            /// You have to create cfg_obj_cataleg_obj entry at SPSXRiskv2\Models\XRSKDataContext.cs
            cfg_obj_cataleg_obj item = db.cfg_obj_cataleg_obj.Where(x => x.objecte == objecte).FirstOrDefault();
            TOXRSKcfg_obj_cataleg_obj(item);

            return this;
        }

        public List<XRSKcfg_obj_cataleg_obj> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.cfg_obj_cataleg_obj//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKcfg_obj_cataleg_obj(query.ToList());
        }

        public XRSKcfg_obj_cataleg_obj Find(string objecte)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(objecte, db);
        }// end Find method

        public XRSKcfg_obj_cataleg_obj Find(string objecte, XRSKDataContext db)
        {
            cfg_obj_cataleg_obj item = db.cfg_obj_cataleg_obj.Find(objecte);
            TOXRSKcfg_obj_cataleg_obj(item);
            return this;
        }
        #endregion

        #region Persistencia
        private cfg_obj_cataleg_obj before_insert(XRSKDataContext db, cfg_obj_cataleg_obj next)
        {
            return next;
        }// end before_insert method

        private cfg_obj_cataleg_obj before_update(XRSKDataContext db, cfg_obj_cataleg_obj prev, cfg_obj_cataleg_obj next)
        {
            return next;
        }// end before_update method

        private cfg_obj_cataleg_obj before_delete(XRSKDataContext db, cfg_obj_cataleg_obj prev)
        {
            return prev;
        }// end before_delete method

        private cfg_obj_cataleg_obj after_insert(XRSKDataContext db, cfg_obj_cataleg_obj next)
        {
            return next;
        }// end after_insert method

        private cfg_obj_cataleg_obj after_update(XRSKDataContext db, cfg_obj_cataleg_obj prev, cfg_obj_cataleg_obj next)
        {
            return next;
        }// end after_update method

        public XRSKcfg_obj_cataleg_obj save()
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

        public XRSKcfg_obj_cataleg_obj save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            cfg_obj_cataleg_obj item = db.cfg_obj_cataleg_obj.Find(objecte);
            cfg_obj_cataleg_obj previous = new cfg_obj_cataleg_obj();
            // Change data
            if (item == null)
            {
                item = new cfg_obj_cataleg_obj();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.categoria = categoria;
            item.descripcio = descripcio;
            item.seguretat = seguretat;
            item.target = target;
            item.tipusObjecte = tipusObjecte;
            item.titol = titol;
            item.url = url;
            item.objecte = objecte;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.cfg_obj_cataleg_obj.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKcfg_obj_cataleg_obj(item, db);

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

        public XRSKcfg_obj_cataleg_obj save(XRSKDataContext db, List<XRSKcfg_obj_cataleg_obj> elemsList)
        {
            foreach (XRSKcfg_obj_cataleg_obj currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKcfg_obj_cataleg_obj delete()
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

        public XRSKcfg_obj_cataleg_obj delete(XRSKDataContext db)
        {
            // Get Entity
            cfg_obj_cataleg_obj item = db.cfg_obj_cataleg_obj.Find(objecte);
            // Before_Delete call
            item = before_delete(db, item);

            db.cfg_obj_cataleg_obj.Remove(item);
            db.SaveChanges();

            // Change data
            item.categoria = null;
            item.descripcio = null;
            item.seguretat = null;
            item.target = null;
            item.tipusObjecte = null;
            item.titol = null;
            item.url = null;
            item.objecte = null;


            return this;
        }// end delete method with method
        #endregion
    }
}
