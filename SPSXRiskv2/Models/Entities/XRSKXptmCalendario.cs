using SPSXRiskv2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKXptmCalendario : XRSKEntity
    {
        #region Propiedades
        public int cabid { get; set; }
        public string codser { get; set; }
        public string descripcion { get; set; }
        public bool flunes { get; set; }
        public bool fmartes { get; set; }
        public bool fmiercoles { get; set; }
        public bool fjueves { get; set; }
        public bool fviernes { get; set; }
        public bool fsabado { get; set; }
        public bool fdomingo { get; set; }
        public string user_created { get; set; }
        public DateTime date_created { get; set; }
        public string user_updated { get; set; }
        public DateTime date_updated { get; set; }
        #endregion

        #region Constructores

        public XRSKXptmCalendario()
        {

        }// Constructor sin parámetros

        public XRSKXptmCalendario(int cabid, string codser, string descripcion, bool flunes, bool fmartes, bool fmiercoles, bool fjueves, bool fviernes,
                                  bool fsabado, bool fdomingo, string user_created, DateTime date_created, string user_updated, DateTime date_updated)
        {
            this.cabid = cabid;
            this.codser = codser;
            this.descripcion = descripcion;
            this.flunes = flunes;
            this.fmartes = fmartes;
            this.fmiercoles = fmiercoles;
            this.fjueves = fjueves;
            this.fviernes = fviernes;
            this.fsabado = fsabado;
            this.fdomingo = fdomingo;
            this.user_created = user_created;
            this.date_created = date_created;
            this.user_updated = user_updated;
            this.date_updated = date_updated;
        }

        public XRSKXptmCalendario(XPTMCalendario item)
        {
            TOXRSKXPTMCalendario(item);
        }// end Constructor EM

        public XRSKXptmCalendario(XPTMCalendario item, XRSKDataContext db)
        {
            TOXRSKXPTMCalendario(item, db);
        }// end Constructor EM

        #endregion

        #region Métodos Privados

        private void TOXRSKXPTMCalendario(XPTMCalendario item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKXPTMCalendario(item, db);

        }// end TOSPSOperario

        private void TOXRSKXPTMCalendario(XPTMCalendario item, XRSKDataContext db)
        {
            this.cabid = item.cabid;
            this.codser = item.codser;
            this.descripcion = item.descripcion;
            this.flunes = item.flunes;
            this.fmartes = item.fmartes;
            this.fmiercoles = item.fmiercoles;
            this.fjueves = item.fjueves;
            this.fviernes = item.fviernes;
            this.fsabado = item.fsabado;
            this.fdomingo = item.fdomingo;
            this.user_created = item.user_created;
            this.date_created = item.date_created;
            this.user_updated = item.user_updated;
            this.date_updated = item.date_updated;
        }
        #endregion

        #region Métodos Públicos
        public List<XRSKXptmCalendario> GetList()
        {
            List<XRSKXptmCalendario> spsitems = new List<XRSKXptmCalendario>();
            XRSKDataContext db = new XRSKDataContext();

            List<XPTMCalendario> items = db.XptmCalendario.ToList();
            int i = 0;
            foreach (XPTMCalendario item in items)
            {
                spsitems.Add(new XRSKXptmCalendario(item));
            }

            return spsitems;
        }// end GetList method

        public XRSKXptmCalendario Find(String codser)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(codser, db);
        }// end Find method

        public XRSKXptmCalendario Find(String codser, XRSKDataContext db)
        {
            XPTMCalendario item = db.XptmCalendario.Where(c => c.codser == codser).FirstOrDefault();
            TOXRSKXPTMCalendario(item);
            return this;
        }// end Find method with context


        #endregion

        #region Persistencia
        private XPTMCalendario before_insert(XRSKDataContext db, XPTMCalendario next)
        {
            return next;
        }// end before_insert method

        private XPTMCalendario before_update(XRSKDataContext db, XPTMCalendario prev, XPTMCalendario next)
        {
            return next;
        }// end before_update method

        private XPTMCalendario before_delete(XRSKDataContext db, XPTMCalendario prev)
        {
            return prev;
        }// end before_delete method

        private XPTMCalendario after_insert(XRSKDataContext db, XPTMCalendario next)
        {
            return next;
        }// end after_insert method

        private XPTMCalendario after_update(XRSKDataContext db, XPTMCalendario prev, XPTMCalendario next)
        {
            return next;
        }// end after_update method


        public XRSKXptmCalendario save()
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

        public XRSKXptmCalendario save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            XPTMCalendario item = db.XptmCalendario.Find(this.cabid);
            XPTMCalendario previous = new XPTMCalendario();
            // Change data
            if (item == null)
            {
                item = new XPTMCalendario();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }
            item.codser = this.codser;
            item.descripcion = this.descripcion;
            item.flunes = this.flunes;
            item.fmartes = this.fmartes;
            item.fmiercoles = this.fmiercoles;
            item.fjueves = this.fjueves;
            item.fviernes = this.fviernes;
            item.fsabado = this.fsabado;
            item.fdomingo = this.fdomingo;


            if (isInsert)
            {
                item = before_insert(db, item);
                db.XptmCalendario.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKXPTMCalendario(item, db);

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

        public XRSKXptmCalendario delete()
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

        public XRSKXptmCalendario delete(XRSKDataContext db)
        {
            // Get Entity
            //XPTMEscenarioDetalle item = db.XptmEscenarioDetalle.Find(fecha, codtipoint, escenario);
            XPTMCalendario item = db.XptmCalendario.Find(this.cabid);
            // Before_Delete call
            item = before_delete(db, item);

            db.XptmCalendario.Remove(item);
            db.SaveChanges();
            // Change data


            return this;
        }// end delete method with method

        #endregion
    }
}