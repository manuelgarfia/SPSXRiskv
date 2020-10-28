using SPSXRiskv2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKXptmTipintd : XRSKEntity
    {
        #region Propiedades
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Periodicidad { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        #endregion

        #region Constructores

        public XRSKXptmTipintd()
        {

        }// Constructor sin parámetros

        public XRSKXptmTipintd(int _ID, string _Codigo, string _Descripcion, int _Periodicidad, string _UsuarioCreacion, DateTime _FechaCreacion, string _UsuarioActualizacion, DateTime _FechaActualizacion)
        {
            ID = _ID;
            Codigo = _Codigo;
            Descripcion = _Descripcion;
            Periodicidad = _Periodicidad;
            UsuarioCreacion = _UsuarioCreacion;
            FechaCreacion = _FechaCreacion;
            UsuarioActualizacion = _UsuarioActualizacion;
            FechaActualizacion = _FechaActualizacion;
        }

        public XRSKXptmTipintd(XPTMTipintd item)
        {
            TOXPTMTipintd(item);
        }// end Constructor EM

        public XRSKXptmTipintd(XPTMTipintd item, XRSKDataContext db)
        {
            TOXPTMTipintd(item, db);
        }// end Constructor EM

        #endregion

        #region Métodos Privados

        private void TOXPTMTipintd(XPTMTipintd item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXPTMTipintd(item, db);

        }// end TOSPSOperario

        private void TOXPTMTipintd(XPTMTipintd item, XRSKDataContext db)
        {
            ID = item.linid;
            Codigo = item.codigo;
            Descripcion = item.descri;
            Periodicidad = item.periodicidad;
            UsuarioCreacion = item.user_created;
            FechaCreacion = item.date_created;
            UsuarioActualizacion = item.user_updated;
            FechaCreacion = item.date_updated;

        }
        #endregion

        #region Métodos Públicos
        public List<XRSKXptmTipintd> GetList()
        {
            List<XRSKXptmTipintd> spsitems = new List<XRSKXptmTipintd>();
            XRSKDataContext db = new XRSKDataContext();

            List<XPTMTipintd> items = db.XptmTipintd.ToList();
            int i = 0;
            foreach (XPTMTipintd item in items)
            {
                spsitems.Add(new XRSKXptmTipintd(item));
                if (i == 10)
                    break;
                else i++;
            }

            return spsitems;
        }// end GetList method

        public XRSKXptmTipintd Find(int _ID)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(_ID, db);
        }// end Find method

        public XRSKXptmTipintd Find(int _ID, XRSKDataContext db)
        {
            XPTMTipintd item = db.XptmTipintd.Find(_ID);
            TOXPTMTipintd(item);
            return this;
        }// end Find method with context


        #endregion

        #region Persistencia
        private XPTMTipintd before_insert(XRSKDataContext db, XPTMTipintd next)
        {
            return next;
        }// end before_insert method

        private XPTMTipintd before_update(XRSKDataContext db, XPTMTipintd prev, XPTMTipintd next)
        {
            return next;
        }// end before_update method

        private XPTMTipintd before_delete(XRSKDataContext db, XPTMTipintd prev)
        {
            return prev;
        }// end before_delete method

        private XPTMTipintd after_insert(XRSKDataContext db, XPTMTipintd next)
        {
            return next;
        }// end after_insert method

        private XPTMTipintd after_update(XRSKDataContext db, XPTMTipintd prev, XPTMTipintd next)
        {
            return next;
        }// end after_update method


        public XRSKXptmTipintd save()
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

        public XRSKXptmTipintd save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            XPTMTipintd item = db.XptmTipintd.Find(ID);
            XPTMTipintd previous = new XPTMTipintd();
            // Change data
            if (item == null)
            {
                item = new XPTMTipintd();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }
            item.codigo = Codigo;
            item.descri = Descripcion;
            item.periodicidad = Periodicidad;
            item.user_created = UsuarioCreacion;
            item.date_created = FechaCreacion;
            item.user_updated = UsuarioActualizacion;
            item.date_updated = FechaActualizacion;

            if (isInsert)
            {
                item = before_insert(db, item);
                db.XptmTipintd.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXPTMTipintd(item, db);

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

        public XRSKXptmTipintd delete()
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

        public XRSKXptmTipintd delete(XRSKDataContext db)
        {
            // Get Entity
            XPTMTipintd item = db.XptmTipintd.Find(ID);
            // Before_Delete call
            item = before_delete(db, item);

            db.XptmTipintd.Remove(item);
            db.SaveChanges();
            // Change data
            ID = 0;
            Codigo = null;
            Descripcion = null;
            Periodicidad = 1;
            UsuarioActualizacion = null;
            FechaCreacion = DateTime.MinValue;
            UsuarioCreacion = null;
            FechaActualizacion = DateTime.MinValue;

            return this;
        }// end delete method with method

        #endregion
    }
}