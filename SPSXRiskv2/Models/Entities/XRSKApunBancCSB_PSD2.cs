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
/// Code generated 14/09/2020 11:48:55 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKApunBancCSB_PSD2 : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("ABCBanco")]
        public string ABCBanco { get; set; }
        [JsonProperty("ABCClaOfiOri")]
        public string ABCClaOfiOri { get; set; }
        [JsonProperty("ABCCodCTA")]
        public string ABCCodCTA { get; set; }
        [JsonProperty("ABCCodUSR")]
        public string ABCCodUSR { get; set; }
        [JsonProperty("ABCComple1")]
        public string ABCComple1 { get; set; }
        [JsonProperty("ABCComple10")]
        public string ABCComple10 { get; set; }
        [JsonProperty("ABCComple2")]
        public string ABCComple2 { get; set; }
        [JsonProperty("ABCComple3")]
        public string ABCComple3 { get; set; }
        [JsonProperty("ABCComple4")]
        public string ABCComple4 { get; set; }
        [JsonProperty("ABCComple5")]
        public string ABCComple5 { get; set; }
        [JsonProperty("ABCComple6")]
        public string ABCComple6 { get; set; }
        [JsonProperty("ABCComple7")]
        public string ABCComple7 { get; set; }
        [JsonProperty("ABCComple8")]
        public string ABCComple8 { get; set; }
        [JsonProperty("ABCComple9")]
        public string ABCComple9 { get; set; }
        [JsonProperty("ABCConCom")]
        public string ABCConCom { get; set; }
        [JsonProperty("ABCConPro")]
        public string ABCConPro { get; set; }
        [JsonProperty("ABCCuenta")]
        public string ABCCuenta { get; set; }
        [JsonProperty("ABCDocumento")]
        public string ABCDocumento { get; set; }
        [JsonProperty("ABCFechaRealConc")]
        public DateTime? ABCFechaRealConc { get; set; }
        [JsonProperty("ABCFechConcil")]
        public DateTime? ABCFechConcil { get; set; }
        [JsonProperty("ABCFechIntro")]
        public DateTime? ABCFechIntro { get; set; }
        [JsonProperty("ABCFechOper")]
        public DateTime? ABCFechOper { get; set; }
        [JsonProperty("ABCFechVal")]
        public DateTime? ABCFechVal { get; set; }
        [JsonProperty("ABCFichEnt")]
        public string ABCFichEnt { get; set; }
        [JsonProperty("ABCGrupo")]
        public string ABCGrupo { get; set; }
        [JsonProperty("ABCHistorif")]
        public bool? ABCHistorif { get; set; }
        [JsonProperty("ABCImporte")]
        public decimal? ABCImporte { get; set; }
        [JsonProperty("ABCIncorporado")]
        public bool ABCIncorporado { get; set; }
        [JsonProperty("ABCLibreLogico1")]
        public bool? ABCLibreLogico1 { get; set; }
        [JsonProperty("ABCLibreLogico2")]
        public bool? ABCLibreLogico2 { get; set; }
        [JsonProperty("ABCLibreLogico3")]
        public bool? ABCLibreLogico3 { get; set; }
        [JsonProperty("ABCLibreTexto1")]
        public string ABCLibreTexto1 { get; set; }
        [JsonProperty("ABCLibreTexto2")]
        public string ABCLibreTexto2 { get; set; }
        [JsonProperty("ABCLibreTexto3")]
        public string ABCLibreTexto3 { get; set; }
        [JsonProperty("ABCOficina")]
        public string ABCOficina { get; set; }
        [JsonProperty("ABCRef1")]
        public string ABCRef1 { get; set; }
        [JsonProperty("ABCRef2")]
        public string ABCRef2 { get; set; }
        [JsonProperty("ABCRefConcil")]
        public double? ABCRefConcil { get; set; }
        [JsonProperty("ABCSigno")]
        public string ABCSigno { get; set; }
        [JsonProperty("ABCTipConcil")]
        public string ABCTipConcil { get; set; }
        [JsonProperty("ABCValorOrganizativo")]
        public string ABCValorOrganizativo { get; set; }
        [JsonProperty("ABCNumerador")]
        public double ABCNumerador { get; set; }
        [JsonProperty("ABCCodCIA")]
        public string ABCCodCIA { get; set; }

        public string numcuenta { get; set; }
        public string complementos { get; set; }
        public string operacion { get; set; }
        public String conComun { get; set; }

        public string cliente { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKApunBancCSB_PSD2()
        {
        }

        public XRSKApunBancCSB_PSD2(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKApunBancCSB_PSD2(ApunBancCSB_PSD2 item)
        {
            TOXRSKApunBancCSB_PSD2(item);
        }

        public XRSKApunBancCSB_PSD2(ApunBancCSB_PSD2 item, ConComun CC)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKApunBancCSB_PSD2_CC(item, CC, db);
        }

        public XRSKApunBancCSB_PSD2(ApunBancCSB_PSD2 item, XRSKDataContext db)
        {
            TOXRSKApunBancCSB_PSD2(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKApunBancCSB_PSD2(ApunBancCSB_PSD2 item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKApunBancCSB_PSD2(item, db);
        }

        private void TOXRSKApunBancCSB_PSD2(ApunBancCSB_PSD2 item, XRSKDataContext db)
        {
            ABCBanco = item.ABCBanco;
            ABCClaOfiOri = item.ABCClaOfiOri;
            ABCCodCTA = item.ABCCodCTA;
            ABCCodUSR = item.ABCCodUSR;
            ABCComple1 = item.ABCComple1;
            ABCComple10 = item.ABCComple10;
            ABCComple2 = item.ABCComple2;
            ABCComple3 = item.ABCComple3;
            ABCComple4 = item.ABCComple4;
            ABCComple5 = item.ABCComple5;
            ABCComple6 = item.ABCComple6;
            ABCComple7 = item.ABCComple7;
            ABCComple8 = item.ABCComple8;
            ABCComple9 = item.ABCComple9;
            ABCConCom = item.ABCConCom;
            ABCConPro = item.ABCConPro;
            ABCCuenta = item.ABCCuenta;
            ABCDocumento = item.ABCDocumento;
            ABCFechaRealConc = item.ABCFechaRealConc;
            ABCFechConcil = item.ABCFechConcil;
            ABCFechIntro = item.ABCFechIntro;
            ABCFechOper = item.ABCFechOper;
            ABCFechVal = item.ABCFechVal;
            ABCFichEnt = item.ABCFichEnt;
            ABCGrupo = item.ABCGrupo;
            ABCHistorif = item.ABCHistorif;
            ABCImporte = item.ABCImporte;
            ABCIncorporado = item.ABCIncorporado;
            ABCLibreLogico1 = item.ABCLibreLogico1;
            ABCLibreLogico2 = item.ABCLibreLogico2;
            ABCLibreLogico3 = item.ABCLibreLogico3;
            ABCLibreTexto1 = item.ABCLibreTexto1;
            ABCLibreTexto2 = item.ABCLibreTexto2;
            ABCLibreTexto3 = item.ABCLibreTexto3;
            ABCOficina = item.ABCOficina;
            ABCRef1 = item.ABCRef1;
            ABCRef2 = item.ABCRef2;
            ABCRefConcil = item.ABCRefConcil;
            ABCSigno = item.ABCSigno;
            ABCTipConcil = item.ABCTipConcil;
            ABCValorOrganizativo = item.ABCValorOrganizativo;
            ABCNumerador = item.ABCNumerador;
            ABCCodCIA = item.ABCCodCIA;

            numcuenta = ABCBanco + " " + ABCOficina + " " + " " + ABCCuenta;

            complementos = item.ABCComple1 + " " + ABCComple2 + " " + ABCComple3 + " " + ABCComple4 + " " + ABCComple5 + " " + ABCComple6 + " " + ABCComple7 + " " + ABCComple8 + " " + ABCComple9 + " " + ABCComple10;
            complementos = complementos.Trim();

            operacion = ABCConCom + "/" + ABCConPro;

        }

        private void TOXRSKApunBancCSB_PSD2_CC(ApunBancCSB_PSD2 item, ConComun cc, XRSKDataContext db)
        {
            ABCBanco = item.ABCBanco;
            ABCClaOfiOri = item.ABCClaOfiOri;
            ABCCodCTA = item.ABCCodCTA;
            ABCCodUSR = item.ABCCodUSR;
            ABCComple1 = item.ABCComple1;
            ABCComple10 = item.ABCComple10;
            ABCComple2 = item.ABCComple2;
            ABCComple3 = item.ABCComple3;
            ABCComple4 = item.ABCComple4;
            ABCComple5 = item.ABCComple5;
            ABCComple6 = item.ABCComple6;
            ABCComple7 = item.ABCComple7;
            ABCComple8 = item.ABCComple8;
            ABCComple9 = item.ABCComple9;
            ABCConCom = item.ABCConCom;
            ABCConPro = item.ABCConPro;
            ABCCuenta = item.ABCCuenta;
            ABCDocumento = item.ABCDocumento;
            ABCFechaRealConc = item.ABCFechaRealConc;
            ABCFechConcil = item.ABCFechConcil;
            ABCFechIntro = item.ABCFechIntro;
            ABCFechOper = item.ABCFechOper;
            ABCFechVal = item.ABCFechVal;
            ABCFichEnt = item.ABCFichEnt;
            ABCGrupo = item.ABCGrupo;
            ABCHistorif = item.ABCHistorif;
            ABCImporte = item.ABCImporte;
            ABCIncorporado = item.ABCIncorporado;
            ABCLibreLogico1 = item.ABCLibreLogico1;
            ABCLibreLogico2 = item.ABCLibreLogico2;
            ABCLibreLogico3 = item.ABCLibreLogico3;
            ABCLibreTexto1 = item.ABCLibreTexto1;
            ABCLibreTexto2 = item.ABCLibreTexto2;
            ABCLibreTexto3 = item.ABCLibreTexto3;
            ABCOficina = item.ABCOficina;
            ABCRef1 = item.ABCRef1;
            ABCRef2 = item.ABCRef2;
            ABCRefConcil = item.ABCRefConcil;
            ABCSigno = item.ABCSigno;
            ABCTipConcil = item.ABCTipConcil;
            ABCValorOrganizativo = item.ABCValorOrganizativo;
            ABCNumerador = item.ABCNumerador;
            ABCCodCIA = item.ABCCodCIA;

            numcuenta = ABCBanco + " " + ABCOficina + " " + " " + ABCCuenta;

            complementos = item.ABCComple1 + " " + ABCComple2 + " " + ABCComple3 + " " + ABCComple4 + " " + ABCComple5 + " " + ABCComple6 + " " + ABCComple7 + " " + ABCComple8;
            complementos = complementos.Trim();

            operacion = ABCConCom + "/" + ABCConPro;

            cliente = item.ABCComple9;

            conComun = cc.CCCDescripcion;

        }

        private List<XRSKApunBancCSB_PSD2> TOXRSKApunBancCSB_PSD2(List<ApunBancCSB_PSD2> items)
        {
            List<XRSKApunBancCSB_PSD2> elemList = new List<XRSKApunBancCSB_PSD2>();
            foreach (ApunBancCSB_PSD2 item in items)
            {
                elemList.Add(new XRSKApunBancCSB_PSD2(item));
            }

            return elemList;
        }

        private IQueryable<ApunBancCSB_PSD2> aplicarSeguridad(IQueryable<ApunBancCSB_PSD2> query)
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

        private IQueryable<ApunBancCSB_PSD2> aplicarFiltro(IQueryable<ApunBancCSB_PSD2> query, FilterModel filter)
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
        public List<XRSKApunBancCSB_PSD2> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();
            XRSKConComunCSB xrskConComun = new XRSKConComunCSB();
            List<XRSKApunBancCSB_PSD2> ccList = new List<XRSKApunBancCSB_PSD2>();

            List<ApunBancCSB_PSD2> items = db.ApunBancCSB_PSD2.ToList();

            foreach(ApunBancCSB_PSD2 item in items)
            {
                ConComun CComun = xrskConComun.getDescripcion(item.ABCConCom);
                ccList.Add(new XRSKApunBancCSB_PSD2(item, CComun));
            }

            return ccList;
        }

        public List<XRSKApunBancCSB_PSD2> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.ApunBancCSB_PSD2//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKApunBancCSB_PSD2(query.ToList());
        }

        public XRSKApunBancCSB_PSD2 Find(double ABCNumerador, string ABCCodCIA)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(ABCNumerador, ABCCodCIA, db);
        }// end Find method

        public XRSKApunBancCSB_PSD2 Find(double ABCNumerador, string ABCCodCIA, XRSKDataContext db)
        {
            ApunBancCSB_PSD2 item = db.ApunBancCSB_PSD2.Find(ABCNumerador, ABCCodCIA);
            TOXRSKApunBancCSB_PSD2(item);
            return this;
        }
        #endregion

        #region Persistencia
        private ApunBancCSB_PSD2 before_insert(XRSKDataContext db, ApunBancCSB_PSD2 next)
        {
            return next;
        }// end before_insert method

        private ApunBancCSB_PSD2 before_update(XRSKDataContext db, ApunBancCSB_PSD2 prev, ApunBancCSB_PSD2 next)
        {
            return next;
        }// end before_update method

        private ApunBancCSB_PSD2 before_delete(XRSKDataContext db, ApunBancCSB_PSD2 prev)
        {
            return prev;
        }// end before_delete method

        private ApunBancCSB_PSD2 after_insert(XRSKDataContext db, ApunBancCSB_PSD2 next)
        {
            return next;
        }// end after_insert method

        private ApunBancCSB_PSD2 after_update(XRSKDataContext db, ApunBancCSB_PSD2 prev, ApunBancCSB_PSD2 next)
        {
            return next;
        }// end after_update method

        public XRSKApunBancCSB_PSD2 save()
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

        public XRSKApunBancCSB_PSD2 save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            ApunBancCSB_PSD2 item = db.ApunBancCSB_PSD2.Find(ABCNumerador, ABCCodCIA);
            ApunBancCSB_PSD2 previous = new ApunBancCSB_PSD2();
            // Change data
            if (item == null)
            {
                item = new ApunBancCSB_PSD2();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.ABCBanco = ABCBanco;
            item.ABCBanco = ABCBanco;
            item.ABCClaOfiOri = ABCClaOfiOri;
            item.ABCClaOfiOri = ABCClaOfiOri;
            item.ABCCodCTA = ABCCodCTA;
            item.ABCCodCTA = ABCCodCTA;
            item.ABCCodUSR = ABCCodUSR;
            item.ABCCodUSR = ABCCodUSR;
            item.ABCComple1 = ABCComple1;
            item.ABCComple1 = ABCComple1;
            item.ABCComple10 = ABCComple10;
            item.ABCComple10 = ABCComple10;
            item.ABCComple2 = ABCComple2;
            item.ABCComple2 = ABCComple2;
            item.ABCComple3 = ABCComple3;
            item.ABCComple3 = ABCComple3;
            item.ABCComple4 = ABCComple4;
            item.ABCComple4 = ABCComple4;
            item.ABCComple5 = ABCComple5;
            item.ABCComple5 = ABCComple5;
            item.ABCComple6 = ABCComple6;
            item.ABCComple6 = ABCComple6;
            item.ABCComple7 = ABCComple7;
            item.ABCComple7 = ABCComple7;
            item.ABCComple8 = ABCComple8;
            item.ABCComple8 = ABCComple8;
            item.ABCComple9 = ABCComple9;
            item.ABCComple9 = ABCComple9;
            item.ABCConCom = ABCConCom;
            item.ABCConCom = ABCConCom;
            item.ABCConPro = ABCConPro;
            item.ABCConPro = ABCConPro;
            item.ABCCuenta = ABCCuenta;
            item.ABCCuenta = ABCCuenta;
            item.ABCDocumento = ABCDocumento;
            item.ABCDocumento = ABCDocumento;
            item.ABCFechaRealConc = ABCFechaRealConc;
            item.ABCFechaRealConc = ABCFechaRealConc;
            item.ABCFechConcil = ABCFechConcil;
            item.ABCFechConcil = ABCFechConcil;
            item.ABCFechIntro = ABCFechIntro;
            item.ABCFechIntro = ABCFechIntro;
            item.ABCFechOper = ABCFechOper;
            item.ABCFechOper = ABCFechOper;
            item.ABCFechVal = ABCFechVal;
            item.ABCFechVal = ABCFechVal;
            item.ABCFichEnt = ABCFichEnt;
            item.ABCFichEnt = ABCFichEnt;
            item.ABCGrupo = ABCGrupo;
            item.ABCGrupo = ABCGrupo;
            item.ABCHistorif = ABCHistorif;
            item.ABCHistorif = ABCHistorif;
            item.ABCImporte = ABCImporte;
            item.ABCImporte = ABCImporte;
            item.ABCIncorporado = ABCIncorporado;
            item.ABCIncorporado = ABCIncorporado;
            item.ABCLibreLogico1 = ABCLibreLogico1;
            item.ABCLibreLogico1 = ABCLibreLogico1;
            item.ABCLibreLogico2 = ABCLibreLogico2;
            item.ABCLibreLogico2 = ABCLibreLogico2;
            item.ABCLibreLogico3 = ABCLibreLogico3;
            item.ABCLibreLogico3 = ABCLibreLogico3;
            item.ABCLibreTexto1 = ABCLibreTexto1;
            item.ABCLibreTexto1 = ABCLibreTexto1;
            item.ABCLibreTexto2 = ABCLibreTexto2;
            item.ABCLibreTexto2 = ABCLibreTexto2;
            item.ABCLibreTexto3 = ABCLibreTexto3;
            item.ABCLibreTexto3 = ABCLibreTexto3;
            item.ABCOficina = ABCOficina;
            item.ABCOficina = ABCOficina;
            item.ABCRef1 = ABCRef1;
            item.ABCRef1 = ABCRef1;
            item.ABCRef2 = ABCRef2;
            item.ABCRef2 = ABCRef2;
            item.ABCRefConcil = ABCRefConcil;
            item.ABCRefConcil = ABCRefConcil;
            item.ABCSigno = ABCSigno;
            item.ABCSigno = ABCSigno;
            item.ABCTipConcil = ABCTipConcil;
            item.ABCTipConcil = ABCTipConcil;
            item.ABCValorOrganizativo = ABCValorOrganizativo;
            item.ABCValorOrganizativo = ABCValorOrganizativo;
            item.ABCNumerador = ABCNumerador;
            item.ABCNumerador = ABCNumerador;
            item.ABCCodCIA = ABCCodCIA;
            item.ABCCodCIA = ABCCodCIA;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.ApunBancCSB_PSD2.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKApunBancCSB_PSD2(item, db);

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

        public XRSKApunBancCSB_PSD2 save(XRSKDataContext db, List<XRSKApunBancCSB_PSD2> elemsList)
        {
            foreach (XRSKApunBancCSB_PSD2 currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKApunBancCSB_PSD2 delete()
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

        public XRSKApunBancCSB_PSD2 delete(XRSKDataContext db)
        {
            // Get Entity
            ApunBancCSB_PSD2 item = db.ApunBancCSB_PSD2.Find(ABCNumerador, ABCCodCIA);
            // Before_Delete call
            item = before_delete(db, item);

            db.ApunBancCSB_PSD2.Remove(item);
            db.SaveChanges();

            // Change data
            item.ABCBanco = null;
            item.ABCClaOfiOri = null;
            item.ABCCodCTA = null;
            item.ABCCodUSR = null;
            item.ABCComple1 = null;
            item.ABCComple10 = null;
            item.ABCComple2 = null;
            item.ABCComple3 = null;
            item.ABCComple4 = null;
            item.ABCComple5 = null;
            item.ABCComple6 = null;
            item.ABCComple7 = null;
            item.ABCComple8 = null;
            item.ABCComple9 = null;
            item.ABCConCom = null;
            item.ABCConPro = null;
            item.ABCCuenta = null;
            item.ABCDocumento = null;
            item.ABCFechaRealConc = DateTime.Today;
            item.ABCFechConcil = DateTime.Today;
            item.ABCFechIntro = DateTime.Today;
            item.ABCFechOper = DateTime.Today;
            item.ABCFechVal = DateTime.Today;
            item.ABCFichEnt = null;
            item.ABCGrupo = null;
            item.ABCHistorif = false;
            item.ABCImporte = 0;
            item.ABCIncorporado = false;
            item.ABCLibreLogico1 = false;
            item.ABCLibreLogico2 = false;
            item.ABCLibreLogico3 = false;
            item.ABCLibreTexto1 = null;
            item.ABCLibreTexto2 = null;
            item.ABCLibreTexto3 = null;
            item.ABCOficina = null;
            item.ABCRef1 = null;
            item.ABCRef2 = null;
            item.ABCRefConcil = 0;
            item.ABCSigno = null;
            item.ABCTipConcil = null;
            item.ABCValorOrganizativo = null;
            item.ABCNumerador = 0;
            item.ABCCodCIA = null;


            return this;
        }// end delete method with method
        #endregion
    }
}
