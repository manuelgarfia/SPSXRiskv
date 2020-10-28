using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]

    public class XRSKClavesPrevisionesController: Controller
    {
        // GET: api/<controller>
        [HttpGet("cia/{compañia}")]
        public List<XRSKClavesPrevisiones> GetList(string compañia)
        {
            XRSKClavesPrevisiones item = new XRSKClavesPrevisiones();
            List<XRSKClavesPrevisiones> listItem = new List<XRSKClavesPrevisiones>();
            try
            {
                listItem = item.GetList(compañia);
            }
            catch(Exception e )
            {
                throw new XRSKException(e.Message);
            }
            return listItem;
        }
    }
}
