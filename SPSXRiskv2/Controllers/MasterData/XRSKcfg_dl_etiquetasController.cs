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
/// Code generated 26/10/2020 11:05:11 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKcfg_dl_etiquetasController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<XRSKcfg_dl_etiquetas> Get()
        {
            XRSKcfg_dl_etiquetas elem = new XRSKcfg_dl_etiquetas();
            List<XRSKcfg_dl_etiquetas> elemsList = new List<XRSKcfg_dl_etiquetas>();

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
        public XRSKcfg_dl_etiquetas Get(string etiqueta, string idioma)
        {
            XRSKcfg_dl_etiquetas elem = new XRSKcfg_dl_etiquetas();
            try
            {
                elem.Find(etiqueta, idioma);
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }

            return elem;
        }

        [HttpPost("filter")]
        public ActionResult<List<XRSKcfg_dl_etiquetas>> GetFiltered(FilterModel filter)
        {
            //ClaimsPrincipal user = HttpContext.User;
            XRSKcfg_dl_etiquetas entity = new XRSKcfg_dl_etiquetas();
            List<XRSKcfg_dl_etiquetas> elemsList = new List<XRSKcfg_dl_etiquetas>();

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
        public ActionResult<XRSKcfg_dl_etiquetas> Post(XRSKcfg_dl_etiquetas elem)
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
        public IActionResult Delete(XRSKcfg_dl_etiquetas elem)
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
