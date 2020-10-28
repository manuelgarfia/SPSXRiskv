using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Common;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Authorize(Policy = "ValidUser")]
    [Route("api/[controller]")]
    public class XRSKCIAController:Controller
    {

        [HttpGet]
        public List<XRSKCompanyia> Get()
        {
            List<XRSKCompanyia> cia_list = new List<XRSKCompanyia>();
            try
            {
                ClaimsPrincipal user = HttpContext.User;
                XRSKCompanyia cia_item = new XRSKCompanyia(user);
                cia_list = cia_item.GetList();
            }
            catch (Exception ex)
            {
                throw new XRSKException(ex.Message);
            }
            return cia_list;
        }
    }
}
