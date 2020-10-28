using SPSXRiskv2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKXptmEscenarioDetalle : XRSKEntity
    {
        #region Propiedades
        public int linid { get; set; }
        public DateTime fecha { get; set; }
        public string codtipoint { get; set; }
        public string escenario { get; set; }
        public decimal pctinteres { get; set; }
        public String user_created { get; set; }
        public DateTime date_created { get; set; }
        public string user_updated { get; set; }
        public DateTime date_updated { get; set; }
        #endregion

        #region Constructores

        public XRSKXptmEscenarioDetalle()
        {

        }// Constructor sin parámetros

        public XRSKXptmEscenarioDetalle(int _linid, DateTime _fecha, string _codtipoint, string _escenario, decimal _pctinteres, string _user_created, DateTime _date_created, string _user_updated, DateTime _date_updated)
        {
            linid = _linid;
            fecha = _fecha;
            codtipoint = _codtipoint;
            escenario = _escenario;
            pctinteres = _pctinteres;
            user_created = _user_created;
            date_created = _date_created;
            user_updated = _user_updated;
            date_updated = _date_updated;
        }

        public XRSKXptmEscenarioDetalle(XPTMEscenarioDetalle item)
        {
            TOXPTMEscenarioDetalle(item);
        }// end Constructor EM

        public XRSKXptmEscenarioDetalle(XPTMEscenarioDetalle item, XRSKDataContext db)
        {
            TOXPTMEscenarioDetalle(item, db);
        }// end Constructor EM

        #endregion

        #region Métodos Privados

        private void TOXPTMEscenarioDetalle(XPTMEscenarioDetalle item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXPTMEscenarioDetalle(item, db);

        }// end TOSPSOperario

        private void TOXPTMEscenarioDetalle(XPTMEscenarioDetalle item, XRSKDataContext db)
        {
            linid = item.linid;
            fecha = item.fecha;
            codtipoint = item.codtipoint;
            escenario = item.escenario;
            pctinteres = item.pctinteres;
            user_created = item.user_created;
            date_created = item.date_created;
            user_updated = item.user_updated;
            date_updated = item.date_updated;
        }
        #endregion

        #region Métodos Públicos
        public List<XRSKXptmEscenarioDetalle> GetList()
        {
            List<XRSKXptmEscenarioDetalle> spsitems = new List<XRSKXptmEscenarioDetalle>();
            XRSKDataContext db = new XRSKDataContext();

            List<XPTMEscenarioDetalle> items = db.XptmEscenarioDetalle.ToList();
            int i = 0;
            foreach (XPTMEscenarioDetalle item in items)
            {
                spsitems.Add(new XRSKXptmEscenarioDetalle(item));
                if (i == 10)
                    break;
                else i++;
            }

            return spsitems;
        }// end GetList method

        public XRSKXptmEscenarioDetalle Find(DateTime _fecha, String _codtipoint, String _escenario)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(_fecha, _codtipoint, _escenario, db);
        }// end Find method

        public XRSKXptmEscenarioDetalle Find(DateTime _fecha, String _codtipoint, String _escenario, XRSKDataContext db)
        {
            XPTMEscenarioDetalle item = db.XptmEscenarioDetalle.Find(_fecha, _codtipoint, _escenario);
            TOXPTMEscenarioDetalle(item);
            return this;
        }// end Find method with context


        #endregion

        #region Persistencia
        private XPTMEscenarioDetalle before_insert(XRSKDataContext db, XPTMEscenarioDetalle next)
        {
            return next;
        }// end before_insert method

        private XPTMEscenarioDetalle before_update(XRSKDataContext db, XPTMEscenarioDetalle prev, XPTMEscenarioDetalle next)
        {
            return next;
        }// end before_update method

        private XPTMEscenarioDetalle before_delete(XRSKDataContext db, XPTMEscenarioDetalle prev)
        {
            return prev;
        }// end before_delete method

        private XPTMEscenarioDetalle after_insert(XRSKDataContext db, XPTMEscenarioDetalle next)
        {
            return next;
        }// end after_insert method

        private XPTMEscenarioDetalle after_update(XRSKDataContext db, XPTMEscenarioDetalle prev, XPTMEscenarioDetalle next)
        {
            return next;
        }// end after_update method

        public XRSKXptmEscenarioDetalle save()
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
                    throw e.InnerException;
                }//end try-catch
            }// end dbContextTransacion

            return this;
        }// end save method

        public XRSKXptmEscenarioDetalle save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            //XPTMEscenarioDetalle item = db.XptmEscenarioDetalle.Find(fecha, codtipoint, escenario);
            XPTMEscenarioDetalle item = db.XptmEscenarioDetalle.Find(linid);
            XPTMEscenarioDetalle previous = new XPTMEscenarioDetalle();
            // Change data
            if (item == null)
            {
                item = new XPTMEscenarioDetalle();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }
            item.fecha = fecha.Date;
            item.codtipoint = codtipoint;
            item.escenario = escenario;
            item.pctinteres = pctinteres;
            if (item.date_created.Equals(DateTime.MinValue))
                item.date_created = DateTime.Now;
            item.date_updated = DateTime.Now;
            item.user_created = user_created;
            item.user_updated = user_updated;

            if (isInsert)
            {
                item = before_insert(db, item);
                db.XptmEscenarioDetalle.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXPTMEscenarioDetalle(item, db);

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

        public XRSKXptmEscenarioDetalle delete()
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

        public XRSKXptmEscenarioDetalle delete(XRSKDataContext db)
        {
            // Get Entity
            //XPTMEscenarioDetalle item = db.XptmEscenarioDetalle.Find(fecha, codtipoint, escenario);
            XPTMEscenarioDetalle item = db.XptmEscenarioDetalle.Find(linid);
            // Before_Delete call
            item = before_delete(db, item);

            db.XptmEscenarioDetalle.Remove(item);
            db.SaveChanges();
            // Change data
            fecha = DateTime.MinValue;
            codtipoint = null;
            escenario = null;
            pctinteres = 0;

            return this;
        }// end delete method with method

        #endregion
    }
}