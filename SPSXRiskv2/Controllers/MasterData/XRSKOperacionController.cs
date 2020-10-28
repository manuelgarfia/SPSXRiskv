using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;
using SPSXRiskv2.Models.Database;
using System.Collections.Generic;
using System;

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKOperacionController
    {
        [HttpGet]
        public List<XRSKOperacion> Get()
        {
            //Get AgrCondiciones
            XRSKOperacion operacion_item = new XRSKOperacion();
            List<XRSKOperacion> operacion_list = new List<XRSKOperacion>();

            try
            {
                operacion_list = operacion_item.GetList();
            }
            catch (Exception ex)
            {
                throw new XRSKException(ex.Message);
            }

            return operacion_list;
        }

        [HttpGet("filter")]
        public List<XRSKOperacion> GetDistinct()
        {
            //Get AgrCondiciones
            XRSKOperacion op = new XRSKOperacion();
            List<XRSKOperacion> opList = new List<XRSKOperacion>();

            try
            {
                opList = op.GetDistinctList();
            }
            catch (Exception ex)
            {
                throw new XRSKException(ex.Message);
            }

            return opList;
        }

    }
}
