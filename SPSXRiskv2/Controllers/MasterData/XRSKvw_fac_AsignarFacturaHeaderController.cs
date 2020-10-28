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
/// Code generated 14/09/2020 13:21:34 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKvw_fac_AsignarFacturaHeaderController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<XRSKvw_fac_AsignarFacturaHeader> Get()
        {
            XRSKvw_fac_AsignarFacturaHeader elem = new XRSKvw_fac_AsignarFacturaHeader();
            List<XRSKvw_fac_AsignarFacturaHeader> elemsList = new List<XRSKvw_fac_AsignarFacturaHeader>();

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
        public XRSKvw_fac_AsignarFacturaHeader Get(int ABCNumerador)
        {
            XRSKvw_fac_AsignarFacturaHeader elem = new XRSKvw_fac_AsignarFacturaHeader();
            try
            {
                elem.GetFacturaHeader(ABCNumerador);
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }

            return elem;
        }

        [HttpPost("filter")]
        public ActionResult<List<XRSKvw_fac_AsignarFacturaHeader>> GetFiltered(FilterModel filter)
        {
            //ClaimsPrincipal user = HttpContext.User;
            XRSKvw_fac_AsignarFacturaHeader entity = new XRSKvw_fac_AsignarFacturaHeader();
            List<XRSKvw_fac_AsignarFacturaHeader> elemsList = new List<XRSKvw_fac_AsignarFacturaHeader>();

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
        public ActionResult<XRSKvw_fac_AsignarFacturaHeader> Post(XRSKvw_fac_AsignarFacturaHeader elem)
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
        public IActionResult Delete(XRSKvw_fac_AsignarFacturaHeader elem)
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
