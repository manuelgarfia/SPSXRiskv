using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKXptmEscenarioController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<XRSKXptmEscenario>> Get()
        {
            XRSKXptmEscenario escenario = new XRSKXptmEscenario();
            List<XRSKXptmEscenario> escenarios = new List<XRSKXptmEscenario>();

            try
            {
                //escenarios.Add(new XRSKXptmEscenario(1, "REAL", "Realidad", "dbo", DateTime.Now, "dbo", DateTime.Now));
                //escenarios.Add(new XRSKXptmEscenario(2, "OPTI", "Optimista", "dbo", DateTime.Now, "dbo", DateTime.Now));

                escenarios = escenario.GetList();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

            return escenarios;
        }

        // GET api/<controller>/5
        [HttpGet("{key}")]
        public ActionResult<XRSKXptmEscenario> Get(int _ID)
        {
            XRSKXptmEscenario escenario = new XRSKXptmEscenario();
            try
            {
                escenario.Find(_ID);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return escenario;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // POST api/<controller>
        [HttpPost("save")]
        //public void Post([FromBody]string value)
        public ActionResult<XRSKXptmEscenario> Post(XRSKXptmEscenario escenario)
        {
            try
            {
                escenario.save();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return escenario;
        }

        // DELETE api/<controller>/5
        [HttpPost("delete")]
        public IActionResult Delete(XRSKXptmEscenario escenario)
        {
            try
            {
                escenario.delete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
