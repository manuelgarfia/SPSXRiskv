using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SPSXRiskv2.Models.Database;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKMVFSimplificado:XRSKEntity
    {
        #region Propiedades
        public int cabid { get; set; }
        public string ClavePrevision { get; set; }
        public string MVFCodCIA { get; set; }
        public double MVFRefXRisk { get; set; }
        public string MVFCodCta { get; set; }
        public string MVFRef1SisExt { get; set; }
        public string MVFAgrOpe { get; set; }
        public string MVFCodOPE { get; set; }
        public string MVFCodCPT { get; set; }
        public string MVFCuentaContableCPT { get; set; }
        public string MVFDescripcion { get; set; }
        public string MVFSisOrig { get; set; }
        public string MVFCodITFLIT { get; set; }
        public string MVFRefLoteLIT { get; set; }
        public string MVFCodUSR { get; set; }
        public DateTime MVFFechImp { get; set; }
        public DateTime MVFFechOperac { get; set; }
        public DateTime MVFFechValor { get; set; }
        public string MVFCodDIV { get; set; }
        public string MVFCodCPTDIV { get; set; }
        public int MVFSigno { get; set; }
        public double MVFImporte { get; set; }
        public string MVFGradCert { get; set; }
        #endregion

        #region Constructores
        public XRSKMVFSimplificado()
        {

        }// Constructor sin parámetros

        public XRSKMVFSimplificado (MVFSimplificado item)
        {
            TOXRSKMVFSimplificado(item);
        }

        public XRSKMVFSimplificado (MVFSimplificado item, XRSKDataContext db)
        {
            TOXRSKMVFSimplificado(item, db);
        }

        #endregion

        #region Private Methods

            private void TOXRSKMVFSimplificado(MVFSimplificado item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKMVFSimplificado(item, db);
        }
        private void TOXRSKMVFSimplificado(MVFSimplificado item, XRSKDataContext db)
        {
            cabid = item.cabid;
            ClavePrevision = item.ClavePrevision;
            MVFCodCIA = item.MVFCodCIA;
            MVFRefXRisk = item.MVFRefXRisk;
            MVFCodCta = item.MVFCodCta;
            MVFRef1SisExt = item.MVFRef1SisExt;
            MVFAgrOpe = item.MVFAgrOpe;
            MVFCodOPE = item.MVFCodOPE;
            MVFCodCPT = item.MVFCodCPT;
            MVFCuentaContableCPT = item.MVFCuentaContableCPT;
            MVFDescripcion = item.MVFDescripcion;
            MVFSisOrig = item.MVFSisOrig;
            MVFCodITFLIT = item.MVFCodITFLIT;
            MVFRefLoteLIT = item.MVFRefLoteLIT;
            MVFCodUSR = item.MVFCodUSR;
            MVFFechImp = item.MVFFechImp;
            MVFFechOperac = item.MVFFechOperac;
            MVFFechValor = item.MVFFechValor;
            MVFCodDIV = item.MVFCodDIV;
            MVFCodCPTDIV = item.MVFCodCPTDIV;
            MVFSigno = item.MVFSigno;
            MVFImporte = item.MVFImporte;
            MVFGradCert = item.MVFGradCert;

        }

        private List<XRSKMVFSimplificado> TOXRSKMVFSimplificado(List<MVFSimplificado> items)
        {
            List<XRSKMVFSimplificado> simplificado = new List<XRSKMVFSimplificado>();

            foreach(MVFSimplificado item in items)
            {
                simplificado.Add(new XRSKMVFSimplificado(item));
            }

            return simplificado;

        }
        #endregion

        #region Funciones

        public List<XRSKMVFSimplificado> GetList()
        {
            List<XRSKMVFSimplificado> spsItems = new List<XRSKMVFSimplificado>();
            XRSKDataContext db = new XRSKDataContext();

            List<MVFSimplificado> items = db.MVFSimplificado.ToList();
            foreach (MVFSimplificado item in items)
            {
                spsItems.Add(new XRSKMVFSimplificado(item));    
            }

            return spsItems;
            
        }
        public XRSKMVFSimplificado save()
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
                }
            }
            return this;
        }


        private XRSKMVFSimplificado save (XRSKDataContext db)
        {
            //XRSKMVFSimplificado movimiento = new XRSKMVFSimplificado();
            Boolean isInsert = false;
            //Get Entity
            MVFSimplificado item = db.MVFSimplificado.Find(cabid);
            MVFSimplificado previous = new MVFSimplificado();

            if (item == null)
            {
                item = new MVFSimplificado();
                isInsert = true;
            }
            else
                {
                    previous = GetOriginal(db, item);
                }

            set_values(db, item);
            if (isInsert)
            {
                item = before_insert(db, item);
                db.MVFSimplificado.Add(item);
            }
            else
            {
                // si se llega a hacer update iría aquí
            }
            db.SaveChanges();
            return this;
        }


       private MVFSimplificado set_values (XRSKDataContext db, MVFSimplificado next)
        {
            next.cabid = cabid;
            next.ClavePrevision = ClavePrevision;
            next.MVFCodCIA = MVFCodCIA;
            next.MVFCodCta = MVFCodCta;
            next.MVFRef1SisExt = MVFRef1SisExt;
            next.MVFAgrOpe = MVFAgrOpe;
            next.MVFCodOPE = MVFCodOPE;
            next.MVFCodCPT = MVFCodCPT;
            next.MVFCuentaContableCPT = MVFCuentaContableCPT;
            next.MVFDescripcion = MVFDescripcion;
            next.MVFSisOrig = MVFSisOrig;
            next.MVFCodITFLIT = MVFCodITFLIT;
            next.MVFRefLoteLIT = MVFRefLoteLIT;
            next.MVFCodUSR = MVFCodUSR;
            next.MVFFechImp = MVFFechImp;
            next.MVFFechOperac = MVFFechOperac;
            next.MVFFechValor = MVFFechValor;
            next.MVFCodDIV = MVFCodDIV;
            next.MVFCodCPTDIV = MVFCodCPTDIV;
            next.MVFSigno = MVFSigno;
            next.MVFImporte = MVFImporte;
            next.MVFGradCert = MVFGradCert;
            return next;
        }


        private MVFSimplificado before_insert(XRSKDataContext db, MVFSimplificado next)
        {
            return next;
        }






        #endregion
    }
}
