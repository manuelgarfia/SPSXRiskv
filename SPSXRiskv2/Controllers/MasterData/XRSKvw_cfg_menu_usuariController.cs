using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;
using SPSXRiskv2.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/// <summary>
/// Code generated 26/10/2020 11:07:17 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKvw_cfg_menu_usuariController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<XRSKvw_cfg_menu_usuari> Get()
        {
            XRSKvw_cfg_menu_usuari elem = new XRSKvw_cfg_menu_usuari();
            List<XRSKvw_cfg_menu_usuari> elemsList = new List<XRSKvw_cfg_menu_usuari>();

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
        public List<XRSKvw_cfg_menu_usuari> Get(string usuari)
        {
            XRSKvw_cfg_menu_usuari elem = new XRSKvw_cfg_menu_usuari();
            List<XRSKvw_cfg_menu_usuari> elemsList = new List<XRSKvw_cfg_menu_usuari>();
            try
            {
                elemsList = elem.GetList(usuari);
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }

            return elemsList;
        }

        [HttpPost("filter")]
        public ActionResult<List<XRSKvw_cfg_menu_usuari>> GetFiltered(FilterModel filter)
        {
            //ClaimsPrincipal user = HttpContext.User;
            XRSKvw_cfg_menu_usuari entity = new XRSKvw_cfg_menu_usuari();
            List<XRSKvw_cfg_menu_usuari> elemsList = new List<XRSKvw_cfg_menu_usuari>();

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
        public ActionResult<XRSKvw_cfg_menu_usuari> Post(XRSKvw_cfg_menu_usuari elem)
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
        public IActionResult Delete(XRSKvw_cfg_menu_usuari elem)
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
