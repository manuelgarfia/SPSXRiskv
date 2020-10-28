using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPSXRiskv2.ViewModels
{
    public class FilterModel
    {
        public List<FilterDetailModel> detail { get; set; }

        #region Constructores
        public FilterModel()
        {
            //detail = new List<FilterDetailModel>();
        }// Constructor por defecto
        #endregion
    }
}
