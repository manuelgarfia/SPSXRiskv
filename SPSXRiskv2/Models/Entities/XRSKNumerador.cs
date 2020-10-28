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
using System.Reflection;

/// <summary>
/// Code generated 28/09/2020 12:07:03 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKNumerador : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("NUMUltApunBanco")]
        public int NUMUltApunBanco { get; set; }
        [JsonProperty("NUMUltAsignacion")]
        public int NUMUltAsignacion { get; set; }
        [JsonProperty("NUMUltCobertura")]
        public int NUMUltCobertura { get; set; }
        [JsonProperty("NUMUltConciliacion")]
        public int NUMUltConciliacion { get; set; }
        [JsonProperty("NUMUltContable")]
        public int NUMUltContable { get; set; }
        [JsonProperty("NUMUltMvto")]
        public int NUMUltMvto { get; set; }
        [JsonProperty("NUMUltOperaciones")]
        public int NUMUltOperaciones { get; set; }
        [JsonProperty("NUMGrupo")]
        public string NUMGrupo { get; set; }
        [JsonProperty("NUMNiv")]
        public string NUMNiv { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKNumerador()
        {
        }

        public XRSKNumerador(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKNumerador(Numerador item)
        {
            TOXRSKNumerador(item);
        }

        public XRSKNumerador(Numerador item, XRSKDataContext db)
        {
            TOXRSKNumerador(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKNumerador(Numerador item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKNumerador(item, db);
        }

        private void TOXRSKNumerador(Numerador item, XRSKDataContext db)
        {
            NUMUltApunBanco = item.NUMUltApunBanco;
            NUMUltAsignacion = item.NUMUltAsignacion;
            NUMUltCobertura = item.NUMUltCobertura;
            NUMUltConciliacion = item.NUMUltConciliacion;
            NUMUltContable = item.NUMUltContable;
            NUMUltMvto = item.NUMUltMvto;
            NUMUltOperaciones = item.NUMUltOperaciones;
            NUMGrupo = item.NUMGrupo;
            NUMNiv = item.NUMNiv;


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKNumerador> TOXRSKNumerador(List<Numerador> items)
        {
            List<XRSKNumerador> elemList = new List<XRSKNumerador>();
            foreach (Numerador item in items)
            {
                elemList.Add(new XRSKNumerador(item));
            }

            return elemList;
        }

        private IQueryable<Numerador> aplicarSeguridad(IQueryable<Numerador> query)
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

        private IQueryable<Numerador> aplicarFiltro(IQueryable<Numerador> query, FilterModel filter)
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
        public List<XRSKNumerador> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create Numerador entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<Numerador> items = db.Numerador.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKNumerador(items);
        }

        public List<XRSKNumerador> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.Numerador//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKNumerador(query.ToList());
        }

        public XRSKNumerador Find(string NUMGrupo, string NUMNiv)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(NUMGrupo, NUMNiv, db);
        }// end Find method

        public XRSKNumerador Find(string NUMGrupo, string NUMNiv, XRSKDataContext db)
        {
            Numerador item = db.Numerador.Find(NUMGrupo, NUMNiv);
            TOXRSKNumerador(item);
            return this;
        }
        #endregion

        #region Procesos
        /// <summary>
        /// Para una compañía concreta y un numerador concreto, obtiene y actualiza su valor
        /// </summary>
        /// <param name="db"></param>
        /// <param name="companyia">Código de compañía para la que obtener el numerador</param>
        /// <param name="campo">Numerador a retornar</param>
        /// <exception cref="NullReferenceException">Si el campo pasado por parámetro no existe</exception>
        /// <returns></returns>
        public int GetAndUpdate(XRSKDataContext db, string companyia, string campo)
        {
            //Obtengo la compañía para la que quiero el numerador
            XRSKCompanyia cia = new XRSKCompanyia();
            cia.GetCompanyia(companyia);

            //A partir de la compañía obtengo su registro de numeradores
            XRSKNumerador numerador = new XRSKNumerador();
            numerador.Find(cia.CIAGrupo, cia.CIAValorOrganizativo);

            //Obtengo el numerador en cuestión; si no existe lanzará una excepción
            Type type = numerador.GetType();
            PropertyInfo propertyInfo = type.GetProperty(campo);
            int value = Convert.ToInt32(propertyInfo.GetValue(numerador, null));

            //Incrementar el valor del numerador
            value++;

            //Actualizar el valor del numerador
            propertyInfo.SetValue(numerador, value, null);

            //Guardar el valor
            numerador.save(db);

            return value;
        }
        #endregion

        #region Persistencia
        private Numerador before_insert(XRSKDataContext db, Numerador next)
        {
            return next;
        }// end before_insert method

        private Numerador before_update(XRSKDataContext db, Numerador prev, Numerador next)
        {
            return next;
        }// end before_update method

        private Numerador before_delete(XRSKDataContext db, Numerador prev)
        {
            return prev;
        }// end before_delete method

        private Numerador after_insert(XRSKDataContext db, Numerador next)
        {
            return next;
        }// end after_insert method

        private Numerador after_update(XRSKDataContext db, Numerador prev, Numerador next)
        {
            return next;
        }// end after_update method

        public XRSKNumerador save()
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

        public XRSKNumerador save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            Numerador item = db.Numerador.Find(NUMGrupo, NUMNiv);
            Numerador previous = new Numerador();
            // Change data
            if (item == null)
            {
                item = new Numerador();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.NUMUltApunBanco = NUMUltApunBanco;
            item.NUMUltAsignacion = NUMUltAsignacion;
            item.NUMUltCobertura = NUMUltCobertura;
            item.NUMUltConciliacion = NUMUltConciliacion;
            item.NUMUltContable = NUMUltContable;
            item.NUMUltMvto = NUMUltMvto;
            item.NUMUltOperaciones = NUMUltOperaciones;
            item.NUMGrupo = NUMGrupo;
            item.NUMNiv = NUMNiv;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.Numerador.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKNumerador(item, db);

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

        public XRSKNumerador save(XRSKDataContext db, List<XRSKNumerador> elemsList)
        {
            foreach (XRSKNumerador currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKNumerador delete()
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

        public XRSKNumerador delete(XRSKDataContext db)
        {
            // Get Entity
            Numerador item = db.Numerador.Find(NUMGrupo, NUMNiv);
            // Before_Delete call
            item = before_delete(db, item);

            db.Numerador.Remove(item);
            db.SaveChanges();

            // Change data
            item.NUMUltApunBanco = 0;
            item.NUMUltAsignacion = 0;
            item.NUMUltCobertura = 0;
            item.NUMUltConciliacion = 0;
            item.NUMUltContable = 0;
            item.NUMUltMvto = 0;
            item.NUMUltOperaciones = 0;
            item.NUMGrupo = null;
            item.NUMNiv = null;


            return this;
        }// end delete method with method
        #endregion
    }
}
