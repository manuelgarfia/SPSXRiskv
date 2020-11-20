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
/// Code generated 14/09/2020 9:34:15 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKDesgloseContr : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("DCP_CPT_TRI_MN_Cb1")]
        public double? DCP_CPT_TRI_MN_Cb1 { get; set; }
        [JsonProperty("DCP_CPT_TRI_MN_Cb2")]
        public double? DCP_CPT_TRI_MN_Cb2 { get; set; }
        [JsonProperty("DCP_ImpTri_CPT_MN")]
        public double? DCP_ImpTri_CPT_MN { get; set; }
        [JsonProperty("DCP_ImpTri_PAR_CPT")]
        public double? DCP_ImpTri_PAR_CPT { get; set; }
        [JsonProperty("DCP_ImpTri_PAR_MN")]
        public double? DCP_ImpTri_PAR_MN { get; set; }
        [JsonProperty("DCP_Par_TRI_CPT_Cb1")]
        public double? DCP_Par_TRI_CPT_Cb1 { get; set; }
        [JsonProperty("DCP_Par_TRI_CPT_Cb2")]
        public double? DCP_Par_TRI_CPT_Cb2 { get; set; }
        [JsonProperty("DCP_Par_TRI_MN_Cb1")]
        public double? DCP_Par_TRI_MN_Cb1 { get; set; }
        [JsonProperty("DCP_Par_TRI_MN_Cb2")]
        public double? DCP_Par_TRI_MN_Cb2 { get; set; }
        [JsonProperty("DCPAgrupacionContrapartidaCPT")]
        public string DCPAgrupacionContrapartidaCPT { get; set; }
        [JsonProperty("DCPBaseImponible")]
        public double? DCPBaseImponible { get; set; }
        [JsonProperty("DCPCambioDivCptMn")]
        public double? DCPCambioDivCptMn { get; set; }
        [JsonProperty("DCPCambioDivisaCpt")]
        public double? DCPCambioDivisaCpt { get; set; }
        [JsonProperty("DCPCodCPT")]
        public string DCPCodCPT { get; set; }
        [JsonProperty("DCPComisCambioCPT")]
        public bool DCPComisCambioCPT { get; set; }
        [JsonProperty("DCPComisionCPT")]
        public bool DCPComisionCPT { get; set; }
        [JsonProperty("DCPConceptoFicticioCPT")]
        public bool DCPConceptoFicticioCPT { get; set; }
        [JsonProperty("DCPContrapartCPT")]
        public bool DCPContrapartCPT { get; set; }
        [JsonProperty("DCPCtaIVACPT")]
        public string DCPCtaIVACPT { get; set; }
        [JsonProperty("DCPCuentaContableCPT")]
        public string DCPCuentaContableCPT { get; set; }
        [JsonProperty("DCPDescripcionCPT")]
        public string DCPDescripcionCPT { get; set; }
        [JsonProperty("DCPDiferenciasCPT")]
        public bool DCPDiferenciasCPT { get; set; }
        [JsonProperty("DCPDivisa")]
        public string DCPDivisa { get; set; }
        [JsonProperty("DCPDivisaCpt")]
        public string DCPDivisaCpt { get; set; }
        [JsonProperty("DCPGrupo")]
        public string DCPGrupo { get; set; }
        [JsonProperty("DCPGtosBancCPT")]
        public bool DCPGtosBancCPT { get; set; }
        [JsonProperty("DCPImporte")]
        public double? DCPImporte { get; set; }
        [JsonProperty("DCPImporteCpt")]
        public double? DCPImporteCpt { get; set; }
        [JsonProperty("DCPImporteCptMn")]
        public double? DCPImporteCptMn { get; set; }
        [JsonProperty("DCPInteresesCPT")]
        public bool DCPInteresesCPT { get; set; }
        [JsonProperty("DCPIVACPT")]
        public bool DCPIVACPT { get; set; }
        [JsonProperty("DCPLibre1CPT")]
        public bool DCPLibre1CPT { get; set; }
        [JsonProperty("DCPLibre2CPT")]
        public bool DCPLibre2CPT { get; set; }
        [JsonProperty("DCPLibre3CPT")]
        public bool DCPLibre3CPT { get; set; }
        [JsonProperty("DCPLibre4CPT")]
        public bool DCPLibre4CPT { get; set; }
        [JsonProperty("DCPLibre5CPT")]
        public bool DCPLibre5CPT { get; set; }
        [JsonProperty("DCPLibre6CPT")]
        public bool DCPLibre6CPT { get; set; }
        [JsonProperty("DCPLibre7CPT")]
        public bool DCPLibre7CPT { get; set; }
        [JsonProperty("DCPLibre8CPT")]
        public bool DCPLibre8CPT { get; set; }
        [JsonProperty("DCPMonedaCPT")]
        public bool DCPMonedaCPT { get; set; }
        [JsonProperty("DCPPorcentajeIVACPT")]
        public double? DCPPorcentajeIVACPT { get; set; }
        [JsonProperty("DCPRefAnalitica1")]
        public string DCPRefAnalitica1 { get; set; }
        [JsonProperty("DCPRefAnalitica2")]
        public string DCPRefAnalitica2 { get; set; }
        [JsonProperty("DCPRefAnalitica3")]
        public string DCPRefAnalitica3 { get; set; }
        [JsonProperty("DCPRefAnalitica4")]
        public string DCPRefAnalitica4 { get; set; }
        [JsonProperty("DCPRefAnalitica5")]
        public string DCPRefAnalitica5 { get; set; }
        [JsonProperty("DCPRefAnalitica6")]
        public string DCPRefAnalitica6 { get; set; }
        [JsonProperty("DCPRefCont")]
        public string DCPRefCont { get; set; }
        [JsonProperty("DCPSignoCPT")]
        public Int16 DCPSignoCPT { get; set; }
        [JsonProperty("DCPCodCIA")]
        public string DCPCodCIA { get; set; }
        [JsonProperty("DCPValorOrganizativo")]
        public string DCPValorOrganizativo { get; set; }
        [JsonProperty("DCPRefXrisk")]
        public double DCPRefXrisk { get; set; }
        [JsonProperty("DCPContador")]
        public int DCPContador { get; set; }
        public string analitica { get; set; }
        public double? importe { get; set; }
        public double? importeOperacion { get; set; }
        public double? importeMonGrupo { get; set; }
        public string refanalitica { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKDesgloseContr()
        {
        }

        public XRSKDesgloseContr(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKDesgloseContr(DesgloseContr item)
        {
            TOXRSKDesgloseContr(item);
        }

        public XRSKDesgloseContr(DesgloseContr item, XRSKDataContext db)
        {
            TOXRSKDesgloseContr(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKDesgloseContr(DesgloseContr item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKDesgloseContr(item, db);
        }

        private void TOXRSKDesgloseContr(DesgloseContr item, XRSKDataContext db)
        {
            DCP_CPT_TRI_MN_Cb1 = item.DCP_CPT_TRI_MN_Cb1;
            DCP_CPT_TRI_MN_Cb2 = item.DCP_CPT_TRI_MN_Cb2;
            DCP_ImpTri_CPT_MN = item.DCP_ImpTri_CPT_MN;
            DCP_ImpTri_PAR_CPT = item.DCP_ImpTri_PAR_CPT;
            DCP_ImpTri_PAR_MN = item.DCP_ImpTri_PAR_MN;
            DCP_Par_TRI_CPT_Cb1 = item.DCP_Par_TRI_CPT_Cb1;
            DCP_Par_TRI_CPT_Cb2 = item.DCP_Par_TRI_CPT_Cb2;
            DCP_Par_TRI_MN_Cb1 = item.DCP_Par_TRI_MN_Cb1;
            DCP_Par_TRI_MN_Cb2 = item.DCP_Par_TRI_MN_Cb2;
            DCPAgrupacionContrapartidaCPT = item.DCPAgrupacionContrapartidaCPT;
            DCPBaseImponible = item.DCPBaseImponible;
            DCPCambioDivCptMn = item.DCPCambioDivCptMn;
            DCPCambioDivisaCpt = item.DCPCambioDivisaCpt;
            DCPCodCPT = item.DCPCodCPT;
            DCPComisCambioCPT = item.DCPComisCambioCPT;
            DCPComisionCPT = item.DCPComisionCPT;
            DCPConceptoFicticioCPT = item.DCPConceptoFicticioCPT;
            DCPContrapartCPT = item.DCPContrapartCPT;
            DCPCtaIVACPT = item.DCPCtaIVACPT;
            DCPCuentaContableCPT = item.DCPCuentaContableCPT;
            DCPDescripcionCPT = item.DCPDescripcionCPT;
            DCPDiferenciasCPT = item.DCPDiferenciasCPT;
            DCPDivisa = item.DCPDivisa;
            DCPDivisaCpt = item.DCPDivisaCpt;
            DCPGrupo = item.DCPGrupo;
            DCPGtosBancCPT = item.DCPGtosBancCPT;
            DCPImporte = item.DCPImporte;
            DCPImporteCpt = item.DCPImporteCpt;
            DCPImporteCptMn = item.DCPImporteCptMn;
            DCPInteresesCPT = item.DCPInteresesCPT;
            DCPIVACPT = item.DCPIVACPT;
            DCPLibre1CPT = item.DCPLibre1CPT;
            DCPLibre2CPT = item.DCPLibre2CPT;
            DCPLibre3CPT = item.DCPLibre3CPT;
            DCPLibre4CPT = item.DCPLibre4CPT;
            DCPLibre5CPT = item.DCPLibre5CPT;
            DCPLibre6CPT = item.DCPLibre6CPT;
            DCPLibre7CPT = item.DCPLibre7CPT;
            DCPLibre8CPT = item.DCPLibre8CPT;
            DCPMonedaCPT = item.DCPMonedaCPT;
            DCPPorcentajeIVACPT = item.DCPPorcentajeIVACPT;
            DCPRefAnalitica1 = item.DCPRefAnalitica1;
            DCPRefAnalitica2 = item.DCPRefAnalitica2;
            DCPRefAnalitica3 = item.DCPRefAnalitica3;
            DCPRefAnalitica4 = item.DCPRefAnalitica4;
            DCPRefAnalitica5 = item.DCPRefAnalitica5;
            DCPRefAnalitica6 = item.DCPRefAnalitica6;
            DCPRefCont = item.DCPRefCont;
            DCPSignoCPT = item.DCPSignoCPT;
            DCPCodCIA = item.DCPCodCIA;
            DCPValorOrganizativo = item.DCPValorOrganizativo;
            DCPRefXrisk = item.DCPRefXrisk;
            DCPContador = item.DCPContador;

            importe = item.DCPImporte * item.DCPSignoCPT;
            importeOperacion = item.DCPSignoCPT * item.DCPImporteCpt;
            importeMonGrupo = item.DCPSignoCPT * item.DCPImporteCptMn;

            analitica = item.DCPRefAnalitica1 + " " + DCPRefAnalitica2 + " " + DCPRefAnalitica3 + " " + DCPRefAnalitica4 + " " + DCPRefAnalitica5 + " " + DCPRefAnalitica6;
            analitica = analitica.Trim();

            refanalitica = item.DCPRefAnalitica5 + " " + DCPRefAnalitica6;
            refanalitica = refanalitica.Trim();

            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKDesgloseContr> TOXRSKDesgloseContr(List<DesgloseContr> items)
        {
            List<XRSKDesgloseContr> elemList = new List<XRSKDesgloseContr>();
            foreach (DesgloseContr item in items)
            {
                elemList.Add(new XRSKDesgloseContr(item));
            }

            return elemList;
        }

        private IQueryable<DesgloseContr> aplicarSeguridad(IQueryable<DesgloseContr> query)
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

        private IQueryable<DesgloseContr> aplicarFiltro(IQueryable<DesgloseContr> query, FilterModel filter)
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
        public List<XRSKDesgloseContr> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.DesgloseContr select x;

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            ///// You have to create DesgloseContr entry at SPSXRiskv2\Models\XRSKDataContext.cs
            //List< DesgloseContr > items = db.DesgloseContr.
            //    Where(x => x.DCPCodCIA == "290" && x.DCPRefXrisk == 2156).
            //    // Include(x => x.Companyia).
            //    ToList();

            List<DesgloseContr> items = query.ToList();

            return TOXRSKDesgloseContr(items);
        }

        public List<XRSKDesgloseContr> GetShortList(string company, string referencia)
        {
            XRSKDataContext db = new XRSKDataContext();
            List<XRSKDesgloseContr> desgloseList = new List<XRSKDesgloseContr>();

            int reference = Convert.ToInt32(referencia);

            var query = from x in db.DesgloseContr.
                        Where(x => x.DCPCodCIA == company && x.DCPRefXrisk == reference)
                        select x;

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            /// You have to create DesgloseContr entry at SPSXRiskv2\Models\XRSKDataContext.cs
            //List<DesgloseContr> items = db.DesgloseContr.
            //    Where(x => x.DCPCodCIA == company && x.DCPRefXrisk == reference).
            //    ToList();
            List<DesgloseContr> items = query.ToList();

            desgloseList = DesgloseContrTrim(items);

            return desgloseList;
        }

        public List<XRSKDesgloseContr> DesgloseContrTrim(List<DesgloseContr> list)
        {
            List<XRSKDesgloseContr> desgloseList = new List<XRSKDesgloseContr>();

            foreach (var item in list)
            {
                if (item.DCPRefAnalitica1 != null)
                    item.DCPRefAnalitica1.Trim();

                if (item.DCPRefAnalitica2 != null)
                    item.DCPRefAnalitica2.Trim();

                if (item.DCPRefAnalitica3 != null)
                    item.DCPRefAnalitica3.Trim();

                if (item.DCPRefAnalitica4 != null)
                    item.DCPRefAnalitica4.Trim();

                if (item.DCPRefAnalitica5 != null)
                    item.DCPRefAnalitica5.Trim();

                if (item.DCPRefAnalitica6 != null)
                    item.DCPRefAnalitica6.Trim();

                desgloseList.Add(new XRSKDesgloseContr(item));
            }

            return desgloseList;
        }

        public List<XRSKDesgloseContr> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.DesgloseContr//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKDesgloseContr(query.ToList());
        }

        public XRSKDesgloseContr Find(string DCPCodCIA, string DCPValorOrganizativo, double DCPRefXrisk, int DCPContador)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(DCPCodCIA, DCPValorOrganizativo, DCPRefXrisk, DCPContador, db);
        }// end Find method

        public XRSKDesgloseContr Find(string DCPCodCIA, string DCPValorOrganizativo, double DCPRefXrisk, int DCPContador, XRSKDataContext db)
        {
            DesgloseContr item = db.DesgloseContr.Find(DCPCodCIA, DCPValorOrganizativo, DCPRefXrisk, DCPContador);
            TOXRSKDesgloseContr(item);
            return this;
        }
        #endregion

        #region Persistencia
        private DesgloseContr before_insert(XRSKDataContext db, DesgloseContr next)
        {
            return next;
        }// end before_insert method

        private DesgloseContr before_update(XRSKDataContext db, DesgloseContr prev, DesgloseContr next)
        {
            return next;
        }// end before_update method

        private DesgloseContr before_delete(XRSKDataContext db, DesgloseContr prev)
        {
            return prev;
        }// end before_delete method

        private DesgloseContr after_insert(XRSKDataContext db, DesgloseContr next)
        {
            return next;
        }// end after_insert method

        private DesgloseContr after_update(XRSKDataContext db, DesgloseContr prev, DesgloseContr next)
        {
            return next;
        }// end after_update method

        public XRSKDesgloseContr save()
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

        public XRSKDesgloseContr save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            DesgloseContr item = db.DesgloseContr.Find(DCPCodCIA, DCPValorOrganizativo, DCPRefXrisk, DCPContador);
            DesgloseContr previous = new DesgloseContr();
            // Change data
            if (item == null)
            {
                item = new DesgloseContr();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.DCP_CPT_TRI_MN_Cb1 = DCP_CPT_TRI_MN_Cb1;
            item.DCP_CPT_TRI_MN_Cb1 = DCP_CPT_TRI_MN_Cb1;
            item.DCP_CPT_TRI_MN_Cb2 = DCP_CPT_TRI_MN_Cb2;
            item.DCP_CPT_TRI_MN_Cb2 = DCP_CPT_TRI_MN_Cb2;
            item.DCP_ImpTri_CPT_MN = DCP_ImpTri_CPT_MN;
            item.DCP_ImpTri_CPT_MN = DCP_ImpTri_CPT_MN;
            item.DCP_ImpTri_PAR_CPT = DCP_ImpTri_PAR_CPT;
            item.DCP_ImpTri_PAR_CPT = DCP_ImpTri_PAR_CPT;
            item.DCP_ImpTri_PAR_MN = DCP_ImpTri_PAR_MN;
            item.DCP_ImpTri_PAR_MN = DCP_ImpTri_PAR_MN;
            item.DCP_Par_TRI_CPT_Cb1 = DCP_Par_TRI_CPT_Cb1;
            item.DCP_Par_TRI_CPT_Cb1 = DCP_Par_TRI_CPT_Cb1;
            item.DCP_Par_TRI_CPT_Cb2 = DCP_Par_TRI_CPT_Cb2;
            item.DCP_Par_TRI_CPT_Cb2 = DCP_Par_TRI_CPT_Cb2;
            item.DCP_Par_TRI_MN_Cb1 = DCP_Par_TRI_MN_Cb1;
            item.DCP_Par_TRI_MN_Cb1 = DCP_Par_TRI_MN_Cb1;
            item.DCP_Par_TRI_MN_Cb2 = DCP_Par_TRI_MN_Cb2;
            item.DCP_Par_TRI_MN_Cb2 = DCP_Par_TRI_MN_Cb2;
            item.DCPAgrupacionContrapartidaCPT = DCPAgrupacionContrapartidaCPT;
            item.DCPAgrupacionContrapartidaCPT = DCPAgrupacionContrapartidaCPT;
            item.DCPBaseImponible = DCPBaseImponible;
            item.DCPBaseImponible = DCPBaseImponible;
            item.DCPCambioDivCptMn = DCPCambioDivCptMn;
            item.DCPCambioDivCptMn = DCPCambioDivCptMn;
            item.DCPCambioDivisaCpt = DCPCambioDivisaCpt;
            item.DCPCambioDivisaCpt = DCPCambioDivisaCpt;
            item.DCPCodCPT = DCPCodCPT;
            item.DCPCodCPT = DCPCodCPT;
            item.DCPComisCambioCPT = DCPComisCambioCPT;
            item.DCPComisCambioCPT = DCPComisCambioCPT;
            item.DCPComisionCPT = DCPComisionCPT;
            item.DCPComisionCPT = DCPComisionCPT;
            item.DCPConceptoFicticioCPT = DCPConceptoFicticioCPT;
            item.DCPConceptoFicticioCPT = DCPConceptoFicticioCPT;
            item.DCPContrapartCPT = DCPContrapartCPT;
            item.DCPContrapartCPT = DCPContrapartCPT;
            item.DCPCtaIVACPT = DCPCtaIVACPT;
            item.DCPCtaIVACPT = DCPCtaIVACPT;
            item.DCPCuentaContableCPT = DCPCuentaContableCPT;
            item.DCPCuentaContableCPT = DCPCuentaContableCPT;
            item.DCPDescripcionCPT = DCPDescripcionCPT;
            item.DCPDescripcionCPT = DCPDescripcionCPT;
            item.DCPDiferenciasCPT = DCPDiferenciasCPT;
            item.DCPDiferenciasCPT = DCPDiferenciasCPT;
            item.DCPDivisa = DCPDivisa;
            item.DCPDivisa = DCPDivisa;
            item.DCPDivisaCpt = DCPDivisaCpt;
            item.DCPDivisaCpt = DCPDivisaCpt;
            item.DCPGrupo = DCPGrupo;
            item.DCPGrupo = DCPGrupo;
            item.DCPGtosBancCPT = DCPGtosBancCPT;
            item.DCPGtosBancCPT = DCPGtosBancCPT;
            item.DCPImporte = DCPImporte;
            item.DCPImporte = DCPImporte;
            item.DCPImporteCpt = DCPImporteCpt;
            item.DCPImporteCpt = DCPImporteCpt;
            item.DCPImporteCptMn = DCPImporteCptMn;
            item.DCPImporteCptMn = DCPImporteCptMn;
            item.DCPInteresesCPT = DCPInteresesCPT;
            item.DCPInteresesCPT = DCPInteresesCPT;
            item.DCPIVACPT = DCPIVACPT;
            item.DCPIVACPT = DCPIVACPT;
            item.DCPLibre1CPT = DCPLibre1CPT;
            item.DCPLibre1CPT = DCPLibre1CPT;
            item.DCPLibre2CPT = DCPLibre2CPT;
            item.DCPLibre2CPT = DCPLibre2CPT;
            item.DCPLibre3CPT = DCPLibre3CPT;
            item.DCPLibre3CPT = DCPLibre3CPT;
            item.DCPLibre4CPT = DCPLibre4CPT;
            item.DCPLibre4CPT = DCPLibre4CPT;
            item.DCPLibre5CPT = DCPLibre5CPT;
            item.DCPLibre5CPT = DCPLibre5CPT;
            item.DCPLibre6CPT = DCPLibre6CPT;
            item.DCPLibre6CPT = DCPLibre6CPT;
            item.DCPLibre7CPT = DCPLibre7CPT;
            item.DCPLibre7CPT = DCPLibre7CPT;
            item.DCPLibre8CPT = DCPLibre8CPT;
            item.DCPLibre8CPT = DCPLibre8CPT;
            item.DCPMonedaCPT = DCPMonedaCPT;
            item.DCPMonedaCPT = DCPMonedaCPT;
            item.DCPPorcentajeIVACPT = DCPPorcentajeIVACPT;
            item.DCPPorcentajeIVACPT = DCPPorcentajeIVACPT;
            item.DCPRefAnalitica1 = DCPRefAnalitica1;
            item.DCPRefAnalitica1 = DCPRefAnalitica1;
            item.DCPRefAnalitica2 = DCPRefAnalitica2;
            item.DCPRefAnalitica2 = DCPRefAnalitica2;
            item.DCPRefAnalitica3 = DCPRefAnalitica3;
            item.DCPRefAnalitica3 = DCPRefAnalitica3;
            item.DCPRefAnalitica4 = DCPRefAnalitica4;
            item.DCPRefAnalitica4 = DCPRefAnalitica4;
            item.DCPRefAnalitica5 = DCPRefAnalitica5;
            item.DCPRefAnalitica5 = DCPRefAnalitica5;
            item.DCPRefAnalitica6 = DCPRefAnalitica6;
            item.DCPRefAnalitica6 = DCPRefAnalitica6;
            item.DCPRefCont = DCPRefCont;
            item.DCPRefCont = DCPRefCont;
            item.DCPSignoCPT = DCPSignoCPT;
            item.DCPSignoCPT = DCPSignoCPT;
            item.DCPCodCIA = DCPCodCIA;
            item.DCPCodCIA = DCPCodCIA;
            item.DCPValorOrganizativo = DCPValorOrganizativo;
            item.DCPValorOrganizativo = DCPValorOrganizativo;
            item.DCPRefXrisk = DCPRefXrisk;
            item.DCPRefXrisk = DCPRefXrisk;
            item.DCPContador = DCPContador;
            item.DCPContador = DCPContador;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.DesgloseContr.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKDesgloseContr(item, db);

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

        public XRSKDesgloseContr save(XRSKDataContext db, List<XRSKDesgloseContr> elemsList)
        {
            foreach (XRSKDesgloseContr currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKDesgloseContr delete()
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

        public XRSKDesgloseContr delete(XRSKDataContext db)
        {
            // Get Entity
            DesgloseContr item = db.DesgloseContr.Find(DCPCodCIA, DCPValorOrganizativo, DCPRefXrisk, DCPContador);
            // Before_Delete call
            item = before_delete(db, item);

            db.DesgloseContr.Remove(item);
            db.SaveChanges();

            // Change data
            item.DCP_CPT_TRI_MN_Cb1 = 0;
            item.DCP_CPT_TRI_MN_Cb2 = 0;
            item.DCP_ImpTri_CPT_MN = 0;
            item.DCP_ImpTri_PAR_CPT = 0;
            item.DCP_ImpTri_PAR_MN = 0;
            item.DCP_Par_TRI_CPT_Cb1 = 0;
            item.DCP_Par_TRI_CPT_Cb2 = 0;
            item.DCP_Par_TRI_MN_Cb1 = 0;
            item.DCP_Par_TRI_MN_Cb2 = 0;
            item.DCPAgrupacionContrapartidaCPT = null;
            item.DCPBaseImponible = 0;
            item.DCPCambioDivCptMn = 0;
            item.DCPCambioDivisaCpt = 0;
            item.DCPCodCPT = null;
            item.DCPComisCambioCPT = false;
            item.DCPComisionCPT = false;
            item.DCPConceptoFicticioCPT = false;
            item.DCPContrapartCPT = false;
            item.DCPCtaIVACPT = null;
            item.DCPCuentaContableCPT = null;
            item.DCPDescripcionCPT = null;
            item.DCPDiferenciasCPT = false;
            item.DCPDivisa = null;
            item.DCPDivisaCpt = null;
            item.DCPGrupo = null;
            item.DCPGtosBancCPT = false;
            item.DCPImporte = 0;
            item.DCPImporteCpt = 0;
            item.DCPImporteCptMn = 0;
            item.DCPInteresesCPT = false;
            item.DCPIVACPT = false;
            item.DCPLibre1CPT = false;
            item.DCPLibre2CPT = false;
            item.DCPLibre3CPT = false;
            item.DCPLibre4CPT = false;
            item.DCPLibre5CPT = false;
            item.DCPLibre6CPT = false;
            item.DCPLibre7CPT = false;
            item.DCPLibre8CPT = false;
            item.DCPMonedaCPT = false;
            item.DCPPorcentajeIVACPT = 0;
            item.DCPRefAnalitica1 = null;
            item.DCPRefAnalitica2 = null;
            item.DCPRefAnalitica3 = null;
            item.DCPRefAnalitica4 = null;
            item.DCPRefAnalitica5 = null;
            item.DCPRefAnalitica6 = null;
            item.DCPRefCont = null;
            item.DCPSignoCPT = 0;
            item.DCPCodCIA = null;
            item.DCPValorOrganizativo = null;
            item.DCPRefXrisk = 0;
            item.DCPContador = 0;


            return this;
        }// end delete method with method
        #endregion
    }
}
