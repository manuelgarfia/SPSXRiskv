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
/// Code generated 07/10/2020 12:52:21 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKOperacion : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("OPEAccesorios")]
        public bool OPEAccesorios { get; set; }
        [JsonProperty("OPECertif")]
        public bool OPECertif { get; set; }
        [JsonProperty("OPECodAOP")]
        public string? OPECodAOP { get; set; }
        [JsonProperty("OPECodCont")]
        public string? OPECodCont { get; set; }
        [JsonProperty("OPECodCPT")]
        public string? OPECodCPT { get; set; }
        [JsonProperty("OPEComCambio")]
        public bool OPEComCambio { get; set; }
        [JsonProperty("OPEComisiones")]
        public bool OPEComisiones { get; set; }
        [JsonProperty("OPEContabil")]
        public bool OPEContabil { get; set; }
        [JsonProperty("OPEContAgrup")]
        public string OPEContAgrup { get; set; }
        [JsonProperty("OPEContrapartida")]
        public bool? OPEContrapartida { get; set; }
        [JsonProperty("OPEDescripcion")]
        public string OPEDescripcion { get; set; }
        [JsonProperty("OPEDesMovDef")]
        public string OPEDesMovDef { get; set; }
        [JsonProperty("OPEDivisa")]
        public bool OPEDivisa { get; set; }
        [JsonProperty("OPEFechaVto")]
        public bool OPEFechaVto { get; set; }
        [JsonProperty("OPEGastos")]
        public bool OPEGastos { get; set; }
        [JsonProperty("OPEIntereses")]
        public bool OPEIntereses { get; set; }
        [JsonProperty("OPENivAOP")]
        public string? OPENivAOP { get; set; }
        [JsonProperty("OPENivCPT")]
        public string? OPENivCPT { get; set; }
        [JsonProperty("OPENomRefAgrup")]
        public string? OPENomRefAgrup { get; set; }
        [JsonProperty("OPENomRefExt")]
        public string? OPENomRefExt { get; set; }
        [JsonProperty("OPERefSist")]
        public bool OPERefSist { get; set; }
        [JsonProperty("OPESignoAcces")]
        public Int16 OPESignoAcces { get; set; }
        [JsonProperty("OPESignoOper")]
        public Int16 OPESignoOper { get; set; }
        [JsonProperty("OPETipoInteres")]
        public bool OPETipoInteres { get; set; }
        [JsonProperty("OPETipoOper")]
        public string OPETipoOper { get; set; }
        [JsonProperty("OPEGrupo")]
        public string OPEGrupo { get; set; }
        [JsonProperty("OPENiv")]
        public string OPENiv { get; set; }
        [JsonProperty("OPECod")]
        public string OPECod { get; set; }
        [JsonProperty("OPENivTLI")]
        public string OPENivTLI { get; set; }
        [JsonProperty("OPECodTLI")]
        public string OPECodTLI { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKOperacion()
        {
        }

        public XRSKOperacion(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKOperacion(Operacion item)
        {
            TOXRSKOperacion(item);
        }

        public XRSKOperacion(Operacion item, XRSKDataContext db)
        {
            TOXRSKOperacion(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKOperacion(Operacion item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKOperacion(item, db);
        }

        private void TOXRSKOperacion(Operacion item, XRSKDataContext db)
        {
            OPEAccesorios = item.OPEAccesorios;
            OPECertif = item.OPECertif;
            OPECodAOP = item.OPECodAOP;
            OPECodCont = item.OPECodCont;
            OPECodCPT = item.OPECodCPT;
            OPEComCambio = item.OPEComCambio;
            OPEComisiones = item.OPEComisiones;
            OPEContabil = item.OPEContabil;
            OPEContAgrup = item.OPEContAgrup;
            OPEContrapartida = item.OPEContrapartida;
            OPEDescripcion = item.OPEDescripcion;
            OPEDesMovDef = item.OPEDesMovDef;
            OPEDivisa = item.OPEDivisa;
            OPEFechaVto = item.OPEFechaVto;
            OPEGastos = item.OPEGastos;
            OPEIntereses = item.OPEIntereses;
            OPENivAOP = item.OPENivAOP;
            OPENivCPT = item.OPENivCPT;
            OPENomRefAgrup = item.OPENomRefAgrup;
            OPENomRefExt = item.OPENomRefExt;
            OPERefSist = item.OPERefSist;
            OPESignoAcces = item.OPESignoAcces;
            OPESignoOper = item.OPESignoOper;
            OPETipoInteres = item.OPETipoInteres;
            OPETipoOper = item.OPETipoOper;
            OPEGrupo = item.OPEGrupo;
            OPENiv = item.OPENiv;
            OPECod = item.OPECod;
            OPENivTLI = item.OPENivTLI;
            OPECodTLI = item.OPECodTLI;


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKOperacion> TOXRSKOperacion(List<Operacion> items)
        {
            List<XRSKOperacion> elemList = new List<XRSKOperacion>();
            foreach (Operacion item in items)
            {
                elemList.Add(new XRSKOperacion(item));
            }

            return elemList;
        }

        private IQueryable<Operacion> aplicarSeguridad(IQueryable<Operacion> query)
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

        private IQueryable<Operacion> aplicarFiltro(IQueryable<Operacion> query, FilterModel filter)
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
        public List<XRSKOperacion> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create Operacion entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<Operacion> items = db.Operacion.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKOperacion(items);
        }

        public List<XRSKOperacion> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.Operacion//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKOperacion(query.ToList());
        }

        public XRSKOperacion Find(string OPEGrupo, string OPENiv, string OPECod, string OPENivTLI, string OPECodTLI)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(OPEGrupo, OPENiv, OPECod, OPENivTLI, OPECodTLI, db);
        }// end Find method

        public XRSKOperacion Find(string OPEGrupo, string OPENiv, string OPECod, string OPENivTLI, string OPECodTLI, XRSKDataContext db)
        {
            Operacion item = db.Operacion.Find(OPEGrupo, OPENiv, OPECod, OPENivTLI, OPECodTLI);
            TOXRSKOperacion(item);
            return this;
        }

        public List<XRSKOperacion> GetDistinctList()
        {
            List<XRSKOperacion> opeList = new List<XRSKOperacion>();
            XRSKDataContext db = new XRSKDataContext();

            List<Operacion> items = db.Operacion.ToList().Distinct().ToList();

            items = GetDistinctOperacion(items);

            foreach (Operacion item in items)
            {
                opeList.Add(new XRSKOperacion(item));
            }

            return opeList;
        }

        public Operacion GetOperacion(string codigo)
        {
            XRSKDataContext db = new XRSKDataContext();
            Operacion op = db.Operacion.Where(b => b.OPECod == codigo).FirstOrDefault();

            return op;
        }

        public List<Operacion> GetDistinctOperacion(List<Operacion> item)
        {
            IEnumerable<Operacion> enumerable = item.GroupBy(x => x.OPECod).Select(x => x.FirstOrDefault());
            List<Operacion> asList = enumerable.ToList();

            return asList;
        }
        #endregion

        #region Persistencia
        private Operacion before_insert(XRSKDataContext db, Operacion next)
        {
            return next;
        }// end before_insert method

        private Operacion before_update(XRSKDataContext db, Operacion prev, Operacion next)
        {
            return next;
        }// end before_update method

        private Operacion before_delete(XRSKDataContext db, Operacion prev)
        {
            return prev;
        }// end before_delete method

        private Operacion after_insert(XRSKDataContext db, Operacion next)
        {
            return next;
        }// end after_insert method

        private Operacion after_update(XRSKDataContext db, Operacion prev, Operacion next)
        {
            return next;
        }// end after_update method

        public XRSKOperacion save()
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

        public XRSKOperacion save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            Operacion item = db.Operacion.Find(OPEGrupo, OPENiv, OPECod, OPENivTLI, OPECodTLI);
            Operacion previous = new Operacion();
            // Change data
            if (item == null)
            {
                item = new Operacion();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.OPEAccesorios = OPEAccesorios;
            item.OPECertif = OPECertif;
            item.OPECodAOP = OPECodAOP;
            item.OPECodCont = OPECodCont;
            item.OPECodCPT = OPECodCPT;
            item.OPEComCambio = OPEComCambio;
            item.OPEComisiones = OPEComisiones;
            item.OPEContabil = OPEContabil;
            item.OPEContAgrup = OPEContAgrup;
            item.OPEContrapartida = OPEContrapartida;
            item.OPEDescripcion = OPEDescripcion;
            item.OPEDesMovDef = OPEDesMovDef;
            item.OPEDivisa = OPEDivisa;
            item.OPEFechaVto = OPEFechaVto;
            item.OPEGastos = OPEGastos;
            item.OPEIntereses = OPEIntereses;
            item.OPENivAOP = OPENivAOP;
            item.OPENivCPT = OPENivCPT;
            item.OPENomRefAgrup = OPENomRefAgrup;
            item.OPENomRefExt = OPENomRefExt;
            item.OPERefSist = OPERefSist;
            item.OPESignoAcces = OPESignoAcces;
            item.OPESignoOper = OPESignoOper;
            item.OPETipoInteres = OPETipoInteres;
            item.OPETipoOper = OPETipoOper;
            item.OPEGrupo = OPEGrupo;
            item.OPENiv = OPENiv;
            item.OPECod = OPECod;
            item.OPENivTLI = OPENivTLI;
            item.OPECodTLI = OPECodTLI;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.Operacion.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKOperacion(item, db);

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

        public XRSKOperacion save(XRSKDataContext db, List<XRSKOperacion> elemsList)
        {
            foreach (XRSKOperacion currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKOperacion delete()
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

        public XRSKOperacion delete(XRSKDataContext db)
        {
            // Get Entity
            Operacion item = db.Operacion.Find(OPEGrupo, OPENiv, OPECod, OPENivTLI, OPECodTLI);
            // Before_Delete call
            item = before_delete(db, item);

            db.Operacion.Remove(item);
            db.SaveChanges();

            // Change data
            item.OPEAccesorios = false;
            item.OPECertif = false;
            item.OPECodAOP = null;
            item.OPECodCont = null;
            item.OPECodCPT = null;
            item.OPEComCambio = false;
            item.OPEComisiones = false;
            item.OPEContabil = false;
            item.OPEContAgrup = null;
            item.OPEContrapartida = false;
            item.OPEDescripcion = null;
            item.OPEDesMovDef = null;
            item.OPEDivisa = false;
            item.OPEFechaVto = false;
            item.OPEGastos = false;
            item.OPEIntereses = false;
            item.OPENivAOP = null;
            item.OPENivCPT = null;
            item.OPENomRefAgrup = null;
            item.OPENomRefExt = null;
            item.OPERefSist = false;
            item.OPESignoAcces = 0;
            item.OPESignoOper = 0;
            item.OPETipoInteres = false;
            item.OPETipoOper = null;
            item.OPEGrupo = null;
            item.OPENiv = null;
            item.OPECod = null;
            item.OPENivTLI = null;
            item.OPECodTLI = null;

            return this;
        }// end delete method with method
        #endregion
    }
}