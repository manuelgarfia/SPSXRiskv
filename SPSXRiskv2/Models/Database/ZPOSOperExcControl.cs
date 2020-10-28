using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPSXRiskv2.Models.Database
{
    [Table("ZPOS_OperExcControl")]
    public class ZPOSOperExcControl
    {
        public string OXPCod { get; set; }
    }
}
