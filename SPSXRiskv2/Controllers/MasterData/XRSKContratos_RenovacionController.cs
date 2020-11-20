using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;
using SPSXRiskv2.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/// <summary>
/// Code generated 29/09/2020 13:11:57 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Authorize(Policy = "ValidUser")]
    [Route("api/[controller]")]
    public class XRSKContratos_RenovacionController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<XRSKContratos_Renovacion> Get()
        {
            ClaimsPrincipal user = HttpContext.User;
            XRSKContratos_Renovacion elem = new XRSKContratos_Renovacion(user);
            List<XRSKContratos_Renovacion> elemsList = new List<XRSKContratos_Renovacion>();

            try
            {
                elemsList = elem.GetList();
            }
            catch (Exception e)
            {

                throw new XRSKException(e.Message);
            }

            return elemsList;
        }

        // GET api/<controller>/5
        [HttpGet("{key}")]
        public XRSKContratos_Renovacion Get(string CTACod, string CTACodCIA, DateTime CTAFechIniPer)
        {
            XRSKContratos_Renovacion elem = new XRSKContratos_Renovacion();
            try
            {
                elem.Find(CTACod, CTACodCIA, CTAFechIniPer);
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }

            return elem;
        }

        [HttpPost("filter")]
        public ActionResult<List<XRSKContratos_Renovacion>> GetFiltered(FilterModel filter)
        {
            ClaimsPrincipal user = HttpContext.User;
            XRSKContratos_Renovacion entity = new XRSKContratos_Renovacion(user);
            List<XRSKContratos_Renovacion> elemsList = new List<XRSKContratos_Renovacion>();

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
        public ActionResult<XRSKContratos_Renovacion> Post(XRSKContratos_Renovacion elem)
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
        public IActionResult Delete(XRSKContratos_Renovacion elem)
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
