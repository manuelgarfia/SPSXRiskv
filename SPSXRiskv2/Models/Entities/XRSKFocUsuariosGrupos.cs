using SPSXRiskv2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKFocUsuariosGrupos
    {

        #region Propiedades
        public int cabid { get; set; }
        public string usuari { get; set; }
        public string grup { get; set; }

        private string nombd = "DEV";      // De moment empinyonem DEV

        public List<XSRKBasesDatosGrupo> BasesDatos = new List<XSRKBasesDatosGrupo>();

        #endregion

        #region Constructores
        public XRSKFocUsuariosGrupos()
        {
        }// Constructor sin parámetros

        public XRSKFocUsuariosGrupos(int _cabid, string _usuari, string _grup)
        {
            cabid = _cabid;
            usuari = _usuari;
            grup = _grup;
        }

        public XRSKFocUsuariosGrupos(FocUsuariosGrupos item)
        {
            TOXRSKFocUsuariosGrupos(item);
        }// end Constructor EM

        public XRSKFocUsuariosGrupos(FocUsuariosGrupos item, XRSKDataContext db)
        {
            TOXRSKFocUsuariosGrupos(item, db);
        }// end Constructor EM

        public XRSKFocUsuariosGrupos(FocUsuariosGrupos item, XRSKDataContext db, Boolean user)
        {
            TOXRSKFocUsuariosGruposNoUser(item,db);
        }// end Constructor EM

        #endregion

        #region Métodos Privados

        private void TOXRSKFocUsuariosGrupos(FocUsuariosGrupos item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKFocUsuariosGrupos(item, db);

        }// end TOSPSOperario

        private void TOXRSKFocUsuariosGrupos(FocUsuariosGrupos item, XRSKDataContext db)
        {
            cabid = item.cabid;
            usuari = item.usuari;
            grup = item.grup;

            List<BasesDatosGrupo> bbdds = db.BasesDatosGrupo.Where(x => x.grup.Equals(grup) && x.nombd.Equals(nombd)).ToList();
            foreach (BasesDatosGrupo bbdd in bbdds)
            {
                BasesDatos.Add(new XSRKBasesDatosGrupo(bbdd));
            }
        }

        private void TOXRSKFocUsuariosGruposNoUser(FocUsuariosGrupos item, XRSKDataContext db)
        {
            cabid = item.cabid;
            usuari = item.usuari;
            grup = item.grup;
        }

        #endregion

        #region Métodos Públicos

        public List<XRSKFocUsuariosGrupos> GetList()
        {

            List<XRSKFocUsuariosGrupos> spsitems = new List<XRSKFocUsuariosGrupos>();
            XRSKDataContext db = new XRSKDataContext();

            List<FocUsuariosGrupos> items = db.FocUsuariosGrupos.ToList();
            foreach (FocUsuariosGrupos item in items)
            {
                spsitems.Add(new XRSKFocUsuariosGrupos(item));
            }

            return spsitems;
        }// end GetList method

        public List<XRSKFocUsuariosGrupos> GetSimpleList()
        {

            List<XRSKFocUsuariosGrupos> spsitems = new List<XRSKFocUsuariosGrupos>();
            XRSKDataContext db = new XRSKDataContext();
            Boolean user = true;

            List<FocUsuariosGrupos> items = db.FocUsuariosGrupos.ToList();
            foreach (FocUsuariosGrupos item in items)
            {
                spsitems.Add(new XRSKFocUsuariosGrupos(item,db,user));
            }

            return spsitems;
        }// end GetList method to get only the list
        #endregion
    }
}
