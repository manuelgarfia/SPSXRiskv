using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKContratosController:Controller
    {


        [Authorize(Policy = "ValidUser")]
        [HttpGet]
        public List<XRSKContratos> GetListContCia()
        {
            
            List<XRSKContratos> contratosList = new List<XRSKContratos>();
            try
            {

                ClaimsPrincipal user = HttpContext.User;
                XRSKContratos contratos_item = new XRSKContratos(user);

                contratosList = contratos_item.GetContratosCia(contratos_item);
            }
           
            catch (Exception ex)
            {
                throw new XRSKException(ex.Message);
            }
            return contratosList;
        }

        [HttpGet ("filter/{cia}")]
        public List<XRSKContratos> GetListContCia(string cia)
        {

            List<XRSKContratos> contratosList = new List<XRSKContratos>();
            try
            {

                ClaimsPrincipal user = HttpContext.User;
                XRSKContratos contratos_item = new XRSKContratos(user);

                contratosList = contratos_item.GetContratosCias(contratos_item,cia);
            }

            catch (Exception ex)
            {
                throw new XRSKException(ex.Message);
            }
            return contratosList;
        }

    }
}
