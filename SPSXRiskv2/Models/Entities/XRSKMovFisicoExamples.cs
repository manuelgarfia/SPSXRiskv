using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.ViewModels;
using System.Linq.Expressions;
using SPSXRiskv2.Common;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKMovFisicoExamples : XRSKEntity
    {
        #region Properties
        public string MVFCodCIA { get; set; }
        public DateTime MVFFechOperac { get; set; }
        public string MVFDescripcion { get; set; }
        public double MVFRefXRisk { get; set; }

        #endregion

        #region Constructores

        public XRSKMovFisicoExamples()
        {

        }

        public XRSKMovFisicoExamples(MovFisicoExamples item)
        {
            TOXRSKMovFisicoExamples(item);
        }

        public XRSKMovFisicoExamples(MovFisicoExamples item, XRSKDataContext db)
        {
            TOXRSKMovFisicoExamples(item, db);
        }

        #endregion

        #region Private Methods

        private void TOXRSKMovFisicoExamples(MovFisicoExamples item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKMovFisicoExamples(item, db);
        }

        private void TOXRSKMovFisicoExamples(MovFisicoExamples item, XRSKDataContext db)
        {
            MVFCodCIA = item.MVFCodCIA;
            MVFFechOperac = item.MVFFechOperac;
            MVFDescripcion = item.MVFDescripcion;
            MVFRefXRisk = item.MVFRefXRisk;

        }

        private List<XRSKMovFisicoExamples> TOXRSKMovFisicoExamples(List<MovFisicoExamples> items)
        {
            List<XRSKMovFisicoExamples> movimientos = new List<XRSKMovFisicoExamples>();
            foreach (MovFisicoExamples item in items)
            {
                movimientos.Add(new XRSKMovFisicoExamples(item));
            }

            return movimientos;
        }
        #endregion

        #region Funciones

        public List<XRSKMovFisicoExamples> GetExamplesList(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in
                           db.MovFisicoExamples
                        select x;

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
                               // query = query.Where(x => x. >= (Double)detail.decValue);
                            }
                            break;
                        case XRSKConstantes.FILTER_SUBTYPE_LESS_EQUAL:
                            if (detail.entity.Equals("MVFImBrDivisa"))
                            {
                              //  query = query.Where(x => x.MVFImBrDivisa <= (Double)detail.decValue);
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

                if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_STRING) && detail.charValue != XRSKConstantes.FILTER_VALUE_EMPTY)
                {
                    switch (detail.subtype)
                    {
                        case XRSKConstantes.FILTER_SUBTYPE_CONTAINS:
                            if (detail.entity.Equals("MVFDescripcion"))
                            {
                                query = query.Where(x => x.MVFDescripcion.Contains(detail.charValue));
                            }
                            break;
                        case XRSKConstantes.FILTER_SUBTYPE_STARTS:
                            if (detail.entity.Equals("MVFDescripcion"))
                            {
                                query = query.Where(x => x.MVFDescripcion.StartsWith(detail.charValue));
                            }
                            break;
                        case XRSKConstantes.FILTER_SUBTYPE_ENDS:
                            if (detail.entity.Equals("MVFDescripcion"))
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
                        query = query.Where(x => detail.values.Contains(x.MVFCodCIA));
                    }
                    if (detail.entity.Equals("MVFCodENT"))
                    {
                      //  query = query.Where(x => detail.values.Contains(x.MVFCodENT));
                    }

                }

            }

            List<MovFisicoExamples> items = query.ToList();

            return TOXRSKMovFisicoExamples(items);
        }

        #endregion

    }
}
