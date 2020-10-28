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
/// Code generated 16/10/2020 10:06:55 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKxptm_prestamos_mvtos : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("codser")]
        public string codser { get; set; }
        [JsonProperty("date_created")]
        public DateTime date_created { get; set; }
        [JsonProperty("date_updated")]
        public DateTime date_updated { get; set; }
        [JsonProperty("descripcio")]
        public string? descripcio { get; set; }
        [JsonProperty("esreal")]
        public bool esreal { get; set; }
        [JsonProperty("fecha")]
        public DateTime fecha { get; set; }
        [JsonProperty("importe")]
        public decimal importe { get; set; }
        [JsonProperty("tipomvto")]
        public string tipomvto { get; set; }
        [JsonProperty("user_created")]
        public string user_created { get; set; }
        [JsonProperty("user_updated")]
        public string user_updated { get; set; }
        [JsonProperty("cabid")]
        public int cabid { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKxptm_prestamos_mvtos()
        {
        }

        public XRSKxptm_prestamos_mvtos(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKxptm_prestamos_mvtos(xptm_prestamos_mvtos item)
        {
            TOXRSKxptm_prestamos_mvtos(item);
        }

        public XRSKxptm_prestamos_mvtos(xptm_prestamos_mvtos item, XRSKDataContext db)
        {
            TOXRSKxptm_prestamos_mvtos(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKxptm_prestamos_mvtos(xptm_prestamos_mvtos item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKxptm_prestamos_mvtos(item, db);
        }

        private void TOXRSKxptm_prestamos_mvtos(xptm_prestamos_mvtos item, XRSKDataContext db)
        {
            codser = item.codser;
            date_created = item.date_created;
            date_updated = item.date_updated;
            descripcio = item.descripcio;
            esreal = item.esreal;
            fecha = item.fecha;
            importe = item.importe;
            tipomvto = item.tipomvto;
            user_created = item.user_created;
            user_updated = item.user_updated;
            cabid = item.cabid;


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKxptm_prestamos_mvtos> TOXRSKxptm_prestamos_mvtos(List<xptm_prestamos_mvtos> items)
        {
            List<XRSKxptm_prestamos_mvtos> elemList = new List<XRSKxptm_prestamos_mvtos>();
            foreach (xptm_prestamos_mvtos item in items)
            {
                elemList.Add(new XRSKxptm_prestamos_mvtos(item));
            }

            return elemList;
        }

        private IQueryable<xptm_prestamos_mvtos> aplicarSeguridad(IQueryable<xptm_prestamos_mvtos> query)
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

        private IQueryable<xptm_prestamos_mvtos> aplicarFiltro(IQueryable<xptm_prestamos_mvtos> query, FilterModel filter)
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
        public List<XRSKxptm_prestamos_mvtos> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create xptm_prestamos_mvtos entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<xptm_prestamos_mvtos> items = db.xptm_prestamos_mvtos.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKxptm_prestamos_mvtos(items);
        }

        public List<XRSKxptm_prestamos_mvtos> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.xptm_prestamos_mvtos//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKxptm_prestamos_mvtos(query.ToList());
        }

        public XRSKxptm_prestamos_mvtos Find(int cabid)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(cabid, db);
        }// end Find method

        public XRSKxptm_prestamos_mvtos Find(int cabid, XRSKDataContext db)
        {
            xptm_prestamos_mvtos item = db.xptm_prestamos_mvtos.Find(cabid);
            TOXRSKxptm_prestamos_mvtos(item);
            return this;
        }
        #endregion

        #region Persistencia
        private xptm_prestamos_mvtos before_insert(XRSKDataContext db, xptm_prestamos_mvtos next)
        {
            return next;
        }// end before_insert method

        private xptm_prestamos_mvtos before_update(XRSKDataContext db, xptm_prestamos_mvtos prev, xptm_prestamos_mvtos next)
        {
            return next;
        }// end before_update method

        private xptm_prestamos_mvtos before_delete(XRSKDataContext db, xptm_prestamos_mvtos prev)
        {
            return prev;
        }// end before_delete method

        private xptm_prestamos_mvtos after_insert(XRSKDataContext db, xptm_prestamos_mvtos next)
        {
            return next;
        }// end after_insert method

        private xptm_prestamos_mvtos after_update(XRSKDataContext db, xptm_prestamos_mvtos prev, xptm_prestamos_mvtos next)
        {
            return next;
        }// end after_update method

        public XRSKxptm_prestamos_mvtos save()
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

        public XRSKxptm_prestamos_mvtos save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            xptm_prestamos_mvtos item = db.xptm_prestamos_mvtos.Find(cabid);
            xptm_prestamos_mvtos previous = new xptm_prestamos_mvtos();
            // Change data
            if (item == null)
            {
                item = new xptm_prestamos_mvtos();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.codser = codser;
            item.date_created = date_created;
            item.date_updated = date_updated;
            item.descripcio = descripcio;
            item.esreal = esreal;
            item.fecha = fecha;
            item.importe = importe;
            item.tipomvto = tipomvto;
            item.user_created = user_created;
            item.user_updated = user_updated;
            item.cabid = cabid;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.xptm_prestamos_mvtos.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKxptm_prestamos_mvtos(item, db);

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

        public XRSKxptm_prestamos_mvtos save(XRSKDataContext db, List<XRSKxptm_prestamos_mvtos> elemsList)
        {
            foreach (XRSKxptm_prestamos_mvtos currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKxptm_prestamos_mvtos delete()
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

        public XRSKxptm_prestamos_mvtos delete(XRSKDataContext db)
        {
            // Get Entity
            xptm_prestamos_mvtos item = db.xptm_prestamos_mvtos.Find(cabid);
            // Before_Delete call
            item = before_delete(db, item);

            db.xptm_prestamos_mvtos.Remove(item);
            db.SaveChanges();

            // Change data
            item.codser = null;
            item.date_created = DateTime.Today;
            item.date_updated = DateTime.Today;
            item.descripcio = null;
            item.esreal = false;
            item.fecha = DateTime.Today;
            item.importe = 0;
            item.tipomvto = null;
            item.user_created = null;
            item.user_updated = null;
            item.cabid = 0;


            return this;
        }// end delete method with method
        #endregion
    }
}
