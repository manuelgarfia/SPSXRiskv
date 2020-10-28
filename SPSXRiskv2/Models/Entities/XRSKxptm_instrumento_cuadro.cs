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
/// Code generated 16/10/2020 10:06:38 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKxptm_instrumento_cuadro : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("amoiva")]
        public decimal? amoiva { get; set; }
        [JsonProperty("cantot")]
        public string cantot { get; set; }
        [JsonProperty("cappen")]
        public decimal cappen { get; set; }
        [JsonProperty("codescenario")]
        public string codescenario { get; set; }
        [JsonProperty("date_created")]
        public DateTime date_created { get; set; }
        [JsonProperty("date_updated")]
        public DateTime date_updated { get; set; }
        [JsonProperty("docser")]
        public string docser { get; set; }
        [JsonProperty("fecha")]
        public DateTime fecha { get; set; }
        [JsonProperty("gastos")]
        public decimal? gastos { get; set; }
        [JsonProperty("impamo")]
        public decimal impamo { get; set; }
        [JsonProperty("impcuo")]
        public decimal impcuo { get; set; }
        [JsonProperty("impcuototal")]
        public decimal? impcuototal { get; set; }
        [JsonProperty("impint")]
        public decimal impint { get; set; }
        [JsonProperty("impiva")]
        public decimal? impiva { get; set; }
        [JsonProperty("intiva")]
        public decimal? intiva { get; set; }
        [JsonProperty("lstdel")]
        public string lstdel { get; set; }
        [JsonProperty("numcuo")]
        public Int16 numcuo { get; set; }
        [JsonProperty("numdias")]
        public int numdias { get; set; }
        [JsonProperty("porint")]
        public decimal porint { get; set; }
        [JsonProperty("poriva")]
        public decimal? poriva { get; set; }
        [JsonProperty("realsimulado")]
        public string realsimulado { get; set; }
        [JsonProperty("simulacion")]
        public string simulacion { get; set; }
        [JsonProperty("user_created")]
        public string user_created { get; set; }
        [JsonProperty("user_updated")]
        public string user_updated { get; set; }
        [JsonProperty("linid")]
        public int linid { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKxptm_instrumento_cuadro()
        {
        }

        public XRSKxptm_instrumento_cuadro(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKxptm_instrumento_cuadro(xptm_instrumento_cuadro item)
        {
            TOXRSKxptm_instrumento_cuadro(item);
        }

        public XRSKxptm_instrumento_cuadro(xptm_instrumento_cuadro item, XRSKDataContext db)
        {
            TOXRSKxptm_instrumento_cuadro(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKxptm_instrumento_cuadro(xptm_instrumento_cuadro item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKxptm_instrumento_cuadro(item, db);
        }

        private void TOXRSKxptm_instrumento_cuadro(xptm_instrumento_cuadro item, XRSKDataContext db)
        {
            amoiva = item.amoiva;
            cantot = item.cantot;
            cappen = item.cappen;
            codescenario = item.codescenario;
            date_created = item.date_created;
            date_updated = item.date_updated;
            docser = item.docser;
            fecha = item.fecha;
            gastos = item.gastos;
            impamo = item.impamo;
            impcuo = item.impcuo;
            impcuototal = item.impcuototal;
            impint = item.impint;
            impiva = item.impiva;
            intiva = item.intiva;
            lstdel = item.lstdel;
            numcuo = item.numcuo;
            numdias = item.numdias;
            porint = item.porint;
            poriva = item.poriva;
            realsimulado = item.realsimulado;
            simulacion = item.simulacion;
            user_created = item.user_created;
            user_updated = item.user_updated;
            linid = item.linid;


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKxptm_instrumento_cuadro> TOXRSKxptm_instrumento_cuadro(List<xptm_instrumento_cuadro> items)
        {
            List<XRSKxptm_instrumento_cuadro> elemList = new List<XRSKxptm_instrumento_cuadro>();
            foreach (xptm_instrumento_cuadro item in items)
            {
                elemList.Add(new XRSKxptm_instrumento_cuadro(item));
            }

            return elemList;
        }

        private IQueryable<xptm_instrumento_cuadro> aplicarSeguridad(IQueryable<xptm_instrumento_cuadro> query)
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

        private IQueryable<xptm_instrumento_cuadro> aplicarFiltro(IQueryable<xptm_instrumento_cuadro> query, FilterModel filter)
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
        public List<XRSKxptm_instrumento_cuadro> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create xptm_instrumento_cuadro entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<xptm_instrumento_cuadro> items = db.xptm_instrumento_cuadro.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKxptm_instrumento_cuadro(items);
        }

        public List<XRSKxptm_instrumento_cuadro> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.xptm_instrumento_cuadro//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKxptm_instrumento_cuadro(query.ToList());
        }

        public XRSKxptm_instrumento_cuadro Find(int linid)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(linid, db);
        }// end Find method

        public XRSKxptm_instrumento_cuadro Find(int linid, XRSKDataContext db)
        {
            xptm_instrumento_cuadro item = db.xptm_instrumento_cuadro.Find(linid);
            TOXRSKxptm_instrumento_cuadro(item);
            return this;
        }
        #endregion

        #region Persistencia
        private xptm_instrumento_cuadro before_insert(XRSKDataContext db, xptm_instrumento_cuadro next)
        {
            return next;
        }// end before_insert method

        private xptm_instrumento_cuadro before_update(XRSKDataContext db, xptm_instrumento_cuadro prev, xptm_instrumento_cuadro next)
        {
            return next;
        }// end before_update method

        private xptm_instrumento_cuadro before_delete(XRSKDataContext db, xptm_instrumento_cuadro prev)
        {
            return prev;
        }// end before_delete method

        private xptm_instrumento_cuadro after_insert(XRSKDataContext db, xptm_instrumento_cuadro next)
        {
            return next;
        }// end after_insert method

        private xptm_instrumento_cuadro after_update(XRSKDataContext db, xptm_instrumento_cuadro prev, xptm_instrumento_cuadro next)
        {
            return next;
        }// end after_update method

        public XRSKxptm_instrumento_cuadro save()
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

        public XRSKxptm_instrumento_cuadro save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            xptm_instrumento_cuadro item = db.xptm_instrumento_cuadro.Find(linid);
            xptm_instrumento_cuadro previous = new xptm_instrumento_cuadro();
            // Change data
            if (item == null)
            {
                item = new xptm_instrumento_cuadro();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.amoiva = amoiva;
            item.cantot = cantot;
            item.cappen = cappen;
            item.codescenario = codescenario;
            item.date_created = date_created;
            item.date_updated = date_updated;
            item.docser = docser;
            item.fecha = fecha;
            item.gastos = gastos;
            item.impamo = impamo;
            item.impcuo = impcuo;
            item.impcuototal = impcuototal;
            item.impint = impint;
            item.impiva = impiva;
            item.intiva = intiva;
            item.lstdel = lstdel;
            item.numcuo = numcuo;
            item.numdias = numdias;
            item.porint = porint;
            item.poriva = poriva;
            item.realsimulado = realsimulado;
            item.simulacion = simulacion;
            item.user_created = user_created;
            item.user_updated = user_updated;
            item.linid = linid;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.xptm_instrumento_cuadro.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKxptm_instrumento_cuadro(item, db);

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

        public XRSKxptm_instrumento_cuadro save(XRSKDataContext db, List<XRSKxptm_instrumento_cuadro> elemsList)
        {
            foreach (XRSKxptm_instrumento_cuadro currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKxptm_instrumento_cuadro delete()
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

        public XRSKxptm_instrumento_cuadro delete(XRSKDataContext db)
        {
            // Get Entity
            xptm_instrumento_cuadro item = db.xptm_instrumento_cuadro.Find(linid);
            // Before_Delete call
            item = before_delete(db, item);

            db.xptm_instrumento_cuadro.Remove(item);
            db.SaveChanges();

            // Change data
            item.amoiva = 0;
            item.cantot = null;
            item.cappen = 0;
            item.codescenario = null;
            item.date_created = DateTime.Today;
            item.date_updated = DateTime.Today;
            item.docser = null;
            item.fecha = DateTime.Today;
            item.gastos = 0;
            item.impamo = 0;
            item.impcuo = 0;
            item.impcuototal = 0;
            item.impint = 0;
            item.impiva = 0;
            item.intiva = 0;
            item.lstdel = null;
            item.numcuo = 0;
            item.numdias = 0;
            item.porint = 0;
            item.poriva = 0;
            item.realsimulado = null;
            item.simulacion = null;
            item.user_created = null;
            item.user_updated = null;
            item.linid = 0;


            return this;
        }// end delete method with method
        #endregion
    }
}
