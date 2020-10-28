using Newtonsoft.Json;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;

/// <summary>
/// Code generated 26/10/2020 11:05:11 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKcfg_dl_etiquetas : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("id")]
        public int? id { get; set; }
        [JsonProperty("valor")]
        public string valor { get; set; }
        [JsonProperty("etiqueta")]
        public string etiqueta { get; set; }
        [JsonProperty("idioma")]
        public string idioma { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKcfg_dl_etiquetas()
        {
        }

        public XRSKcfg_dl_etiquetas(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKcfg_dl_etiquetas(cfg_dl_etiquetas item)
        {
            TOXRSKcfg_dl_etiquetas(item);
        }

        public XRSKcfg_dl_etiquetas(cfg_dl_etiquetas item, XRSKDataContext db)
        {
            TOXRSKcfg_dl_etiquetas(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKcfg_dl_etiquetas(cfg_dl_etiquetas item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKcfg_dl_etiquetas(item, db);
        }

        private void TOXRSKcfg_dl_etiquetas(cfg_dl_etiquetas item, XRSKDataContext db)
        {
            id = item.id;
            valor = item.valor;
            etiqueta = item.etiqueta;
            idioma = item.idioma;


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKcfg_dl_etiquetas> TOXRSKcfg_dl_etiquetas(List<cfg_dl_etiquetas> items)
        {
            List<XRSKcfg_dl_etiquetas> elemList = new List<XRSKcfg_dl_etiquetas>();
            foreach (cfg_dl_etiquetas item in items)
            {
                elemList.Add(new XRSKcfg_dl_etiquetas(item));
            }

            return elemList;
        }

        private IQueryable<cfg_dl_etiquetas> aplicarSeguridad(IQueryable<cfg_dl_etiquetas> query)
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

        private IQueryable<cfg_dl_etiquetas> aplicarFiltro(IQueryable<cfg_dl_etiquetas> query, FilterModel filter)
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
        public List<XRSKcfg_dl_etiquetas> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create cfg_dl_etiquetas entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<cfg_dl_etiquetas> items = db.cfg_dl_etiquetas.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKcfg_dl_etiquetas(items);
        }

        public XRSKcfg_dl_etiquetas GetEtiqueta(string descripcioObjecte)
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create cfg_dl_etiquetas entry at SPSXRiskv2\Models\XRSKDataContext.cs
            cfg_dl_etiquetas item = db.cfg_dl_etiquetas
                .Where(x => x.etiqueta == descripcioObjecte).FirstOrDefault();

            TOXRSKcfg_dl_etiquetas(item);
            return this;
        }

        public List<XRSKcfg_dl_etiquetas> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.cfg_dl_etiquetas//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKcfg_dl_etiquetas(query.ToList());
        }

        public XRSKcfg_dl_etiquetas Find(string etiqueta, string idioma)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(etiqueta, idioma, db);
        }// end Find method

        public XRSKcfg_dl_etiquetas Find(string etiqueta, string idioma, XRSKDataContext db)
        {
            cfg_dl_etiquetas item = db.cfg_dl_etiquetas.Find(etiqueta, idioma);
            TOXRSKcfg_dl_etiquetas(item);
            return this;
        }
        #endregion

        #region Persistencia
        private cfg_dl_etiquetas before_insert(XRSKDataContext db, cfg_dl_etiquetas next)
        {
            return next;
        }// end before_insert method

        private cfg_dl_etiquetas before_update(XRSKDataContext db, cfg_dl_etiquetas prev, cfg_dl_etiquetas next)
        {
            return next;
        }// end before_update method

        private cfg_dl_etiquetas before_delete(XRSKDataContext db, cfg_dl_etiquetas prev)
        {
            return prev;
        }// end before_delete method

        private cfg_dl_etiquetas after_insert(XRSKDataContext db, cfg_dl_etiquetas next)
        {
            return next;
        }// end after_insert method

        private cfg_dl_etiquetas after_update(XRSKDataContext db, cfg_dl_etiquetas prev, cfg_dl_etiquetas next)
        {
            return next;
        }// end after_update method

        public XRSKcfg_dl_etiquetas save()
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

        public XRSKcfg_dl_etiquetas save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            cfg_dl_etiquetas item = db.cfg_dl_etiquetas.Find(etiqueta, idioma);
            cfg_dl_etiquetas previous = new cfg_dl_etiquetas();
            // Change data
            if (item == null)
            {
                item = new cfg_dl_etiquetas();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.id = id;
            item.valor = valor;
            item.etiqueta = etiqueta;
            item.idioma = idioma;

            if (isInsert)
            {
                item = before_insert(db, item);
                db.cfg_dl_etiquetas.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKcfg_dl_etiquetas(item, db);

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

        public XRSKcfg_dl_etiquetas save(XRSKDataContext db, List<XRSKcfg_dl_etiquetas> elemsList)
        {
            foreach (XRSKcfg_dl_etiquetas currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKcfg_dl_etiquetas delete()
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

        public XRSKcfg_dl_etiquetas delete(XRSKDataContext db)
        {
            // Get Entity
            cfg_dl_etiquetas item = db.cfg_dl_etiquetas.Find(etiqueta, idioma);
            // Before_Delete call
            item = before_delete(db, item);

            db.cfg_dl_etiquetas.Remove(item);
            db.SaveChanges();

            // Change data
            item.id = 0;
            item.valor = null;
            item.etiqueta = null;
            item.idioma = null;


            return this;
        }// end delete method with method
        #endregion
    }
}
