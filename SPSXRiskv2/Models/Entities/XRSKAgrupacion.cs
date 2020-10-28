using SPSXRiskv2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKAgrupacion : XRSKEntity
    {
        #region Propiedades

        public String ACPGrupo { get; set; }
        public String ACPNiv { get; set; }
        public String ACPCod { get; set; }
        public String ACPDescripcion { get; set; }

        #endregion

        #region Constructores

        public XRSKAgrupacion()
        {

        }// Constructor sin parámetros

        public XRSKAgrupacion(String _ACPGrupo, String _ACPNiv, String _ACPCod, String _ACPDescripcion)
        {
            ACPGrupo = _ACPGrupo;
            ACPNiv = _ACPNiv;
            ACPCod = _ACPCod;
            ACPDescripcion = _ACPDescripcion;
        }

        public XRSKAgrupacion(Agrupacion item)
        {
            TOXRSKAgrupacion(item);
        }// end Constructor EM

        public XRSKAgrupacion(Agrupacion item, XRSKDataContext db)
        {
            TOXRSKAgrupacion(item, db);
        }// end Constructor EM

        #endregion

        #region Métodos Privados

        private void TOXRSKAgrupacion(Agrupacion item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKAgrupacion(item, db);

        }// end TOSPSOperario

        private void TOXRSKAgrupacion(Agrupacion item, XRSKDataContext db)
        {
            ACPCod = item.ACPCod;
            ACPNiv = item.ACPNiv;
            ACPGrupo = item.ACPGrupo;
            ACPDescripcion = item.ACPDescripcion;
        }

        #endregion

        #region Métodos Públicos

        public List<XRSKAgrupacion> GetList()
        {

            List<XRSKAgrupacion> spsitems = new List<XRSKAgrupacion>();
            XRSKDataContext db = new XRSKDataContext();


            List<Agrupacion> items = db.Agrupacion.ToList();
            foreach (Agrupacion item in items)
            {
                spsitems.Add(new XRSKAgrupacion(item));
            }

            return spsitems;
        }// end GetList method

        public XRSKAgrupacion Find(String _ACPGrupo, String _ACPNiv, String _ACPCod)
        {
            XRSKDataContext db = new XRSKDataContext();
            return Find(_ACPGrupo, _ACPNiv, _ACPCod, db);
        }// end Find method

        public XRSKAgrupacion Find(String _ACPGrupo, String _ACPNiv, String _ACPCod, XRSKDataContext db)
        {
            Agrupacion item = db.Agrupacion.Find(_ACPGrupo, _ACPNiv, _ACPCod);
            TOXRSKAgrupacion(item);
            return this;
        }// end Find method with context


        #endregion

        #region Persistencia

        private Agrupacion before_insert(XRSKDataContext db, Agrupacion next)
        {
            // Valores por defecto explicados por Rosa
            if (next.ACPGrupo.Equals(""))
            {
                next.ACPGrupo = "GRP";
            }
            // Valores por defecto explicados por Rosa
            if (next.ACPNiv.Equals(""))
            {
                next.ACPNiv = ".........";
            }
            if (next.ACPCod.Equals(""))
            {
                throw new Exception("El Código de Agrupación de Contrapartidas no puede estar vacío.");
            }
            return next;
        }// end before_insert method

        private Agrupacion before_update(XRSKDataContext db, Agrupacion prev, Agrupacion next)
        {
            return next;
        }// end before_update method

        private Agrupacion before_delete(XRSKDataContext db, Agrupacion prev)
        {
            return prev;
        }// end before_delete method

        private Agrupacion after_insert(XRSKDataContext db, Agrupacion next)
        {
            return next;
        }// end after_insert method

        private Agrupacion after_update(XRSKDataContext db, Agrupacion prev, Agrupacion next)
        {
            return next;
        }// end after_update method


        public XRSKAgrupacion save()
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

        public XRSKAgrupacion save(XRSKDataContext db)
        {
            Boolean isInsert = false;
            // Get Entity
            Agrupacion item = db.Agrupacion.Find(ACPGrupo, ACPNiv, ACPCod);
            Agrupacion previous = new Agrupacion();
            // Change data
            if (item == null)
            {
                item = new Agrupacion();
                isInsert = true;
            }
            else
            {
                previous = GetOriginal(db, item);
            }
            item.ACPGrupo = ACPGrupo;
            item.ACPNiv = ACPNiv;
            item.ACPCod = ACPCod;
            item.ACPDescripcion = ACPDescripcion;

            if (isInsert)
            {
                item = before_insert(db, item);
                db.Agrupacion.Add(item);
            }
            else
            {
                item = before_update(db, previous, item);
            }

            // Update Context
            db.SaveChanges();
            // Change data

            TOXRSKAgrupacion(item, db);

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

        public XRSKAgrupacion delete()
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

        public XRSKAgrupacion delete(XRSKDataContext db)
        {
            // Get Entity
            Agrupacion item = db.Agrupacion.Find(ACPGrupo, ACPNiv, ACPCod);
            // Before_Delete call
            item = before_delete(db, item);

            db.Agrupacion.Remove(item);
            db.SaveChanges();
            // Change data
            ACPGrupo = null; ;
            ACPNiv = null;
            ACPCod = null;
            ACPDescripcion = null;

            return this;
        }// end delete method with method

        #endregion
    }
}