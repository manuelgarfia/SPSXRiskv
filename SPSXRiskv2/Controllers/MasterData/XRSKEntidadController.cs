using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;
using SPSXRiskv2.Models.Database;


namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKEntidadController
    {
        public List<XRSKEntidad> Get()
        {
            //Get AgrCondiciones
            XRSKEntidad entidad_item = new XRSKEntidad();
            List<XRSKEntidad> entidad_list = new List<XRSKEntidad>();

            try
            {
                entidad_list = entidad_item.GetList();
            }
            catch (Exception ex)
            {
                throw new XRSKException(ex.Message);
            }
            return entidad_list;
        }


    }
}
