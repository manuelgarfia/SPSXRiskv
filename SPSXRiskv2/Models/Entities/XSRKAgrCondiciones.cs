using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Database;

namespace SPSXRiskv2.Models.Entities
{
    public class XSRKAgrCondiciones
    {

        #region Propiedades
        public string ACOGrupo { get; set; }
        public string ACONiv { get; set; }
        public string ACOCod { get; set; }
        public string ACODescripcion { get; set; }
        public string ACOTipo { get; set; }
        #endregion

        #region Constructors
        public XSRKAgrCondiciones()
        {

        }

        public XSRKAgrCondiciones(String _ACOGrupo, String _ACONiv, String _ACODescripcion, String _ACOTipo)
        {
            ACOGrupo = _ACOGrupo;
            ACONiv = _ACONiv;
            ACODescripcion = _ACODescripcion;
            ACOTipo = _ACOTipo;
        }

        public XSRKAgrCondiciones(AgrCondiciones item)
        {
            TOXRSK_AgrCondiciones(item);
        }// end Constructor EM

        private void TOXRSK_AgrCondiciones(AgrCondiciones item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSK_AgrCondiciones(item, db);

        }

        public XSRKAgrCondiciones(AgrCondiciones item, XRSKDataContext db)
        {
            TOXRSK_AgrCondiciones(item, db);
        }

        private void TOXRSK_AgrCondiciones(AgrCondiciones item, XRSKDataContext db)
        {
            ACOGrupo = item.ACOGrupo;
            ACONiv = item.ACONiv;
            ACOCod = item.ACOCod;
            ACOTipo = item.ACOTipo;
        }

        #endregion



        public List<XSRKAgrCondiciones> GetList()
        {

            List<XSRKAgrCondiciones> cbv_items = new List<XSRKAgrCondiciones>();
            XRSKDataContext db = new XRSKDataContext();
            List<AgrCondiciones> items = db.context_AgrCondiciones.ToList();

            foreach (AgrCondiciones item in items)
            {
                cbv_items.Add(new XSRKAgrCondiciones(item));
            }

            return cbv_items;
        }

        public XSRKAgrCondiciones Find(String _ACOTipo)
        {
            XRSKDataContext db = new XRSKDataContext();
            return this;

        }
    }
}
