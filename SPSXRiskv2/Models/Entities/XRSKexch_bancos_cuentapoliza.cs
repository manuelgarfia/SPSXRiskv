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
/// Code generated 29/09/2020 13:11:41 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKexch_bancos_cuentapoliza : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("abierto")]
        public bool abierto { get; set; }
        [JsonProperty("banco")]
        public string banco { get; set; }
        [JsonProperty("calendario")]
        public string? calendario { get; set; }
        [JsonProperty("clavepais")]
        public string? clavepais { get; set; }
        [JsonProperty("codigo")]
        public string codigo { get; set; }
        [JsonProperty("codproveedor")]
        public string? codproveedor { get; set; }
        [JsonProperty("convfechas")]
        public string? convfechas { get; set; }
        [JsonProperty("ctactble")]
        public string? ctactble { get; set; }
        [JsonProperty("ctafinanciacion")]
        public string? ctafinanciacion { get; set; }
        [JsonProperty("date_created")]
        public DateTime date_created { get; set; }
        [JsonProperty("date_updated")]
        public DateTime date_updated { get; set; }
        [JsonProperty("descripcion")]
        public string? descripcion { get; set; }
        [JsonProperty("diasfijacion")]
        public int? diasfijacion { get; set; }
        [JsonProperty("divisa")]
        public string divisa { get; set; }
        [JsonProperty("divisaCSB")]
        public string? divisaCSB { get; set; }
        [JsonProperty("divisoractivo")]
        public int divisoractivo { get; set; }
        [JsonProperty("divisorpasivo")]
        public int divisorpasivo { get; set; }
        [JsonProperty("empresa")]
        public string empresa { get; set; }
        [JsonProperty("fechaaltacontrato")]
        public DateTime? fechaaltacontrato { get; set; }
        [JsonProperty("fechabaja")]
        public DateTime? fechabaja { get; set; }
        [JsonProperty("fechaproxrenovacion")]
        public DateTime? fechaproxrenovacion { get; set; }
        [JsonProperty("fecharenovacion")]
        public DateTime? fecharenovacion { get; set; }
        [JsonProperty("fechaultimoextracto")]
        public DateTime? fechaultimoextracto { get; set; }
        [JsonProperty("fechaultliquid")]
        public DateTime? fechaultliquid { get; set; }
        [JsonProperty("fechaultrevision")]
        public DateTime? fechaultrevision { get; set; }
        [JsonProperty("fechavencimiento")]
        public DateTime? fechavencimiento { get; set; }
        [JsonProperty("formulaliquid")]
        public string? formulaliquid { get; set; }
        [JsonProperty("iban")]
        public string iban { get; set; }
        [JsonProperty("limitedivisa")]
        public decimal? limitedivisa { get; set; }
        [JsonProperty("limitemn")]
        public decimal? limitemn { get; set; }
        [JsonProperty("multidivisa")]
        public bool? multidivisa { get; set; }
        [JsonProperty("numcuenta")]
        public string numcuenta { get; set; }
        [JsonProperty("oficina")]
        public string oficina { get; set; }
        [JsonProperty("oficinaalt")]
        public string? oficinaalt { get; set; }
        [JsonProperty("pctcomapertura")]
        public double? pctcomapertura { get; set; }
        [JsonProperty("pctcomnodisp")]
        public double? pctcomnodisp { get; set; }
        [JsonProperty("pcttiporefactivofijado")]
        public decimal? pcttiporefactivofijado { get; set; }
        [JsonProperty("pcttiporefexcedfijado")]
        public decimal? pcttiporefexcedfijado { get; set; }
        [JsonProperty("pcttiporefpasivofijado")]
        public decimal? pcttiporefpasivofijado { get; set; }
        [JsonProperty("periodicidadliquid")]
        public int? periodicidadliquid { get; set; }
        [JsonProperty("periodicidadrevision")]
        public int? periodicidadrevision { get; set; }
        [JsonProperty("saldoultimoextr")]
        public decimal? saldoultimoextr { get; set; }
        [JsonProperty("signosaldoultextr")]
        public int? signosaldoultextr { get; set; }
        [JsonProperty("spreadactivo")]
        public decimal? spreadactivo { get; set; }
        [JsonProperty("spreadexced")]
        public double? spreadexced { get; set; }
        [JsonProperty("spreadpasivo")]
        public decimal? spreadpasivo { get; set; }
        [JsonProperty("tipolinea")]
        public string tipolinea { get; set; }
        [JsonProperty("tipoperiodliquid")]
        public string tipoperiodliquid { get; set; }
        [JsonProperty("tipoperiodrevision")]
        public string tipoperiodrevision { get; set; }
        [JsonProperty("tiporefactivo")]
        public string? tiporefactivo { get; set; }
        [JsonProperty("tiporefactivofijado")]
        public bool? tiporefactivofijado { get; set; }
        [JsonProperty("tiporefexced")]
        public string? tiporefexced { get; set; }
        [JsonProperty("tiporefexcedfijado")]
        public bool? tiporefexcedfijado { get; set; }
        [JsonProperty("tiporefpasivo")]
        public string? tiporefpasivo { get; set; }
        [JsonProperty("tiporefpasivofijado")]
        public bool? tiporefpasivofijado { get; set; }
        [JsonProperty("ultimodiafechaliq")]
        public bool? ultimodiafechaliq { get; set; }
        [JsonProperty("ultimodiarevision")]
        public bool? ultimodiarevision { get; set; }
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
        public XRSKexch_bancos_cuentapoliza()
        {
        }

        public XRSKexch_bancos_cuentapoliza(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKexch_bancos_cuentapoliza(exch_bancos_cuentapoliza item)
        {
            TOXRSKexch_bancos_cuentapoliza(item);
        }

        public XRSKexch_bancos_cuentapoliza(exch_bancos_cuentapoliza item, XRSKDataContext db)
        {
            TOXRSKexch_bancos_cuentapoliza(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKexch_bancos_cuentapoliza(exch_bancos_cuentapoliza item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKexch_bancos_cuentapoliza(item, db);
        }

        private void TOXRSKexch_bancos_cuentapoliza(exch_bancos_cuentapoliza item, XRSKDataContext db)
        {
            abierto = item.abierto;
            banco = item.banco;
            calendario = item.calendario;
            clavepais = item.clavepais;
            codigo = item.codigo;
            codproveedor = item.codproveedor;
            convfechas = item.convfechas;
            ctactble = item.ctactble;
            ctafinanciacion = item.ctafinanciacion;
            date_created = item.date_created;
            date_updated = item.date_updated;
            descripcion = item.descripcion;
            diasfijacion = item.diasfijacion;
            divisa = item.divisa;
            divisaCSB = item.divisaCSB;
            divisoractivo = item.divisoractivo;
            divisorpasivo = item.divisorpasivo;
            empresa = item.empresa;
            fechaaltacontrato = item.fechaaltacontrato;
            fechabaja = item.fechabaja;
            fechaproxrenovacion = item.fechaproxrenovacion;
            fecharenovacion = item.fecharenovacion;
            fechaultimoextracto = item.fechaultimoextracto;
            fechaultliquid = item.fechaultliquid;
            fechaultrevision = item.fechaultrevision;
            fechavencimiento = item.fechavencimiento;
            formulaliquid = item.formulaliquid;
            iban = item.iban;
            limitedivisa = item.limitedivisa;
            limitemn = item.limitemn;
            multidivisa = item.multidivisa;
            numcuenta = item.numcuenta;
            oficina = item.oficina;
            oficinaalt = item.oficinaalt;
            pctcomapertura = item.pctcomapertura;
            pctcomnodisp = item.pctcomnodisp;
            pcttiporefactivofijado = item.pcttiporefactivofijado;
            pcttiporefexcedfijado = item.pcttiporefexcedfijado;
            pcttiporefpasivofijado = item.pcttiporefpasivofijado;
            periodicidadliquid = item.periodicidadliquid;
            periodicidadrevision = item.periodicidadrevision;
            saldoultimoextr = item.saldoultimoextr;
            signosaldoultextr = item.signosaldoultextr;
            spreadactivo = item.spreadactivo;
            spreadexced = item.spreadexced;
            spreadpasivo = item.spreadpasivo;
            tipolinea = item.tipolinea;
            tipoperiodliquid = item.tipoperiodliquid;
            tipoperiodrevision = item.tipoperiodrevision;
            tiporefactivo = item.tiporefactivo;
            tiporefactivofijado = item.tiporefactivofijado;
            tiporefexced = item.tiporefexced;
            tiporefexcedfijado = item.tiporefexcedfijado;
            tiporefpasivo = item.tiporefpasivo;
            tiporefpasivofijado = item.tiporefpasivofijado;
            ultimodiafechaliq = item.ultimodiafechaliq;
            ultimodiarevision = item.ultimodiarevision;
            user_created = item.user_created;
            user_updated = item.user_updated;
            cabid = item.cabid;


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKexch_bancos_cuentapoliza> TOXRSKexch_bancos_cuentapoliza(List<exch_bancos_cuentapoliza> items)
        {
            List<XRSKexch_bancos_cuentapoliza> elemList = new List<XRSKexch_bancos_cuentapoliza>();
            foreach (exch_bancos_cuentapoliza item in items)
            {
                elemList.Add(new XRSKexch_bancos_cuentapoliza(item));
            }

            return elemList;
        }

        private IQueryable<exch_bancos_cuentapoliza> aplicarSeguridad(IQueryable<exch_bancos_cuentapoliza> query)
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

        private IQueryable<exch_bancos_cuentapoliza> aplicarFiltro(IQueryable<exch_bancos_cuentapoliza> query, FilterModel filter)
        {

            XRSKContratosSaldos contratos = new XRSKContratosSaldos();

            foreach (FilterDetailModel detail in filter.detail)
            {
                // Filtering sample, uncomment and change it at your own if your consider
                if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_DATE))
                {
                    switch (detail.subtype)
                    {
                        case XRSKConstantes.FILTER_SUBTYPE_RANGE:
                            if (detail.entity.Equals("fechaultimoextracto"))
                            {
                                query = query.Where(x => x.fechaultimoextracto == detail.from );
                            }
                            break;

                    }
                }

                //Elementos
                 if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_ITEMS) && detail.values != null && detail.values.Length != 0)
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
                    if (detail.entity.Equals("entidades"))
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
                    if (detail.entity.Equals("contrato"))
                    {
                        if (detail.values.Length.Equals(1))
                        {
                            query = query.Where(x => x.ctactble.Equals(detail.values[0]));
                        }
                        else
                        {
                            query = query.Where(x => detail.values.Contains(x.ctactble));
                        }
                    }
                    if (detail.entity.Equals("divisa"))
                    {
                        if (detail.values.Length.Equals(1))
                        {
                            query = query.Where(x => x.divisa.Equals(detail.values[0]));
                        }
                        else
                        {
                            query = query.Where(x => detail.values.Contains(x.divisa));
                        }
                    }
                }
            }

            return query;
        }
        #endregion

        #region Public Methods
        public List<XRSKexch_bancos_cuentapoliza> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create exch_bancos_cuentapoliza entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<exch_bancos_cuentapoliza> items = db.exch_bancos_cuentapoliza.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKexch_bancos_cuentapoliza(items);
        }

        public XRSKexch_bancos_cuentapoliza GetCuentaCorriente(string company, string contrato)
        {

            XRSKDataContext db = new XRSKDataContext();
            /// You have to create exch_bancos_cuentapoliza entry at SPSXRiskv2\Models\XRSKDataContext.cs
            exch_bancos_cuentapoliza item = db.exch_bancos_cuentapoliza.
                            Where(x => x.empresa == company && x.codigo == contrato).FirstOrDefault();

            XRSKexch_bancos_cuentapoliza poliza = new XRSKexch_bancos_cuentapoliza(item);

            return poliza;
        }

        public List<XRSKexch_bancos_cuentapoliza> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.exch_bancos_cuentapoliza//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKexch_bancos_cuentapoliza(query.ToList());
        }

        public XRSKexch_bancos_cuentapoliza Find(int cabid)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(cabid, db);
        }// end Find method

        public XRSKexch_bancos_cuentapoliza Find(int cabid, XRSKDataContext db)
        {
            exch_bancos_cuentapoliza item = db.exch_bancos_cuentapoliza.Find(cabid);
            TOXRSKexch_bancos_cuentapoliza(item);
            return this;
        }
        #endregion

        #region Persistencia
        private exch_bancos_cuentapoliza before_insert(XRSKDataContext db, exch_bancos_cuentapoliza next)
        {
            return next;
        }// end before_insert method

        private exch_bancos_cuentapoliza before_update(XRSKDataContext db, exch_bancos_cuentapoliza prev, exch_bancos_cuentapoliza next)
        {
            return next;
        }// end before_update method

        private exch_bancos_cuentapoliza before_delete(XRSKDataContext db, exch_bancos_cuentapoliza prev)
        {
            return prev;
        }// end before_delete method

        private exch_bancos_cuentapoliza after_insert(XRSKDataContext db, exch_bancos_cuentapoliza next)
        {
            return next;
        }// end after_insert method

        private exch_bancos_cuentapoliza after_update(XRSKDataContext db, exch_bancos_cuentapoliza prev, exch_bancos_cuentapoliza next)
        {
            return next;
        }// end after_update method

        public XRSKexch_bancos_cuentapoliza save()
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

        public XRSKexch_bancos_cuentapoliza save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            exch_bancos_cuentapoliza item = db.exch_bancos_cuentapoliza.Find(cabid);
            exch_bancos_cuentapoliza previous = new exch_bancos_cuentapoliza();
            // Change data
            if (item == null)
            {
                item = new exch_bancos_cuentapoliza();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.abierto = abierto;
            item.banco = banco;
            item.calendario = calendario;
            item.clavepais = clavepais;
            item.codigo = codigo;
            item.codproveedor = codproveedor;
            item.convfechas = convfechas;
            item.ctactble = ctactble;
            item.ctafinanciacion = ctafinanciacion;
            item.date_created = date_created;
            item.date_updated = date_updated;
            item.descripcion = descripcion;
            item.diasfijacion = diasfijacion;
            item.divisa = divisa;
            item.divisaCSB = divisaCSB;
            item.divisoractivo = divisoractivo;
            item.divisorpasivo = divisorpasivo;
            item.empresa = empresa;
            item.fechaaltacontrato = fechaaltacontrato;
            item.fechabaja = fechabaja;
            item.fechaproxrenovacion = fechaproxrenovacion;
            item.fecharenovacion = fecharenovacion;
            item.fechaultimoextracto = fechaultimoextracto;
            item.fechaultliquid = fechaultliquid;
            item.fechaultrevision = fechaultrevision;
            item.fechavencimiento = fechavencimiento;
            item.formulaliquid = formulaliquid;
            item.iban = iban;
            item.limitedivisa = limitedivisa;
            item.limitemn = limitemn;
            item.multidivisa = multidivisa;
            item.numcuenta = numcuenta;
            item.oficina = oficina;
            item.oficinaalt = oficinaalt;
            item.pctcomapertura = pctcomapertura;
            item.pctcomnodisp = pctcomnodisp;
            item.pcttiporefactivofijado = pcttiporefactivofijado;
            item.pcttiporefexcedfijado = pcttiporefexcedfijado;
            item.pcttiporefpasivofijado = pcttiporefpasivofijado;
            item.periodicidadliquid = periodicidadliquid;
            item.periodicidadrevision = periodicidadrevision;
            item.saldoultimoextr = saldoultimoextr;
            item.signosaldoultextr = signosaldoultextr;
            item.spreadactivo = spreadactivo;
            item.spreadexced = spreadexced;
            item.spreadpasivo = spreadpasivo;
            item.tipolinea = tipolinea;
            item.tipoperiodliquid = tipoperiodliquid;
            item.tipoperiodrevision = tipoperiodrevision;
            item.tiporefactivo = tiporefactivo;
            item.tiporefactivofijado = tiporefactivofijado;
            item.tiporefexced = tiporefexced;
            item.tiporefexcedfijado = tiporefexcedfijado;
            item.tiporefpasivo = tiporefpasivo;
            item.tiporefpasivofijado = tiporefpasivofijado;
            item.ultimodiafechaliq = ultimodiafechaliq;
            item.ultimodiarevision = ultimodiarevision;
            item.user_created = user_created;
            item.user_updated = user_updated;
            item.cabid = cabid;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.exch_bancos_cuentapoliza.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKexch_bancos_cuentapoliza(item, db);

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

        public XRSKexch_bancos_cuentapoliza save(XRSKDataContext db, List<XRSKexch_bancos_cuentapoliza> elemsList)
        {
            foreach (XRSKexch_bancos_cuentapoliza currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKexch_bancos_cuentapoliza delete()
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

        public XRSKexch_bancos_cuentapoliza delete(XRSKDataContext db)
        {
            // Get Entity
            exch_bancos_cuentapoliza item = db.exch_bancos_cuentapoliza.Find(cabid);
            // Before_Delete call
            item = before_delete(db, item);

            db.exch_bancos_cuentapoliza.Remove(item);
            db.SaveChanges();

            // Change data
            item.abierto = false;
            item.banco = null;
            item.calendario = null;
            item.clavepais = null;
            item.codigo = null;
            item.codproveedor = null;
            item.convfechas = null;
            item.ctactble = null;
            item.ctafinanciacion = null;
            item.date_created = DateTime.Today;
            item.date_updated = DateTime.Today;
            item.descripcion = null;
            item.diasfijacion = 0;
            item.divisa = null;
            item.divisaCSB = null;
            item.divisoractivo = 0;
            item.divisorpasivo = 0;
            item.empresa = null;
            item.fechaaltacontrato = DateTime.Today;
            item.fechabaja = DateTime.Today;
            item.fechaproxrenovacion = DateTime.Today;
            item.fecharenovacion = DateTime.Today;
            item.fechaultimoextracto = DateTime.Today;
            item.fechaultliquid = DateTime.Today;
            item.fechaultrevision = DateTime.Today;
            item.fechavencimiento = DateTime.Today;
            item.formulaliquid = null;
            item.iban = null;
            item.limitedivisa = 0;
            item.limitemn = 0;
            item.multidivisa = false;
            item.numcuenta = null;
            item.oficina = null;
            item.oficinaalt = null;
            item.pctcomapertura = 0;
            item.pctcomnodisp = 0;
            item.pcttiporefactivofijado = 0;
            item.pcttiporefexcedfijado = 0;
            item.pcttiporefpasivofijado = 0;
            item.periodicidadliquid = 0;
            item.periodicidadrevision = 0;
            item.saldoultimoextr = 0;
            item.signosaldoultextr = 0;
            item.spreadactivo = 0;
            item.spreadexced = 0;
            item.spreadpasivo = 0;
            item.tipolinea = null;
            item.tipoperiodliquid = null;
            item.tipoperiodrevision = null;
            item.tiporefactivo = null;
            item.tiporefactivofijado = false;
            item.tiporefexced = null;
            item.tiporefexcedfijado = false;
            item.tiporefpasivo = null;
            item.tiporefpasivofijado = false;
            item.ultimodiafechaliq = false;
            item.ultimodiarevision = false;
            item.user_created = null;
            item.user_updated = null;
            item.cabid = 0;


            return this;
        }// end delete method with method
        #endregion
    }
}
