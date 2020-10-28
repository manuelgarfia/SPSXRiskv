using SPSXRiskv2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SPSXRiskv2.Models.Entities
{
    public class XSRKBasesDatosGrupo : XRSKEntity
    {


        #region Propiedades
        public int linid { get; set; }
        public string grup { get; set; }
        public string nombd { get; set; }
        public int prioritat { get; set; }
        public string perfmenu { get; set; }
        public string perfobj { get; set; }
        public string perfsql { get; set; }
        public string iniPage { get; set; }
        public string perfseg { get; set; }

        public string[] companies { get; set; }


        #endregion

        #region Constructores
        public XSRKBasesDatosGrupo()
        {

        }// Constructor sin parámetros


        public XSRKBasesDatosGrupo(BasesDatosGrupo item)
        {
            TOXRSKBasesDatosGrupo(item);
        }// end Constructor EM

        public XSRKBasesDatosGrupo(BasesDatosGrupo item, XRSKDataContext db)
        {
            TOXRSKBasesDatosGrupo(item, db);
        }// end Constructor EM

        #endregion

        #region Métodos Privados

        private void TOXRSKBasesDatosGrupo(BasesDatosGrupo item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKBasesDatosGrupo(item, db);

        }// end TOSPSOperario

        private void TOXRSKBasesDatosGrupo(BasesDatosGrupo item, XRSKDataContext db)
        {
            linid = item.linid;
            grup = item.grup;
            nombd = item.nombd;
            prioritat = item.prioritat;
            perfmenu = item.perfmenu;
            perfobj = item.perfobj;
            perfsql = item.perfsql;
            perfseg = item.perfseg;
            iniPage = item.iniPage;

            var codigo = db.SecurityObject.Where(x => x.codigo.Equals(perfseg)).FirstOrDefault();
            string companiesString = codigo.permitidos;
            companies = companiesString.Split(",");

        }

        #endregion

        #region Métodos Públicos

        public List<XSRKBasesDatosGrupo> GetList()
        {

            List<XSRKBasesDatosGrupo> spsitems = new List<XSRKBasesDatosGrupo>();
            XRSKDataContext db = new XRSKDataContext();


            List<BasesDatosGrupo> items = db.BasesDatosGrupo.ToList();
            foreach (BasesDatosGrupo item in items)
            {
                spsitems.Add(new XSRKBasesDatosGrupo(item));
            }

            return spsitems;
        }// end GetList method
        #endregion

        #region Functions

        public XSRKBasesDatosGrupo Find(string code)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(code, db);
        }// end Find method

        public XSRKBasesDatosGrupo Find(string code, XRSKDataContext db)
        {
            BasesDatosGrupo item = db.BasesDatosGrupo.Find(code);
            if (item == null)
            {
                return null;
            }

            TOXRSKBasesDatosGrupo(item);
            return this;
        }// end Find method with context
        #endregion
    }
}
