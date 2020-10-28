using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPSXRiskv2.Models
{
    static class XRSKConstantes
    {
        #region Constantes
        #region Filtros
        public const string FILTER_TYPE_DATE = "date";
        public const string FILTER_TYPE_ITEMS = "items";
        public const string FILTER_TYPE_NUMBER = "number";
        public const string FILTER_TYPE_STRING = "string";

        public const string FILTER_SUBTYPE_CONTAINS = "contains";
        public const string FILTER_SUBTYPE_ENDS = "ends";
        public const string FILTER_SUBTYPE_GREATER_EQUAL = ">=";
        public const string FILTER_SUBTYPE_LESS_EQUAL = "<=";
        public const string FILTER_SUBTYPE_RANGE = "range";
        public const string FILTER_SUBTYPE_STARTS = "starts";

        public const string FILTER_VALUE_EMPTY = "";
        #endregion

        #region Movimientos físicos y apuntes bancarios
        #region Grados de certeza
        public const string MVF_GC_CONTABILIZADO = "A";
        public const string MVF_GC_CIERTO = "C";
        public const string MVF_GC_PROVISORIO = "P";
        public const string MVF_GC_ESTIMADO = "S";
        #endregion

        #region Tipos de conciliación/certificación
        public const string TCONC_MANUAL = "MA";
        #endregion
        #endregion
        #endregion
    }
}
