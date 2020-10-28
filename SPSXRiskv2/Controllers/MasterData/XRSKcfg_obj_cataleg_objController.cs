using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;
using SPSXRiskv2.ViewModels;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/// <summary>
/// Code generated 26/10/2020 11:04:36 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKcfg_obj_cataleg_objController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<XRSKcfg_obj_cataleg_obj> Get()
        {
            XRSKcfg_obj_cataleg_obj elem = new XRSKcfg_obj_cataleg_obj();
            List<XRSKcfg_obj_cataleg_obj> elemsList = new List<XRSKcfg_obj_cataleg_obj>();

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
        public XRSKcfg_obj_cataleg_obj Get(string objecte)
        {
            XRSKcfg_obj_cataleg_obj elem = new XRSKcfg_obj_cataleg_obj();
            try
            {
                elem.Find(objecte);
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }

            return elem;
        }

        [HttpPost("filter")]
        public ActionResult<List<XRSKcfg_obj_cataleg_obj>> GetFiltered(FilterModel filter)
        {
            //ClaimsPrincipal user = HttpContext.User;
            XRSKcfg_obj_cataleg_obj entity = new XRSKcfg_obj_cataleg_obj();
            List<XRSKcfg_obj_cataleg_obj> elemsList = new List<XRSKcfg_obj_cataleg_obj>();

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
        public ActionResult<XRSKcfg_obj_cataleg_obj> Post(XRSKcfg_obj_cataleg_obj elem)
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
        public IActionResult Delete(XRSKcfg_obj_cataleg_obj elem)
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
