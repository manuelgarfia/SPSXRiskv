using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.ViewModels;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKCertezas
    {
        #region Propiedades
        public string grado { get; set; }
        public string descripcion { get; set; }

        #endregion

        #region Constructores
        public XRSKCertezas()
        {

        } //Constructor Vacío

        public XRSKCertezas (string _grado, string _descripcion)
        {
            grado = _grado;
            descripcion = _descripcion;

        }
        public XRSKCertezas(Certezas item)
        {
            TOXRSKCertezas(item);
        }
        public XRSKCertezas (Certezas item, XRSKDataContext db)
        {
            TOXRSKCertezas(item, db);
        }
        #endregion
        #region Métodos Privados
        private void  TOXRSKCertezas(Certezas item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKCertezas(item, db);
        }

        private void TOXRSKCertezas (Certezas item, XRSKDataContext db)
        {
            grado = item.grado;
            descripcion = item.descripcion;
        }
        private List<XRSKCertezas> TOXRSKCertezas(List<Certezas> items)
        {
            List<XRSKCertezas> certezas = new List<XRSKCertezas>();
            foreach (Certezas item in items)
            {
                certezas.Add(new XRSKCertezas(item));
            }
            return certezas;
        }

        #endregion

        #region Funciones
        public List<XRSKCertezas> GetList()
        {
            List<Certezas> certezasItems = new List<Certezas>();
            XRSKDataContext db = new XRSKDataContext();
            var query = from x in db.Certezas
                        select x;
            certezasItems = query.ToList();
            return TOXRSKCertezas(certezasItems);

        }
        #endregion


    }
}
