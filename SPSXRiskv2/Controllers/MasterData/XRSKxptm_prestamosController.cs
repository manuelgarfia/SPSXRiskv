using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;
using SPSXRiskv2.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/// <summary>
/// Code generated 16/10/2020 10:05:18 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Authorize(Policy = "ValidUser")]
    [Route("api/[controller]")]
    public class XRSKxptm_prestamosController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<XRSKxptm_prestamos> Get()
        {
            ClaimsPrincipal user = HttpContext.User;
            XRSKxptm_prestamos elem = new XRSKxptm_prestamos(user);
            List<XRSKxptm_prestamos> elemsList = new List<XRSKxptm_prestamos>();

            try
            {
                elemsList = elem.GetList(user);
            }
            catch (Exception e)
            {

                throw new XRSKException(e.Message);
            }

            return elemsList;
        }

        // GET api/<controller>/5
        [HttpGet("{key}")]
        public XRSKxptm_prestamos Get(int cabid)
        {
            XRSKxptm_prestamos elem = new XRSKxptm_prestamos();
            try
            {
                elem.Find(cabid);
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }

            return elem;
        }

        [HttpPost("filter")]
        public ActionResult<List<XRSKxptm_prestamos>> GetFiltered(FilterModel filter)
        {
            ClaimsPrincipal user = HttpContext.User;
            XRSKxptm_prestamos entity = new XRSKxptm_prestamos(user);
            List<XRSKxptm_prestamos> elemsList = new List<XRSKxptm_prestamos>();

            try
            {
                elemsList = entity.GetFiltered(filter);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return elemsList;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // POST api/<controller>
        [HttpPost("save")]
        //public void Post([FromBody]string value)
        public ActionResult<XRSKxptm_prestamos> Post(XRSKxptm_prestamos elem)
        {
            try
            {
                elem.save();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return elem;
        }

        // DELETE api/<controller>/5
        [HttpPost("delete")]
        public IActionResult Delete(XRSKxptm_prestamos elem)
        {
            try
            {
                elem.delete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
