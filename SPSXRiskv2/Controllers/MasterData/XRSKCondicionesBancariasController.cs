using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Models.Database;

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKCondicionesBancariasController
    {
        [HttpGet]
        public List<XRSKCondicionesBancarias> Get()
        {
            XRSKCondicionesBancarias cb = new XRSKCondicionesBancarias();
            List<XRSKCondicionesBancarias> cbv_List = new List<XRSKCondicionesBancarias>();
            CondicionesBancarias condbanc = new CondicionesBancarias();

            try
            {
                //condbanc = cb.delete();

            }
            catch (Exception e)
            {

                throw new XRSKException(e.Message);
            }

            return cbv_List;
        }
    }
}
