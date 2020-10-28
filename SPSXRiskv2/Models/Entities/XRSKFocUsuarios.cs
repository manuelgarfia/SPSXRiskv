using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKFocUsuarios
    {

        #region Propiedades
        public int cabid { get; set; }
        public string usuari { get; set; }
        public string usuariZoom { get; set; }
        public string paswrd { get; set; }
        public string nombre { get; set; }
        public string idioma { get; set; }
        public bool activo { get; set; }

        public List<XRSKFocUsuariosGrupos> Grupos = new List<XRSKFocUsuariosGrupos>();

        #endregion

        #region Constructores
        public XRSKFocUsuarios()
        {

        }// Constructor sin parámetros

        public XRSKFocUsuarios(String _Usuario)
        {
            XRSKDataContext db = new XRSKDataContext();
            FocUsuarios item = db.FocUsuarios.Where(x => x.usuari.Equals(_Usuario)).FirstOrDefault();

            TOXRSKFocUsuarios(item);
        }// Constructor con parámetro Código Usuario

        public XRSKFocUsuarios(String _Usuario, XRSKDataContext db)
        {
            FocUsuarios item = db.FocUsuarios.Where(x => x.usuari.Equals(_Usuario)).FirstOrDefault();
   
            TOXRSKFocUsuarios(item);
        }// Constructor con parámetro Código Usuario


        public XRSKFocUsuarios(int _cabid, string _usuari, string _usuariZoom, string _paswrd, string _nombre, string _idioma, bool _activo)
        {
            cabid = _cabid;
            usuari = _usuari;
            usuariZoom = _usuariZoom;
            paswrd = _paswrd;
            nombre = _nombre;
            idioma = _idioma;
            activo = _activo;
        }

        public XRSKFocUsuarios(FocUsuarios item)
        {
            TOXRSKFocUsuarios(item);
        }// end Constructor EM

        public XRSKFocUsuarios(FocUsuarios item, XRSKDataContext db)
        {
            TOXRSKFocUsuarios(item, db);
        }// end Constructor EM

        public XRSKFocUsuarios(FocUsuarios item, XRSKDataContext db, Boolean noUser)
        {
            TOXRSKFocUsuariosNoUser(item, db);
        }// Constructor per tornar la llista simple d'usuaris de FocUsuarios

        #endregion

        #region Métodos Privados

        private void TOXRSKFocUsuarios(FocUsuarios item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKFocUsuarios(item, db);

        }// end TOSPSOperario

        private void TOXRSKFocUsuariosNoUser(FocUsuarios item, XRSKDataContext db)
        {
            cabid = item.cabid;
            usuari = item.usuari;
            usuariZoom = item.usuariZoom;
            paswrd = item.paswrd;
            nombre = item.nombre;
            idioma = item.idioma;
            activo = item.activo;
        }

        private void TOXRSKFocUsuarios(FocUsuarios item, XRSKDataContext db)
        {
            cabid = item.cabid;
            usuari = item.usuari;
            usuariZoom = item.usuariZoom;
            paswrd = item.paswrd;
            nombre = item.nombre;
            idioma = item.idioma;
            activo = item.activo;

            List <FocUsuariosGrupos> grupos = db.FocUsuariosGrupos.Where(x => x.usuari.Equals(usuari)).ToList();
            foreach(FocUsuariosGrupos grupo in grupos)
            {
                Grupos.Add(new XRSKFocUsuariosGrupos(grupo));
            }
        }

        #endregion

        #region Métodos Públicos

        public List<XRSKFocUsuarios> GetList()
        {

            List<XRSKFocUsuarios> spsitems = new List<XRSKFocUsuarios>();
            XRSKDataContext db = new XRSKDataContext();


            List<FocUsuarios> items = db.FocUsuarios.ToList();
            foreach (FocUsuarios item in items)
            {
                spsitems.Add(new XRSKFocUsuarios(item));
            }

            return spsitems;
        }// end GetList method
        #endregion

        public List<XRSKFocUsuarios> GetSimpleList()
        {

            List<XRSKFocUsuarios> spsitems = new List<XRSKFocUsuarios>();
            XRSKDataContext db = new XRSKDataContext();
            Boolean noUser = true;

            List<FocUsuarios> items = db.FocUsuarios.ToList();
            foreach (FocUsuarios item in items)
            {
                spsitems.Add(new XRSKFocUsuarios(item,db,noUser));
            }

            return spsitems;
        }// end GetList method but without user


        //Métodos de inicio de usuario
        public XRSKFocUsuarios Find(LoginModel model)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(model, db);
        }// end Find method

        public XRSKFocUsuarios Find(LoginModel model, XRSKDataContext db)
        {
            FocUsuarios item = db.FocUsuarios.Where(x => x.usuari.Equals(model.Username) && x.paswrd.Equals(model.Password)).FirstOrDefault();
            if(item == null)
            {
                return null;
            }
            TOXRSKFocUsuarios(item);
            return this;
        }// end Find method with context

        public XRSKFocUsuarios Find(String usuario)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(usuario, db);
        }// end Find method

        public XRSKFocUsuarios Find(String usuario, XRSKDataContext db)
        {
            FocUsuarios item = db.FocUsuarios.Where(x => x.usuari.Equals(usuario)).FirstOrDefault();
            if (item == null)
            {
                return null;
            }
            TOXRSKFocUsuarios(item);
            return this;
        }// end Find method with context



    }
}
