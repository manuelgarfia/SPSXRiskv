using Microsoft.EntityFrameworkCore;
using SPSXRiskv2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;


namespace SPSXRiskv2.Models.Entities
{
    public class XRSKContratos : XRSKEntity
    {
        #region Propiedades
        public string ctacodcia { get; set; }
        public string ctacod { get; set; }
        public string ctadescripcion { get; set; }
        public string ctacoddiv { get; set; }
        public string ctacodtli { get; set; }
        public string ctafechavalidez { get; set; }
        #endregion

        #region Constructores
        public XRSKContratos()
        {

        }// Constructor sin parámetros

        public XRSKContratos(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKContratos(Contratos item)
        {
            TOXRSKContratos(item);
        }

        public XRSKContratos(Contratos item, XRSKDataContext db)
        {
            TOXRSKContratos(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKContratos(Contratos item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKContratos(item, db);
        }

        private void TOXRSKContratos(Contratos item, XRSKDataContext db)
        {
            ctacodcia = item.ctacodcia;
            ctacod = item.ctacod;
            ctadescripcion = item.ctadescripcion;
            ctacoddiv = item.ctacoddiv;
            ctacodtli = item.ctacodtli;
            ctafechavalidez = item.ctafechavalidez;

        }

        private List<XRSKContratos> TOXRSKContratos(List<Contratos> items)
        {
            List<XRSKContratos> contratos = new List<XRSKContratos>();
            foreach (Contratos item in items)
            {
                contratos.Add(new XRSKContratos(item));
            }

            return contratos;
        }

        private IQueryable<Contratos> aplicarSeguridad(IQueryable<Contratos> query)
        {
            foreach (var grupo in Usuario.Grupos)
            {
                if (grupo.BasesDatos != null)
                {
                    foreach (XSRKBasesDatosGrupo bd in grupo.BasesDatos)
                    {
                        query = query.Where(x => bd.companies.Contains(x.ctacodcia));
                    }
                }
            }
            return query;
        }
        #endregion

        #region Public Methods
        public List<XRSKContratos> GetList()
        {
            List<XRSKContratos> contratos = new List<XRSKContratos>();
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.Contratos select x;

            //List < Contratos > items = db.Contratos.ToList();
            query = aplicarSeguridad(query);

            foreach (Contratos item in query.ToList())
            {
                contratos.Add(new XRSKContratos(item));
            }

            return contratos;
        }

        public List<XRSKContratos> GetContratosCia(XRSKContratos contract)
        {
            XRSKDataContext db = new XRSKDataContext();
            List<Contratos> contratosList = new List<Contratos>();

            var query = from x in
                       db.Contratos
                        select x;

            query = query.Where(x => x.ctafechavalidez == "99999999");
            //query = query.Where(x => x.ctacod == "AVBBK100");

            query = aplicarSeguridad(query);

            contratosList = query.ToList();

            return TOXRSKContratos(contratosList);
        }

        public List<XRSKContratos> GetContratosCias(XRSKContratos contract, string cia)
        {

            XRSKDataContext db = new XRSKDataContext();
            List<Contratos> contratosList = new List<Contratos>();

            var query = from x in
                       db.Contratos
                        select x;

            query = query.Where(x => x.ctafechavalidez == "99999999");
            //query = query.Where(x => x.ctacod == "AVBBK100");

            foreach (var grupo in contract.Usuario.Grupos)
            {
                if (grupo.BasesDatos != null)
                {
                    foreach (XSRKBasesDatosGrupo bd in grupo.BasesDatos)
                    {
                        query = query.Where(x => bd.companies.Contains(cia));
                        query = query.Where(x => x.ctacodcia.Contains(cia));

                    }
                }
            }
            contratosList = query.ToList();

            return TOXRSKContratos(contratosList);
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

            query = query.Where(x => x.grup.Contains(group) && x.iniPage != null);
            items = query.ToList();

            foreach (var item in items)
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

        #endregion
    }
}
