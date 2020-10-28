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


    public class XRSKXptmCalendarioController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<XRSKXptmCalendario> Get()
        {
            XRSKXptmCalendario calendario = new XRSKXptmCalendario();
            List<XRSKXptmCalendario> calendario_list = new List<XRSKXptmCalendario>();

            try
            {
                calendario_list = calendario.GetList();
            }
            catch (Exception e)
            {

                throw new XRSKException(e.Message);
            }

            return calendario_list;
        }

        // GET api/<controller>/5
        [HttpGet("{key}")]
        public XRSKXptmCalendario Get(String codser)
        {
            XRSKXptmCalendario calendario = new XRSKXptmCalendario();
            try
            {
                calendario.Find(codser);
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }

            return calendario;
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

        // DELETE api/<controller>/5
        [HttpPost("delete")]
        public IActionResult Delete(XRSKXptmCalendario calendario)
        {
            try
            {
                calendario.delete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
