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
/// Code generated 14/09/2020 12:15:26 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKfac_clientes : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("CodigoPostal")]
        public string? CodigoPostal { get; set; }
        [JsonProperty("CuentaContable")]
        public string? CuentaContable { get; set; }
        [JsonProperty("Descripcion")]
        public string? Descripcion { get; set; }
        [JsonProperty("Direccion")]
        public string? Direccion { get; set; }
        [JsonProperty("Empresa")]
        public string Empresa { get; set; }
        [JsonProperty("FormaPago")]
        public string? FormaPago { get; set; }
        [JsonProperty("NIF")]
        public string? NIF { get; set; }
        [JsonProperty("Nombre")]
        public string? Nombre { get; set; }
        [JsonProperty("Pais")]
        public string? Pais { get; set; }
        [JsonProperty("Poblacion")]
        public string? Poblacion { get; set; }
        [JsonProperty("Provincia")]
        public string? Provincia { get; set; }
        [JsonProperty("Telefono")]
        public string? Telefono { get; set; }
        [JsonProperty("Codigo")]
        public string Codigo { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKfac_clientes()
        {
        }

        public XRSKfac_clientes(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKfac_clientes(fac_clientes item)
        {
            TOXRSKfac_clientes(item);
        }

        public XRSKfac_clientes(fac_clientes item, XRSKDataContext db)
        {
            TOXRSKfac_clientes(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKfac_clientes(fac_clientes item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKfac_clientes(item, db);
        }

        private void TOXRSKfac_clientes(fac_clientes item, XRSKDataContext db)
        {
            CodigoPostal = item.CodigoPostal;
            CuentaContable = item.CuentaContable;
            Descripcion = item.Descripcion;
            Direccion = item.Direccion;
            Empresa = item.Empresa;
            FormaPago = item.FormaPago;
            NIF = item.NIF;
            Nombre = item.Nombre;
            Pais = item.Pais;
            Poblacion = item.Poblacion;
            Provincia = item.Provincia;
            Telefono = item.Telefono;
            Codigo = item.Codigo;


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKfac_clientes> TOXRSKfac_clientes(List<fac_clientes> items)
        {
            List<XRSKfac_clientes> elemList = new List<XRSKfac_clientes>();
            foreach (fac_clientes item in items)
            {
                elemList.Add(new XRSKfac_clientes(item));
            }

            return elemList;
        }

        private IQueryable<fac_clientes> aplicarSeguridad(IQueryable<fac_clientes> query)
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

        private IQueryable<fac_clientes> aplicarFiltro(IQueryable<fac_clientes> query, FilterModel filter)
        {
            foreach (FilterDetailModel detail in filter.detail)
            {
                // Filtering sample, uncomment and change it at your own if your consider
                // if (detail.type.Equals(XRSKConstantes.FILTER_TYPE_DATE))
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
        public List<XRSKfac_clientes> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create fac_clientes entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<fac_clientes> items = db.fac_clientes.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKfac_clientes(items);
        }


        public List<XRSKfac_clientes> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.fac_clientes//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKfac_clientes(query.ToList());
        }

        public XRSKfac_clientes Find(string Codigo)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(Codigo, db);
        }// end Find method

        public XRSKfac_clientes Find(string Codigo, XRSKDataContext db)
        {
            fac_clientes item = db.fac_clientes.Find(Codigo);
            TOXRSKfac_clientes(item);
            return this;
        }
        #endregion

        #region Persistencia
        private fac_clientes before_insert(XRSKDataContext db, fac_clientes next)
        {
            return next;
        }// end before_insert method

        private fac_clientes before_update(XRSKDataContext db, fac_clientes prev, fac_clientes next)
        {
            return next;
        }// end before_update method

        private fac_clientes before_delete(XRSKDataContext db, fac_clientes prev)
        {
            return prev;
        }// end before_delete method

        private fac_clientes after_insert(XRSKDataContext db, fac_clientes next)
        {
            return next;
        }// end after_insert method

        private fac_clientes after_update(XRSKDataContext db, fac_clientes prev, fac_clientes next)
        {
            return next;
        }// end after_update method

        public XRSKfac_clientes save()
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

        public XRSKfac_clientes save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            fac_clientes item = db.fac_clientes.Find(Codigo);
            fac_clientes previous = new fac_clientes();
            // Change data
            if (item == null)
            {
                item = new fac_clientes();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.CodigoPostal = CodigoPostal;
            item.CodigoPostal = CodigoPostal;
            item.CuentaContable = CuentaContable;
            item.CuentaContable = CuentaContable;
            item.Descripcion = Descripcion;
            item.Descripcion = Descripcion;
            item.Direccion = Direccion;
            item.Direccion = Direccion;
            item.Empresa = Empresa;
            item.Empresa = Empresa;
            item.FormaPago = FormaPago;
            item.FormaPago = FormaPago;
            item.NIF = NIF;
            item.NIF = NIF;
            item.Nombre = Nombre;
            item.Nombre = Nombre;
            item.Pais = Pais;
            item.Pais = Pais;
            item.Poblacion = Poblacion;
            item.Poblacion = Poblacion;
            item.Provincia = Provincia;
            item.Provincia = Provincia;
            item.Telefono = Telefono;
            item.Telefono = Telefono;
            item.Codigo = Codigo;
            item.Codigo = Codigo;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.fac_clientes.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKfac_clientes(item, db);

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

        public XRSKfac_clientes save(XRSKDataContext db, List<XRSKfac_clientes> elemsList)
        {
            foreach (XRSKfac_clientes currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKfac_clientes delete()
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

        public XRSKfac_clientes delete(XRSKDataContext db)
        {
            // Get Entity
            fac_clientes item = db.fac_clientes.Find(Codigo);
            // Before_Delete call
            item = before_delete(db, item);

            db.fac_clientes.Remove(item);
            db.SaveChanges();

            // Change data
            item.CodigoPostal = null;
            item.CuentaContable = null;
            item.Descripcion = null;
            item.Direccion = null;
            item.Empresa = null;
            item.FormaPago = null;
            item.NIF = null;
            item.Nombre = null;
            item.Pais = null;
            item.Poblacion = null;
            item.Provincia = null;
            item.Telefono = null;
            item.Codigo = null;


            return this;
        }// end delete method with method
        #endregion
    }
}
