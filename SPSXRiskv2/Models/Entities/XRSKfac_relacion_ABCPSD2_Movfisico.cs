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
/// Code generated 14/09/2020 11:54:07 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKfac_relacion_ABCPSD2_Movfisico : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("ABCCodCIA")]
        public string ABCCodCIA { get; set; }
        [JsonProperty("ABCNumerador")]
        public double ABCNumerador { get; set; }
        [JsonProperty("CodigoCliente")]
        public string? CodigoCliente { get; set; }
        [JsonProperty("MVFrefXrisk")]
        public double MVFrefXrisk { get; set; }
        [JsonProperty("cabid")]
        public int cabid { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKfac_relacion_ABCPSD2_Movfisico()
        {
        }

        public XRSKfac_relacion_ABCPSD2_Movfisico(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKfac_relacion_ABCPSD2_Movfisico(fac_relacion_ABCPSD2_Movfisico item)
        {
            TOXRSKfac_relacion_ABCPSD2_Movfisico(item);
        }

        public XRSKfac_relacion_ABCPSD2_Movfisico(fac_relacion_ABCPSD2_Movfisico item, XRSKDataContext db)
        {
            TOXRSKfac_relacion_ABCPSD2_Movfisico(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKfac_relacion_ABCPSD2_Movfisico(fac_relacion_ABCPSD2_Movfisico item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKfac_relacion_ABCPSD2_Movfisico(item, db);
        }

        private void TOXRSKfac_relacion_ABCPSD2_Movfisico(fac_relacion_ABCPSD2_Movfisico item, XRSKDataContext db)
        {
            ABCCodCIA = item.ABCCodCIA;
            ABCNumerador = item.ABCNumerador;
            CodigoCliente = item.CodigoCliente;
            MVFrefXrisk = item.MVFrefXrisk;
            cabid = item.cabid;


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKfac_relacion_ABCPSD2_Movfisico> TOXRSKfac_relacion_ABCPSD2_Movfisico(List<fac_relacion_ABCPSD2_Movfisico> items)
        {
            List<XRSKfac_relacion_ABCPSD2_Movfisico> elemList = new List<XRSKfac_relacion_ABCPSD2_Movfisico>();
            foreach (fac_relacion_ABCPSD2_Movfisico item in items)
            {
                elemList.Add(new XRSKfac_relacion_ABCPSD2_Movfisico(item));
            }

            return elemList;
        }

        private IQueryable<fac_relacion_ABCPSD2_Movfisico> aplicarSeguridad(IQueryable<fac_relacion_ABCPSD2_Movfisico> query)
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

        private IQueryable<fac_relacion_ABCPSD2_Movfisico> aplicarFiltro(IQueryable<fac_relacion_ABCPSD2_Movfisico> query, FilterModel filter)
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
        public List<XRSKfac_relacion_ABCPSD2_Movfisico> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create fac_relacion_ABCPSD2_Movfisico entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<fac_relacion_ABCPSD2_Movfisico> items = db.fac_relacion_ABCPSD2_Movfisico.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKfac_relacion_ABCPSD2_Movfisico(items);
        }

        public List<XRSKfac_relacion_ABCPSD2_Movfisico> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.fac_relacion_ABCPSD2_Movfisico//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKfac_relacion_ABCPSD2_Movfisico(query.ToList());
        }

        public XRSKfac_relacion_ABCPSD2_Movfisico Find(int cabid)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(cabid, db);
        }// end Find method

        public XRSKfac_relacion_ABCPSD2_Movfisico Find(int cabid, XRSKDataContext db)
        {
            fac_relacion_ABCPSD2_Movfisico item = db.fac_relacion_ABCPSD2_Movfisico.Find(cabid);
            TOXRSKfac_relacion_ABCPSD2_Movfisico(item);
            return this;
        }
        #endregion

        #region Persistencia
        private fac_relacion_ABCPSD2_Movfisico before_insert(XRSKDataContext db, fac_relacion_ABCPSD2_Movfisico next)
        {
            return next;
        }// end before_insert method

        private fac_relacion_ABCPSD2_Movfisico before_update(XRSKDataContext db, fac_relacion_ABCPSD2_Movfisico prev, fac_relacion_ABCPSD2_Movfisico next)
        {
            return next;
        }// end before_update method

        private fac_relacion_ABCPSD2_Movfisico before_delete(XRSKDataContext db, fac_relacion_ABCPSD2_Movfisico prev)
        {
            return prev;
        }// end before_delete method

        private fac_relacion_ABCPSD2_Movfisico after_insert(XRSKDataContext db, fac_relacion_ABCPSD2_Movfisico next)
        {
            return next;
        }// end after_insert method

        private fac_relacion_ABCPSD2_Movfisico after_update(XRSKDataContext db, fac_relacion_ABCPSD2_Movfisico prev, fac_relacion_ABCPSD2_Movfisico next)
        {
            return next;
        }// end after_update method

        public XRSKfac_relacion_ABCPSD2_Movfisico save()
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

        public XRSKfac_relacion_ABCPSD2_Movfisico save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            fac_relacion_ABCPSD2_Movfisico item = db.fac_relacion_ABCPSD2_Movfisico.Find(cabid);
            fac_relacion_ABCPSD2_Movfisico previous = new fac_relacion_ABCPSD2_Movfisico();
            // Change data
            if (item == null)
            {
                item = new fac_relacion_ABCPSD2_Movfisico();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.ABCCodCIA = ABCCodCIA;
            item.ABCNumerador = ABCNumerador;
            item.CodigoCliente = CodigoCliente;
            item.MVFrefXrisk = MVFrefXrisk;
            item.cabid = cabid;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.fac_relacion_ABCPSD2_Movfisico.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKfac_relacion_ABCPSD2_Movfisico(item, db);

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

        public XRSKfac_relacion_ABCPSD2_Movfisico save(XRSKDataContext db, List<XRSKfac_relacion_ABCPSD2_Movfisico> elemsList)
        {
            foreach (XRSKfac_relacion_ABCPSD2_Movfisico currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKfac_relacion_ABCPSD2_Movfisico delete()
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

        public XRSKfac_relacion_ABCPSD2_Movfisico delete(XRSKDataContext db)
        {
            // Get Entity
            fac_relacion_ABCPSD2_Movfisico item = db.fac_relacion_ABCPSD2_Movfisico.Find(cabid);
            // Before_Delete call
            item = before_delete(db, item);

            db.fac_relacion_ABCPSD2_Movfisico.Remove(item);
            db.SaveChanges();

            // Change data
            item.ABCCodCIA = null;
            item.ABCNumerador = 0;
            item.CodigoCliente = null;
            item.MVFrefXrisk = 0;
            item.cabid = 0;


            return this;
        }// end delete method with method
        #endregion
    }
}
