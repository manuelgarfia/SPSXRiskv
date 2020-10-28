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
    public class XRSKXptmTipintdController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<XRSKXptmTipintd>> Get()
        {
            XRSKXptmTipintd tipo = new XRSKXptmTipintd();
            List<XRSKXptmTipintd> tipos = new List<XRSKXptmTipintd>();

            try
            {
                //tipos.Add(new XRSKXptmTipintd(1, "USDLIMB1", "Tipo 1", 1, "dbo", DateTime.Now, "dbo", DateTime.Now));
                //tipos.Add(new XRSKXptmTipintd(2, "USDLIMB2", "Tipo 2", 1, "dbo", DateTime.Now, "dbo", DateTime.Now));

                tipos = tipo.GetList();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

            return tipos;
        }

        // GET api/<controller>/5
        [HttpGet("{key}")]
        public ActionResult<XRSKXptmTipintd> Get(int _ID)
        {
            XRSKXptmTipintd tipo = new XRSKXptmTipintd();
            try
            {
                tipo.Find(_ID);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return tipo;
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
        public ActionResult<XRSKXptmTipintd> Post(XRSKXptmTipintd tipo)
        {
            try
            {
                tipo.save();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return tipo;
        }

        // DELETE api/<controller>/5
        [HttpPost("delete")]
        public IActionResult Delete(XRSKXptmTipintd tipo)
        {
            try
            {
                tipo.delete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
