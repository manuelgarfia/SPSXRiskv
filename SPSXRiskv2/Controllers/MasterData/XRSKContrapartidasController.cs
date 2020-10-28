using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Common;

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKContrapartidasController
    {
        [HttpGet]
        public List<XRSKContrapartidas> Get()
        {
            //Get AgrCondiciones
            XRSKContrapartidas cpt_item = new XRSKContrapartidas();
            List<XRSKContrapartidas> cpt_list = new List<XRSKContrapartidas>();

            try
            {
                cpt_list = cpt_item.GetList();
            }
            catch (Exception ex)
            {
                throw new XRSKException(ex.Message);
            }
            return cpt_list;
        }
    }
}