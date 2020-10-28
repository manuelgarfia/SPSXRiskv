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
/// Code generated 15/09/2020 10:54:28 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKEfectos : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("abcnumerador")]
        public double? abcnumerador { get; set; }
        [JsonProperty("Asiento")]
        public string Asiento { get; set; }
        [JsonProperty("AsientoContable")]
        public string AsientoContable { get; set; }
        [JsonProperty("Cambio")]
        public decimal Cambio { get; set; }
        [JsonProperty("ClaseEfecto")]
        public string? ClaseEfecto { get; set; }
        [JsonProperty("CodigoCliente")]
        public string CodigoCliente { get; set; }
        [JsonProperty("CuentaContable")]
        public string? CuentaContable { get; set; }
        [JsonProperty("CuentaFinanciera")]
        public string? CuentaFinanciera { get; set; }
        [JsonProperty("empresa")]
        public string empresa { get; set; }
        [JsonProperty("Enviado")]
        public bool? Enviado { get; set; }
        [JsonProperty("Error")]
        public string? Error { get; set; }
        [JsonProperty("EstadoEfecto")]
        public string EstadoEfecto { get; set; }
        [JsonProperty("Factura")]
        public string? Factura { get; set; }
        [JsonProperty("FechaFactura")]
        public DateTime? FechaFactura { get; set; }
        [JsonProperty("FechaVto")]
        public DateTime? FechaVto { get; set; }
        [JsonProperty("Iban")]
        public string? Iban { get; set; }
        [JsonProperty("idProcesoCarga")]
        public DateTime? idProcesoCarga { get; set; }
        [JsonProperty("Importe")]
        public double? Importe { get; set; }
        [JsonProperty("ImporteDivisa")]
        public double? ImporteDivisa { get; set; }
        [JsonProperty("Lote")]
        public string? Lote { get; set; }
        [JsonProperty("Moneda")]
        public string? Moneda { get; set; }
        [JsonProperty("mvfcodcia")]
        public string? mvfcodcia { get; set; }
        [JsonProperty("mvfrefxrisk")]
        public double? mvfrefxrisk { get; set; }
        [JsonProperty("NombreCliente")]
        public string? NombreCliente { get; set; }
        [JsonProperty("notas")]
        public string? notas { get; set; }
        [JsonProperty("Recibo")]
        public string? Recibo { get; set; }
        [JsonProperty("Remesa")]
        public string? Remesa { get; set; }
        [JsonProperty("TipoEfecto")]
        public string TipoEfecto { get; set; }
        [JsonProperty("traspasado")]
        public bool traspasado { get; set; }
        [JsonProperty("id")]
        public int id { get; set; }
        public int contador { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKEfectos()
        {
        }

        public XRSKEfectos(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKEfectos(Efectos item)
        {
            TOXRSKEfectos(item);
        }

        public XRSKEfectos(Efectos item, XRSKDataContext db)
        {
            TOXRSKEfectos(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKEfectos(Efectos item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKEfectos(item, db);
        }

        private void TOXRSKEfectos(Efectos item, XRSKDataContext db)
        {
            abcnumerador = item.abcnumerador;
            Asiento = item.Asiento;
            AsientoContable = item.AsientoContable;
            Cambio = item.Cambio;
            ClaseEfecto = item.ClaseEfecto;
            CodigoCliente = item.CodigoCliente;
            CuentaContable = item.CuentaContable;
            CuentaFinanciera = item.CuentaFinanciera;
            empresa = item.empresa;
            Enviado = item.Enviado;
            Error = item.Error;
            EstadoEfecto = item.EstadoEfecto;
            Factura = item.Factura;
            FechaFactura = item.FechaFactura;
            FechaVto = item.FechaVto;
            Iban = item.Iban;
            idProcesoCarga = item.idProcesoCarga;
            Importe = item.Importe;
            ImporteDivisa = item.ImporteDivisa;
            Lote = item.Lote;
            Moneda = item.Moneda;
            mvfcodcia = item.mvfcodcia;
            mvfrefxrisk = item.mvfrefxrisk;
            NombreCliente = item.NombreCliente;
            notas = item.notas;
            Recibo = item.Recibo;
            Remesa = item.Remesa;
            TipoEfecto = item.TipoEfecto;
            traspasado = item.traspasado;
            id = item.id;
            


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKEfectos> TOXRSKEfectos(List<Efectos> items)
        {
            List<XRSKEfectos> elemList = new List<XRSKEfectos>();
            foreach (Efectos item in items)
            {
                elemList.Add(new XRSKEfectos(item));
            }

            return elemList;
        }

        private IQueryable<Efectos> aplicarSeguridad(IQueryable<Efectos> query)
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

        private IQueryable<Efectos> aplicarFiltro(IQueryable<Efectos> query, FilterModel filter)
        {
            foreach (FilterDetailModel detail in filter.detail)
            {
                // Filtering sample, uncomment and change it at your own if your consider
                // if (detail.type.Equals("date"))
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
        public List<XRSKEfectos> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create Efectos entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<Efectos> items = db.Efectos.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKEfectos(items);
        }

        public List<XRSKEfectos> GetListEfectosCliente(string cliente)
        {
            XRSKDataContext db = new XRSKDataContext();

            double numeradorCliente = Convert.ToDouble(cliente);

            /// You have to create Efectos entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<Efectos> items = db.Efectos.
                Where(x => x.abcnumerador == numeradorCliente).
                ToList();
            return TOXRSKEfectos(items);
        }

        public List<XRSKEfectos> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.Efectos//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKEfectos(query.ToList());
        }

        public List<XRSKEfectos> GetCliente(string codigo)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.Efectos.Where(x => x.CodigoCliente == codigo)
                        select x;

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKEfectos(query.ToList());
        }

        public List<XRSKEfectos> GetMovimiento(int movimiento)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.Efectos.Where(x => x.mvfrefxrisk == movimiento)
                        select x;

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKEfectos(query.ToList());
        }

        public XRSKEfectos Find(int id)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(id, db);
        }// end Find method

        public XRSKEfectos Find(int id, XRSKDataContext db)
        {
            Efectos item = db.Efectos.Find(id);
            TOXRSKEfectos(item);
            return this;
        }

        public List<carteraEfectos> GetClienteList() // Manolo: Se hace un merge con la api XRSKCarteraEfectos
        {
           
            List<XRSKEfectos> efectosClientes = new List<XRSKEfectos>();
            XRSKDataContext db = new XRSKDataContext();

            //var query = from x in db.Efectos
            //            select x;
            //query = (IQueryable<Efectos>)query.GroupBy(x => new { x.CodigoCliente, x.NombreCliente, x.Importe })
            //                                  .Where(y => y.Sum(p => p.Importe) != 0)
            //                                  .Select new 
            //                                  {
            //                                      CodigoCliente =y.Key.CodigoCliente,
            //                                      NombreCliente =x.Key.NombreCliente,
            //                                      //contador = grp.Count(),
            //                                      Importe = grp.Key.Importe
            //                                  });
            var query = from x in db.carteraEfectos
                        select x;
                        
                       




            return (query.ToList()); 
        }





        #endregion

        #region Persistencia
        private Efectos before_insert(XRSKDataContext db, Efectos next)
        {
            return next;
        }// end before_insert method

        private Efectos before_update(XRSKDataContext db, Efectos prev, Efectos next)
        {
            return next;
        }// end before_update method

        private Efectos before_delete(XRSKDataContext db, Efectos prev)
        {
            return prev;
        }// end before_delete method

        private Efectos after_insert(XRSKDataContext db, Efectos next)
        {
            return next;
        }// end after_insert method

        private Efectos after_update(XRSKDataContext db, Efectos prev, Efectos next)
        {
            return next;
        }// end after_update method

        public XRSKEfectos save()
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

        public XRSKEfectos save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            Efectos item = db.Efectos.Find(id);
            Efectos previous = new Efectos();
            // Change data
            if (item == null)
            {
                item = new Efectos();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.abcnumerador = abcnumerador;
            item.Asiento = Asiento;
            item.AsientoContable = AsientoContable;
            item.Cambio = Cambio;
            item.ClaseEfecto = ClaseEfecto;
            item.CodigoCliente = CodigoCliente;
            item.CuentaContable = CuentaContable;
            item.CuentaFinanciera = CuentaFinanciera;
            item.empresa = empresa;
            item.Enviado = Enviado;
            item.Error = Error;
            item.EstadoEfecto = EstadoEfecto;
            item.Factura = Factura;
            item.FechaFactura = FechaFactura;
            item.FechaVto = FechaVto;
            item.Iban = Iban;
            item.idProcesoCarga = idProcesoCarga;
            item.Importe = Importe;
            item.ImporteDivisa = ImporteDivisa;
            item.Lote = Lote;
            item.Moneda = Moneda;
            item.mvfcodcia = mvfcodcia;
            item.mvfrefxrisk = mvfrefxrisk;
            item.NombreCliente = NombreCliente;
            item.notas = notas;
            item.Recibo = Recibo;
            item.Remesa = Remesa;
            item.TipoEfecto = TipoEfecto;
            item.traspasado = traspasado;
            item.id = id;

            if (isInsert)
            {
                item = before_insert(db, item);
                db.Efectos.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKEfectos(item, db);

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

        public XRSKEfectos save(XRSKDataContext db, List<XRSKEfectos> elemsList)
        {
            foreach (XRSKEfectos currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKEfectos delete()
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

        public XRSKEfectos delete(XRSKDataContext db)
        {
            // Get Entity
            Efectos item = db.Efectos.Find(id);
            // Before_Delete call
            item = before_delete(db, item);

            db.Efectos.Remove(item);
            db.SaveChanges();

            // Change data
            item.abcnumerador = 0;
            item.Asiento = null;
            item.AsientoContable = null;
            item.Cambio = 0;
            item.ClaseEfecto = null;
            item.CodigoCliente = null;
            item.CuentaContable = null;
            item.CuentaFinanciera = null;
            item.empresa = null;
            item.Enviado = false;
            item.Error = null;
            item.EstadoEfecto = null;
            item.Factura = null;
            item.FechaFactura = null;
            item.FechaVto = null;
            item.Iban = null;
            item.idProcesoCarga = DateTime.Today;
            item.Importe = 0;
            item.ImporteDivisa = 0;
            item.Lote = null;
            item.Moneda = null;
            item.mvfcodcia = null;
            item.mvfrefxrisk = 0;
            item.NombreCliente = null;
            item.notas = null;
            item.Recibo = null;
            item.Remesa = null;
            item.TipoEfecto = null;
            item.traspasado = false;
            item.id = 0;


            return this;
        }// end delete method with method
        #endregion
    }
}
