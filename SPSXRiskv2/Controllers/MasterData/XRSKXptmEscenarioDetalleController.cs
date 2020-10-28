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
    public class XRSKXptmEscenarioDetalleController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<XRSKXptmEscenarioDetalle> Get()
        {
            XRSKXptmEscenarioDetalle escenarioDetalle = new XRSKXptmEscenarioDetalle();
            List<XRSKXptmEscenarioDetalle> escenarioDetalles = new List<XRSKXptmEscenarioDetalle>();

            try
            {
                //escenarioDetalles.Add(new XRSKXptmEscenarioDetalle(0, DateTime.Today, "USDLIMB1", "REAL", 38, "oys.dl", DateTime.Now, "oys.dl", DateTime.Now));
                //escenarioDetalles.Add(new XRSKXptmEscenarioDetalle(0, DateTime.Today, "USDLIMB1", "REAL", 38, "oys.dl", DateTime.Now, "oys.dl", DateTime.Now));
                escenarioDetalles = escenarioDetalle.GetList();
            }
            catch (Exception e)
            {

                throw new XRSKException(e.Message);
            }

            return escenarioDetalles;
        }

        // GET api/<controller>/5
        [HttpGet("{key}")]
        public XRSKXptmEscenarioDetalle Get(DateTime fecha, String codtipoint, String escenario)
        {
            XRSKXptmEscenarioDetalle escenarioDetalle = new XRSKXptmEscenarioDetalle();
            try
            {
                escenarioDetalle.Find(fecha, codtipoint, escenario);
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }

            return escenarioDetalle;
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
        public ActionResult<XRSKXptmEscenarioDetalle> Post(XRSKXptmEscenarioDetalle escenarioDetalle)
        {
            try
            {
                escenarioDetalle.save();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return escenarioDetalle;
        }

        // DELETE api/<controller>/5
        [HttpPost("delete")]
        public IActionResult Delete(XRSKXptmEscenarioDetalle escenarioDetalle)
        {
            try
            {
                escenarioDetalle.delete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
