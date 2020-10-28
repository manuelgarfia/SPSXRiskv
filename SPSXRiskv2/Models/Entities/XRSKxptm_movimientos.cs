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
/// Code generated 16/10/2020 11:52:10 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKxptm_movimientos : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("certificacion")]
        public string? certificacion { get; set; }
        [JsonProperty("codescenario")]
        public string? codescenario { get; set; }
        [JsonProperty("date_created")]
        public DateTime date_created { get; set; }
        [JsonProperty("date_updated")]
        public DateTime date_updated { get; set; }
        [JsonProperty("docser")]
        public string docser { get; set; }
        [JsonProperty("feccontab")]
        public DateTime? feccontab { get; set; }
        [JsonProperty("fecoperacion")]
        public DateTime? fecoperacion { get; set; }
        [JsonProperty("fecvalor")]
        public DateTime? fecvalor { get; set; }
        [JsonProperty("importe")]
        public decimal importe { get; set; }
        [JsonProperty("importeprev")]
        public decimal? importeprev { get; set; }
        [JsonProperty("mvfcodcia")]
        public string? mvfcodcia { get; set; }
        [JsonProperty("mvfrefxrisk")]
        public double? mvfrefxrisk { get; set; }
        [JsonProperty("numcuota")]
        public int? numcuota { get; set; }
        [JsonProperty("pctinteres")]
        public decimal pctinteres { get; set; }
        [JsonProperty("realsimulado")]
        public string realsimulado { get; set; }
        [JsonProperty("refmvto")]
        public string refmvto { get; set; }
        [JsonProperty("simulacion")]
        public string simulacion { get; set; }
        [JsonProperty("tipcta")]
        public string tipcta { get; set; }
        [JsonProperty("tipmvto")]
        public string tipmvto { get; set; }
        [JsonProperty("tipoconciliacion")]
        public string? tipoconciliacion { get; set; }
        [JsonProperty("user_created")]
        public string user_created { get; set; }
        [JsonProperty("user_updated")]
        public string user_updated { get; set; }
        [JsonProperty("serid")]
        public int serid { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKxptm_movimientos()
        {
        }

        public XRSKxptm_movimientos(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKxptm_movimientos(xptm_movimientos item)
        {
            TOXRSKxptm_movimientos(item);
        }

        public XRSKxptm_movimientos(xptm_movimientos item, XRSKDataContext db)
        {
            TOXRSKxptm_movimientos(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKxptm_movimientos(xptm_movimientos item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKxptm_movimientos(item, db);
        }

        private void TOXRSKxptm_movimientos(xptm_movimientos item, XRSKDataContext db)
        {
            certificacion = item.certificacion;
            codescenario = item.codescenario;
            date_created = item.date_created;
            date_updated = item.date_updated;
            docser = item.docser;
            feccontab = item.feccontab;
            fecoperacion = item.fecoperacion;
            fecvalor = item.fecvalor;
            importe = item.importe;
            importeprev = item.importeprev;
            mvfcodcia = item.mvfcodcia;
            mvfrefxrisk = item.mvfrefxrisk;
            numcuota = item.numcuota;
            pctinteres = item.pctinteres;
            realsimulado = item.realsimulado;
            refmvto = item.refmvto;
            simulacion = item.simulacion;
            tipcta = item.tipcta;
            tipmvto = item.tipmvto;
            tipoconciliacion = item.tipoconciliacion;
            user_created = item.user_created;
            user_updated = item.user_updated;
            serid = item.serid;


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKxptm_movimientos> TOXRSKxptm_movimientos(List<xptm_movimientos> items)
        {
            List<XRSKxptm_movimientos> elemList = new List<XRSKxptm_movimientos>();
            foreach (xptm_movimientos item in items)
            {
                elemList.Add(new XRSKxptm_movimientos(item));
            }

            return elemList;
        }

        private IQueryable<xptm_movimientos> aplicarSeguridad(IQueryable<xptm_movimientos> query)
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

        private IQueryable<xptm_movimientos> aplicarFiltro(IQueryable<xptm_movimientos> query, FilterModel filter)
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
        public List<XRSKxptm_movimientos> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create xptm_movimientos entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<xptm_movimientos> items = db.xptm_movimientos.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKxptm_movimientos(items);
        }

        public decimal getSumImporte(string docser)
        {
            XRSKDataContext db = new XRSKDataContext();
            decimal capPendiente = 0;

            var query = from x in db.xptm_movimientos.
                        Where(x => x.docser == docser && x.realsimulado == "S" && x.tipcta == "DEU")
                        select x;

            foreach(var item in query)
            {
                capPendiente = capPendiente + item.importe; 
            }

            return capPendiente;
        }

        public List<XRSKxptm_movimientos> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.xptm_movimientos//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKxptm_movimientos(query.ToList());
        }

        public XRSKxptm_movimientos Find(int serid)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(serid, db);
        }// end Find method

        public XRSKxptm_movimientos Find(int serid, XRSKDataContext db)
        {
            xptm_movimientos item = db.xptm_movimientos.Find(serid);
            TOXRSKxptm_movimientos(item);
            return this;
        }
        #endregion

        #region Persistencia
        private xptm_movimientos before_insert(XRSKDataContext db, xptm_movimientos next)
        {
            return next;
        }// end before_insert method

        private xptm_movimientos before_update(XRSKDataContext db, xptm_movimientos prev, xptm_movimientos next)
        {
            return next;
        }// end before_update method

        private xptm_movimientos before_delete(XRSKDataContext db, xptm_movimientos prev)
        {
            return prev;
        }// end before_delete method

        private xptm_movimientos after_insert(XRSKDataContext db, xptm_movimientos next)
        {
            return next;
        }// end after_insert method

        private xptm_movimientos after_update(XRSKDataContext db, xptm_movimientos prev, xptm_movimientos next)
        {
            return next;
        }// end after_update method

        public XRSKxptm_movimientos save()
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

        public XRSKxptm_movimientos save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            xptm_movimientos item = db.xptm_movimientos.Find(serid);
            xptm_movimientos previous = new xptm_movimientos();
            // Change data
            if (item == null)
            {
                item = new xptm_movimientos();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.certificacion = certificacion;
            item.codescenario = codescenario;
            item.date_created = date_created;
            item.date_updated = date_updated;
            item.docser = docser;
            item.feccontab = feccontab;
            item.fecoperacion = fecoperacion;
            item.fecvalor = fecvalor;
            item.importe = importe;
            item.importeprev = importeprev;
            item.mvfcodcia = mvfcodcia;
            item.mvfrefxrisk = mvfrefxrisk;
            item.numcuota = numcuota;
            item.pctinteres = pctinteres;
            item.realsimulado = realsimulado;
            item.refmvto = refmvto;
            item.simulacion = simulacion;
            item.tipcta = tipcta;
            item.tipmvto = tipmvto;
            item.tipoconciliacion = tipoconciliacion;
            item.user_created = user_created;
            item.user_updated = user_updated;
            item.serid = serid;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.xptm_movimientos.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKxptm_movimientos(item, db);

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


        public XRSKxptm_movimientos save(XRSKDataContext db, List<XRSKxptm_movimientos> elemsList)
        {
            foreach (XRSKxptm_movimientos currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKxptm_movimientos delete()
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

        public XRSKxptm_movimientos delete(XRSKDataContext db)
        {
            // Get Entity
            xptm_movimientos item = db.xptm_movimientos.Find(serid);
            // Before_Delete call
            item = before_delete(db, item);

            db.xptm_movimientos.Remove(item);
            db.SaveChanges();

            // Change data
            item.certificacion = null;
            item.codescenario = null;
            item.date_created = DateTime.Today;
            item.date_updated = DateTime.Today;
            item.docser = null;
            item.feccontab = DateTime.Today;
            item.fecoperacion = DateTime.Today;
            item.fecvalor = DateTime.Today;
            item.importe = 0;
            item.importeprev = 0;
            item.mvfcodcia = null;
            item.mvfrefxrisk = 0;
            item.numcuota = 0;
            item.pctinteres = 0;
            item.realsimulado = null;
            item.refmvto = null;
            item.simulacion = null;
            item.tipcta = null;
            item.tipmvto = null;
            item.tipoconciliacion = null;
            item.user_created = null;
            item.user_updated = null;
            item.serid = 0;


            return this;
        }// end delete method with method
        #endregion
    }
}
