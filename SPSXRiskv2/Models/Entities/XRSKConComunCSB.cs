using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.ViewModels;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKConComunCSB : XRSKEntity
    {
        #region Propiedades
        public string CCCCod { get; set; }
        public string CCCNiv { get; set; }
        public string CCCDescripcion { get; set; }
        #endregion

        #region Constructores
        public XRSKConComunCSB()
        {
        }

        public XRSKConComunCSB(ClaimsPrincipal _Usuario) : base(_Usuario)
        {
        }

        public XRSKConComunCSB(ConComun item)
        {
            TOXRSKConComunCSB(item);
        }

        public XRSKConComunCSB(ConComun item, XRSKDataContext db)
        {
            TOXRSKConComunCSB(item, db);
        }
        #endregion

        #region Private Methods
        private void TOXRSKConComunCSB(ConComun item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKConComunCSB(item, db);
        }

        private List<XRSKConComunCSB> TOXRSKConComunCSB(List<ConComun> items)
        {
            List<XRSKConComunCSB> certezas = new List<XRSKConComunCSB>();
            foreach (ConComun item in items)
            {
                certezas.Add(new XRSKConComunCSB(item));
            }
            return certezas;
        }

        private void TOXRSKConComunCSB(ConComun item, XRSKDataContext db)
        {
            CCCCod = item.CCCCod;
            CCCNiv = item.CCCNiv;
            CCCDescripcion = item.CCCDescripcion;
        }
        #endregion

        #region Funciones
        public List<XRSKConComunCSB> GetList()
        {
            List<ConComun> ConComunItems = new List<ConComun>();
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.ConComunCSB
                        select x;
            ConComunItems = query.ToList();
            return TOXRSKConComunCSB(ConComunItems);
        }


        public ConComun getDescripcion(string code)
        {
            XRSKDataContext db = new XRSKDataContext();
            ConComun cc = db.ConComunCSB.Where(b => b.CCCCod == code).FirstOrDefault();

            return cc;
        }

        #endregion
    }
}
