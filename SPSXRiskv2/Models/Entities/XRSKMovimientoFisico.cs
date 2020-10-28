using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.ViewModels;
using System.Linq.Expressions;
using System.IO;
using System.Security.Claims;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKMovimientoFisico : XRSKEntity
    {
        #region Propiedades
        public string MVFGrupo { get; set; }
        public string MVFCodCIA { get; set; }
        public string MVFDescripcion { get; set; }
        public string MVFValorOrganizativo { get; set; }
        public double MVFRefXRisk { get; set; }
        public string MVFCodGEN { get; set; }
        public string MVFCodENT { get; set; }
        public string MVFCodTLI { get; set; }
        public string MVFCodCTA { get; set; }
        public string MVFRef1SisExt { get; set; }
        public string MVFAgrOpe { get; set; }
        public string MVFCodCPT { get; set; }
        public string MVFCodOPE { get; set; }
        public string MVFCodDIV { get; set; }
        public string MVFTipoOPE { get; set; }
        public string MVFContAgrOPE { get; set; }
        public bool MVFContrapartidaOPE { get; set; }
        public double MVFImBrDivisa { get; set; }
        public Int16 MVFSigImpNet { get; set; }
        public double MVFImNetDiv { get; set; }
        public string MVFGradCert { get; set; }
        public string MVFConciliado { get; set; }
        public DateTime? MVFFechIncor { get; set; }
        public int? MVFRefIncor { get; set; }
        public DateTime? MVFFechCert { get; set; }
        public int? MVFRefCert { get; set; }
        public DateTime MVFFechOperac { get; set; }
        public DateTime? MVFFechValor { get; set; }
        public double? MVFImpNetDivMN { get; set; }
        public double? MVFCamBrImpu { get; set; }
        public double? MVFImBrPtas { get; set; }
        public double? MVFCamNetCptMn { get; set; }
        public string MVFCodCPTDIV { get; set; }
        public DateTime? MVFFechConc { get; set; }
        public int? MVFRefConc { get; set; }
        public DateTime? MVFFechCont { get; set; }
        public double? MVFRefCont { get; set; }

        //3r tab
        public int? MVFCodTIntREF { get; set; }
        public DateTime? MVFFechVto { get; set; }
        public double? MVFSpread { get; set; }
        public double? MVFTipInt { get; set; }

        //4t tab
        public string MVFCodAOP { get; set; }
        public string MVFCodGFL { get; set; }
        public string MVFCodFLU { get; set; }
        public string MVFCodACP { get; set; }
        public DateTime? MVFFechImp { get; set; }
        public string MVFSisOrig { get; set; }
        public string MVFCodIrcREF { get; set; }
        public DateTime MVFFechEstimada { get; set; }
        public string MVFCodUSR { get; set; }
        public DateTime? MVFFechaRealConc { get; set; }
        #endregion

        #region Propiedades Entidades Relacionadas
        public String CIADescripcion { get; set; } // Nombre de Compañía
        #endregion

        #region Constructores
        public XRSKMovimientoFisico()
        {
        }

        public XRSKMovimientoFisico(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKMovimientoFisico(MovimientoFisico item)
        {
            TOXRSKMovimientoFisico(item);
        }

        public XRSKMovimientoFisico(MovimientoFisico item, XRSKDataContext db)
        {
            TOXRSKMovimientoFisico(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKMovimientoFisico(MovimientoFisico item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKMovimientoFisico(item, db);
        }

        private void TOXRSKMovimientoFisico(MovimientoFisico item, XRSKDataContext db)
        {
            MVFAgrOpe = item.MVFAgrOpe;
            MVFCamBrImpu = item.MVFCamBrImpu;
            MVFCamNetCptMn = item.MVFCamNetCptMn;
            MVFCodACP = item.MVFCodACP;
            MVFCodAOP = item.MVFCodAOP;
            MVFCodCIA = item.MVFCodCIA;
            MVFCodCPT = item.MVFCodCPT;
            MVFCodCPTDIV = item.MVFCodCPTDIV;
            MVFCodCTA = item.MVFCodCTA;
            MVFCodDIV = item.MVFCodDIV;
            MVFCodENT = item.MVFCodENT;
            MVFCodFLU = item.MVFCodFLU;
            MVFCodGEN = item.MVFCodGEN;
            MVFCodGFL = item.MVFCodGFL;
            MVFCodIrcREF = item.MVFCodIrcREF;
            MVFCodOPE = item.MVFCodOPE;
            MVFCodTIntREF = item.MVFCodTIntREF;
            MVFCodTLI = item.MVFCodTLI;
            MVFCodUSR = item.MVFCodUSR;
            MVFConciliado = item.MVFConciliado;
            MVFContAgrOPE = item.MVFContAgrOPE;
            MVFContrapartidaOPE = item.MVFContrapartidaOPE;
            MVFDescripcion = item.MVFDescripcion;
            MVFFechaRealConc = item.MVFFechaRealConc;
            MVFFechConc = item.MVFFechConc;
            MVFFechCont = item.MVFFechCont;
            MVFFechEstimada = item.MVFFechEstimada;
            MVFFechImp = item.MVFFechImp;
            MVFFechOperac = item.MVFFechOperac;
            MVFFechValor = item.MVFFechValor;
            MVFFechVto = item.MVFFechVto;
            MVFGradCert = item.MVFGradCert;
            MVFGrupo = item.MVFGrupo;
            MVFImBrDivisa = item.MVFImBrDivisa;
            MVFImBrPtas = item.MVFImBrPtas;
            MVFImNetDiv = item.MVFImNetDiv;
            MVFImpNetDivMN = item.MVFImpNetDivMN;
            MVFRef1SisExt = item.MVFRef1SisExt;
            MVFRefCert = item.MVFRefCert;
            MVFRefConc = item.MVFRefConc;
            MVFRefCont = item.MVFRefCont;
            MVFRefIncor = item.MVFRefIncor;
            MVFRefXRisk = item.MVFRefXRisk;
            MVFSigImpNet = item.MVFSigImpNet;
            MVFSisOrig = item.MVFSisOrig;
            MVFSpread = item.MVFSpread;
            MVFTipInt = item.MVFTipInt;
            MVFTipoOPE = item.MVFTipoOPE;
            MVFValorOrganizativo = item.MVFValorOrganizativo;

            if (item.Companyia != null)
            {
                CIADescripcion = item.Companyia.CIADescripcion;
            }
        }

        private List<XRSKMovimientoFisico> TOXRSKMovimientoFisico(List<MovimientoFisico> items)
        {
            List<XRSKMovimientoFisico> movimientos = new List<XRSKMovimientoFisico>();
            foreach (MovimientoFisico item in items)
            {
                movimientos.Add(new XRSKMovimientoFisico(item));
            }

            return movimientos;
        }

        private IQueryable<MovimientoFisico> aplicarSeguridad(IQueryable<MovimientoFisico> query)
        {
            if (Usuario.Grupos != null)
            {
                foreach (XRSKFocUsuariosGrupos grupo in Usuario.Grupos)
                {
                    if (grupo.BasesDatos != null)
                    {
                        foreach (XSRKBasesDatosGrupo bd in grupo.BasesDatos)
                        {
                            query = query.Where(x => bd.companies.Contains(x.MVFCodCIA));
                        }
                    }
                }
            }
            return query;
        }

        private IQueryable<MovimientoFisico> aplicarFiltro(IQueryable<MovimientoFisico> query, FilterModel filter)
        {
            foreach (FilterDetailModel detail in filter.detail)
            {
                // Fechas
                if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_DATE))
                {
                    switch (detail.subtype)
                    {
                        case XRSKConstantes.FILTER_SUBTYPE_RANGE:
                            if (detail.entity.Equals("MVFFechOperac"))
                            {
                                query = query.Where(x => x.MVFFechOperac >= detail.from && x.MVFFechOperac <= detail.to);
                            }
                            break;
                    }
                }
                // Numeros

                if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_NUMBER))
                {
                    switch (detail.subtype)
                    {
                        case XRSKConstantes.FILTER_SUBTYPE_GREATER_EQUAL:
                            if (detail.entity.Equals("MVFImBrDivisa"))
                            {
                                query = query.Where(x => x.MVFImBrDivisa >= (Double)detail.decValue);
                            }
                            break;
                        case XRSKConstantes.FILTER_SUBTYPE_LESS_EQUAL:
                            if (detail.entity.Equals("MVFImBrDivisa"))
                            {
                                query = query.Where(x => x.MVFImBrDivisa <= (Double)detail.decValue);
                            }
                            break;
                        case XRSKConstantes.FILTER_SUBTYPE_RANGE:
                            if (detail.entity.Equals("MVFImBrDivisa"))
                            {
                                query = query.Where(x => x.MVFImBrDivisa >= (Double)detail.decValue && x.MVFImBrDivisa <= (Double)detail.importMax);
                            }
                            break;
                    }
                }

                if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_STRING) && detail.charValue != XRSKConstantes.FILTER_VALUE_EMPTY)
                {
                    switch (detail.subtype)
                    {
                        case XRSKConstantes.FILTER_SUBTYPE_CONTAINS:
                            if (detail.entity.Equals("MVFRefXRisk"))
                            {
                                query = query.Where(x => x.MVFRefXRisk.ToString().Contains(detail.charValue));
                            }
                            else if (detail.entity.Equals("MVFDescripcion"))
                            {
                                query = query.Where(x => x.MVFDescripcion.Contains(detail.charValue));
                            }
                            break;
                        case XRSKConstantes.FILTER_SUBTYPE_STARTS:
                            if (detail.entity.Equals("MVFRefXRisk"))
                            {
                                query = query.Where(x => x.MVFRefXRisk.ToString().StartsWith("P"));
                            }
                            else if (detail.entity.Equals("MVFDescripcion"))
                            {
                                query = query.Where(x => x.MVFDescripcion.StartsWith(detail.charValue));
                            }
                            break;
                        case XRSKConstantes.FILTER_SUBTYPE_ENDS:
                            if (detail.entity.Equals("MVFRefXRisk"))
                            {
                                query = query.Where(x => x.MVFRefXRisk.ToString().EndsWith(detail.charValue));
                            }
                            else if (detail.entity.Equals("MVFDescripcion"))
                            {
                                query = query.Where(x => x.MVFDescripcion.EndsWith(detail.charValue));
                            }
                            break;
                    }
                }

                // Elementos
                if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_ITEMS) && detail.values != null && detail.values.Length != 0)
                {
                    if (detail.entity.Equals("MVFCodCIA"))
                    {
                        if (detail.values.Length.Equals(1))
                        {
                            query = query.Where(x => x.MVFCodCIA.Equals(detail.values[0]));
                        }
                        else
                        {
                            query = query.Where(x => detail.values.Contains(x.MVFCodCIA));
                        }
                    }
                    if (detail.entity.Equals("MVFCodENT"))
                    {
                        if (detail.values.Length.Equals(1))
                        {
                            query = query.Where(x => x.MVFCodENT.Equals(detail.values[0]));
                        }
                        else
                        {
                            query = query.Where(x => detail.values.Contains(x.MVFCodENT));
                        }

                    }
                    if (detail.entity.Equals("MVFCodCTA"))
                    {
                        if (detail.values.Length.Equals(1))
                        {
                            query = query.Where(x => x.MVFCodCTA.Equals(detail.values[0]));
                        }
                        else
                        {
                            query = query.Where(x => detail.values.Contains(x.MVFCodCTA));
                        }
                    }
                    if (detail.entity.Equals("MVFGradCert"))
                    {
                        if (detail.values.Length.Equals(1))
                        {
                            query = query.Where(x => x.MVFGradCert.Equals(detail.values[0]));
                        }
                        else
                        {
                            query = query.Where(x => detail.values.Contains(x.MVFGradCert));
                        }
                    }
                    if (detail.entity.Equals("MVFConciliado"))
                    {
                        if (detail.values.Length.Equals(1))
                        {
                            query = query.Where(x => x.MVFConciliado.Equals(detail.values[0]));
                        }
                        else
                        {
                            query = query.Where(x => detail.values.Contains(x.MVFConciliado));
                        }

                    }
                }
            }

            return query;
        }

        private IQueryable<MovimientoFisico> aplicarFiltro(IQueryable<MovimientoFisico> query, List<MovimientosDetailModel> _mvtos)
        {
            List<Double> mvfRefs = new List<double>();
            string cia = (_mvtos.Count() > 0) ? _mvtos[0].cia : "---";

            foreach (MovimientosDetailModel detail in _mvtos)
            {
                mvfRefs.Add(detail.Referencia);
            }

            query = query.Where(x => x.MVFCodCIA.Equals(cia));
            query = query.Where(x => mvfRefs.Contains(x.MVFRefXRisk));

            return query;
        }
        #endregion

        #region Public Methods
        public List<XRSKMovimientoFisico> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            DateTime fechaMovimiento = new DateTime(2016, 1, 12);

            List<MovimientoFisico> items = db.MovimientoFisico.
                Include(x => x.Companyia).
                Where(x => x.MVFCodCIA.Equals("550") && x.MVFFechOperac.Equals(fechaMovimiento)).
                ToList();
            return TOXRSKMovimientoFisico(items);
        }

        public MovimientoFisico GetListCompanyRef(string cia, string reference)
        {
            XRSKDataContext db = new XRSKDataContext();

            int referen = Convert.ToInt32(reference);

            MovimientoFisico item = db.MovimientoFisico.
                Where(x => x.MVFCodCIA.Equals(cia) && x.MVFRefXRisk.Equals(referen)).FirstOrDefault();

            return item;
        }

        public List<XRSKMovimientoFisico> GetByRefConciliacion(string cia, int referencia)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.MovimientoFisico.Include(x => x.Companyia)
                            .Where(x => x.MVFCodCIA.Equals(cia) && x.MVFRefConc.Equals(referencia))
                        select x;

            return TOXRSKMovimientoFisico(query.ToList());
        }

        public List<XRSKMovimientoFisico> GetListRange()
        {
            XRSKDataContext db = new XRSKDataContext();
            string date_string = "2018 - 12 - 29 00:00:00.000";
            DateTime date = DateTime.Parse(date_string);

            var query = from x in db.MovimientoFisico.Include(x => x.Companyia)
                        select x;

            query = query.Where(x => x.MVFCodCIA.Equals("550") && x.MVFFechOperac.Equals(date));

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKMovimientoFisico(query.ToList());
            //return null;
        }

        public List<XRSKMovimientoFisico> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.MovimientoFisico.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKMovimientoFisico(query.ToList());
        }

        public List<XRSKMovimientoFisico> GetFiltered(List<MovimientosDetailModel> mvtosConciliacion)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.MovimientoFisico.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, mvtosConciliacion);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKMovimientoFisico(query.ToList());
        }

        /// <summary>
        /// Obtenció dels provisoris per a la pantalla de conciliació.
        /// Si en el filtre del paràmetre no disposem d'una "Compañias" i d'un "Contratos", la consulta no retornarà res.
        /// </summary>
        /// <param name="filter">Filtre que s'aplicarà en els provisoris, les entitats "Compañias" i "Contratos" són requerides</param>
        /// <returns>Llista dels provisoris obtinguts</returns>
        public List<XRSKMovimientoFisico> GetConciliacionFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            List<MovimientoFisico> items = new List<MovimientoFisico>();

            FilterDetailModel ciaFilter = filter.detail.Find(x => x.entity.Equals("Compañias"));
            FilterDetailModel ctaFilter = filter.detail.Find(x => x.entity.Equals("Contratos"));
            string[] estatsConciliacio = { "PE", "DC", "DE" };

            if (ciaFilter != null && ctaFilter != null && ciaFilter.values.Length == 1 && ctaFilter.values.Length == 1)
            {
                var query = from mf in db.MovimientoFisico.
                            Where(mf => mf.MVFCodCIA.Equals(ciaFilter.values[0])).
                            Where(mf => mf.MVFCodCTA.Equals(ctaFilter.values[0])).
                            Where(mf => estatsConciliacio.Contains(mf.MVFConciliado)).
                            Where(mf => !db.ZPOSOperExcControl.Any(zp => zp.OXPCod == mf.MVFCodOPE)).
                            Where(mf => mf.MVFGradCert.Equals(XRSKConstantes.MVF_GC_PROVISORIO))
                            select mf;

                // Afegim condicions de Filtre per pantalla
                query = aplicarFiltro(query, filter);

                items = query.ToList();
            }

            return TOXRSKMovimientoFisico(items);
        }
        #endregion

        #region Persistencia
        private MovimientoFisico before_insert(XRSKDataContext db, MovimientoFisico next)
        {
            return next;
        }// end before_insert method

        private MovimientoFisico before_update(XRSKDataContext db, MovimientoFisico prev, MovimientoFisico next)
        {
            return next;
        }// end before_update method

        private MovimientoFisico before_delete(XRSKDataContext db, MovimientoFisico prev)
        {
            return prev;
        }// end before_delete method

        private MovimientoFisico after_insert(XRSKDataContext db, MovimientoFisico next)
        {
            return next;
        }// end after_insert method

        private MovimientoFisico after_update(XRSKDataContext db, MovimientoFisico prev, MovimientoFisico next)
        {
            return next;
        }// end after_update method

        public XRSKMovimientoFisico save()
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

        public XRSKMovimientoFisico save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            MovimientoFisico item = db.MovimientoFisico.Find(MVFCodCIA, MVFValorOrganizativo, MVFRefXRisk);
            MovimientoFisico previous = new MovimientoFisico();
            // Change data
            if (item == null)
            {
                item = new MovimientoFisico();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.MVFAgrOpe = MVFAgrOpe;
            item.MVFCamBrImpu = MVFCamBrImpu;
            item.MVFCamNetCptMn = MVFCamNetCptMn;
            item.MVFCodACP = MVFCodACP;
            item.MVFCodAOP = MVFCodAOP;
            item.MVFCodCIA = MVFCodCIA;
            item.MVFCodCPT = MVFCodCPT;
            item.MVFCodCPTDIV = MVFCodCPTDIV;
            item.MVFCodCTA = MVFCodCTA;
            item.MVFCodDIV = MVFCodDIV;
            item.MVFCodENT = MVFCodENT;
            item.MVFCodFLU = MVFCodFLU;
            item.MVFCodGEN = MVFCodGEN;
            item.MVFCodGFL = MVFCodGFL;
            item.MVFCodIrcREF = MVFCodIrcREF;
            item.MVFCodOPE = MVFCodOPE;
            item.MVFCodTIntREF = MVFCodTIntREF;
            item.MVFCodTLI = MVFCodTLI;
            item.MVFCodUSR = MVFCodUSR;
            item.MVFConciliado = MVFConciliado;
            item.MVFContAgrOPE = MVFContAgrOPE;
            item.MVFContrapartidaOPE = MVFContrapartidaOPE;
            item.MVFDescripcion = MVFDescripcion;
            item.MVFFechaRealConc = MVFFechaRealConc;
            item.MVFFechConc = MVFFechConc;
            item.MVFFechCont = MVFFechCont;
            item.MVFFechEstimada = MVFFechEstimada;
            item.MVFFechImp = MVFFechImp;
            item.MVFFechOperac = MVFFechOperac;
            item.MVFFechValor = MVFFechValor;
            item.MVFFechVto = MVFFechVto;
            item.MVFGradCert = MVFGradCert;
            item.MVFGrupo = MVFGrupo;
            item.MVFImBrDivisa = MVFImBrDivisa;
            item.MVFImBrPtas = MVFImBrPtas;
            item.MVFImNetDiv = MVFImNetDiv;
            item.MVFImpNetDivMN = MVFImpNetDivMN;
            item.MVFRef1SisExt = MVFRef1SisExt;
            item.MVFRefCert = MVFRefCert;
            item.MVFRefConc = MVFRefConc;
            item.MVFRefCont = MVFRefCont;
            item.MVFRefIncor = MVFRefIncor;
            item.MVFRefXRisk = MVFRefXRisk;
            item.MVFSigImpNet = MVFSigImpNet;
            item.MVFSisOrig = MVFSisOrig;
            item.MVFSpread = MVFSpread;
            item.MVFTipInt = MVFTipInt;
            item.MVFTipoOPE = MVFTipoOPE;
            item.MVFValorOrganizativo = MVFValorOrganizativo;

            if (isInsert)
            {
                item = before_insert(db, item);
                db.MovimientoFisico.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKMovimientoFisico(item, db);

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

        public XRSKMovimientoFisico save(XRSKDataContext db, List<XRSKMovimientoFisico> movimientos)
        {
            foreach (XRSKMovimientoFisico movimiento in movimientos)
                movimiento.save(db);
            return this;
        }

        public XRSKMovimientoFisico delete()
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

        public XRSKMovimientoFisico delete(XRSKDataContext db)
        {
            // Get Entity
            MovimientoFisico item = db.MovimientoFisico.Find(MVFCodCIA, MVFValorOrganizativo, MVFRefXRisk);
            // Before_Delete call
            item = before_delete(db, item);

            db.MovimientoFisico.Remove(item);
            db.SaveChanges();

            // Change data
            item.MVFAgrOpe = null;
            item.MVFCamBrImpu = null;
            item.MVFCamNetCptMn = null;
            item.MVFCodACP = null;
            item.MVFCodAOP = null;
            item.MVFCodCIA = null;
            item.MVFCodCPT = null;
            item.MVFCodCPTDIV = null;
            item.MVFCodCTA = null;
            item.MVFCodDIV = null;
            item.MVFCodENT = null;
            item.MVFCodFLU = null;
            item.MVFCodGEN = null;
            item.MVFCodGFL = null;
            item.MVFCodIrcREF = null;
            item.MVFCodOPE = null;
            item.MVFCodTIntREF = null;
            item.MVFCodTLI = null;
            item.MVFCodUSR = null;
            item.MVFConciliado = "PE";
            item.MVFContAgrOPE = null;
            item.MVFContrapartidaOPE = false;
            item.MVFDescripcion = null;
            item.MVFFechaRealConc = null;
            item.MVFFechConc = null;
            item.MVFFechCont = null;
            item.MVFFechEstimada = DateTime.Now.Date;
            item.MVFFechImp = null;
            item.MVFFechOperac = DateTime.Now.Date;
            item.MVFFechValor = DateTime.Now.Date;
            item.MVFFechVto = null;
            item.MVFGradCert = XRSKConstantes.MVF_GC_PROVISORIO;
            item.MVFGrupo = null;
            item.MVFImBrDivisa = 0;
            item.MVFImBrPtas = 0;
            item.MVFImNetDiv = 0;
            item.MVFImpNetDivMN = 0;
            item.MVFRef1SisExt = null;
            item.MVFRefCert = null;
            item.MVFRefConc = null;
            item.MVFRefCont = null;
            item.MVFRefIncor = null;
            item.MVFRefXRisk = 0;
            item.MVFSigImpNet = 0;
            item.MVFSisOrig = null;
            item.MVFSpread = null;
            item.MVFTipInt = null;
            item.MVFTipoOPE = null;
            item.MVFValorOrganizativo = null;

            return this;
        }// end delete method with method
        #endregion
    }
}
