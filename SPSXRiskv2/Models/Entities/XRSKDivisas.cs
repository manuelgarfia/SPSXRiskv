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
/// Code generated 14/08/2020 11:09:11 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKDivisas : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("DIVDescripcion")]
        public string DIVDescripcion { get; set; }
        [JsonProperty("DIVDifHora")]
        public Int16? DIVDifHora { get; set; }
        [JsonProperty("DIVFesDomingo")]
        public bool DIVFesDomingo { get; set; }
        [JsonProperty("DIVFesJueves")]
        public bool DIVFesJueves { get; set; }
        [JsonProperty("DIVFesLunes")]
        public bool DIVFesLunes { get; set; }
        [JsonProperty("DIVFesMartes")]
        public bool DIVFesMartes { get; set; }
        [JsonProperty("DIVFesMiercoles")]
        public bool DIVFesMiercoles { get; set; }
        [JsonProperty("DIVFesSabado")]
        public bool DIVFesSabado { get; set; }
        [JsonProperty("DIVFesViernes")]
        public bool DIVFesViernes { get; set; }
        [JsonProperty("DIVGenero")]
        public string DIVGenero { get; set; }
        [JsonProperty("DIVGrupo")]
        public string DIVGrupo { get; set; }
        [JsonProperty("DIVHoraFin")]
        public DateTime? DIVHoraFin { get; set; }
        [JsonProperty("DIVHoraInicio")]
        public DateTime? DIVHoraInicio { get; set; }
        [JsonProperty("DIVNumDecPres")]
        public Int16 DIVNumDecPres { get; set; }
        [JsonProperty("DIVNumEnterPres")]
        public Int16 DIVNumEnterPres { get; set; }
        [JsonProperty("DIVPais")]
        public string? DIVPais { get; set; }
        [JsonProperty("DIVRelCodCsb")]
        public string? DIVRelCodCsb { get; set; }
        [JsonProperty("DIVNiv")]
        public string DIVNiv { get; set; }
        [JsonProperty("DIVCod")]
        public string DIVCod { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKDivisas()
        {
        }

        public XRSKDivisas(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKDivisas(Divisas item)
        {
            TOXRSKDivisas(item);
        }

        public XRSKDivisas(Divisas item, XRSKDataContext db)
        {
            TOXRSKDivisas(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKDivisas(Divisas item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKDivisas(item, db);
        }

        private void TOXRSKDivisas(Divisas item, XRSKDataContext db)
        {
            DIVDescripcion = item.DIVDescripcion;
            DIVDifHora = item.DIVDifHora;
            DIVFesDomingo = item.DIVFesDomingo;
            DIVFesJueves = item.DIVFesJueves;
            DIVFesLunes = item.DIVFesLunes;
            DIVFesMartes = item.DIVFesMartes;
            DIVFesMiercoles = item.DIVFesMiercoles;
            DIVFesSabado = item.DIVFesSabado;
            DIVFesViernes = item.DIVFesViernes;
            DIVGenero = item.DIVGenero;
            DIVGrupo = item.DIVGrupo;
            DIVHoraFin = item.DIVHoraFin;
            DIVHoraInicio = item.DIVHoraInicio;
            DIVNumDecPres = item.DIVNumDecPres;
            DIVNumEnterPres = item.DIVNumEnterPres;
            DIVPais = item.DIVPais;
            DIVRelCodCsb = item.DIVRelCodCsb;
            DIVNiv = item.DIVNiv;
            DIVCod = item.DIVCod;


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKDivisas> TOXRSKDivisas(List<Divisas> items)
        {
            List<XRSKDivisas> elemList = new List<XRSKDivisas>();
            foreach (Divisas item in items)
            {
                elemList.Add(new XRSKDivisas(item));
            }

            return elemList;
        }

        private IQueryable<Divisas> aplicarSeguridad(IQueryable<Divisas> query)
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

        private IQueryable<Divisas> aplicarFiltro(IQueryable<Divisas> query, FilterModel filter)
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
        public List<XRSKDivisas> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create Divisas entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<Divisas> items = db.Divisas.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKDivisas(items);
        }

        public List<XRSKDivisas> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.Divisas//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKDivisas(query.ToList());
        }

        public XRSKDivisas Find(string DIVNiv, string DIVCod)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(DIVNiv, DIVCod, db);
        }// end Find method

        public XRSKDivisas Find(string DIVNiv, string DIVCod, XRSKDataContext db)
        {
            Divisas item = db.Divisas.Find(DIVNiv, DIVCod);
            TOXRSKDivisas(item);
            return this;
        }
        #endregion

        #region Persistencia
        private Divisas before_insert(XRSKDataContext db, Divisas next)
        {
            return next;
        }// end before_insert method

        private Divisas before_update(XRSKDataContext db, Divisas prev, Divisas next)
        {
            return next;
        }// end before_update method

        private Divisas before_delete(XRSKDataContext db, Divisas prev)
        {
            return prev;
        }// end before_delete method

        private Divisas after_insert(XRSKDataContext db, Divisas next)
        {
            return next;
        }// end after_insert method

        private Divisas after_update(XRSKDataContext db, Divisas prev, Divisas next)
        {
            return next;
        }// end after_update method

        public XRSKDivisas save()
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

        public XRSKDivisas save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            Divisas item = db.Divisas.Find(DIVNiv, DIVCod);
            Divisas previous = new Divisas();
            // Change data
            if (item == null)
            {
                item = new Divisas();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.DIVDescripcion = DIVDescripcion;
            item.DIVDifHora = DIVDifHora;
            item.DIVFesDomingo = DIVFesDomingo;
            item.DIVFesJueves = DIVFesJueves;
            item.DIVFesLunes = DIVFesLunes;
            item.DIVFesMartes = DIVFesMartes;
            item.DIVFesMiercoles = DIVFesMiercoles;
            item.DIVFesSabado = DIVFesSabado;
            item.DIVFesViernes = DIVFesViernes;
            item.DIVGenero = DIVGenero;
            item.DIVGrupo = DIVGrupo;
            item.DIVHoraFin = DIVHoraFin;
            item.DIVHoraInicio = DIVHoraInicio;
            item.DIVNumDecPres = DIVNumDecPres;
            item.DIVNumEnterPres = DIVNumEnterPres;
            item.DIVPais = DIVPais;
            item.DIVRelCodCsb = DIVRelCodCsb;
            item.DIVNiv = DIVNiv;
            item.DIVCod = DIVCod;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.Divisas.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKDivisas(item, db);

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

        public XRSKDivisas save(XRSKDataContext db, List<XRSKDivisas> elemsList)
        {
            foreach (XRSKDivisas currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKDivisas delete()
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

        public XRSKDivisas delete(XRSKDataContext db)
        {
            // Get Entity
            Divisas item = db.Divisas.Find(DIVNiv, DIVCod);
            // Before_Delete call
            item = before_delete(db, item);

            db.Divisas.Remove(item);
            db.SaveChanges();

            // Change data
            item.DIVDescripcion = null;
            item.DIVDifHora = 0;
            item.DIVFesDomingo = false;
            item.DIVFesJueves = false;
            item.DIVFesLunes = false;
            item.DIVFesMartes = false;
            item.DIVFesMiercoles = false;
            item.DIVFesSabado = false;
            item.DIVFesViernes = false;
            item.DIVGenero = null;
            item.DIVGrupo = null;
            item.DIVHoraFin = DateTime.Today;
            item.DIVHoraInicio = DateTime.Today;
            item.DIVNumDecPres = 0;
            item.DIVNumEnterPres = 0;
            item.DIVPais = null;
            item.DIVRelCodCsb = null;
            item.DIVNiv = null;
            item.DIVCod = null;


            return this;
        }// end delete method with method
        #endregion
    }
}
