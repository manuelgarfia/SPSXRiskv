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
/// Code generated 16/10/2020 10:06:55 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKxptm_prestamos_mvtosController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<XRSKxptm_prestamos_mvtos> Get()
        {
            XRSKxptm_prestamos_mvtos elem = new XRSKxptm_prestamos_mvtos();
            List<XRSKxptm_prestamos_mvtos> elemsList = new List<XRSKxptm_prestamos_mvtos>();

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
        public XRSKxptm_prestamos_mvtos Get(int cabid)
        {
            XRSKxptm_prestamos_mvtos elem = new XRSKxptm_prestamos_mvtos();
            try
            {
                elem.Find(cabid);
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }

            return elem;
        }

        [HttpPost("filter")]
        public ActionResult<List<XRSKxptm_prestamos_mvtos>> GetFiltered(FilterModel filter)
        {
            //ClaimsPrincipal user = HttpContext.User;
            XRSKxptm_prestamos_mvtos entity = new XRSKxptm_prestamos_mvtos();
            List<XRSKxptm_prestamos_mvtos> elemsList = new List<XRSKxptm_prestamos_mvtos>();

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
        public ActionResult<XRSKxptm_prestamos_mvtos> Post(XRSKxptm_prestamos_mvtos elem)
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
        public IActionResult Delete(XRSKxptm_prestamos_mvtos elem)
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
