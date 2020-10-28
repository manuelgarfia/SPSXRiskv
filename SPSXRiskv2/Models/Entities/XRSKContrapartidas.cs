using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Database;


namespace SPSXRiskv2.Models.Entities
{
    public class XRSKContrapartidas
    {
        #region Propiedades
        public string CPTGrupo { get; set; }
        public string CPTCod { get; set; }
        public string CPTDescripcion { get; set; }
        #endregion

        #region Constructores

        public XRSKContrapartidas()
        {

        }

        public XRSKContrapartidas(String _CPTGrupo, String _CPTCod, String _CPTDescripcion)
        {
            CPTGrupo = _CPTGrupo;
            CPTCod = _CPTCod;
            CPTDescripcion = _CPTDescripcion;

        }

        public XRSKContrapartidas(Contrapartidas item)
        {
            TOXRSK_Companyia(item);
        }


        private void TOXRSK_Companyia(Contrapartidas item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSK_Companyia(item, db);
        }

        public XRSKContrapartidas(Contrapartidas item, XRSKDataContext db)
        {
            TOXRSK_Companyia(item, db);
        }

        private void TOXRSK_Companyia(Contrapartidas item, XRSKDataContext db)
        {
            CPTGrupo = item.
            CPTCod = item.CPTCod;
            CPTDescripcion = item.CPTDescripcion;
        }

        #endregion


        #region Funciones

        public List<XRSKContrapartidas> GetList()
        {

            List<XRSKContrapartidas> list_entidad = new List<XRSKContrapartidas>();
            XRSKDataContext db = new XRSKDataContext();

            List<Contrapartidas> items = db.context_contrapartidas.ToList();

            items = GetDistinctContrapartidas(items);

            foreach (Contrapartidas item in items)
            {
                list_entidad.Add(new XRSKContrapartidas(item));
            }

            return list_entidad;
        }


        public List<Contrapartidas> GetDistinctContrapartidas(List<Contrapartidas> item)
        {
            IEnumerable<Contrapartidas> enumerable = item.GroupBy(x => x.CPTCod).Select(x => x.FirstOrDefault());
            List<Contrapartidas> asList = enumerable.ToList();

            return asList;
        }
        #endregion
    }
}
