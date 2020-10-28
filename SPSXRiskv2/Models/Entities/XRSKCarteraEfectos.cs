//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Dynamic.Core;
//using System.Threading.Tasks;
//using SPSXRiskv2.Models.Database;
//using SPSXRiskv2.ViewModels;
//using System.Linq.Expressions;
//using System.IO;
//using System.Security.Claims;

//namespace SPSXRiskv2.Models.Entities
//{
//    public class XRSKCarteraEfectos
//    {
//        #region Propiedades
//        public int id { get; set; }
//        public DateTime? idProcesoCarga { get; set; }
//        public string empresa { get; set; }
//        public string Asiento { get; set; }
//        public string EstadoEfecto { get; set; }
//        public string ClaseEfecto { get; set; }
//        public string TipoEfecto { get; set; }
//        public string AsientoContable { get; set; }
//        public string Factura { get; set; }
//        public string Recibo { get; set; }
//        public string CodigoCliente { get; set; }
//        public string Iban { get; set; }
//        public string CuentaContable { get; set; }
//        public string CuentaFinanciera { get; set; }
//        public string Remesa { get; set; }
//        public string NombreCliente { get; set; }
//        public DateTime? FechaFactura { get; set; }
//        public DateTime? FechaVto { get; set; }
//        public string Moneda { get; set; }
//        public decimal Cambio { get; set; }
//        public double? Importe { get; set; }
//        public double? ImporteDivisa { get; set; }
//        public bool? Enviado { get; set; }
//        public string Error { get; set; }
//        public string mvfcodcia { get; set; }
//        public double? mvfrefxrisk { get; set; }
//        public double? abcnumerador { get; set; }
//        public bool? traspasado { get; set; }
//        public string Lote { get; set; }
//        public string notas { get; set; }

//        public int contador { get; set; }
//        #endregion

//        #region Constructores
//        public XRSKCarteraEfectos()
//        {

//        }

//        //public XRSKCarteraEfectos(ClaimsPrincipal _Usuario) : base(_Usuario)
//        //{
//        //}
//        public XRSKCarteraEfectos(Efectos item)
//        {
//            TOXRSKCarteraEfectos(item);
//        }
//        public XRSKCarteraEfectos(Efectos item, XRSKDataContext db)
//        {
//            TOXRSKCarteraEfectos(item, db);
//        }

//        #endregion

//        #region Private Methods
//        private void TOXRSKCarteraEfectos(Efectos item)
//        {
//            XRSKDataContext db = new XRSKDataContext();
//            TOXRSKCarteraEfectos(item, db);
//        }

//        private void TOXRSKCarteraEfectos(Efectos item, XRSKDataContext db)
//        {
//            id = item.id;
//            //////idProcesoCarga = item.idProcesoCarga;
//            empresa = item.empresa;
//            Asiento = item.Asiento;
//            EstadoEfecto = item.EstadoEfecto;
//            ClaseEfecto = item.ClaseEfecto;
//            TipoEfecto = item.TipoEfecto;
//            AsientoContable = item.AsientoContable;
//            Factura = item.Factura;
//            Recibo = item.Recibo;
//            CodigoCliente = item.CodigoCliente;
//            Iban = item.Iban;
//            CuentaContable = item.CuentaContable;
//            CuentaFinanciera = item.CuentaFinanciera;
//            Remesa = item.Remesa;
//            NombreCliente = item.NombreCliente;
//            FechaFactura = item.FechaFactura;
//            FechaVto = item.FechaVto;
//            Moneda = item.Moneda;
//            Cambio = item.Cambio;
//            Importe = item.Importe;
//            ImporteDivisa = item.ImporteDivisa;
//            Enviado = item.Enviado;
//            Error = item.Error;
//            mvfcodcia = item.mvfcodcia;
//            mvfrefxrisk = item.mvfrefxrisk;
//            abcnumerador = item.abcnumerador;
//            traspasado = item.traspasado;
//            Lote = item.Lote;
//            notas = item.notas;
//            //contador = null;
//        }

//        private List<Efectos> TOXRSKCarteraEfectos(List<Efectos> items)
//        {
//            List<XRSKCarteraEfectos> cartera = new List<XRSKCarteraEfectos>();
//            foreach (Efectos item in items)
//            {
//                cartera.Add(new XRSKCarteraEfectos(item));
//            }
//            return cartera;
//        }
//        #endregion

//        #region Public Methods
//        public List<XRSKCarteraEfectos> GetList()
//        {
//            List<XRSKCarteraEfectos> efectos = new List<XRSKCarteraEfectos>();

//            XRSKDataContext db = new XRSKDataContext();

//            var query = from x in db.Efectos
//                        select x;
//            List<Efectos> items = query.ToList();


//            foreach (Efectos item in items)
//            {
//                efectos.Add(new XRSKCarteraEfectos(item));
//            }

//            return efectos;
//        }



     
       









//        #endregion
//    }
//}
