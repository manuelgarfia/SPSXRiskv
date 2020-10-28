using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPSXRiskv2.ViewModels
{
    public class ConciliacionModel
    {
        public String Companyia { get; set; }
        public String Operacion { get; set; }
        public List<MovimientosDetailModel> Movimientos { get; set; }
        public List<ApuntesDetailModel> Apuntes { get; set; }

        #region Constructores
        public ConciliacionModel()
        {
            //detail = new List<FilterDetailModel>();
        }// Constructor por defecto
        #endregion
    }
}
