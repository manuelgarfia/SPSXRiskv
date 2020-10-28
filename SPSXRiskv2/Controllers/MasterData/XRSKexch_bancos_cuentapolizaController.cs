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
/// Code generated 29/09/2020 13:11:41 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKexch_bancos_cuentapolizaController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<XRSKexch_bancos_cuentapoliza> Get()
        {
            XRSKexch_bancos_cuentapoliza elem = new XRSKexch_bancos_cuentapoliza();
            List<XRSKexch_bancos_cuentapoliza> elemsList = new List<XRSKexch_bancos_cuentapoliza>();

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

        [HttpGet("polizas/{company}/{contrato}")]
        public XRSKexch_bancos_cuentapoliza GetPoliza(string company, string contrato)
        {
            XRSKexch_bancos_cuentapoliza elem = new XRSKexch_bancos_cuentapoliza();
            //List<XRSKexch_bancos_cuentapoliza> elemsList = new List<XRSKexch_bancos_cuentapoliza>();

            try
            {
                elem = elem.GetCuentaCorriente(company, contrato);
            }
            catch (Exception e)
            {

                throw new XRSKException(e.Message);
            }

            return elem;
        }

        // GET api/<controller>/5
        [HttpGet("{key}")]
        public XRSKexch_bancos_cuentapoliza Get(int cabid)
        {
            XRSKexch_bancos_cuentapoliza elem = new XRSKexch_bancos_cuentapoliza();
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
        public ActionResult<List<XRSKexch_bancos_cuentapoliza>> GetFiltered(FilterModel filter)
        {
            //ClaimsPrincipal user = HttpContext.User;
            XRSKexch_bancos_cuentapoliza entity = new XRSKexch_bancos_cuentapoliza();
            List<XRSKexch_bancos_cuentapoliza> elemsList = new List<XRSKexch_bancos_cuentapoliza>();

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
        public ActionResult<XRSKexch_bancos_cuentapoliza> Post(XRSKexch_bancos_cuentapoliza elem)
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
        public IActionResult Delete(XRSKexch_bancos_cuentapoliza elem)
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
