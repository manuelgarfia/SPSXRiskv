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
/// Code generated 14/09/2020 13:21:33 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKvw_fac_AsignarFacturaHeader : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("ABCCodCIA")]
        public string ABCCodCIA { get; set; }
        [JsonProperty("ABCCodCTA")]
        public string ABCCodCTA { get; set; }
        [JsonProperty("ABCComple")]
        public string ABCComple { get; set; }
        [JsonProperty("ABCFechOper")]
        public DateTime? ABCFechOper { get; set; }
        [JsonProperty("ABCFechVal")]
        public DateTime? ABCFechVal { get; set; }
        [JsonProperty("ABCImporteSigno")]
        public decimal? ABCImporteSigno { get; set; }
        [JsonProperty("ABCNumerador")]
        public double ABCNumerador { get; set; }
        [JsonProperty("CodDiv")]
        public string CodDiv { get; set; }
        [JsonProperty("Codigo")]
        public string? Codigo { get; set; }
        [JsonProperty("Descripcion")]
        public string? Descripcion { get; set; }
        [JsonProperty("MVFrefXrisk")]
        public double MVFrefXrisk { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKvw_fac_AsignarFacturaHeader()
        {
        }

        public XRSKvw_fac_AsignarFacturaHeader(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKvw_fac_AsignarFacturaHeader(vw_fac_AsignarFacturaHeader item)
        {
            TOXRSKvw_fac_AsignarFacturaHeader(item);
        }

        public XRSKvw_fac_AsignarFacturaHeader(vw_fac_AsignarFacturaHeader item, XRSKDataContext db)
        {
            TOXRSKvw_fac_AsignarFacturaHeader(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKvw_fac_AsignarFacturaHeader(vw_fac_AsignarFacturaHeader item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKvw_fac_AsignarFacturaHeader(item, db);
        }

        private void TOXRSKvw_fac_AsignarFacturaHeader(vw_fac_AsignarFacturaHeader item, XRSKDataContext db)
        {
            ABCCodCIA = item.ABCCodCIA;
            ABCCodCTA = item.ABCCodCTA;
            ABCComple = item.ABCComple;
            ABCFechOper = item.ABCFechOper;
            ABCFechVal = item.ABCFechVal;
            ABCImporteSigno = item.ABCImporteSigno;
            ABCNumerador = item.ABCNumerador;
            CodDiv = item.CodDiv;
            Codigo = item.Codigo;
            Descripcion = item.Descripcion;
            MVFrefXrisk = item.MVFrefXrisk;


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKvw_fac_AsignarFacturaHeader> TOXRSKvw_fac_AsignarFacturaHeader(List<vw_fac_AsignarFacturaHeader> items)
        {
            List<XRSKvw_fac_AsignarFacturaHeader> elemList = new List<XRSKvw_fac_AsignarFacturaHeader>();
            foreach (vw_fac_AsignarFacturaHeader item in items)
            {
                elemList.Add(new XRSKvw_fac_AsignarFacturaHeader(item));
            }

            return elemList;
        }

        private IQueryable<vw_fac_AsignarFacturaHeader> aplicarSeguridad(IQueryable<vw_fac_AsignarFacturaHeader> query)
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

        private IQueryable<vw_fac_AsignarFacturaHeader> aplicarFiltro(IQueryable<vw_fac_AsignarFacturaHeader> query, FilterModel filter)
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
        public List<XRSKvw_fac_AsignarFacturaHeader> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create vw_fac_AsignarFacturaHeader entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<vw_fac_AsignarFacturaHeader> items = db.vw_fac_AsignarFacturaHeader.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKvw_fac_AsignarFacturaHeader(items);
        }

        public List<XRSKvw_fac_AsignarFacturaHeader> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.vw_fac_AsignarFacturaHeader//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKvw_fac_AsignarFacturaHeader(query.ToList());
        }

        public XRSKvw_fac_AsignarFacturaHeader GetFacturaHeader(int ABCNumerador)
        {
            XRSKDataContext db = new XRSKDataContext();
            return GetFacturaHeader(ABCNumerador, db);
        }// end Find method

        public XRSKvw_fac_AsignarFacturaHeader GetFacturaHeader(int ABCNumerador, XRSKDataContext db)
        {
            vw_fac_AsignarFacturaHeader item = db.vw_fac_AsignarFacturaHeader.Where(x => x.ABCNumerador == ABCNumerador).FirstOrDefault();
            TOXRSKvw_fac_AsignarFacturaHeader(item);
            return this;
        }
        #endregion

        #region Persistencia
        private vw_fac_AsignarFacturaHeader before_insert(XRSKDataContext db, vw_fac_AsignarFacturaHeader next)
        {
            return next;
        }// end before_insert method

        private vw_fac_AsignarFacturaHeader before_update(XRSKDataContext db, vw_fac_AsignarFacturaHeader prev, vw_fac_AsignarFacturaHeader next)
        {
            return next;
        }// end before_update method

        private vw_fac_AsignarFacturaHeader before_delete(XRSKDataContext db, vw_fac_AsignarFacturaHeader prev)
        {
            return prev;
        }// end before_delete method

        private vw_fac_AsignarFacturaHeader after_insert(XRSKDataContext db, vw_fac_AsignarFacturaHeader next)
        {
            return next;
        }// end after_insert method

        private vw_fac_AsignarFacturaHeader after_update(XRSKDataContext db, vw_fac_AsignarFacturaHeader prev, vw_fac_AsignarFacturaHeader next)
        {
            return next;
        }// end after_update method

        public XRSKvw_fac_AsignarFacturaHeader save()
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

        public XRSKvw_fac_AsignarFacturaHeader save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            vw_fac_AsignarFacturaHeader item = db.vw_fac_AsignarFacturaHeader.Find();
            vw_fac_AsignarFacturaHeader previous = new vw_fac_AsignarFacturaHeader();
            // Change data
            if (item == null)
            {
                item = new vw_fac_AsignarFacturaHeader();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.ABCCodCIA = ABCCodCIA;
            item.ABCCodCTA = ABCCodCTA;
            item.ABCComple = ABCComple;
            item.ABCFechOper = ABCFechOper;
            item.ABCFechVal = ABCFechVal;
            item.ABCImporteSigno = ABCImporteSigno;
            item.ABCNumerador = ABCNumerador;
            item.CodDiv = CodDiv;
            item.Codigo = Codigo;
            item.Descripcion = Descripcion;
            item.MVFrefXrisk = MVFrefXrisk;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.vw_fac_AsignarFacturaHeader.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKvw_fac_AsignarFacturaHeader(item, db);

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

        public XRSKvw_fac_AsignarFacturaHeader save(XRSKDataContext db, List<XRSKvw_fac_AsignarFacturaHeader> elemsList)
        {
            foreach (XRSKvw_fac_AsignarFacturaHeader currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKvw_fac_AsignarFacturaHeader delete()
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

        public XRSKvw_fac_AsignarFacturaHeader delete(XRSKDataContext db)
        {
            // Get Entity
            vw_fac_AsignarFacturaHeader item = db.vw_fac_AsignarFacturaHeader.Find();
            // Before_Delete call
            item = before_delete(db, item);

            db.vw_fac_AsignarFacturaHeader.Remove(item);
            db.SaveChanges();

            // Change data
            item.ABCCodCIA = null;
            item.ABCCodCTA = null;
            item.ABCComple = null;
            item.ABCFechOper = DateTime.Today;
            item.ABCFechVal = DateTime.Today;
            item.ABCImporteSigno = 0;
            item.ABCNumerador = 0;
            item.CodDiv = null;
            item.Codigo = null;
            item.Descripcion = null;
            item.MVFrefXrisk = 0;


            return this;
        }// end delete method with method
        #endregion
    }
}
