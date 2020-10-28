using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]


    public class XRSKAgrupacionController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<XRSKAgrupacion>> Get()
        {
            XRSKAgrupacion agrupacion = new XRSKAgrupacion();
            List<XRSKAgrupacion> agrupacionList = new List<XRSKAgrupacion>();

            try
            {
                //agrupacionList.Add(new XRSKAgrupacion("1", "---", "BAN", "Bancos"));
                //agrupacionList.Add(new XRSKAgrupacion("1", "---", "CRE", "Creditos"));
                agrupacionList = agrupacion.GetList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return agrupacionList;
        }

        // GET api/<controller>/5
        [HttpGet("{key}")]
        public ActionResult<XRSKAgrupacion> Get(String ACPGrupo, String ACPNiv, String ACPCod)
        {
            XRSKAgrupacion agrupacion = new XRSKAgrupacion();
            try
            {
                agrupacion.Find(ACPGrupo, ACPNiv, ACPCod);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            /*
            if (ACPCod.Equals("BAN"))
            {
                agrupacion = new XRSKAgrupacion("1", "---", "BAN", "Bancos");
            }
            else
            {
                agrupacion = new XRSKAgrupacion("1", "---", "CRE", "Creditos");
            }
            */
            return agrupacion;
        }

        // POST api/<controller>
        [HttpPost("save")]
        //public void Post([FromBody]string value)
        public ActionResult<XRSKAgrupacion> Post(XRSKAgrupacion agrupacion)
        {
            try
            {
                agrupacion.save();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return agrupacion;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpPost("delete")]
        public IActionResult Delete(XRSKAgrupacion agrupacion)
        {
            try
            {
                agrupacion.delete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
