using Newtonsoft.Json;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKCNCSituacion : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("CNCGrupo")]
        public string CNCGrupo { get; set; }
        [JsonProperty("CNCValorOrganizativo")]
        public string CNCValorOrganizativo { get; set; }
        [JsonProperty("CNCCodCIA")]
        public string CNCCodCIA { get; set; }
        [JsonProperty("CNCCodCTA")]
        public string CNCCodCTA { get; set; }
        [JsonProperty("signo")]
        public string signo { get; set; }
        [JsonProperty("CNCBancoNONum")]
        public int? CNCBancoNONum { get; set; }
        [JsonProperty("CNCBancoNOImporte")]
        public double? CNCBancoNOImporte { get; set; }
        [JsonProperty("CNCXRProvNum")]
        public int? CNCXRProvNum { get; set; }
        [JsonProperty("CNCXRProvImporte")]
        public double? CNCXRProvImporte { get; set; }
        [JsonProperty("CNCXRContNum")]
        public int? CNCXRContNum { get; set; }
        [JsonProperty("CNCXRContImporte")]
        public double? CNCXRContImporte { get; set; }
        #endregion

        #region Constructores
        public XRSKCNCSituacion()
        {

        }

        public XRSKCNCSituacion(ClaimsPrincipal _Usuario) : base(_Usuario)
        {

        }

        public XRSKCNCSituacion(CNCSituacion item)
        {
            TOXRSKCNCSituacion(item);
        }

        public XRSKCNCSituacion(CNCSituacion item, XRSKDataContext db)
        {
            TOXRSKCNCSituacion(item, db);
        }
        #endregion

        #region Funciones
        /// <summary>
        /// Gets the list of CNCSituacion elements
        /// </summary>
        /// <returns></returns>
        public List<XRSKCNCSituacion> GetList()
        {
            return GetFilteredList(new FilterModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemsSelected"></param>
        /// <returns></returns>
        public List<XRSKCNCSituacion> GetFilteredList(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in
                        db.CNCSituacion
                        select x;

            // Afegim condicions de Filtre de Seguretat
            query = aplicarSeguridad(query);

            if (filter.detail != null)
            {
                foreach (FilterDetailModel detail in filter.detail)
                {
                    if (detail.entity.Equals("Compañias") && detail.values.Length > 0)
                        query = query.Where(x => detail.values.Contains(x.CNCCodCIA));
                    if (detail.entity.Equals("Contratos") && detail.values.Length > 0)
                        query = query.Where(x => detail.values.Contains(x.CNCCodCTA));
                }
            }

            List<CNCSituacion> items = query.ToList();

            return TOXRSKCNCSituacion(items);
        }
        #endregion

        #region Support methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private IQueryable<CNCSituacion> aplicarSeguridad(IQueryable<CNCSituacion> query)
        {
            if (Usuario.Grupos != null)
            {
                foreach (XRSKFocUsuariosGrupos grupo in Usuario.Grupos)
                {
                    if (grupo.BasesDatos != null)
                    {
                        foreach (XSRKBasesDatosGrupo bd in grupo.BasesDatos)
                        {
                            query = query.Where(x => bd.companies.Contains(x.CNCCodCIA));
                        }
                    }
                }
            }
            return query;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void TOXRSKCNCSituacion(CNCSituacion item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKCNCSituacion(item, db);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="db"></param>
        private void TOXRSKCNCSituacion(CNCSituacion item, XRSKDataContext db)
        {
            CNCGrupo = item.CNCGrupo;
            CNCValorOrganizativo = item.CNCValorOrganizativo;
            CNCCodCIA = item.CNCCodCIA;
            CNCCodCTA = item.CNCCodCTA;
            signo = item.signo;
            CNCBancoNONum = item.CNCBancoNONum;
            CNCBancoNOImporte = item.CNCBancoNOImporte;
            CNCXRProvNum = item.CNCXRProvNum;
            CNCXRProvImporte = item.CNCXRProvImporte;
            CNCXRContNum = item.CNCXRContNum;
            CNCXRContImporte = item.CNCXRContImporte;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name=XRSKConstantes.FILTER_TYPE_ITEMS></param>
        /// <returns></returns>
        private List<XRSKCNCSituacion> TOXRSKCNCSituacion(List<CNCSituacion> items)
        {
            List<XRSKCNCSituacion> cncList = new List<XRSKCNCSituacion>();
            foreach (CNCSituacion item in items)
            {
                cncList.Add(new XRSKCNCSituacion(item));
            }

            return cncList;
        }
        #endregion
    }
}
