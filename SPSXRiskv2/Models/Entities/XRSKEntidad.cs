using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Database;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKEntidad : XRSKEntity
    {
        #region Propiedades
        public string ENTCod { get; set; }
        public string ENTDescripcion { get; set; }
        #endregion

        #region Constructores

        public XRSKEntidad()
        {

        }

        public XRSKEntidad(String _ENTCod, String _ENTDescripcion)
        {
            ENTCod = _ENTCod;
            ENTDescripcion = _ENTDescripcion;

        }

        public XRSKEntidad(Entidades item)
        {
            TOXRSK_Entidades(item);
        }


        private void TOXRSK_Entidades(Entidades item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSK_Entidades(item, db);
        }

        public XRSKEntidad(Entidades item, XRSKDataContext db)
        {
            TOXRSK_Entidades(item, db);
        }

        private void TOXRSK_Entidades(Entidades item, XRSKDataContext db)
        {
            ENTCod = item.ENTCod;
            ENTDescripcion = item.ENTDescripcion;
        }

        #endregion

        #region Funciones

        public List<XRSKEntidad> GetList()
        {

            List<XRSKEntidad> list_entidad = new List<XRSKEntidad>();
            XRSKDataContext db = new XRSKDataContext();

            List<Entidades> items = db.context_entidades.ToList();


            foreach (Entidades item in items)
            {
                list_entidad.Add(new XRSKEntidad(item));
            }

            return list_entidad;
        }

        public List<XRSKEntidad> GetFilteredEntidades(string[] itemSelected)
        {

            List<XRSKEntidad> list_entidad = new List<XRSKEntidad>();
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in db.context_entidades
                        select x;

            //query = query.Where(x => x.ENTCod == fromDate);

            return list_entidad;
        }


        #endregion

    }
}
