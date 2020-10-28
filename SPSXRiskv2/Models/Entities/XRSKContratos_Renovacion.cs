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
/// Code generated 29/09/2020 13:11:57 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKContratos_Renovacion : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("CLQComisionnoDisp1")]
        public double? CLQComisionnoDisp1 { get; set; }
        [JsonProperty("CLQComisionnoDisp2")]
        public double? CLQComisionnoDisp2 { get; set; }
        [JsonProperty("CLQComisionnoDisp3")]
        public double? CLQComisionnoDisp3 { get; set; }
        [JsonProperty("CLQFechaInicioLiq")]
        public DateTime? CLQFechaInicioLiq { get; set; }
        [JsonProperty("CLQFechaInicioRev")]
        public DateTime? CLQFechaInicioRev { get; set; }
        [JsonProperty("CLQFechaInicioRevComNoDisp")]
        public DateTime? CLQFechaInicioRevComNoDisp { get; set; }
        [JsonProperty("CLQPeriodicidadComNoDisp")]
        public string? CLQPeriodicidadComNoDisp { get; set; }
        [JsonProperty("CLQPeriodicidadLiq")]
        public string? CLQPeriodicidadLiq { get; set; }
        [JsonProperty("CLQPeriodicidadRev")]
        public string? CLQPeriodicidadRev { get; set; }
        [JsonProperty("CLQTipoPeriodLiquid")]
        public string? CLQTipoPeriodLiquid { get; set; }
        [JsonProperty("CLQTipoPeriodRevision")]
        public string? CLQTipoPeriodRevision { get; set; }
        [JsonProperty("CLQTipoPeriodRevisionComNoDisp")]
        public string? CLQTipoPeriodRevisionComNoDisp { get; set; }
        [JsonProperty("CLQTramoComisionnoDisp1")]
        public double? CLQTramoComisionnoDisp1 { get; set; }
        [JsonProperty("CLQTramoComisionnoDisp2")]
        public double? CLQTramoComisionnoDisp2 { get; set; }
        [JsonProperty("CLQTramoComisionnoDisp3")]
        public double? CLQTramoComisionnoDisp3 { get; set; }
        [JsonProperty("CLQUltimoDiaLiq")]
        public bool? CLQUltimoDiaLiq { get; set; }
        [JsonProperty("CLQUltimoDiaRev")]
        public bool? CLQUltimoDiaRev { get; set; }
        [JsonProperty("CLQUltimoDiaRevComNoDisp")]
        public bool? CLQUltimoDiaRevComNoDisp { get; set; }
        [JsonProperty("CTACodIntAct1REF")]
        public string? CTACodIntAct1REF { get; set; }
        [JsonProperty("CTACodIntAct2REF")]
        public string? CTACodIntAct2REF { get; set; }
        [JsonProperty("CTACodIntAct3REF")]
        public string? CTACodIntAct3REF { get; set; }
        [JsonProperty("CTACodIntAct4REF")]
        public string? CTACodIntAct4REF { get; set; }
        [JsonProperty("CTACodIntActREF")]
        public string? CTACodIntActREF { get; set; }
        [JsonProperty("CTACodIntExcedREF")]
        public string? CTACodIntExcedREF { get; set; }
        [JsonProperty("CTACodIntPasREF")]
        public string? CTACodIntPasREF { get; set; }
        [JsonProperty("CTACodTLQ")]
        public string? CTACodTLQ { get; set; }
        [JsonProperty("CTADivisorActivo")]
        public Int16? CTADivisorActivo { get; set; }
        [JsonProperty("CTADivisorPasivo")]
        public Int16? CTADivisorPasivo { get; set; }
        [JsonProperty("CTAEscActDiv1")]
        public double? CTAEscActDiv1 { get; set; }
        [JsonProperty("CTAEscActDiv2")]
        public double? CTAEscActDiv2 { get; set; }
        [JsonProperty("CTAEscActDiv3")]
        public double? CTAEscActDiv3 { get; set; }
        [JsonProperty("CTAEscActDiv4")]
        public double? CTAEscActDiv4 { get; set; }
        [JsonProperty("CTAEscActPts1")]
        public double? CTAEscActPts1 { get; set; }
        [JsonProperty("CTAEscActPts2")]
        public double? CTAEscActPts2 { get; set; }
        [JsonProperty("CTAEscActPts3")]
        public double? CTAEscActPts3 { get; set; }
        [JsonProperty("CTAEscActPts4")]
        public double? CTAEscActPts4 { get; set; }
        [JsonProperty("CTAFechAvisoRenov")]
        public DateTime? CTAFechAvisoRenov { get; set; }
        [JsonProperty("CTAFechFinPer")]
        public DateTime? CTAFechFinPer { get; set; }
        [JsonProperty("CTAImpoPtsLimContr")]
        public double? CTAImpoPtsLimContr { get; set; }
        [JsonProperty("CTAImporPtsExc")]
        public double? CTAImporPtsExc { get; set; }
        [JsonProperty("CTAImporPtsInfAvis")]
        public double? CTAImporPtsInfAvis { get; set; }
        [JsonProperty("CTAImporPtsOper")]
        public double? CTAImporPtsOper { get; set; }
        [JsonProperty("CTAImporPtsSupAviso")]
        public double? CTAImporPtsSupAviso { get; set; }
        [JsonProperty("CTAInteresAct1Fijo")]
        public bool CTAInteresAct1Fijo { get; set; }
        [JsonProperty("CTAInteresAct2Fijo")]
        public bool CTAInteresAct2Fijo { get; set; }
        [JsonProperty("CTAInteresAct3Fijo")]
        public bool CTAInteresAct3Fijo { get; set; }
        [JsonProperty("CTAInteresAct4Fijo")]
        public bool CTAInteresAct4Fijo { get; set; }
        [JsonProperty("CTAInteresExcedFijo")]
        public bool CTAInteresExcedFijo { get; set; }
        [JsonProperty("CTAInteresPasFijo")]
        public bool CTAInteresPasFijo { get; set; }
        [JsonProperty("CTAInteresRestoFijo")]
        public bool CTAInteresRestoFijo { get; set; }
        [JsonProperty("CTAMultiplicActivo")]
        public Int16? CTAMultiplicActivo { get; set; }
        [JsonProperty("CTAMultiplicPasivo")]
        public Int16? CTAMultiplicPasivo { get; set; }
        [JsonProperty("CTANumeros")]
        public Int16? CTANumeros { get; set; }
        [JsonProperty("CTARestoActivDiv")]
        public double? CTARestoActivDiv { get; set; }
        [JsonProperty("CTARestoActivPts")]
        public double? CTARestoActivPts { get; set; }
        [JsonProperty("CTASpreadAct1")]
        public double? CTASpreadAct1 { get; set; }
        [JsonProperty("CTASpreadAct2")]
        public double? CTASpreadAct2 { get; set; }
        [JsonProperty("CTASpreadAct3")]
        public double? CTASpreadAct3 { get; set; }
        [JsonProperty("CTASpreadAct4")]
        public double? CTASpreadAct4 { get; set; }
        [JsonProperty("CTASpreadExced")]
        public double? CTASpreadExced { get; set; }
        [JsonProperty("CTASpreadPas")]
        public double? CTASpreadPas { get; set; }
        [JsonProperty("CTASpreadResto")]
        public double? CTASpreadResto { get; set; }
        [JsonProperty("CTATipInteresAct1")]
        public double? CTATipInteresAct1 { get; set; }
        [JsonProperty("CTATipInteresAct2")]
        public double? CTATipInteresAct2 { get; set; }
        [JsonProperty("CTATipInteresAct3")]
        public double? CTATipInteresAct3 { get; set; }
        [JsonProperty("CTATipInteresAct4")]
        public double? CTATipInteresAct4 { get; set; }
        [JsonProperty("CTATipInteresExced")]
        public double? CTATipInteresExced { get; set; }
        [JsonProperty("CTATipInteresPas")]
        public double? CTATipInteresPas { get; set; }
        [JsonProperty("CTATipInteresResto")]
        public double? CTATipInteresResto { get; set; }
        [JsonProperty("DIASFIJACION")]
        public double? DIASFIJACION { get; set; }
        [JsonProperty("CTACod")]
        public string CTACod { get; set; }
        [JsonProperty("CTACodCIA")]
        public string CTACodCIA { get; set; }
        [JsonProperty("CTAFechIniPer")]
        public DateTime CTAFechIniPer { get; set; }

        #endregion

        // Related entities sample, uncomment and change it at your own if your consider
        //#region Propiedades Entidades Relacionadas
        //public String CIADescripcion { get; set; } // Nombre de Compañía
        //#endregion

        #region Constructores
        public XRSKContratos_Renovacion()
        {
        }

        public XRSKContratos_Renovacion(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKContratos_Renovacion(Contratos_Renovacion item)
        {
            TOXRSKContratos_Renovacion(item);
        }

        public XRSKContratos_Renovacion(Contratos_Renovacion item, XRSKDataContext db)
        {
            TOXRSKContratos_Renovacion(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKContratos_Renovacion(Contratos_Renovacion item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKContratos_Renovacion(item, db);
        }

        private void TOXRSKContratos_Renovacion(Contratos_Renovacion item, XRSKDataContext db)
        {
            CLQComisionnoDisp1 = item.CLQComisionnoDisp1;
            CLQComisionnoDisp2 = item.CLQComisionnoDisp2;
            CLQComisionnoDisp3 = item.CLQComisionnoDisp3;
            CLQFechaInicioLiq = item.CLQFechaInicioLiq;
            CLQFechaInicioRev = item.CLQFechaInicioRev;
            CLQFechaInicioRevComNoDisp = item.CLQFechaInicioRevComNoDisp;
            CLQPeriodicidadComNoDisp = item.CLQPeriodicidadComNoDisp;
            CLQPeriodicidadLiq = item.CLQPeriodicidadLiq;
            CLQPeriodicidadRev = item.CLQPeriodicidadRev;
            CLQTipoPeriodLiquid = item.CLQTipoPeriodLiquid;
            CLQTipoPeriodRevision = item.CLQTipoPeriodRevision;
            CLQTipoPeriodRevisionComNoDisp = item.CLQTipoPeriodRevisionComNoDisp;
            CLQTramoComisionnoDisp1 = item.CLQTramoComisionnoDisp1;
            CLQTramoComisionnoDisp2 = item.CLQTramoComisionnoDisp2;
            CLQTramoComisionnoDisp3 = item.CLQTramoComisionnoDisp3;
            CLQUltimoDiaLiq = item.CLQUltimoDiaLiq;
            CLQUltimoDiaRev = item.CLQUltimoDiaRev;
            CLQUltimoDiaRevComNoDisp = item.CLQUltimoDiaRevComNoDisp;
            CTACodIntAct1REF = item.CTACodIntAct1REF;
            CTACodIntAct2REF = item.CTACodIntAct2REF;
            CTACodIntAct3REF = item.CTACodIntAct3REF;
            CTACodIntAct4REF = item.CTACodIntAct4REF;
            CTACodIntActREF = item.CTACodIntActREF;
            CTACodIntExcedREF = item.CTACodIntExcedREF;
            CTACodIntPasREF = item.CTACodIntPasREF;
            CTACodTLQ = item.CTACodTLQ;
            CTADivisorActivo = item.CTADivisorActivo;
            CTADivisorPasivo = item.CTADivisorPasivo;
            CTAEscActDiv1 = item.CTAEscActDiv1;
            CTAEscActDiv2 = item.CTAEscActDiv2;
            CTAEscActDiv3 = item.CTAEscActDiv3;
            CTAEscActDiv4 = item.CTAEscActDiv4;
            CTAEscActPts1 = item.CTAEscActPts1;
            CTAEscActPts2 = item.CTAEscActPts2;
            CTAEscActPts3 = item.CTAEscActPts3;
            CTAEscActPts4 = item.CTAEscActPts4;
            CTAFechAvisoRenov = item.CTAFechAvisoRenov;
            CTAFechFinPer = item.CTAFechFinPer;
            CTAImpoPtsLimContr = item.CTAImpoPtsLimContr;
            CTAImporPtsExc = item.CTAImporPtsExc;
            CTAImporPtsInfAvis = item.CTAImporPtsInfAvis;
            CTAImporPtsOper = item.CTAImporPtsOper;
            CTAImporPtsSupAviso = item.CTAImporPtsSupAviso;
            CTAInteresAct1Fijo = item.CTAInteresAct1Fijo;
            CTAInteresAct2Fijo = item.CTAInteresAct2Fijo;
            CTAInteresAct3Fijo = item.CTAInteresAct3Fijo;
            CTAInteresAct4Fijo = item.CTAInteresAct4Fijo;
            CTAInteresExcedFijo = item.CTAInteresExcedFijo;
            CTAInteresPasFijo = item.CTAInteresPasFijo;
            CTAInteresRestoFijo = item.CTAInteresRestoFijo;
            CTAMultiplicActivo = item.CTAMultiplicActivo;
            CTAMultiplicPasivo = item.CTAMultiplicPasivo;
            CTANumeros = item.CTANumeros;
            CTARestoActivDiv = item.CTARestoActivDiv;
            CTARestoActivPts = item.CTARestoActivPts;
            CTASpreadAct1 = item.CTASpreadAct1;
            CTASpreadAct2 = item.CTASpreadAct2;
            CTASpreadAct3 = item.CTASpreadAct3;
            CTASpreadAct4 = item.CTASpreadAct4;
            CTASpreadExced = item.CTASpreadExced;
            CTASpreadPas = item.CTASpreadPas;
            CTASpreadResto = item.CTASpreadResto;
            CTATipInteresAct1 = item.CTATipInteresAct1;
            CTATipInteresAct2 = item.CTATipInteresAct2;
            CTATipInteresAct3 = item.CTATipInteresAct3;
            CTATipInteresAct4 = item.CTATipInteresAct4;
            CTATipInteresExced = item.CTATipInteresExced;
            CTATipInteresPas = item.CTATipInteresPas;
            CTATipInteresResto = item.CTATipInteresResto;
            DIASFIJACION = item.DIASFIJACION;
            CTACod = item.CTACod;
            CTACodCIA = item.CTACodCIA;
            CTAFechIniPer = item.CTAFechIniPer;


            // Related entities sample, uncomment and change it at your own if your consider
            // if (item.Companyia != null)
            // {
            // CIADescripcion = item.Companyia.CIADescripcion;
            // }
        }

        private List<XRSKContratos_Renovacion> TOXRSKContratos_Renovacion(List<Contratos_Renovacion> items)
        {
            List<XRSKContratos_Renovacion> elemList = new List<XRSKContratos_Renovacion>();
            foreach (Contratos_Renovacion item in items)
            {
                elemList.Add(new XRSKContratos_Renovacion(item));
            }

            return elemList;
        }

        private IQueryable<Contratos_Renovacion> aplicarSeguridad(IQueryable<Contratos_Renovacion> query)
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

        private IQueryable<Contratos_Renovacion> aplicarFiltro(IQueryable<Contratos_Renovacion> query, FilterModel filter)
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
        public List<XRSKContratos_Renovacion> GetList()
        {
            XRSKDataContext db = new XRSKDataContext();

            /// You have to create Contratos_Renovacion entry at SPSXRiskv2\Models\XRSKDataContext.cs
            List<Contratos_Renovacion> items = db.Contratos_Renovacion.
                // Include(x => x.Companyia).
                ToList();
            return TOXRSKContratos_Renovacion(items);
        }

        public List<XRSKContratos_Renovacion> GetFiltered(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.Contratos_Renovacion//.Include(x => x.Companyia)
                        select x;

            // Afegim condicions de Filtre per pantalla
            query = aplicarFiltro(query, filter);

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            return TOXRSKContratos_Renovacion(query.ToList());
        }

        public XRSKContratos_Renovacion Find(string CTACod, string CTACodCIA, DateTime CTAFechIniPer)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(CTACod, CTACodCIA, CTAFechIniPer, db);
        }// end Find method

        public XRSKContratos_Renovacion Find(string CTACod, string CTACodCIA, DateTime CTAFechIniPer, XRSKDataContext db)
        {
            Contratos_Renovacion item = db.Contratos_Renovacion.Find(CTACod, CTACodCIA, CTAFechIniPer);
            TOXRSKContratos_Renovacion(item);
            return this;
        }
        #endregion

        #region Persistencia
        private Contratos_Renovacion before_insert(XRSKDataContext db, Contratos_Renovacion next)
        {
            return next;
        }// end before_insert method

        private Contratos_Renovacion before_update(XRSKDataContext db, Contratos_Renovacion prev, Contratos_Renovacion next)
        {
            return next;
        }// end before_update method

        private Contratos_Renovacion before_delete(XRSKDataContext db, Contratos_Renovacion prev)
        {
            return prev;
        }// end before_delete method

        private Contratos_Renovacion after_insert(XRSKDataContext db, Contratos_Renovacion next)
        {
            return next;
        }// end after_insert method

        private Contratos_Renovacion after_update(XRSKDataContext db, Contratos_Renovacion prev, Contratos_Renovacion next)
        {
            return next;
        }// end after_update method

        public XRSKContratos_Renovacion save()
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

        public XRSKContratos_Renovacion save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            Contratos_Renovacion item = db.Contratos_Renovacion.Find(CTACod, CTACodCIA, CTAFechIniPer);
            Contratos_Renovacion previous = new Contratos_Renovacion();
            // Change data
            if (item == null)
            {
                item = new Contratos_Renovacion();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }

            item.CLQComisionnoDisp1 = CLQComisionnoDisp1;
            item.CLQComisionnoDisp2 = CLQComisionnoDisp2;
            item.CLQComisionnoDisp3 = CLQComisionnoDisp3;
            item.CLQFechaInicioLiq = CLQFechaInicioLiq;
            item.CLQFechaInicioRev = CLQFechaInicioRev;
            item.CLQFechaInicioRevComNoDisp = CLQFechaInicioRevComNoDisp;
            item.CLQPeriodicidadComNoDisp = CLQPeriodicidadComNoDisp;
            item.CLQPeriodicidadLiq = CLQPeriodicidadLiq;
            item.CLQPeriodicidadRev = CLQPeriodicidadRev;
            item.CLQTipoPeriodLiquid = CLQTipoPeriodLiquid;
            item.CLQTipoPeriodRevision = CLQTipoPeriodRevision;
            item.CLQTipoPeriodRevisionComNoDisp = CLQTipoPeriodRevisionComNoDisp;
            item.CLQTramoComisionnoDisp1 = CLQTramoComisionnoDisp1;
            item.CLQTramoComisionnoDisp2 = CLQTramoComisionnoDisp2;
            item.CLQTramoComisionnoDisp3 = CLQTramoComisionnoDisp3;
            item.CLQUltimoDiaLiq = CLQUltimoDiaLiq;
            item.CLQUltimoDiaRev = CLQUltimoDiaRev;
            item.CLQUltimoDiaRevComNoDisp = CLQUltimoDiaRevComNoDisp;
            item.CTACodIntAct1REF = CTACodIntAct1REF;
            item.CTACodIntAct2REF = CTACodIntAct2REF;
            item.CTACodIntAct3REF = CTACodIntAct3REF;
            item.CTACodIntAct4REF = CTACodIntAct4REF;
            item.CTACodIntActREF = CTACodIntActREF;
            item.CTACodIntExcedREF = CTACodIntExcedREF;
            item.CTACodIntPasREF = CTACodIntPasREF;
            item.CTACodTLQ = CTACodTLQ;
            item.CTADivisorActivo = CTADivisorActivo;
            item.CTADivisorPasivo = CTADivisorPasivo;
            item.CTAEscActDiv1 = CTAEscActDiv1;
            item.CTAEscActDiv2 = CTAEscActDiv2;
            item.CTAEscActDiv3 = CTAEscActDiv3;
            item.CTAEscActDiv4 = CTAEscActDiv4;
            item.CTAEscActPts1 = CTAEscActPts1;
            item.CTAEscActPts2 = CTAEscActPts2;
            item.CTAEscActPts3 = CTAEscActPts3;
            item.CTAEscActPts4 = CTAEscActPts4;
            item.CTAFechAvisoRenov = CTAFechAvisoRenov;
            item.CTAFechFinPer = CTAFechFinPer;
            item.CTAImpoPtsLimContr = CTAImpoPtsLimContr;
            item.CTAImporPtsExc = CTAImporPtsExc;
            item.CTAImporPtsInfAvis = CTAImporPtsInfAvis;
            item.CTAImporPtsOper = CTAImporPtsOper;
            item.CTAImporPtsSupAviso = CTAImporPtsSupAviso;
            item.CTAInteresAct1Fijo = CTAInteresAct1Fijo;
            item.CTAInteresAct2Fijo = CTAInteresAct2Fijo;
            item.CTAInteresAct3Fijo = CTAInteresAct3Fijo;
            item.CTAInteresAct4Fijo = CTAInteresAct4Fijo;
            item.CTAInteresExcedFijo = CTAInteresExcedFijo;
            item.CTAInteresPasFijo = CTAInteresPasFijo;
            item.CTAInteresRestoFijo = CTAInteresRestoFijo;
            item.CTAMultiplicActivo = CTAMultiplicActivo;
            item.CTAMultiplicPasivo = CTAMultiplicPasivo;
            item.CTANumeros = CTANumeros;
            item.CTARestoActivDiv = CTARestoActivDiv;
            item.CTARestoActivPts = CTARestoActivPts;
            item.CTASpreadAct1 = CTASpreadAct1;
            item.CTASpreadAct2 = CTASpreadAct2;
            item.CTASpreadAct3 = CTASpreadAct3;
            item.CTASpreadAct4 = CTASpreadAct4;
            item.CTASpreadExced = CTASpreadExced;
            item.CTASpreadPas = CTASpreadPas;
            item.CTASpreadResto = CTASpreadResto;
            item.CTATipInteresAct1 = CTATipInteresAct1;
            item.CTATipInteresAct2 = CTATipInteresAct2;
            item.CTATipInteresAct3 = CTATipInteresAct3;
            item.CTATipInteresAct4 = CTATipInteresAct4;
            item.CTATipInteresExced = CTATipInteresExced;
            item.CTATipInteresPas = CTATipInteresPas;
            item.CTATipInteresResto = CTATipInteresResto;
            item.DIASFIJACION = DIASFIJACION;
            item.CTACod = CTACod;
            item.CTACodCIA = CTACodCIA;
            item.CTAFechIniPer = CTAFechIniPer;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.Contratos_Renovacion.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKContratos_Renovacion(item, db);

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

        public XRSKContratos_Renovacion save(XRSKDataContext db, List<XRSKContratos_Renovacion> elemsList)
        {
            foreach (XRSKContratos_Renovacion currentElem in elemsList)
                currentElem.save(db);
            return this;
        }

        public XRSKContratos_Renovacion delete()
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

        public XRSKContratos_Renovacion delete(XRSKDataContext db)
        {
            // Get Entity
            Contratos_Renovacion item = db.Contratos_Renovacion.Find(CTACod, CTACodCIA, CTAFechIniPer);
            // Before_Delete call
            item = before_delete(db, item);

            db.Contratos_Renovacion.Remove(item);
            db.SaveChanges();

            // Change data
            item.CLQComisionnoDisp1 = 0;
            item.CLQComisionnoDisp2 = 0;
            item.CLQComisionnoDisp3 = 0;
            item.CLQFechaInicioLiq = DateTime.Today;
            item.CLQFechaInicioRev = DateTime.Today;
            item.CLQFechaInicioRevComNoDisp = DateTime.Today;
            item.CLQPeriodicidadComNoDisp = null;
            item.CLQPeriodicidadLiq = null;
            item.CLQPeriodicidadRev = null;
            item.CLQTipoPeriodLiquid = null;
            item.CLQTipoPeriodRevision = null;
            item.CLQTipoPeriodRevisionComNoDisp = null;
            item.CLQTramoComisionnoDisp1 = 0;
            item.CLQTramoComisionnoDisp2 = 0;
            item.CLQTramoComisionnoDisp3 = 0;
            item.CLQUltimoDiaLiq = false;
            item.CLQUltimoDiaRev = false;
            item.CLQUltimoDiaRevComNoDisp = false;
            item.CTACodIntAct1REF = null;
            item.CTACodIntAct2REF = null;
            item.CTACodIntAct3REF = null;
            item.CTACodIntAct4REF = null;
            item.CTACodIntActREF = null;
            item.CTACodIntExcedREF = null;
            item.CTACodIntPasREF = null;
            item.CTACodTLQ = null;
            item.CTADivisorActivo = 0;
            item.CTADivisorPasivo = 0;
            item.CTAEscActDiv1 = 0;
            item.CTAEscActDiv2 = 0;
            item.CTAEscActDiv3 = 0;
            item.CTAEscActDiv4 = 0;
            item.CTAEscActPts1 = 0;
            item.CTAEscActPts2 = 0;
            item.CTAEscActPts3 = 0;
            item.CTAEscActPts4 = 0;
            item.CTAFechAvisoRenov = DateTime.Today;
            item.CTAFechFinPer = DateTime.Today;
            item.CTAImpoPtsLimContr = 0;
            item.CTAImporPtsExc = 0;
            item.CTAImporPtsInfAvis = 0;
            item.CTAImporPtsOper = 0;
            item.CTAImporPtsSupAviso = 0;
            item.CTAInteresAct1Fijo = false;
            item.CTAInteresAct2Fijo = false;
            item.CTAInteresAct3Fijo = false;
            item.CTAInteresAct4Fijo = false;
            item.CTAInteresExcedFijo = false;
            item.CTAInteresPasFijo = false;
            item.CTAInteresRestoFijo = false;
            item.CTAMultiplicActivo = 0;
            item.CTAMultiplicPasivo = 0;
            item.CTANumeros = 0;
            item.CTARestoActivDiv = 0;
            item.CTARestoActivPts = 0;
            item.CTASpreadAct1 = 0;
            item.CTASpreadAct2 = 0;
            item.CTASpreadAct3 = 0;
            item.CTASpreadAct4 = 0;
            item.CTASpreadExced = 0;
            item.CTASpreadPas = 0;
            item.CTASpreadResto = 0;
            item.CTATipInteresAct1 = 0;
            item.CTATipInteresAct2 = 0;
            item.CTATipInteresAct3 = 0;
            item.CTATipInteresAct4 = 0;
            item.CTATipInteresExced = 0;
            item.CTATipInteresPas = 0;
            item.CTATipInteresResto = 0;
            item.DIASFIJACION = 0;
            item.CTACod = null;
            item.CTACodCIA = null;
            item.CTAFechIniPer = DateTime.Today;


            return this;
        }// end delete method with method
        #endregion
    }
}
