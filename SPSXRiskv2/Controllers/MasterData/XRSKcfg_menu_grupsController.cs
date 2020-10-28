using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;
using SPSXRiskv2.ViewModels;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/// <summary>
/// Code generated 26/10/2020 11:01:01 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKcfg_menu_grupsController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<XRSKcfg_menu_grups> Get()
        {
            XRSKcfg_menu_grups elem = new XRSKcfg_menu_grups();
            List<XRSKcfg_menu_grups> elemsList = new List<XRSKcfg_menu_grups>();

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
        public XRSKcfg_menu_grups Get(string grup, string usuari)
        {
            XRSKcfg_menu_grups elem = new XRSKcfg_menu_grups();
            try
            {
                elem.Find(grup, usuari);
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }

            return elem;
        }

        [HttpPost("filter")]
        public ActionResult<List<XRSKcfg_menu_grups>> GetFiltered(FilterModel filter)
        {
            //ClaimsPrincipal user = HttpContext.User;
            XRSKcfg_menu_grups entity = new XRSKcfg_menu_grups();
            List<XRSKcfg_menu_grups> elemsList = new List<XRSKcfg_menu_grups>();

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
        public ActionResult<XRSKcfg_menu_grups> Post(XRSKcfg_menu_grups elem)
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
        public IActionResult Delete(XRSKcfg_menu_grups elem)
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
