using Microsoft.AspNetCore.Identity;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKSecurityObject : XRSKEntity
    {

        #region Propiedades
        public string codigo { get; set; }
        public bool permitir { get; set; }
        public bool denegar { get; set; }
        public string permitidos { get; set; }
        public string denegados { get; set; }

        #endregion

        #region Constructores
        public XRSKSecurityObject()
        {

        }// Constructor sin parámetros


        public XRSKSecurityObject(SecurityObject item)
        {
            TOXRSKSecurityObject(item);
        }// end Constructor EM

        public XRSKSecurityObject(SecurityObject item, XRSKDataContext db)
        {
            TOXRSKSecurityObject(item, db);
        }// end Constructor EM

        #endregion

        #region Métodos Privados

        private void TOXRSKSecurityObject(SecurityObject item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKSecurityObject(item, db);

        }// end TOSPSOperario

        private void TOXRSKSecurityObject(SecurityObject item, XRSKDataContext db)
        {
            codigo = item.codigo;
            permitir = item.permitir;
            denegar = item.denegar;
            permitidos = item.permitidos;
            denegados = item.denegados;
        }

        #endregion

        #region Métodos Públicos

        public List<XRSKSecurityObject> GetList()
        {

            List<XRSKSecurityObject> spsitems = new List<XRSKSecurityObject>();
            XRSKDataContext db = new XRSKDataContext();


            List<SecurityObject> items = db.SecurityObject.ToList();
            foreach (SecurityObject item in items)
            {
                spsitems.Add(new XRSKSecurityObject(item));
            }

            return spsitems;
        }// end GetList method
        #endregion

        #region Functions

        public XRSKSecurityObject Find(string code)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(code, db);
        }// end Find method

        public XRSKSecurityObject Find(string code, XRSKDataContext db)
        {
            SecurityObject item = db.SecurityObject.Find(code);
            if (item == null)
            {
                return null;
            }
            TOXRSKSecurityObject(item);
            return this;
        }// end Find method with context
        #endregion
    }
}
