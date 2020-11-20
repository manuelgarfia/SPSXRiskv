using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.ViewModels;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKCompanyia : XRSKEntity
    {
        #region Propiedades
        public string CIACod { get; set; }
        public string CIADescripcion { get; set; }
        [JsonProperty("CIAGrupo")]
        public string CIAGrupo { get; set; }
        [JsonProperty("CIANiv")]
        public string CIANiv { get; set; }
        [JsonProperty("CIANOrganizativo")]
        public Int16 CIANOrganizativo { get; set; }
        [JsonProperty("CIAValorOrganizativo")]
        public string CIAValorOrganizativo { get; set; }
        [JsonProperty("CIADesred")]
        public string CIADesred { get; set; }
        [JsonProperty("CIARazonSocial")]
        public string? CIARazonSocial { get; set; }
        [JsonProperty("CIADireccion")]
        public string? CIADireccion { get; set; }
        [JsonProperty("CIACP")]
        public string? CIACP { get; set; }
        [JsonProperty("CIAPoblacion")]
        public string? CIAPoblacion { get; set; }
        [JsonProperty("CIANIF")]
        public string? CIANIF { get; set; }
        [JsonProperty("CIACodCont")]
        public string? CIACodCont { get; set; }
        [JsonProperty("CIADivisa")]
        public string? CIADivisa { get; set; }
        [JsonProperty("CIATelefono")]
        public string? CIATelefono { get; set; }
        [JsonProperty("CIAFAX")]
        public string? CIAFAX { get; set; }
        [JsonProperty("CIAEmail")]
        public string? CIAEmail { get; set; }
        [JsonProperty("CIAWeb")]
        public string? CIAWeb { get; set; }
        [JsonProperty("CIAPais")]
        public string? CIAPais { get; set; }
        [JsonProperty("CIASistemaERP")]
        public string? CIASistemaERP { get; set; }
        [JsonProperty("CIACotizada")]
        public bool? CIACotizada { get; set; }
        [JsonProperty("CIAUnidadPublica")]
        public string? CIAUnidadPublica { get; set; }
        [JsonProperty("CIAISIN")]
        public string? CIAISIN { get; set; }
        [JsonProperty("CIACNAE")]
        public string? CIACNAE { get; set; }
        [JsonProperty("CIAClaveProvincia")]
        public string? CIAClaveProvincia { get; set; }
        [JsonProperty("CIAProvincia")]
        public string? CIAProvincia { get; set; }
        [JsonProperty("CIAClavePais")]
        public string? CIAClavePais { get; set; }
        [JsonProperty("CIADeclaraBDE")]
        public bool? CIADeclaraBDE { get; set; }
        #endregion

        #region Propiedades Entidades Relacionadas
        public FocUsuarios user { get; set; } // Nombre de Compañía
        #endregion

        #region Constructores

        public XRSKCompanyia()
        {

        }
        public XRSKCompanyia(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKCompanyia(String _CIACod, String _CIADescripcion)
        {
            CIACod = _CIACod;
            CIADescripcion = _CIADescripcion;

        }

        public XRSKCompanyia(Companyia item)
        {
            TOXRSKCompanyia(item);
        }

        public XRSKCompanyia(Companyia item, XRSKDataContext db)
        {
            TOXRSKCompanyia(item, db);
        }
        #endregion

        #region Métodos Privados
        private void TOXRSKCompanyia(Companyia item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKCompanyia(item, db);
        }

        private void TOXRSKCompanyia(Companyia item, XRSKDataContext db)
        {
            CIACod = item.CIACod;
            CIADescripcion = item.CIADescripcion;
            CIAGrupo = item.CIAGrupo;
            CIANiv = item.CIANiv;
            CIANOrganizativo = item.CIANOrganizativo;
            CIAValorOrganizativo = item.CIAValorOrganizativo;
            CIADesred = item.CIADesred;
            CIARazonSocial = item.CIARazonSocial;
            CIADireccion = item.CIADireccion;
            CIACP = item.CIACP;
            CIAPoblacion = item.CIAPoblacion;
            CIANIF = item.CIANIF;
            CIACodCont = item.CIACodCont;
            CIADivisa = item.CIADivisa;
            CIATelefono = item.CIATelefono;
            CIAFAX = item.CIAFAX;
            CIAEmail = item.CIAEmail;
            CIAWeb = item.CIAWeb;
            CIAPais = item.CIAPais;
            CIASistemaERP = item.CIASistemaERP;
            CIACotizada = item.CIACotizada;
            CIAUnidadPublica = item.CIAUnidadPublica;
            CIAISIN = item.CIAISIN;
            CIACNAE = item.CIACNAE;
            CIAClaveProvincia = item.CIAClaveProvincia;
            CIAProvincia = item.CIAProvincia;
            CIAClavePais = item.CIAClavePais;
            CIADeclaraBDE = item.CIADeclaraBDE;
    }

        private List<XRSKCompanyia> TOXRSKCompanyia(List<Companyia> items)
        {
            List<XRSKCompanyia> companyias = new List<XRSKCompanyia>();
            foreach (Companyia item in items)
            {
                companyias.Add(new XRSKCompanyia(item));
            }

            return companyias;
        }

        private IQueryable<Companyia> aplicarSeguridad(IQueryable<Companyia> query)
        {
            if (Usuario.Grupos != null)
            {
                foreach (XRSKFocUsuariosGrupos grupo in Usuario.Grupos)
                {
                    if (grupo.BasesDatos != null)
                    {
                        foreach (XSRKBasesDatosGrupo bd in grupo.BasesDatos)
                        {
                            query = query.Where(x => bd.companies.Contains(x.CIACod));
                        }
                    }
                }
            }
            return query;
        }

        private IQueryable<MovimientoFisico> aplicarFiltro(IQueryable<MovimientoFisico> query, FilterModel filter)
        {
            // To Do
            foreach (FilterDetailModel detail in filter.detail)
            {
            }

            return query;
        }
        #endregion

        #region Funciones
        public List<XRSKCompanyia> GetList()
        {
            List<Companyia> companyitems = new List<Companyia>();
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.context_companyia
                        select x;

            query = aplicarSeguridad(query);

            companyitems = query.ToList();
            return TOXRSKCompanyia(companyitems);
        }

        public string GetDescripcionEmpresa(string empresa)
        {
            Companyia empresaItem = new Companyia();
            XRSKDataContext db = new XRSKDataContext();
            string empresaDesc;

            empresaItem = db.context_companyia.Where(x => x.CIACod == empresa).FirstOrDefault();
            empresaDesc = empresaItem.CIADescripcion;

            //companyitems = query.ToList();
            return empresaDesc;
        }

        #endregion

        #region User Functions 
        public string[] findUserGroup(string user)
        {
            XRSKDataContext db = new XRSKDataContext();
            return findUserGroup(user, db);
        }

        public string[] findUserGroup(string user, XRSKDataContext db)
        {
            FocUsuariosGrupos usuarioGrupo = db.FocUsuariosGrupos.Where(x => x.usuari == user).FirstOrDefault();
            string group = usuarioGrupo.grup.ToString();
            return findUserSecurity(group);
        }

        public string[] findUserSecurity(string group)
        {
            XRSKDataContext db = new XRSKDataContext();
            List<BasesDatosGrupo> items = new List<BasesDatosGrupo>();
            string sqlseq = "";

            var query = from x in
                        db.BasesDatosGrupo
                        select x;

            query = query.Where(x => x.grup.Contains(group) && x.iniPage!= null);
            items = query.ToList();

            foreach(var item in items)
            {
                sqlseq = item.iniPage;
            }

            return findCompanies(sqlseq);
        }

        public string[] findCompanies(string code)
        {
            XRSKDataContext db = new XRSKDataContext();
            Companyia company = new Companyia();

            var companiesList = db.SecurityObject.Where(x => x.codigo == code).FirstOrDefault();

            string companiesString = companiesList.permitidos;

            string[] companies = companiesString.Split(",");

            return companies;
        }

        public void GetCompanyia(string codCIA)
        {
            XRSKDataContext db = new XRSKDataContext();

            Companyia companyia = db.context_companyia.Where(x => x.CIACod == codCIA).FirstOrDefault();

            TOXRSKCompanyia(companyia, db);
        }
        #endregion
    }
}
