using Newtonsoft.Json;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;

/// <summary>
/// Code generated 26/10/2020 11:07:17 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKvw_cfg_menu_usuari : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("categoria")]
        public string categoria { get; set; }
        [JsonProperty("descripcioNivell1")]
        public string? descripcioNivell1 { get; set; }
        [JsonProperty("descripcioNivell2")]
        public string descripcioNivell2 { get; set; }
        [JsonProperty("descripcioObjecte")]
        public string? descripcioObjecte { get; set; }
        [JsonProperty("grup")]
        public string grup { get; set; }
        [JsonProperty("idioma")]
        public string? idioma { get; set; }
        [JsonProperty("objecte")]
        public string objecte { get; set; }
        [JsonProperty("ordreNivell1")]
        public int ordreNivell1 { get; set; }
        [JsonProperty("ordreNivell2")]
        public int ordreNivell2 { get; set; }
        [JsonProperty("ordreNivell3")]
        public int ordreNivell3 { get; set; }
        [JsonProperty("seguretat")]
        public string? seguretat { get; set; }
        [JsonProperty("tipusmenu")]
        public string tipusmenu { get; set; }
        [JsonProperty("tipusObjecte")]
        public string tipusObjecte { get; set; }
        [JsonProperty("titolObjecte")]
        public string? titolObjecte { get; set; }
        [JsonProperty("url")]
        public string? url { get; set; }
        [JsonProperty("usuari")]
        public string usuari { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKvw_cfg_menu_usuari()
        {
        }

        public XRSKvw_cfg_menu_usuari(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKvw_cfg_menu_usuari(vw_cfg_menu_usuari item)
        {
            TOXRSKvw_cfg_menu_usuari(item);
        }

        public XRSKvw_cfg_menu_usuari(vw_cfg_menu_usuari item, XRSKDataContext db)
        {
            TOXRSKvw_cfg_menu_usuari(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKvw_cfg_menu_usuari(vw_cfg_menu_usuari item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKvw_cfg_menu_usuari(item, db);
        }

        private void TOXRSKvw_cfg_menu_usuari(vw_cfg_menu_usuari item, XRSKDataContext db)
        {
            categoria = item.categoria;
            descripcioNivell1 = item.descripcioNivell1;
            descripcioNivell2 = item.descripcioNivell2;
            descripcioObjecte = item.descripcioObjecte;
            grup = item.grup;
            idioma = item.idioma;
            objecte = item.objecte;
            ordreNivell1 = item.ordreNivell1;
            ordreNivell2 = item.ordreNivell2;
            ordreNivell3 = item.ordreNivell3;
            seguretat = item.seguretat;
            tipusmenu = item.tipusmenu;
            tipusObjecte = item.tipusObjecte;
            titolObjecte = item.titolObjecte;
            url = item.url;
            usuari = item.usuari;


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKvw_cfg_menu_usuari> TOXRSKvw_cfg_menu_usuari(List<vw_cfg_menu_usuari> items)
        {
            List<XRSKvw_cfg_menu_usuari> elemList = new List<XRSKvw_cfg_menu_usuari>();
            foreach (vw_cfg_menu_usuari item in items)
            {
                elemList.Add(new XRSKvw_cfg_menu_usuari(item));
            }

            return elemList;
        }

        private IQueryable<vw_cfg_menu_usuari> aplicarSeguridad(IQueryable<vw_cfg_menu_usuari> query)
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

        private IQueryable<vw_cfg_menu_usuari> aplicarFiltro(IQueryable<vw_cfg_menu_usuari> query, FilterModel filter)
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
        public List<XRSKvw_cfg_menu_usuari> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create vw_cfg_menu_usuari entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<vw_cfg_menu_usuari> items = db.vw_cfg_menu_usuari.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKvw_cfg_menu_usuari(items);
        }

        public List<XRSKvw_cfg_menu_usuari> GetList(string usuari)
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create vw_cfg_menu_usuari entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<vw_cfg_menu_usuari> items = db.vw_cfg_menu_usuari.
                Where(x => x.usuari.Equals(usuari)).
                ToList();
            return TOXRSKvw_cfg_menu_usuari(items);
        }

        public XRSKvw_cfg_menu_usuari GetObj(string obj)
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create vw_cfg_menu_usuari entry at SPSXRiskv2\Models\XRSKDataContext.cs
            vw_cfg_menu_usuari item = db.vw_cfg_menu_usuari.
            Where(x => x.objecte == obj).FirstOrDefault();

            TOXRSKvw_cfg_menu_usuari(item);

            return this;
        }

        public XRSKvw_cfg_menu_usuari GetDescripcio(string grup)
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create vw_cfg_menu_usuari entry at SPSXRiskv2\Models\XRSKDataContext.cs
            vw_cfg_menu_usuari item = db.vw_cfg_menu_usuari.Where(x => x.grup == grup).FirstOrDefault();

            if(item != null)
            {
                TOXRSKvw_cfg_menu_usuari(item);
            }
            return this;
        }

        public string GetPrimerNivell(string tipusmenu)
        {
            XRSKDataContext db = new XRSKDataContext();
            string stringprimernivell = "";

            /// You have to create vw_cfg_menu_usuari entry at SPSXRiskv2\Models\XRSKDataContext.cs
            vw_cfg_menu_usuari item = db.vw_cfg_menu_usuari.Where(x => x.tipusmenu == tipusmenu).FirstOrDefault();

            if (item != null)
            {
                TOXRSKvw_cfg_menu_usuari(item);
                stringprimernivell = item.descripcioNivell1;
            }

            return stringprimernivell;
        }

        public List<XRSKvw_cfg_menu_usuari> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.vw_cfg_menu_usuari//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKvw_cfg_menu_usuari(query.ToList());
        }
        #endregion

        #region Persistencia
        private vw_cfg_menu_usuari before_insert(XRSKDataContext db, vw_cfg_menu_usuari next)
        {
            return next;
        }// end before_insert method

        private vw_cfg_menu_usuari before_update(XRSKDataContext db, vw_cfg_menu_usuari prev, vw_cfg_menu_usuari next)
        {
            return next;
        }// end before_update method

        private vw_cfg_menu_usuari before_delete(XRSKDataContext db, vw_cfg_menu_usuari prev)
        {
            return prev;
        }// end before_delete method

        private vw_cfg_menu_usuari after_insert(XRSKDataContext db, vw_cfg_menu_usuari next)
        {
            return next;
        }// end after_insert method

        private vw_cfg_menu_usuari after_update(XRSKDataContext db, vw_cfg_menu_usuari prev, vw_cfg_menu_usuari next)
        {
            return next;
        }// end after_update method

        public XRSKvw_cfg_menu_usuari save()
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

        public XRSKvw_cfg_menu_usuari save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            vw_cfg_menu_usuari item = db.vw_cfg_menu_usuari.Find();
            vw_cfg_menu_usuari previous = new vw_cfg_menu_usuari();
            // Change data
            if (item == null)
            {
                item = new vw_cfg_menu_usuari();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.categoria = categoria;
            item.descripcioNivell1 = descripcioNivell1;
            item.descripcioNivell2 = descripcioNivell2;
            item.descripcioObjecte = descripcioObjecte;
            item.grup = grup;
            item.idioma = idioma;
            item.objecte = objecte;
            item.ordreNivell1 = ordreNivell1;
            item.ordreNivell2 = ordreNivell2;
            item.ordreNivell3 = ordreNivell3;
            item.seguretat = seguretat;
            item.tipusmenu = tipusmenu;
            item.tipusObjecte = tipusObjecte;
            item.titolObjecte = titolObjecte;
            item.url = url;
            item.usuari = usuari;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.vw_cfg_menu_usuari.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKvw_cfg_menu_usuari(item, db);

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

        public XRSKvw_cfg_menu_usuari save(XRSKDataContext db, List<XRSKvw_cfg_menu_usuari> elemsList)
        {
            foreach (XRSKvw_cfg_menu_usuari currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKvw_cfg_menu_usuari delete()
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

        public XRSKvw_cfg_menu_usuari delete(XRSKDataContext db)
        {
            // Get Entity
            vw_cfg_menu_usuari item = db.vw_cfg_menu_usuari.Find();
            // Before_Delete call
            item = before_delete(db, item);

            db.vw_cfg_menu_usuari.Remove(item);
            db.SaveChanges();

            // Change data
            item.categoria = null;
            item.descripcioNivell1 = null;
            item.descripcioNivell2 = null;
            item.descripcioObjecte = null;
            item.grup = null;
            item.idioma = null;
            item.objecte = null;
            item.ordreNivell1 = 0;
            item.ordreNivell2 = 0;
            item.ordreNivell3 = 0;
            item.seguretat = null;
            item.tipusmenu = null;
            item.tipusObjecte = null;
            item.titolObjecte = null;
            item.url = null;
            item.usuari = null;


            return this;
        }// end delete method with method
        #endregion
    }
}
