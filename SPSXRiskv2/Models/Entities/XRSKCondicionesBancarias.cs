using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Database;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKCondicionesBancarias : XRSKEntity
    {
        public int cabid { get; set; }
        public string CONCodACO { get; set; }
        public DateTime CONFechaDesde { get; set; }
        public DateTime CONFechaHasta { get; set; }
        public string CONCodCIA { get; set; }
        public string CONCodENT { get; set; }
        public string CONCodCTA { get; set; }
        public string CONCodOPE { get; set; }
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

        #region Constructores

        public XRSKCondicionesBancarias()
        {

        }

        public XRSKCondicionesBancarias(String _CONCodACO, DateTime _CONFechaDesde, DateTime _CONFechaHasta, String _CONCodCIA, String _CONCodENT)
        {
            //CONCodACO = _CONCodACO;
            //CONFechaDesde = _CONFechaDesde;
            //CONFechaHasta = _CONFechaHasta;
            //CONCodCIA = _CONCodCIA;
            //CONCodENT = _CONCodENT;
        }

        public XRSKCondicionesBancarias(CondicionesBancarias item)
        {
            TOXRSKCondicionesBancarias(item);
        }

        public XRSKCondicionesBancarias(CondicionesBancarias item, XRSKDataContext db)
        {
            TOXRSKCondicionesBancarias(item, db);
        }

        public void TOXRSKCondicionesBancarias(CondicionesBancarias item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKCondicionesBancarias(item, db);

        }

        public void TOXRSKCondicionesBancarias(CondicionesBancarias item, XRSKDataContext db)
        {

            CONCodACO = item.CONCodACO;
            CONCodCIA = item.CONCodCIA;
            //CONFechaDesde = item.CONFechaDesde;
            //CONFechaHasta = item.CONFechaHasta;
            CONCodENT = item.CONCodENT;
            CONCodCTA = item.CONCodCTA;
            CONCodOPE = item.CONCodOPE;
            ////OPEDescripcion = op_item.OPEDescripcion;
            //CONIdCPT = item.CONIdCPT;
            //CONMovGastos = item.CONMovGastos;
            //CONCodGastosOPE = item.CONCodGastosOPE;
            //CONCodCPT = item.CONCodOPE;
            //CONPorcentaje = item.CONPorcentaje;
            //CONImpMin = item.CONImpMin;
            //CONImpMax = item.CONImpMax;
            //CONFijo = item.CONFijo;
            //CONCosteXefecto = item.CONCosteXefecto;
            //CONTipoEfecto = item.CONTipoEfecto;
            //CONInteresesDto = item.CONInteresesDto;
            //CONPorcentajeInteresDto = item.CONPorcentajeInteresDto;
            //CONCalculoPorDivisa = item.CONCalculoPorDivisa;
            //CONNuevaCPTIVA = item.CONNuevaCPTIVA;
            //CONCodIVACPT = item.CONCodIVACPT;
            //CONPorcentajeIVA = item.CONPorcentajeIVA;
            //CONDesdeImporte = item.CONDesdeImporte;

        }

        #endregion


        public List<XRSKCondicionesBancarias> GetList()
        {

            List<XRSKCondicionesBancarias> cbv_items = new List<XRSKCondicionesBancarias>();
            XRSKDataContext db = new XRSKDataContext();

            List<CondicionesBancarias> items = db.CondicionesBancarias.ToList();
            // XSRKOperacion operacion = new XSRKOperacion();

            foreach (CondicionesBancarias item in items)
            {
                //  Operacion op = operacion.GetOperacion(item.CONCodOPE);
                cbv_items.Add(new XRSKCondicionesBancarias(item));
            }

            return cbv_items;
        }

        public CondicionesBancarias delete(int? codigo_cabid)
        {
            try
            {
                XRSKDataContext db = new XRSKDataContext();
                CondicionesBancarias cb = db.CondicionesBancarias.Where(x => x.cabid == codigo_cabid).FirstOrDefault();
                return cb;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }


    }
}
