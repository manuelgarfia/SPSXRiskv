using Microsoft.EntityFrameworkCore;
using SPSXRiskv2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using SPSXRiskv2.ViewModels;
using System.Web;
using System.Security.Claims;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKCBVigentes : XRSKEntity
    {

        #region Propiedades

        public int? cabid { get; set; }
        public string CONCodACO { get; set; }
        public DateTime CONFechaDesde { get; set; }
        public DateTime CONFechaHasta { get; set; }
        public string CONCodCIA { get; set; }
        public string CONCodENT { get; set; }
        public string CONCodCTA { get; set; }
        public string CONCodOPE { get; set; }

        public string OPEDescripcion { get; set; }
        public int CONIdCPT { get; set; }
        public bool CONMovGastos { get; set; }
        public string CONCodGastosOPE { get; set; }
        public string CONCodCPT { get; set; }
        public double CONPorcentaje { get; set; }
        public double CONImpMin { get; set; }
        public double CONImpMax { get; set; }
        public double CONFijo { get; set; }
        public bool CONCosteXefecto { get; set; }
        public string CONTipoEfecto { get; set; }
        public bool? CONInteresesDto { get; set; }
        public double? CONPorcentajeInteresDto { get; set; }
        public bool? CONCalculoPorDivisa { get; set; }
        public bool? CONNuevaCPTIVA { get; set; }
        public string CONCodIVACPT { get; set; }
        public double? CONPorcentajeIVA { get; set; }
        public double? CONDesdeImporte { get; set; }

        #endregion

        #region Propiedades Entidades Relacionadas
        public FocUsuarios user { get; set; } // Nombre de Compañía
        #endregion

        #region Constructores

        public XRSKCBVigentes()
        {

        }// Constructor sin parámetros

        public XRSKCBVigentes(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKCBVigentes(CBVigentes item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKCBVigentes(item, db);
        }

        public XRSKCBVigentes(String _CONCodACO, DateTime _CONFechaDesde, DateTime _CONFechaHasta, String _CONCodCIA, String _CONCodENT)
        {
            CONCodACO = _CONCodACO;
            CONFechaDesde = _CONFechaDesde;
            CONFechaHasta = _CONFechaHasta;
            CONCodCIA = _CONCodCIA;
            CONCodENT = _CONCodENT;
        }

        public XRSKCBVigentes(CBVigentes item, Operacion op_item)
        {
            TOXRSKCBVigentes(item, op_item);
        }// end Constructor EM

        public XRSKCBVigentes(CBVigentes item, Operacion op_item, XRSKDataContext db)
        {
            TOXRSKCBVigentes(item, op_item, db);
        }// end Constructor EM

        private void TOXRSKCBVigentes(CBVigentes item, Operacion op_item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKCBVigentes(item, op_item, db);

        }// end TOSPSOperario

        #endregion

        #region Private Functions

        private void TOXRSKCBVigentes(CBVigentes item, Operacion op_item, XRSKDataContext db)
        {
            cabid = item.cabid;
            CONCodACO = item.CONCodACO;
            CONCodCIA = item.CONCodCIA;
            CONFechaDesde = item.CONFechaDesde;
            CONFechaHasta = item.CONFechaHasta;
            CONCodENT = item.CONCodENT;
            CONCodCTA = item.CONCodCTA;
            CONCodOPE = item.CONCodOPE;
            OPEDescripcion = op_item.OPEDescripcion;
            CONIdCPT = item.CONIdCPT;
            CONMovGastos = item.CONMovGastos;
            CONCodGastosOPE = item.CONCodGastosOPE;
            CONCodCPT = item.CONCodCPT;
            CONPorcentaje = item.CONPorcentaje;
            CONImpMin = item.CONImpMin;
            CONImpMax = item.CONImpMax;
            CONFijo = item.CONFijo;
            CONCosteXefecto = item.CONCosteXefecto;
            CONTipoEfecto = item.CONTipoEfecto;
            CONInteresesDto = item.CONInteresesDto;
            CONPorcentajeInteresDto = item.CONPorcentajeInteresDto;
            CONCalculoPorDivisa = item.CONCalculoPorDivisa;
            CONNuevaCPTIVA = item.CONNuevaCPTIVA;
            CONCodIVACPT = item.CONCodIVACPT;
            CONPorcentajeIVA = item.CONPorcentajeIVA;
            CONDesdeImporte = item.CONDesdeImporte;

        }
        private void TOXRSKCBVigentes(CBVigentes item, XRSKDataContext db)
        {
            cabid = item.cabid;
            CONCodACO = item.CONCodACO;
            CONCodCIA = item.CONCodCIA;
            CONFechaDesde = item.CONFechaDesde;
            CONFechaHasta = item.CONFechaHasta;
            CONCodENT = item.CONCodENT;
            CONCodCTA = item.CONCodCTA;
            CONCodOPE = item.CONCodOPE;
            CONIdCPT = item.CONIdCPT;
            CONMovGastos = item.CONMovGastos;
            CONCodGastosOPE = item.CONCodGastosOPE;
            CONCodCPT = item.CONCodCPT;
            CONPorcentaje = item.CONPorcentaje;
            CONImpMin = item.CONImpMin;
            CONImpMax = item.CONImpMax;
            CONFijo = item.CONFijo;
            CONCosteXefecto = item.CONCosteXefecto;
            CONTipoEfecto = item.CONTipoEfecto;
            CONInteresesDto = item.CONInteresesDto;
            CONPorcentajeInteresDto = item.CONPorcentajeInteresDto;
            CONCalculoPorDivisa = item.CONCalculoPorDivisa;
            CONNuevaCPTIVA = item.CONNuevaCPTIVA;
            CONCodIVACPT = item.CONCodIVACPT;
            CONPorcentajeIVA = item.CONPorcentajeIVA;
            CONDesdeImporte = item.CONDesdeImporte;

        }

        private List<XRSKCBVigentes> TOXRSKCBVigentes(List<CBVigentes> items)
        {
            List<XRSKCBVigentes> condBanc = new List<XRSKCBVigentes>();
            foreach (CBVigentes item in items)
            {
                condBanc.Add(new XRSKCBVigentes(item));
            }

            return condBanc;
        }

        private List<XRSKCBVigentes> TOXRSKCBVigentesList(List<CBVigentes> items, List<XRSKCBVigentes> result_list)
        {
            //  List<XRSKCBVigentes> condBanc = new List<XRSKCBVigentes>();
            foreach (CBVigentes item in items)
            {
                result_list.Add(new XRSKCBVigentes(item));
            }

            return result_list;
        }

        private IQueryable<CBVigentes> aplicarFiltro(IQueryable<CBVigentes> query, FilterModel filter)
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
                                query = query.Where(x => x.CONFechaDesde >= detail.from && x.CONFechaHasta <= detail.to);
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
                                //query = query.Where(x => x.MVFImBrDivisa >= (Double)detail.decValue);
                            }
                            break;
                        case XRSKConstantes.FILTER_SUBTYPE_LESS_EQUAL:
                            if (detail.entity.Equals("MVFImBrDivisa"))
                            {
                                // query = query.Where(x => x.MVFImBrDivisa <= (Double)detail.decValue);
                            }
                            break;
                        case XRSKConstantes.FILTER_SUBTYPE_RANGE:
                            if (detail.entity.Equals("MVFImBrDivisa"))
                            {
                                //  query = query.Where(x => x.MVFImBrDivisa >= (Double)detail.decValue && x.MVFImBrDivisa <= (Double)detail.importMax);
                            }
                            break;
                    }
                }

                if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_STRING))
                {
                    switch (detail.subtype)
                    {
                        case XRSKConstantes.FILTER_SUBTYPE_CONTAINS:
                            if (detail.entity.Equals("MVFCodENT"))
                            {
                                query = query.Where(x => x.CONCodENT.Contains(detail.charValue));
                            }
                            break;
                    }

                }
                // Elementos
                if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_ITEMS) && detail.values != null)
                {
                    if (detail.entity.Equals("MVFCodCIA"))
                    {
                        query = query.Where(x => detail.values.Contains(x.CONCodCIA));
                    }
                }
            }
            return query;
        }

        private IQueryable<CBVigentes> aplicarSeguridad(IQueryable<CBVigentes> query)
        {
            if (Usuario.Grupos != null)
            {
                foreach (XRSKFocUsuariosGrupos grupo in Usuario.Grupos)
                {
                    if (grupo.BasesDatos != null)
                    {
                        foreach (XSRKBasesDatosGrupo bd in grupo.BasesDatos)
                        {
                            query = query.Where(x => bd.companies.Contains(x.CONCodCIA));
                        }
                    }
                }
            }

            return query;
        }
        #endregion

        #region Functions
        public List<XRSKCBVigentes> GetList()
        {

            List<XRSKCBVigentes> cbv_items = new List<XRSKCBVigentes>();
            XRSKDataContext db = new XRSKDataContext();

            List<CBVigentes> items = db.CBancariasVigentes.ToList();
            XRSKOperacion operacion = new XRSKOperacion();


            foreach (CBVigentes item in items)
            {
                Operacion op = operacion.GetOperacion(item.CONCodOPE);
                cbv_items.Add(new XRSKCBVigentes(item, op));
            }

            return cbv_items;
        }


        public XRSKCBVigentes save()
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
                }
            }
            return this;
        }

        public XRSKCBVigentes save(XRSKDataContext db)
        {
            XRSKCondicionesBancarias cb = new XRSKCondicionesBancarias();
            Boolean isInsert = false;
            // Get Entity
            CondicionesBancarias item = db.CondicionesBancarias.Find(cabid);
            CondicionesBancarias previous = new CondicionesBancarias();

            // Change data
            if (item == null)
            {
                item = new CondicionesBancarias();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            set_values(db, item);

            if (isInsert)
            {
                item = before_insert(db, item);
                db.CondicionesBancarias.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            db.SaveChanges();

            //cb.TOXRSKCondicionesBancarias(item);

            //if (isInsert)
            //{
            //    after_insert(db, item);
            //    db.SaveChanges();
            //}
            //else
            //{
            //    after_update(db, previous, item);
            //    // Update Context
            //    db.SaveChanges();
            //}
            return this;
        }


        private CondicionesBancarias set_values(XRSKDataContext db, CondicionesBancarias next)
        {
            next.CONCodACO = CONCodACO;

            string date_str = CONFechaDesde.ToShortDateString();
            DateTime fechadesde = Convert.ToDateTime(date_str);
            next.CONFechaDesde = fechadesde;

            next.CONCodCIA = CONCodCIA;
            next.CONCodENT = CONCodENT;
            next.CONCodCTA = CONCodCTA;
            next.CONCodOPE = CONCodOPE;
            next.CONIdCPT = CONIdCPT;
            next.CONMovGastos = CONMovGastos;
            next.CONCodGastosOPE = CONCodGastosOPE;
            next.CONCodCPT = CONCodCPT;
            next.CONPorcentaje = CONPorcentaje;
            next.CONImpMin = CONImpMin;
            next.CONImpMax = CONImpMax;
            next.CONFijo = CONFijo;
            next.CONCosteXefecto = CONCosteXefecto;
            next.CONTipoEfecto = "%";
            next.CONInteresesDto = CONInteresesDto;
            next.CONPorcentajeInteresDto = CONPorcentajeInteresDto;
            next.CONCalculoPorDivisa = false;
            next.CONNuevaCPTIVA = true;
            next.CONCodIVACPT = CONCodIVACPT;
            next.CONPorcentajeIVA = 1;
            next.CONDesdeImporte = CONDesdeImporte;

            return next;
        }

        private CondicionesBancarias before_insert(XRSKDataContext db, CondicionesBancarias next)
        {
            return next;
        }

        private CondicionesBancarias before_update(XRSKDataContext db, CondicionesBancarias prev, CondicionesBancarias next)
        {
            return next;
        }

        private CondicionesBancarias before_delete(XRSKDataContext db, CondicionesBancarias prev)
        {
            return prev;
        }// end before_delete method


        private CondicionesBancarias after_insert(XRSKDataContext db, CondicionesBancarias next)
        {
            return next;
        }// end after_insert method

        private CondicionesBancarias after_update(XRSKDataContext db, CondicionesBancarias prev, CondicionesBancarias next)
        {
            return next;
        }// end after_update method


        public XRSKCBVigentes delete()
        {
            XRSKDataContext db = new XRSKDataContext();

            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                     delete(db);
                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    throw e;
                }
            }

            return this;
        }

        public XRSKCBVigentes delete(XRSKDataContext db)
        {

            XRSKCondicionesBancarias condicion_bancaria = new XRSKCondicionesBancarias();
            int? codigo_cabid = cabid;
            CondicionesBancarias cb = condicion_bancaria.delete(codigo_cabid);

            cb = before_delete(db, cb);

            db.CondicionesBancarias.Remove(cb);

            db.SaveChanges();
            //Change data
            //ACPGrupo = null; ;
            //ACPNiv = null;
            //ACPCod = null;
            //ACPDescripcion = null;

            return null;
        }

        public CBVigentes get_cbv_register(string codigo_entidad, string codigo_operacion)
        {
            XRSKDataContext cbv_db = new XRSKDataContext();

            CBVigentes new_item = cbv_db.CBancariasVigentes.Where(x => x.CONCodENT == codigo_entidad).FirstOrDefault();
            return null;

        }

        public List<XRSKCBVigentes> GetFilteredList(FilterModel filter)
        {

            XRSKDataContext db = new XRSKDataContext();

            var query = from x in
                        db.CBancariasVigentes
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKCBVigentes(query.ToList());

        }

        

     #endregion

    }
}
