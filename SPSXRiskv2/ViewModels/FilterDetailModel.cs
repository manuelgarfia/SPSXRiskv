using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPSXRiskv2.ViewModels
{

    public class FilterDetailModel
    {
        #region Propiedades

        public string title { get; set; }
        public string entity { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
        public string[] values {get; set; }
        public string charValue { get; set; }
        public decimal? decValue { get; set; }
        public decimal? importMax { get; set; }
        public string compareType { get;set; }
        public DateTime? from { get; set; }
        public DateTime? to { get; set; }
        #endregion

        #region Constructores
        public FilterDetailModel()
        {

        }// Constructor por defecto
        #endregion

    }
}
