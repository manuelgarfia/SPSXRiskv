using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.AspNetCore.Routing;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKContratosSaldos : XRSKEntity
    {
        #region Propiedades
        public string CTATipoFecha { get; set; }
        public string CTACodCIA { get; set; }
        public string CTACod { get; set; }
        public DateTime Fecha { get; set; }
        public double Saldo { get; set; }

        #endregion

        #region Constructores

        public XRSKContratosSaldos()
        {
        }// Constructor sin parámetros

        public XRSKContratosSaldos(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKContratosSaldos(string _cTATipoFecha, string _cTACodCIA, string _cTACod, DateTime _fecha, double _saldo)
        {
            CTATipoFecha = _cTATipoFecha;
            CTACodCIA = _cTACodCIA;
            CTACod = _cTACod;
            Fecha = _fecha;
            Saldo = _saldo;
        }

        public XRSKContratosSaldos(ContratosSaldos item)
        {
           TOXRSKContratosSaldos(item);
        }// end Constructor EM



        public XRSKContratosSaldos(ContratosSaldos item, XRSKDataContext db)
        {
            TOXRSKContratosSaldos(item, db);

        }// end Constructor EM

        private void TOXRSKContratosSaldos(ContratosSaldos item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKContratosSaldos(item, db);
        }

        #endregion

        #region Metodos Privados    
        private List<XRSKContratosSaldos> TOXRSKContratosSaldos(List<ContratosSaldos> items)
        {
         
            List<XRSKContratosSaldos> contratos = new List<XRSKContratosSaldos>();
            foreach (ContratosSaldos item in items)
            {
                contratos.Add(new XRSKContratosSaldos(item));
            }

            return contratos;
        }
        private void TOXRSKContratosSaldos(ContratosSaldos item, XRSKDataContext db)
        {
            CTATipoFecha = item.CTATipoFecha;
            CTACodCIA = item.CTACodCIA;
            CTACod = item.CTACod;
            Fecha = item.Fecha;
            Saldo = item.Saldo;

        }

        #endregion

        #region Metodos publicos
        public List<XRSKContratosSaldos> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();
            List<XRSKContratosSaldos> spsItems = new List<XRSKContratosSaldos>();

            List<ContratosSaldos> items = db.ContratosSaldos.ToList();
            foreach (ContratosSaldos item in items)
            {
                spsItems.Add(new XRSKContratosSaldos(item));
            }

            return spsItems;
        }

      

        public List<XRSKContratosSaldos> GetFilteredList_2()
        {
            XRSKDataContext db = new XRSKDataContext();
            List<XRSKContratosSaldos> spsItems = new List<XRSKContratosSaldos>();

            DateTime fechaCorte1 = new DateTime(2015, 10, 1);
            DateTime fechaCorte2 = new DateTime(2015, 10, 10);

            List<ContratosSaldos> items = db.ContratosSaldos.Where(x => x.Fecha >= fechaCorte1 && x.Fecha <= fechaCorte2 && x.CTATipoFecha =="RO")
                                        .GroupBy(x => x.Fecha)
                                        .OrderBy(x => x.Key)                                                                                                         
                                        .Select(g => new ContratosSaldos { Fecha = g.Key, Saldo = g.Sum(x => x.Saldo) }).ToList();

            foreach (ContratosSaldos item in items)
            {
                spsItems.Add(new XRSKContratosSaldos(item));
            }

            return spsItems;
        }

        public List<XRSKContratosSaldos> GetRangedList(DateTime desde, DateTime hasta, string cia, string contratos)
        {
            XRSKDataContext db = new XRSKDataContext();
            List<XRSKContratosSaldos> spsItems = new List<XRSKContratosSaldos>();

            DateTime fechaCorte1 = desde;
            DateTime fechaCorte2 = hasta;

            List<ContratosSaldos> items = db.ContratosSaldos.Where(x => x.Fecha >= fechaCorte1 && x.Fecha <= fechaCorte2 && x.CTACodCIA == cia && contratos.Contains(x.CTACod))
                .GroupBy(x => new {Fecha=x.Fecha,CTACod=x.CTACod })
                .Select(g => new ContratosSaldos
               {
                  Fecha=  g.Key.Fecha,
                  CTACod= g.Key.CTACod,
                  Saldo= g.Sum(x=>x.Saldo)
               }).ToList();

            

            foreach (ContratosSaldos item in items)
            {
                spsItems.Add(new XRSKContratosSaldos(item));
            }

            return spsItems;
        }
        public List<XRSKContratosSaldos> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();
            List<XRSKContratosSaldos> spsItems= new List<XRSKContratosSaldos>();

            //var query = from x in db.ContratosSaldos
            //            group x by new { x.Fecha, x.CTACod } into y
            //            select new ContratosSaldos
            //            {
            //                CTACod = y.Key.CTACod,
            //                Fecha = y.Key.Fecha,
            //                Saldo = y.Sum(x => x.Saldo)
            //            };
            var query = from x in db.ContratosSaldos
                        select x;

            foreach (FilterDetailModel detail in filter.detail)
            {
                
                if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_DATE))
                {
                    switch (detail.subtype)
                    {
                        case XRSKConstantes.FILTER_SUBTYPE_RANGE:
                            if (detail.entity.Equals("MVFFechOperac"))
                            {
                                query = query.Where(x => x.Fecha >= detail.from && x.Fecha <= detail.to);
                            }
                            break;
                    }
                }
                
                if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_ITEMS) && detail.values != null && detail.values.Length != 0)
                {
                    if (detail.entity.Equals("MVFCodCIA"))
                    {
                        query = query.Where(x => detail.values.Contains(x.CTACodCIA));
                    }
                 
                    if (detail.entity.Equals("ctaCod"))
                    {
                        query = query.Where(x => detail.values.Contains(x.CTACod));
                    }
                 
                }

            }

            query = (IQueryable<ContratosSaldos>)query.GroupBy(x => new { x.CTACod, x.Fecha })
                          
                          .Select(grp => new ContratosSaldos
                          {
                              Fecha = grp.Key.Fecha,
                              CTACod = grp.Key.CTACod,
                              Saldo = grp.Sum(x => x.Saldo)
                          });



            List<ContratosSaldos> items = query.ToList();
              spsItems= TOXRSKContratosSaldos(items);
               return spsItems;
        }

        public List<XRSKContratosSaldos> GetFilteredCia(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();
            List<XRSKContratosSaldos> sendItems = new List<XRSKContratosSaldos>();


            var query = from x in db.ContratosSaldos
                        select x;
            /*
                        group x by new { x.CTACodCIA, x.Fecha, x.CTATipoFecha } into y
                        where y.Sum(p => p.Saldo) != 0 && y.Key.CTATipoFecha == "RV"
                        select new XRSKContratosSaldos
                        {                            
                            Fecha = y.Key.Fecha,
                            CTACodCIA = y.Key.CTACodCIA,
                            Saldo = y.Sum(x => x.Saldo)

                        };
            */
            // Aplicación del Filtro previa al Group By !!!!!!!!

            foreach (FilterDetailModel detail in filter.detail)
            {
                
                if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_DATE))
                {
                    switch (detail.subtype)
                    {
                        case XRSKConstantes.FILTER_SUBTYPE_RANGE:
                            if (detail.entity.Equals("MVFFechOperac"))
                            {
                                query = query.Where(x => x.Fecha.Date == detail.from.Value.Date);
                            }
                            break;
                    }
                }
                
                if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_ITEMS) && detail.values != null && detail.values.Length != 0)
                {
                    if (detail.entity.Equals("MVFCodCIA"))
                    {
                        query = query.Where(x => detail.values.Contains(x.CTACodCIA));
                    }
                    if (detail.entity.Equals("ctaCod"))
                    {
                        query = query.Where(x => detail.values.Contains(x.CTACod));
                    }
                }
            }

            // Agregar directivas de Group By y retorno.

            query = (IQueryable<ContratosSaldos>)query.GroupBy(x => new { x.CTACod, x.Fecha, x.CTATipoFecha, x.Saldo })
                            .Where(y => y.Sum(p => p.Saldo) != 0 && y.Key.CTATipoFecha == "RV")
                            .Select(grp => new ContratosSaldos
                            {
                                Fecha = grp.Key.Fecha,
                                CTACod = grp.Key.CTACod,
                                Saldo = grp.Key.Saldo
                            });


            

            List<ContratosSaldos> items = query.ToList();
           sendItems= TOXRSKContratosSaldos(items);
            
            return sendItems;
        }


        public List<XRSKContratosSaldos> getContratosList(string company, string contrato)
        {
            XRSKDataContext db = new XRSKDataContext();
            List<ContratosSaldos> sendItems = new List<ContratosSaldos>();

            DateTime fechaSaldos = new DateTime(2015, 10, 1);

            var query =  db.ContratosSaldos
                        .Where(x => x.CTACodCIA.Equals(company) && x.CTACod.Equals(contrato) && x.Fecha.Month == 10 && x.CTATipoFecha == "RO")
                        .ToList();

            sendItems = query;

            return TOXRSKContratosSaldos(sendItems);
        }

        public List<XRSKContratosSaldos> getContratosListDateRange(string company, string contrato, string dateDesde, string dateHasta)
        {
            XRSKDataContext db = new XRSKDataContext();
            List<ContratosSaldos> sendItems = new List<ContratosSaldos>();

            DateTime fechadesde = Convert.ToDateTime(dateDesde);
            DateTime fechahasta = Convert.ToDateTime(dateHasta);

            var query = db.ContratosSaldos
                        .Where(x => x.CTACodCIA.Equals(company) && x.CTACod.Equals(contrato) && x.Fecha >= fechadesde && x.Fecha <= fechahasta && x.CTATipoFecha == "RO" )
                        .ToList();

            sendItems = query;

            return TOXRSKContratosSaldos(sendItems);
        }

        public List<double> getSaldosByMonth(string company, string contrato)
        {
            XRSKDataContext db = new XRSKDataContext();
            List<ContratosSaldos> contratosItems = new List<ContratosSaldos>();

            List<double> contratos = new List<double>();


            var query = db.ContratosSaldos
                            .Where(x => x.CTACodCIA.Equals(company) && x.CTACod.Equals(contrato))
                            .ToList();


            foreach(var con in contratosItems)
            {
                contratos.Add(con.Saldo);
            }


            return contratos;
        }

        #endregion
    }
}
