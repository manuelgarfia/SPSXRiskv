using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.Models.Entities;
using SPSXRiskv2.ViewModels;

namespace SPSXRiskv2.Models.Procesos
{
    public class XRSKConciliacion : XRSKEntity
    {
        #region Propiedades
        public string companyia { get; set; }
        public string operacio { get; set; }
        public List<XRSKMovimientoFisico> moviments { get; set; }
        public List<XRSKApunteBancario> apunts { get; set; }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacío
        /// </summary>
        public XRSKConciliacion()
        {
        }

        public XRSKConciliacion(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }
        public XRSKConciliacion(ClaimsPrincipal _Usuario, string _companyia, string _operacio, List<XRSKMovimientoFisico> _moviments) : this(_Usuario, _companyia, _operacio, _moviments, new List<XRSKApunteBancario>())
        {
        }

        public XRSKConciliacion(ClaimsPrincipal _Usuario, string _companyia, string _operacio, List<XRSKApunteBancario> _apunts) : this(_Usuario, _companyia, _operacio, new List<XRSKMovimientoFisico>(), _apunts)
        {
        }

        public XRSKConciliacion(ClaimsPrincipal _Usuario, string _companyia, string _operacio, List<XRSKMovimientoFisico> _moviments, List<XRSKApunteBancario> _apunts) : base(_Usuario)
        {
            companyia = _companyia.ToUpper();
            operacio = _operacio.ToUpper();
            moviments = _moviments;
            apunts = _apunts;
        }

        #endregion

        #region Métodos Públicos
        public double Execute()
        {
            XRSKDataContext db = new XRSKDataContext();
            int referencia = -1;

            using (var dbContextTransaction = db.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
            {
                referencia = ObtenerNumerador(db, "NUMUltConciliacion");
                switch (operacio)
                {
                    case "CERTIFICAR":
                        // Las dos fechas son fechaOperación y fechaValor. Sus valores deberán venir de la pantalla
                        Certificar(db, referencia, DateTime.Now.Date, DateTime.Now.Date);
                        break;
                    case "COMPENSAR":
                        Compensar(db, referencia);
                        break;
                    case "CONCILIAR":
                        Conciliar(db, referencia, DateTime.Now.Date, DateTime.Now.Date);
                        break;
                    case "INCORPORAR":
                        Incorporar(db, referencia);
                        break;
                    case "RELACIONAR":
                        Relacionar(db, referencia);
                        break;
                    default:
                        throw new Exception(String.Format("{0} is an invalid operation", operacio));
                }

                dbContextTransaction.Commit();
            }
            return referencia;
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Certificación
        /// </summary>
        /// <param name="db">Contexto de base de datos</param>
        /// <param name="referencia">Referencia que se asignará a la certificación</param>
        /// <param name="fechaOperacion">Fecha operación de la certificación</param>
        /// <param name="fechaValor">Fecha valor de la certificación</param>
        private void Certificar(XRSKDataContext db, int referencia, DateTime fechaOperacion, DateTime fechaValor)
        {
            CompruebaRangosFechas();

            bool nomesBancaris = moviments.Count == 0;
            DateTime fechaCertificacion = nomesBancaris ? apunts.Max(a => a.ABCFechOper) : DateTime.Now.Date;

            foreach (XRSKApunteBancario apunt in apunts)
            {
                apunt.ABCTipConcil = nomesBancaris ? "CO" : "MA";
                apunt.ABCIncorporado = false;
                apunt.ABCRefConcil = referencia;
                apunt.ABCFechConcil = fechaCertificacion;
                apunt.save(db);
            }

            foreach (XRSKMovimientoFisico moviment in moviments)
            {
                moviment.MVFFechCert = DateTime.Now.Date;
                moviment.MVFRefCert = referencia;
                moviment.MVFGradCert = XRSKConstantes.MVF_GC_CIERTO;
                moviment.MVFConciliado = "MA";
                moviment.MVFCodUSR = Usuario.usuari;
                moviment.MVFFechOperac = fechaOperacion;
                moviment.MVFFechValor = fechaValor;
                moviment.MVFRefConc = null;
                moviment.save(db);
            }
        }

        private void Descertificar(XRSKDataContext db)
        {
            foreach (XRSKApunteBancario apunt in apunts)
            {
                apunt.ABCTipConcil = "DE";
                apunt.ABCIncorporado = false;
                apunt.ABCRefConcil = null;
                apunt.ABCFechaRealConc = null;
                apunt.save(db);
            }

            foreach (XRSKMovimientoFisico moviment in moviments) {
                moviment.MVFFechCert = null;
                moviment.MVFRefCert = null;
                moviment.MVFRefConc = null;
                moviment.MVFGradCert = XRSKConstantes.MVF_GC_PROVISORIO;
                moviment.MVFConciliado = "DE";
                //moviment.MVFFechOper_AntCNC = null;
                //moviment.MVFFechValor_AntCNC = null;
                moviment.MVFFechConc = null;
                moviment.save(db);
            }
        }

        /// <summary>
        /// Compensación de apuntes o de movimientos
        /// </summary>
        /// <param name="db">Contexto de base de datos</param>
        /// <param name="referencia">Referencia que se asignará a la certificación</param>
        private void Compensar(XRSKDataContext db, int referencia)
        {
            DateTime fecha;

            if (apunts.Count > 0)
            {
                fecha = apunts.Max(a => a.ABCFechOper);

                foreach (XRSKApunteBancario apunt in apunts)
                {
                    apunt.ABCRefConcil = referencia;
                    apunt.ABCFechConcil = fecha;
                    apunt.ABCTipConcil = "CO";
                    apunt.ABCFechaRealConc = DateTime.Now.Date;
                    apunt.save(db);
                }
            }

            if (moviments.Count > 0)
            {
                fecha = Convert.ToDateTime(moviments.Max(m => m.MVFFechCont));

                foreach (XRSKMovimientoFisico moviment in moviments)
                {
                    moviment.MVFRefConc = referencia;
                    moviment.MVFFechConc = fecha.Equals(DateTime.MinValue) ? DateTime.Now.Date : fecha;
                    moviment.MVFConciliado = "CO";
                    moviment.MVFFechaRealConc = DateTime.Now.Date;
                    // Segons les especificacions, quan passem per aquí el grau de certesa és P o A. Si és P, el modifiquem a C.
                    moviment.MVFGradCert = moviment.MVFGradCert.Equals(XRSKConstantes.MVF_GC_PROVISORIO) ? XRSKConstantes.MVF_GC_CIERTO : XRSKConstantes.MVF_GC_CONTABILIZADO;
                    moviment.save(db);
                }
            }
        }

        /// <summary>
        /// Descompensación
        /// </summary>
        /// <param name="db">Contexto de base de datos</param>
        private void Descompensar(XRSKDataContext db)
        {
            Desconciliar(db, "DE");
        }

        /// <summary>
        /// Conciliación
        /// </summary>
        /// <param name="db">Contexto de base de datos</param>
        /// <param name="referencia">Referencia que se asignará a la conciliación</param>
        /// <param name="fechaOperacion">Fecha operación de la conciliación</param>
        /// <param name="fechaValor">Fecha valor de la conciliación</param>
        private void Conciliar(XRSKDataContext db, int referencia, DateTime fechaOperacion, DateTime fechaValor)
        {
            DateTime maxFechaOperacion = apunts.Max(a => a.ABCFechOper);
            DateTime maxFechaContable = Convert.ToDateTime(moviments.Max(m => m.MVFFechCont));
            DateTime maxFecha = maxFechaOperacion.CompareTo(maxFechaContable) > 0 ? maxFechaOperacion : maxFechaContable;

            foreach (XRSKApunteBancario apunt in apunts)
            {
                apunt.ABCRefConcil = referencia;
                apunt.ABCFechConcil = maxFecha;
                apunt.ABCTipConcil = "MA";
                apunt.ABCFechaRealConc = DateTime.Now.Date;
                apunt.save(db);
            }

            foreach (XRSKMovimientoFisico moviment in moviments)
            {
                if (apunts.Count > 1 && moviments.Count > 1)
                {
                    moviment.MVFFechOperac = fechaOperacion;
                    moviment.MVFFechValor = fechaValor;
                }
                moviment.MVFRefConc = referencia;
                moviment.MVFFechConc = maxFechaOperacion;
                moviment.MVFConciliado = "MA";
                moviment.MVFFechaRealConc = DateTime.Now.Date;
                moviment.save(db);
            }

        }

        /// <summary>
        /// Desconciliación
        /// </summary>
        /// <param name="db">Contexto de base de datos</param>
        private void Desconciliar(XRSKDataContext db)
        {
            Desconciliar(db, "DE");
        }

        /// <summary>
        /// Desconciliación
        /// </summary>
        /// <param name="db">Contexto de base de datos</param>
        /// <param name="operacion">Operación a asignar en el proceso</param>
        private void Desconciliar(XRSKDataContext db, string operacion)
        {
            foreach (XRSKApunteBancario apunt in apunts)
            {
                apunt.ABCIncorporado = false;
                apunt.ABCRefConcil = null;
                apunt.ABCFechConcil = null;
                apunt.ABCFechaRealConc = DateTime.Now.Date;
                apunt.ABCTipConcil = operacion;
                apunt.save(db);
            }

            foreach (XRSKMovimientoFisico moviment in moviments) {
                moviment.MVFConciliado = operacion;
                moviment.MVFFechConc = null;
                moviment.MVFRefConc = null;
                moviment.MVFFechIncor = null;
                moviment.MVFRefIncor = null;
                moviment.MVFFechCert = null;
                moviment.MVFRefCert = null;
                moviment.MVFFechaRealConc = DateTime.Now.Date;
                if (!moviment.MVFGradCert.Equals(XRSKConstantes.MVF_GC_CONTABILIZADO))
                    moviment.MVFGradCert = XRSKConstantes.MVF_GC_PROVISORIO;
                moviment.save(db);
            }
        }

        private void Incorporar(XRSKDataContext db, int referencia)
        {
        }

        private void Relacionar(XRSKDataContext db, int referencia)
        {
            foreach (XRSKApunteBancario apunt in apunts)
            {
                apunt.ABCRefConcil = referencia;
                apunt.save(db);
            }

            foreach (XRSKMovimientoFisico moviment in moviments)
            {
                moviment.MVFRefConc = referencia;
                moviment.MVFGradCert = "W";
                moviment.save(db);
            }
        }

        private void Desrelacionar(XRSKDataContext db)
        {
            foreach (XRSKApunteBancario apunt in apunts)
            {
                apunt.ABCRefConcil = null;
                apunt.ABCTipConcil = "PE";
                apunt.ABCFechConcil = null;
                apunt.save(db);
            }

            foreach (XRSKMovimientoFisico moviment in moviments)
            {
                moviment.MVFRefCert = null;
                moviment.MVFGradCert = XRSKConstantes.MVF_GC_PROVISORIO;
                moviment.MVFConciliado = "PE";
                moviment.save(db);
            }
        }
        private void CompruebaRangosFechas()
        {
            //JCS 20141021 Canvi de criteris en les certificacions en grup
            if (moviments.Count > 1 && apunts.Count > 1)
            {
                // Els dos converts són perquè MVFFechValor pot ser null. Això no hauria de ser!!!!
                DateTime minFechaOperacionProv = moviments.Min(m => m.MVFFechOperac);
                DateTime maxFechaOperacionProv = moviments.Max(m => m.MVFFechOperac);
                DateTime minFechaValorProv = Convert.ToDateTime(moviments.Min(m => m.MVFFechValor));
                DateTime maxFechaValorProv = Convert.ToDateTime(moviments.Max(m => m.MVFFechValor));
                DateTime minFechaOperacionBanc = apunts.Min(a => a.ABCFechOper);
                DateTime maxFechaOperacionBanc = apunts.Max(a => a.ABCFechOper);
                DateTime minFechaValorBanc = apunts.Min(a => a.ABCFechVal);
                DateTime maxFechaValorBanc = apunts.Max(a => a.ABCFechVal);
                //JCS 20150529 Modificacions certificació/conciliació segons correu electrònic 12 de maig de 2015
                //if (/*numBancaris > 1 && numProvisoris > 1 &&*/
                //    (minFechaOperacionProv < minFechaOperacionBanc || maxFechaOperacionProv > maxFechaOperacionBanc || minFechaValorProv < minFechaValorBanc || maxFechaValorProv > maxFechaValorBanc))
                //{
                //    throw new Exception("Error en los rangos de fechas");
                //}
                //JCS 20150529 FI
            }
            //JCS 20141021 FI
        }
        /// <summary>
        /// Aquest mètode és per simular que fem alguna cosa.
        /// Quan totes les operacions estiguin implementades s'ha d'esborrar.
        /// </summary>

        private int ObtenerNumerador(XRSKDataContext db, string campo)
        {
            XRSKNumerador numerador = new XRSKNumerador();
            return numerador.GetAndUpdate(db, companyia, campo);
        }

        private XRSKMovimientoFisico Model2Entity(MovimientosDetailModel moviment)
        {
            XRSKMovimientoFisico provisori = new XRSKMovimientoFisico();
            provisori.MVFCodCIA = moviment.cia;
            provisori.MVFRefXRisk = moviment.Referencia;
            return provisori;
        }

        private XRSKApunteBancario Model2Entity(ApuntesDetailModel apunt)
        {
            return null;
        }
        #endregion
    }
}
