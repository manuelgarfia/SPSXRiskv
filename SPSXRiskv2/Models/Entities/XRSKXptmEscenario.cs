using SPSXRiskv2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKXptmEscenario : XRSKEntity
    {
        #region Propiedades
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        #endregion

        #region Constructores

        public XRSKXptmEscenario()
        {

        }// Constructor sin parámetros

        public XRSKXptmEscenario(int _ID, string _Codigo, string _Descripcion, string _UsuarioCreacion, DateTime _FechaCreacion, string _UsuarioActualizacion, DateTime _FechaActualizacion)
        {
            ID = _ID;
            Codigo = _Codigo;
            Descripcion = _Descripcion;
            UsuarioCreacion = _UsuarioCreacion;
            FechaCreacion = _FechaCreacion;
            UsuarioActualizacion = _UsuarioActualizacion;
            FechaActualizacion = _FechaActualizacion;
        }

        public XRSKXptmEscenario(XPTMEscenario item)
        {
            TOXPTMEscenario(item);
        }// end Constructor EM

        public XRSKXptmEscenario(XPTMEscenario item, XRSKDataContext db)
        {
            TOXPTMEscenario(item, db);
        }// end Constructor EM

        #endregion

        #region Métodos Privados

        private void TOXPTMEscenario(XPTMEscenario item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXPTMEscenario(item, db);

        }// end TOSPSOperario

        private void TOXPTMEscenario(XPTMEscenario item, XRSKDataContext db)
        {
            ID = item.cabid;
            Codigo = item.codesc;
            Descripcion = item.descri;
            UsuarioCreacion = item.user_created;
            FechaCreacion = item.date_created;
            UsuarioActualizacion = item.user_updated;
            FechaCreacion = item.date_updated;

        }
        #endregion

        #region Métodos Públicos
        public List<XRSKXptmEscenario> GetList()
        {
            List<XRSKXptmEscenario> spsitems = new List<XRSKXptmEscenario>();
            XRSKDataContext db = new XRSKDataContext();

            List<XPTMEscenario> items = db.XptmEscenario.ToList();
            int i = 0;
            foreach (XPTMEscenario item in items)
            {
                spsitems.Add(new XRSKXptmEscenario(item));
                if (i == 10)
                    break;
                else i++;
            }

            return spsitems;
        }// end GetList method

        public XRSKXptmEscenario Find(int _ID)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(_ID, db);
        }// end Find method

        public XRSKXptmEscenario Find(int _ID, XRSKDataContext db)
        {
            XPTMEscenario item = db.XptmEscenario.Find(_ID);
            TOXPTMEscenario(item);
            return this;
        }// end Find method with context


        #endregion

        #region Persistencia
        private XPTMEscenario before_insert(XRSKDataContext db, XPTMEscenario next)
        {
            return next;
        }// end before_insert method

        private XPTMEscenario before_update(XRSKDataContext db, XPTMEscenario prev, XPTMEscenario next)
        {
            return next;
        }// end before_update method

        private XPTMEscenario before_delete(XRSKDataContext db, XPTMEscenario prev)
        {
            return prev;
        }// end before_delete method

        private XPTMEscenario after_insert(XRSKDataContext db, XPTMEscenario next)
        {
            return next;
        }// end after_insert method

        private XPTMEscenario after_update(XRSKDataContext db, XPTMEscenario prev, XPTMEscenario next)
        {
            return next;
        }// end after_update method


        public XRSKXptmEscenario save()
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

        public XRSKXptmEscenario save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            XPTMEscenario item = db.XptmEscenario.Find(ID);
            XPTMEscenario previous = new XPTMEscenario();
            // Change data
            if (item == null)
            {
                item = new XPTMEscenario();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }
            item.codesc = Codigo;
            item.descri = Descripcion;
            item.user_created = UsuarioCreacion;
            item.date_created = FechaCreacion;
            item.user_updated = UsuarioActualizacion;
            item.date_updated = FechaActualizacion;

            if (isInsert)
            {
                item = before_insert(db, item);
                db.XptmEscenario.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXPTMEscenario(item, db);

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

        public XRSKXptmEscenario delete()
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

        public XRSKXptmEscenario delete(XRSKDataContext db)
        {
            // Get Entity
            XPTMEscenario item = db.XptmEscenario.Find(ID);
            // Before_Delete call
            item = before_delete(db, item);

            db.XptmEscenario.Remove(item);
            db.SaveChanges();
            // Change data
            ID = 0;
            Codigo = null;
            Descripcion = null;
            UsuarioActualizacion = null;
            FechaCreacion = DateTime.MinValue;
            UsuarioCreacion = null;
            FechaActualizacion = DateTime.MinValue;

            return this;
        }// end delete method with method

        #endregion
    }
}