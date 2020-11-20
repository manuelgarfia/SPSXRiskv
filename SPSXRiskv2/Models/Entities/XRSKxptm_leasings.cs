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
/// Code generated 29/10/2020 9:44:31 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKxptm_leasings : XRSKEntity
    {
        #region Propiedades
		[JsonProperty("amortfija")]
        public decimal? amortfija { get; set; }
        [JsonProperty("basedias")]
        public int basedias { get; set; }
        [JsonProperty("bonificacion")]
        public decimal bonificacion { get; set; }
        [JsonProperty("broker")]
        public decimal broker { get; set; }
        [JsonProperty("calendario")]
        public string? calendario { get; set; }
        [JsonProperty("carencia")]
        public int carencia { get; set; }
        [JsonProperty("centrocoste")]
        public string? centrocoste { get; set; }
        [JsonProperty("codser")]
        public string codser { get; set; }
        [JsonProperty("comapertura")]
        public decimal comapertura { get; set; }
        [JsonProperty("comcancpromotor")]
        public decimal comcancpromotor { get; set; }
        [JsonProperty("comcanparcial")]
        public decimal comcanparcial { get; set; }
        [JsonProperty("comcantotal")]
        public decimal comcantotal { get; set; }
        [JsonProperty("comdemora")]
        public decimal comdemora { get; set; }
        [JsonProperty("comestudio")]
        public decimal comestudio { get; set; }
        [JsonProperty("comreclamacion")]
        public decimal comreclamacion { get; set; }
        [JsonProperty("comsubrogacion")]
        public decimal comsubrogacion { get; set; }
        [JsonProperty("convFechas")]
        public string? convFechas { get; set; }
        [JsonProperty("correo")]
        public decimal correo { get; set; }
        [JsonProperty("ctafinanciera")]
        public string? ctafinanciera { get; set; }
        [JsonProperty("ctamovimientos")]
        public string? ctamovimientos { get; set; }
        [JsonProperty("date_created")]
        public DateTime date_created { get; set; }
        [JsonProperty("date_updated")]
        public DateTime date_updated { get; set; }
        [JsonProperty("descripcion")]
        public string? descripcion { get; set; }
        [JsonProperty("diapago")]
        public int diapago { get; set; }
        [JsonProperty("diarevision")]
        public int diarevision { get; set; }
        [JsonProperty("diasfixingdate")]
        public int diasfixingdate { get; set; }
        [JsonProperty("diferencial")]
        public decimal diferencial { get; set; }
        [JsonProperty("difsubrogacion")]
        public string? difsubrogacion { get; set; }
        [JsonProperty("docser")]
        public string docser { get; set; }
        [JsonProperty("empresa")]
        public string empresa { get; set; }
        [JsonProperty("entidad")]
        public string? entidad { get; set; }
        [JsonProperty("estado")]
        public string estado { get; set; }
        [JsonProperty("fecha1cuota")]
        public DateTime? fecha1cuota { get; set; }
        [JsonProperty("fecha1liq")]
        public DateTime? fecha1liq { get; set; }
        [JsonProperty("fecha1revision")]
        public DateTime? fecha1revision { get; set; }
        [JsonProperty("fechacontabauto")]
        public DateTime? fechacontabauto { get; set; }
        [JsonProperty("fechacontrato")]
        public DateTime? fechacontrato { get; set; }
        [JsonProperty("fechadispinicial")]
        public DateTime? fechadispinicial { get; set; }
        [JsonProperty("fechaestado")]
        public DateTime fechaestado { get; set; }
        [JsonProperty("fechaVR")]
        public DateTime? fechaVR { get; set; }
        [JsonProperty("fechavto")]
        public DateTime? fechavto { get; set; }
        [JsonProperty("formula")]
        public string? formula { get; set; }
        [JsonProperty("fredondeo")]
        public int fredondeo { get; set; }
        [JsonProperty("hay1liq")]
        public bool hay1liq { get; set; }
        [JsonProperty("interesesprepag")]
        public bool interesesprepag { get; set; }
        [JsonProperty("interesini")]
        public decimal? interesini { get; set; }
        [JsonProperty("mesescomerciales")]
        public bool mesescomerciales { get; set; }
        [JsonProperty("nominal")]
        public decimal? nominal { get; set; }
        [JsonProperty("numpagos")]
        public int numpagos { get; set; }
        [JsonProperty("pctinteres")]
        public decimal pctinteres { get; set; }
        [JsonProperty("pctsubvencionado")]
        public decimal? pctsubvencionado { get; set; }
        [JsonProperty("peramo")]
        public int peramo { get; set; }
        [JsonProperty("perliq")]
        public int perliq { get; set; }
        [JsonProperty("perliqcarencia")]
        public int perliqcarencia { get; set; }
        [JsonProperty("perrevision")]
        public int perrevision { get; set; }
        [JsonProperty("refcot")]
        public string refcot { get; set; }
        [JsonProperty("tipo")]
        public string tipo { get; set; }
        [JsonProperty("user_created")]
        public string user_created { get; set; }
        [JsonProperty("user_updated")]
        public string user_updated { get; set; }
        [JsonProperty("valorresidual")]
        public decimal? valorresidual { get; set; }
        [JsonProperty("cabid")]
        public int cabid { get; set; }

        public decimal calculoCP { get; set; }
        public string descripcionEmpresa { get; set; }
        public string descripcionEntidad { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKxptm_leasings()
        {
        }

        public XRSKxptm_leasings(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKxptm_leasings(xptm_leasings item)
        {
            TOXRSKxptm_leasings(item);
        }

        public XRSKxptm_leasings(xptm_leasings item, XRSKDataContext db)
        {
            TOXRSKxptm_leasings(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKxptm_leasings(xptm_leasings item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKxptm_leasings(item, db);
        }

        private void TOXRSKxptm_leasings(xptm_leasings item, XRSKDataContext db)
        {
            amortfija = item.amortfija;
            basedias = item.basedias;
            bonificacion = item.bonificacion;
            broker = item.broker;
            calendario = item.calendario;
            carencia = item.carencia;
            centrocoste = item.centrocoste;
            codser = item.codser;
            comapertura = item.comapertura;
            comcancpromotor = item.comcancpromotor;
            comcanparcial = item.comcanparcial;
            comcantotal = item.comcantotal;
            comdemora = item.comdemora;
            comestudio = item.comestudio;
            comreclamacion = item.comreclamacion;
            comsubrogacion = item.comsubrogacion;
            convFechas = item.convFechas;
            correo = item.correo;
            ctafinanciera = item.ctafinanciera;
            ctamovimientos = item.ctamovimientos;
            date_created = item.date_created;
            date_updated = item.date_updated;
            descripcion = item.descripcion;
            diapago = item.diapago;
            diarevision = item.diarevision;
            diasfixingdate = item.diasfixingdate;
            diferencial = item.diferencial;
            difsubrogacion = item.difsubrogacion;
            docser = item.docser;
            empresa = item.empresa;
            entidad = item.entidad;
            estado = item.estado;
            fecha1cuota = item.fecha1cuota;
            fecha1liq = item.fecha1liq;
            fecha1revision = item.fecha1revision;
            fechacontabauto = item.fechacontabauto;
            fechacontrato = item.fechacontrato;
            fechadispinicial = item.fechadispinicial;
            fechaestado = item.fechaestado;
            fechaVR = item.fechaVR;
            fechavto = item.fechavto;
            formula = item.formula;
            fredondeo = item.fredondeo;
            hay1liq = item.hay1liq;
            interesesprepag = item.interesesprepag;
            interesini = item.interesini;
            mesescomerciales = item.mesescomerciales;
            nominal = item.nominal;
            numpagos = item.numpagos;
            pctinteres = item.pctinteres;
            pctsubvencionado = item.pctsubvencionado;
            peramo = item.peramo;
            perliq = item.perliq;
            perliqcarencia = item.perliqcarencia;
            perrevision = item.perrevision;
            refcot = item.refcot;
            tipo = item.tipo;
            user_created = item.user_created;
            user_updated = item.user_updated;
            valorresidual = item.valorresidual;
            cabid = item.cabid;

            XRSKxptm_movimientos movs = new XRSKxptm_movimientos();
            calculoCP = movs.getSumImporte(docser);

            XRSKCompanyia empresas = new XRSKCompanyia();
            descripcionEmpresa = empresas.GetDescripcionEmpresa(empresa);

            XRSKEntidad entidades = new XRSKEntidad();
            descripcionEntidad = entidades.GetDescripcionEntidad(entidad);
        }

        private List<XRSKxptm_leasings> TOXRSKxptm_leasings(List<xptm_leasings> items)
        {
            List<XRSKxptm_leasings> elemList = new List<XRSKxptm_leasings>();
            foreach (xptm_leasings item in items)
            {
                elemList.Add(new XRSKxptm_leasings(item));
            }

            return elemList;
        }

        private IQueryable<xptm_leasings> aplicarSeguridad(IQueryable<xptm_leasings> query)
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
                            query = query.Where(x => bd.companies.Contains(x.empresa));
                        }
                    }
                }
            }
            return query;
        }

        private IQueryable<xptm_leasings> aplicarFiltro(IQueryable<xptm_leasings> query, FilterModel filter)
        {
            foreach (FilterDetailModel detail in filter.detail)
            {
                // Filtering sample, uncomment and change it at your own if your consider
                // if (detail.type.Equals("date"))
                // {
                // switch (detail.subtype)
                // {
                // case "range":
                // if (detail.entity.Equals("MVFFechOperac"))
                // {
                // query = query.Where(x => x.MVFFechOperac >= detail.from && x.MVFFechOperac <= detail.to);
                // }
                // break;
                // }
                // }

                // if (detail.type.Equals("number"))
                // {
                // switch (detail.subtype)
                // {
                // case ">=":
                // if (detail.entity.Equals("MVFImBrDivisa"))
                // {
                // query = query.Where(x => x.MVFImBrDivisa >= (Double)detail.decValue);
                // }
                // break;
                // case "<=":
                // if (detail.entity.Equals("MVFImBrDivisa"))
                // {
                // query = query.Where(x => x.MVFImBrDivisa <= (Double)detail.decValue);
                // }
                // break;
                // case "range":
                // if (detail.entity.Equals("MVFImBrDivisa"))
                // {
                // query = query.Where(x => x.MVFImBrDivisa >= (Double)detail.decValue && x.MVFImBrDivisa <= (Double)detail.importMax);
                // }
                // break;
                // }
                // }

                // if (detail.type.Equals("string") && detail.charValue != "")
                // {
                // switch (detail.subtype)
                // {
                // case "contains":
                // if (detail.entity.Equals("MVFRefXRisk"))
                // {
                // query = query.Where(x => x.MVFRefXRisk.ToString().Contains(detail.charValue));
                // }
                // break;
                // case "starts":
                // if (detail.entity.Equals("MVFRefXRisk"))
                // {
                // query = query.Where(x => x.MVFRefXRisk.ToString().StartsWith("P"));
                // }
                // break;
                // case "ends":
                // if (detail.entity.Equals("MVFRefXRisk"))
                // {
                // query = query.Where(x => x.MVFRefXRisk.ToString().Contains(detail.charValue));
                // }
                // break;
                // }
                // }

                // Elementos
                if (detail.type.Equals("items") && detail.values != null && detail.values.Length != 0)
                {
                    if (detail.entity.Equals("empresa"))
                    {
                        if (detail.values.Length.Equals(1))
                        {
                            query = query.Where(x => x.empresa.Equals(detail.values[0]));
                        }
                        else
                        {
                            query = query.Where(x => detail.values.Contains(x.empresa));
                        }
                    }

                    if (detail.entity.Equals("entidad"))
                    {
                        if (detail.values.Length.Equals(1))
                        {
                            query = query.Where(x => x.entidad.Equals(detail.values[0]));
                        }
                        else
                        {
                            query = query.Where(x => detail.values.Contains(x.entidad));
                        }
                    }
                }
            }

            return query;
        }
        #endregion

        #region Public Methods
        public List<XRSKxptm_leasings> GetList(ClaimsPrincipal user)
        {
            XRSKDataContext db = new XRSKDataContext();
            List<XRSKxptm_leasings> leasingsList = new List<XRSKxptm_leasings>();
            /// You have to create xptm_leasings entry at SPSXRiskv2\Models\XRSKDataContext.cs
            //List<xptm_leasings> items = db.xptm_leasings.
            //    // Include(x => x.Companyia).
            //    ToList();

            if (Usuario.Grupos != null)
            {
                foreach (XRSKFocUsuariosGrupos grupo in Usuario.Grupos)
                {
                    if (grupo.BasesDatos != null)
                    {
                        foreach (XSRKBasesDatosGrupo bd in grupo.BasesDatos)
                        {
                            var query = from x in db.xptm_leasings
                                        select x;

                            query = query.Where(x => bd.companies.Contains(x.empresa));

                            query.ToList();

                            leasingsList = TOXRSKxptm_leasings(query.ToList());
                        }
                    }
                }
            }

            return leasingsList;
        }

        public List<XRSKxptm_leasings> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.xptm_leasings//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKxptm_leasings(query.ToList());
        }

        public XRSKxptm_leasings Find(int cabid)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(cabid, db);
        }// end Find method

        public XRSKxptm_leasings Find(int cabid, XRSKDataContext db)
        {
            xptm_leasings item = db.xptm_leasings.Find(cabid);
            TOXRSKxptm_leasings(item);
            return this;
        }
        #endregion

        #region Persistencia
        private xptm_leasings before_insert(XRSKDataContext db, xptm_leasings next)
        {
            return next;
        }// end before_insert method

        private xptm_leasings before_update(XRSKDataContext db, xptm_leasings prev, xptm_leasings next)
        {
            return next;
        }// end before_update method

        private xptm_leasings before_delete(XRSKDataContext db, xptm_leasings prev)
        {
            return prev;
        }// end before_delete method

        private xptm_leasings after_insert(XRSKDataContext db, xptm_leasings next)
        {
            return next;
        }// end after_insert method

        private xptm_leasings after_update(XRSKDataContext db, xptm_leasings prev, xptm_leasings next)
        {
            return next;
        }// end after_update method

        public XRSKxptm_leasings save()
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

        public XRSKxptm_leasings save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            xptm_leasings item = db.xptm_leasings.Find(cabid);
            xptm_leasings previous = new xptm_leasings();
            // Change data
            if (item == null)
            {
                item = new xptm_leasings();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.amortfija = amortfija;
item.basedias = basedias;
item.bonificacion = bonificacion;
item.broker = broker;
item.calendario = calendario;
item.carencia = carencia;
item.centrocoste = centrocoste;
item.codser = codser;
item.comapertura = comapertura;
item.comcancpromotor = comcancpromotor;
item.comcanparcial = comcanparcial;
item.comcantotal = comcantotal;
item.comdemora = comdemora;
item.comestudio = comestudio;
item.comreclamacion = comreclamacion;
item.comsubrogacion = comsubrogacion;
item.convFechas = convFechas;
item.correo = correo;
item.ctafinanciera = ctafinanciera;
item.ctamovimientos = ctamovimientos;
item.date_created = date_created;
item.date_updated = date_updated;
item.descripcion = descripcion;
item.diapago = diapago;
item.diarevision = diarevision;
item.diasfixingdate = diasfixingdate;
item.diferencial = diferencial;
item.difsubrogacion = difsubrogacion;
item.docser = docser;
item.empresa = empresa;
item.entidad = entidad;
item.estado = estado;
item.fecha1cuota = fecha1cuota;
item.fecha1liq = fecha1liq;
item.fecha1revision = fecha1revision;
item.fechacontabauto = fechacontabauto;
item.fechacontrato = fechacontrato;
item.fechadispinicial = fechadispinicial;
item.fechaestado = fechaestado;
item.fechaVR = fechaVR;
item.fechavto = fechavto;
item.formula = formula;
item.fredondeo = fredondeo;
item.hay1liq = hay1liq;
item.interesesprepag = interesesprepag;
item.interesini = interesini;
item.mesescomerciales = mesescomerciales;
item.nominal = nominal;
item.numpagos = numpagos;
item.pctinteres = pctinteres;
item.pctsubvencionado = pctsubvencionado;
item.peramo = peramo;
item.perliq = perliq;
item.perliqcarencia = perliqcarencia;
item.perrevision = perrevision;
item.refcot = refcot;
item.tipo = tipo;
item.user_created = user_created;
item.user_updated = user_updated;
item.valorresidual = valorresidual;
item.cabid = cabid;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.xptm_leasings.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKxptm_leasings(item, db);

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

        public XRSKxptm_leasings save(XRSKDataContext db, List<XRSKxptm_leasings> elemsList)
        {
            foreach (XRSKxptm_leasings currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKxptm_leasings delete()
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

        public XRSKxptm_leasings delete(XRSKDataContext db)
        {
            // Get Entity
            xptm_leasings item = db.xptm_leasings.Find(cabid);
            // Before_Delete call
            item = before_delete(db, item);

            db.xptm_leasings.Remove(item);
            db.SaveChanges();

            // Change data
            item.amortfija = 0;
item.basedias = 0;
item.bonificacion = 0;
item.broker = 0;
item.calendario = null;
item.carencia = 0;
item.centrocoste = null;
item.codser = null;
item.comapertura = 0;
item.comcancpromotor = 0;
item.comcanparcial = 0;
item.comcantotal = 0;
item.comdemora = 0;
item.comestudio = 0;
item.comreclamacion = 0;
item.comsubrogacion = 0;
item.convFechas = null;
item.correo = 0;
item.ctafinanciera = null;
item.ctamovimientos = null;
item.date_created = DateTime.Today;
item.date_updated = DateTime.Today;
item.descripcion = null;
item.diapago = 0;
item.diarevision = 0;
item.diasfixingdate = 0;
item.diferencial = 0;
item.difsubrogacion = null;
item.docser = null;
item.empresa = null;
item.entidad = null;
item.estado = null;
item.fecha1cuota = DateTime.Today;
item.fecha1liq = DateTime.Today;
item.fecha1revision = DateTime.Today;
item.fechacontabauto = DateTime.Today;
item.fechacontrato = DateTime.Today;
item.fechadispinicial = DateTime.Today;
item.fechaestado = DateTime.Today;
item.fechaVR = DateTime.Today;
item.fechavto = DateTime.Today;
item.formula = null;
item.fredondeo = 0;
item.hay1liq = false;
item.interesesprepag = false;
item.interesini = 0;
item.mesescomerciales = false;
item.nominal = 0;
item.numpagos = 0;
item.pctinteres = 0;
item.pctsubvencionado = 0;
item.peramo = 0;
item.perliq = 0;
item.perliqcarencia = 0;
item.perrevision = 0;
item.refcot = null;
item.tipo = null;
item.user_created = null;
item.user_updated = null;
item.valorresidual = 0;
item.cabid = 0;


            return this;
        }// end delete method with method
        #endregion
    }
}
