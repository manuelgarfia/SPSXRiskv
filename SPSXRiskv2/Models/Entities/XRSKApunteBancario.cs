using Microsoft.EntityFrameworkCore;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKApunteBancario : XRSKEntity
    {
        #region Propiedades
        public string ABCCodCIA { get; set; }
        public double ABCNumerador { get; set; }
        public string ABCCodCTA { get; set; }
        public string ABCBanco { get; set; }
        public string ABCOficina { get; set; }
        public string ABCCuenta { get; set; }
        public DateTime ABCFechOper { get; set; }
        public DateTime ABCFechVal { get; set; }
        public string ABCConCom { get; set; }
        public string ABCConPro { get; set; }
        public string ABCSigno { get; set; }
        public decimal ABCImporte { get; set; }
        public string ABCDocumento { get; set; }
        public string ABCRef1 { get; set; }
        public string ABCRef2 { get; set; }
        public string ABCTipConcil { get; set; }
        public double? ABCRefConcil { get; set; }
        public DateTime? ABCFechConcil { get; set; }
        public string ABCComple1 { get; set; }
        public string ABCComple2 { get; set; }
        public string ABCComple3 { get; set; }
        public string ABCComple4 { get; set; }
        public string ABCComple5 { get; set; }
        public string ABCComple6 { get; set; }
        public string ABCComple7 { get; set; }
        public string ABCComple8 { get; set; }
        public string ABCComple9 { get; set; }
        public string ABCComple10 { get; set; }
        public bool? ABCIncorporado { get; set; }
        public DateTime? ABCFechaRealConc { get; set; }
        public bool? ABCHistorif { get; set; }
        public DateTime? ABCFechIntro { get; set; }
        public string ABCCodUSR { get; set; }
        public string ABCFichEnt { get; set; }
        public bool? ABCLibreLogico1 { get; set; }
        public bool? ABCLibreLogico2 { get; set; }
        public bool? ABCLibreLogico3 { get; set; }
        public string ABCLibreTexto1 { get; set; }
        public string ABCLibreTexto2 { get; set; }
        public string ABCLibreTexto3 { get; set; }
        public string numcuenta { get; set; }
        public string complementos { get; set; }
        public string operacion { get; set; }
        #endregion

        #region Propiedades Entidades Relacionadas
        public String CIADescripcion { get; set; } // Nombre de Compañía
        #endregion

        #region Constructores
        public XRSKApunteBancario()
        {
        }

        public XRSKApunteBancario(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKApunteBancario(ApunteBancario item)
        {
            TOXRSKApunteBancario(item);
        }

        public XRSKApunteBancario(ApunteBancario item, XRSKDataContext db)
        {
            TOXRSKApunteBancario(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKApunteBancario(ApunteBancario item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKApunteBancario(item, db);
        }

        private void TOXRSKApunteBancario(ApunteBancario item, XRSKDataContext db)
        {
            ABCCodCIA = item.ABCCodCIA;
            ABCNumerador = item.ABCNumerador;
            ABCCodCTA = item.ABCCodCTA;
            ABCBanco = item.ABCBanco;
            ABCOficina = item.ABCOficina;
            ABCCuenta = item.ABCCuenta;
            ABCFechOper = item.ABCFechOper;
            ABCFechVal = item.ABCFechVal;
            ABCConCom = item.ABCConCom;
            ABCConPro = item.ABCConPro;
            ABCSigno = item.ABCSigno;
            ABCImporte = item.ABCImporte;
            ABCDocumento = item.ABCDocumento;
            ABCRef1 = item.ABCRef1;
            ABCRef2 = item.ABCRef2;
            ABCTipConcil = item.ABCTipConcil;
            ABCRefConcil = item.ABCRefConcil;
            ABCFechConcil = item.ABCFechConcil;
            ABCComple1 = item.ABCComple1;
            ABCComple2 = item.ABCComple2;
            ABCComple3 = item.ABCComple3;
            ABCComple4 = item.ABCComple4;
            ABCComple5 = item.ABCComple5;
            ABCComple6 = item.ABCComple6;
            ABCComple7 = item.ABCComple7;
            ABCComple8 = item.ABCComple8;
            ABCComple9 = item.ABCComple9;
            ABCComple10 = item.ABCComple10;
            ABCIncorporado = item.ABCIncorporado;
            ABCFechaRealConc = item.ABCFechaRealConc;
            ABCHistorif = item.ABCHistorif;
            ABCFechIntro = item.ABCFechIntro;
            ABCCodUSR = item.ABCCodUSR;
            ABCFichEnt = item.ABCFichEnt;
            ABCLibreLogico1 = item.ABCLibreLogico1;
            ABCLibreLogico2 = item.ABCLibreLogico2;
            ABCLibreLogico3 = item.ABCLibreLogico3;
            ABCLibreTexto1 = item.ABCLibreTexto1;
            ABCLibreTexto2 = item.ABCLibreTexto2;
            ABCLibreTexto3 = item.ABCLibreTexto3;

            numcuenta = ABCBanco + " " + ABCOficina + " " + " " + ABCCuenta;

            complementos = item.ABCComple1 + " " + ABCComple2 + " " + ABCComple3 + " " + ABCComple4 + " " + ABCComple5 + " " + ABCComple6 + " " + ABCComple7 + " " + ABCComple8 + " " + ABCComple9 + " " + ABCComple10;
            complementos = complementos.Trim();

            operacion = ABCConCom + "/" + ABCConPro;

            if (item.Companyia != null)
            {
                CIADescripcion = item.Companyia.CIADescripcion;
            }
        }

        private List<XRSKApunteBancario> TOXRSKApunteBancario(List<ApunteBancario> items)
        {
            List<XRSKApunteBancario> apuntes = new List<XRSKApunteBancario>();
            foreach (ApunteBancario item in items)
            {
                apuntes.Add(new XRSKApunteBancario(item));
            }

            return apuntes;
        }

        private IQueryable<ApunteBancario> aplicarSeguridad(IQueryable<ApunteBancario> query)
        {
            if (Usuario.Grupos != null)
            {
                foreach (XRSKFocUsuariosGrupos grupo in Usuario.Grupos)
                {
                    if (grupo.BasesDatos != null)
                    {
                        foreach (XSRKBasesDatosGrupo bd in grupo.BasesDatos)
                        {
                            query = query.Where(x => bd.companies.Contains(x.ABCCodCIA));
                        }
                    }
                }
            }
            return query;
        }

        private IQueryable<ApunteBancario> aplicarFiltro(IQueryable<ApunteBancario> query, FilterModel filter)
        {
            foreach (FilterDetailModel detail in filter.detail)
            {
                if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_DATE))
                {
                    switch (detail.subtype)
                    {
                        case XRSKConstantes.FILTER_SUBTYPE_RANGE:
                            if (detail.entity.Equals("ABCFechOper"))
                            {
                                query = query.Where(x => x.ABCFechOper >= detail.from && x.ABCFechOper <= detail.to);
                            }
                            else if (detail.entity.Equals("ABCFechVal"))
                            {
                                query = query.Where(x => x.ABCFechVal >= detail.from && x.ABCFechVal <= detail.to);
                            }
                            break;
                    }
                }
                else if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_NUMBER))
                {
                    switch (detail.subtype)
                    {
                        case XRSKConstantes.FILTER_SUBTYPE_GREATER_EQUAL:
                            if (detail.entity.Equals("ABCImporte"))
                            {
                                query = query.Where(x => x.ABCImporte >= (Decimal)detail.decValue);
                            }
                            break;
                        case XRSKConstantes.FILTER_SUBTYPE_LESS_EQUAL:
                            if (detail.entity.Equals("ABCImporte"))
                            {
                                query = query.Where(x => x.ABCImporte <= (Decimal)detail.decValue);
                            }
                            break;
                        case XRSKConstantes.FILTER_SUBTYPE_RANGE:
                            if (detail.entity.Equals("ABCImporte"))
                            {
                                query = query.Where(x => x.ABCImporte >= (Decimal)detail.decValue && x.ABCImporte <= (Decimal)detail.importMax);
                            }
                            break;
                    }
                }
                else if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_STRING) && detail.charValue != XRSKConstantes.FILTER_VALUE_EMPTY)
                {
                    switch (detail.subtype)
                    {
                        case XRSKConstantes.FILTER_SUBTYPE_CONTAINS:
                            if (detail.entity.Equals("ABCConCom"))
                            {
                                query = query.Where(x => x.ABCConCom.Contains(detail.charValue));
                            }
                            else if (detail.entity.Equals("ABCConPro"))
                            {
                                query = query.Where(x => x.ABCConPro.Contains(detail.charValue));
                            }
                            else if (detail.entity.Equals("ABCComple1"))
                            {
                                query = query.Where(x => x.ABCComple1.Contains(detail.charValue));
                            }
                            break;
                        case XRSKConstantes.FILTER_SUBTYPE_STARTS:
                            if (detail.entity.Equals("ABCConCom"))
                            {
                                query = query.Where(x => x.ABCConCom.StartsWith(detail.charValue));
                            }
                            else if (detail.entity.Equals("ABCConPro"))
                            {
                                query = query.Where(x => x.ABCConPro.StartsWith(detail.charValue));
                            }
                            else if (detail.entity.Equals("ABCComple1"))
                            {
                                query = query.Where(x => x.ABCComple1.StartsWith(detail.charValue));
                            }
                            break;
                        case XRSKConstantes.FILTER_SUBTYPE_ENDS:
                            if (detail.entity.Equals("ABCConCom"))
                            {
                                query = query.Where(x => x.ABCConCom.EndsWith(detail.charValue));
                            }
                            else if (detail.entity.Equals("ABCConPro"))
                            {
                                query = query.Where(x => x.ABCConPro.EndsWith(detail.charValue));
                            }
                            else if (detail.entity.Equals("ABCComple1"))
                            {
                                query = query.Where(x => x.ABCComple1.EndsWith(detail.charValue));
                            }
                            break;
                    }
                }

            }
            return query;
        }

        private IQueryable<ApunteBancario> aplicarFiltro(IQueryable<ApunteBancario> query, List<ApuntesDetailModel> _apunts)
        {
            List<Double> abcNums = new List<double>();
            string cia = (_apunts.Count() > 0) ? _apunts[0].cia : "---";

            foreach (ApuntesDetailModel detail in _apunts)
            {
                abcNums.Add(detail.Referencia);
            }

            query = query.Where(x => x.ABCCodCIA.Equals(cia));
            query = query.Where(x => abcNums.Contains(x.ABCNumerador));

            return query;
        }
        #endregion

        #region Funciones
        public List<XRSKApunteBancario> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            DateTime fechaApunte = new DateTime(2016, 1, 12);

            var query = from x in db.ApunteBancario
                .Include(ab => ab.Companyia)
                .Where(ab => ab.ABCFechOper.Equals(fechaApunte))
                select x;

            query = aplicarSeguridad(query);

            List<ApunteBancario> items = query.ToList();

            return TOXRSKApunteBancario(items);
        }

        public List<XRSKApunteBancario> GetFiltered(List<ApuntesDetailModel> apuntesConciliacion)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.ApunteBancario.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, apuntesConciliacion);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKApunteBancario(query.ToList());
        }

        /// <summary>
        /// Obtenció dels apunts per a la pantalla de conciliació.
        /// Si en el filtre del paràmetre no disposem d'una "Compañias" i d'un "Contratos", la consulta no retornarà res.
        /// </summary>
        /// <param name="filter">Filtre que s'aplicarà en els apunts, les entitats "Compañias" i "Contratos" són requerides</param>
        /// <returns>Llista dels provisoris obtinguts</returns>
        public List<XRSKApunteBancario> GetConciliacionFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            List<ApunteBancario> items = new List<ApunteBancario>();

            FilterDetailModel ciaFilter = filter.detail.Find(x => x.entity.Equals("Compañias"));
            FilterDetailModel ctaFilter = filter.detail.Find(x => x.entity.Equals("Contratos"));
            string[] tipusConciliacio = { "PE", "DE", "DC", "W1", "W2", "W3", "R1", "R2", "R3" };

            if (ciaFilter != null && ctaFilter != null && ciaFilter.values.Length == 1 && ctaFilter.values.Length == 1)
            {
                var query = from ab in db.ApunteBancario
                            .Where(ab => ab.ABCCodCIA.Equals(ciaFilter.values[0]))
                            .Where(ab => ab.ABCCodCTA.Equals(ctaFilter.values[0]))
                            .Where(ab => tipusConciliacio.Contains(ab.ABCTipConcil))
                            .Where(ab => !ab.ABCIncorporado.Equals(true))
                            select ab;

                query = aplicarSeguridad(query);

                query = aplicarFiltro(query, filter);

                items = query.ToList();
            }

            return TOXRSKApunteBancario(items);
        }

        public List<XRSKApunteBancario> GetByRefConciliacion(string cia, int referencia)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from ab in db.ApunteBancario
                            .Where(ab => ab.ABCCodCIA.Equals(cia) && ab.ABCRefConcil.Equals(referencia))
                        select ab;

            query = aplicarSeguridad(query);

            return TOXRSKApunteBancario(query.ToList());
        }

        public List<object> getCardInfo()
        {
            int numEmpresas;
            int numApuntes;

            XRSKDataContext db = new XRSKDataContext();
            List<ApunteBancario> apuntBanc = new List<ApunteBancario>();
            List<object> ABCList = new List<object>();

            string dateString = "2015-12-30 09:51:42.877";
            DateTime fechIntro = Convert.ToDateTime(dateString);

            var query = from x in db.ApunteBancario
                        select x;

            query = aplicarSeguridad(query);

            //Obtenció de número d'apunts segons la FechaIntro
            query = query.Where(x => x.ABCFechIntro == fechIntro);
            numApuntes = query.Count();

            //Número d'empreses que han entrat
            apuntBanc = query.ToList();
            IEnumerable<ApunteBancario> enumerable = apuntBanc.GroupBy(x => x.ABCCodCIA).Select(x => x.FirstOrDefault());
            List<ApunteBancario> empresasList = enumerable.ToList();
            numEmpresas = empresasList.Count();

            //Incloure les dades a la llista
            ABCList.Add(numApuntes);
            ABCList.Add(numEmpresas);

            string shortDate = fechIntro.ToShortDateString();
            ABCList.Add(shortDate);

            return ABCList;
        }
        #endregion

        #region Persistencia
        private ApunteBancario before_insert(XRSKDataContext db, ApunteBancario next)
        {
            return next;
        }// end before_insert method

        private ApunteBancario before_update(XRSKDataContext db, ApunteBancario prev, ApunteBancario next)
        {
            return next;
        }// end before_update method

        private ApunteBancario before_delete(XRSKDataContext db, ApunteBancario prev)
        {
            return prev;
        }// end before_delete method

        private ApunteBancario after_insert(XRSKDataContext db, ApunteBancario next)
        {
            return next;
        }// end after_insert method

        private ApunteBancario after_update(XRSKDataContext db, ApunteBancario prev, ApunteBancario next)
        {
            return next;
        }// end after_update method

        public XRSKApunteBancario save()
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

        public XRSKApunteBancario save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            ApunteBancario item = db.ApunteBancario.Find(ABCCodCIA, ABCNumerador);
            ApunteBancario previous = new ApunteBancario();
            // Change data
            if (item == null)
            {
                item = new ApunteBancario();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.ABCCodCIA = ABCCodCIA;
            item.ABCNumerador = ABCNumerador;
            item.ABCCodCTA = ABCCodCTA;
            item.ABCBanco = ABCBanco;
            item.ABCOficina = ABCOficina;
            item.ABCCuenta = ABCCuenta;
            item.ABCConCom = ABCConCom;
            item.ABCConPro = ABCConPro;
            item.ABCFechOper = ABCFechOper;
            item.ABCFechVal = ABCFechVal;
            item.ABCSigno = ABCSigno;
            item.ABCImporte = ABCImporte;
            item.ABCDocumento = ABCDocumento;
            item.ABCRef1 = ABCRef1;
            item.ABCRef2 = ABCRef2;
            item.ABCTipConcil = ABCTipConcil;
            item.ABCRefConcil = ABCRefConcil;
            item.ABCIncorporado = ABCIncorporado;
            item.ABCFechaRealConc = ABCFechaRealConc;

            if (isInsert)
            {
                item = before_insert(db, item);
                db.ApunteBancario.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKApunteBancario(item, db);

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

        public XRSKApunteBancario save(XRSKDataContext db, List<XRSKApunteBancario> apunts)
        {
            foreach (XRSKApunteBancario apunt in apunts)
                apunt.save(db);
            return this;
        }

        public XRSKApunteBancario delete()
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

        public XRSKApunteBancario delete(XRSKDataContext db)
        {
            // Get Entity
            ApunteBancario item = db.ApunteBancario.Find(ABCCodCIA, ABCNumerador);
            // Before_Delete call
            item = before_delete(db, item);

            db.ApunteBancario.Remove(item);
            db.SaveChanges();
            // Change data
            item.ABCCodCIA = null;
            item.ABCNumerador = -1;
            item.ABCCodCTA = null;
            item.ABCBanco = null;
            item.ABCOficina = null;
            item.ABCCuenta = null;
            item.ABCConCom = null;
            item.ABCConPro = null;
            item.ABCFechOper = DateTime.Today.Date;
            item.ABCFechVal = DateTime.Today.Date;
            item.ABCSigno = null;
            item.ABCImporte = 0;
            item.ABCDocumento = null;
            item.ABCRef1 = null;
            item.ABCRef2 = null;
            item.ABCTipConcil = null;
            item.ABCRefConcil = -1;
            item.ABCIncorporado = false;
            item.ABCFechaRealConc = DateTime.Today.Date;

            return this;
        }// end delete method with method
        #endregion
    }
}
