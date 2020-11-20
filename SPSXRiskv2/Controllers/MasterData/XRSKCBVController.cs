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
using SPSXRiskv2.ViewModels;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Authorize(Policy = "ValidUser")]
    [Route("api/[controller]")]
    public class XRSKCBVController : Controller
    {

        // GET: api/<controller>
        [HttpGet]
        public List<XRSKCBVigentes> Get()
        {
            ClaimsPrincipal user = HttpContext.User;
            XRSKCBVigentes cb_vigentes = new XRSKCBVigentes(user);
            List<XRSKCBVigentes> cbv_List = new List<XRSKCBVigentes>();

            try
            {
                cbv_List = cb_vigentes.GetList();

            }
            catch (Exception e)
            {

               throw new XRSKException(e.Message);
              //  throw new XRSKException("No se ha podido conectar al servidor!");
            }

            return cbv_List;
        }

        // DELETE api/<controller>/5
        [HttpPost("delete")]
        public IActionResult Delete(XRSKCBVigentes cond_banc)
        {
            try
            {
                cond_banc.delete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }


        // POST api/<controller>
        [HttpPost("save")]
        public ActionResult<XRSKCBVigentes> Post(XRSKCBVigentes cond_banc)
        {
            try
            {
                cond_banc.save();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return cond_banc;
        }


        // POST api/<controller>
        [HttpPost("filter")]
        public ActionResult<List<XRSKCBVigentes>> GetFiltered(FilterModel filter)
        {
            ClaimsPrincipal user = HttpContext.User;
            XRSKCBVigentes condicionesBancarias = new XRSKCBVigentes(user);
            List<XRSKCBVigentes> filtered_list = new List<XRSKCBVigentes>();
            var currentUser = HttpContext.User;

                try
                {
                    filtered_list = condicionesBancarias.GetFilteredList(filter);
                }
                catch (Exception e)
                {
                    throw new XRSKException(e.Message);
                }

            return filtered_list;
        }

    }
}
