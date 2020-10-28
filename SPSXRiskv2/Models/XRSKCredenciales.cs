using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPSXRiskv2.Models
{
    static class XRSKCredenciales
    {
        private static string _ConnectionString = "";

        public static string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

    }
}
