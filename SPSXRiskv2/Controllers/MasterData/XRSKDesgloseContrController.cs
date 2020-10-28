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
/// Code generated 14/09/2020 9:34:15 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKDesgloseContrController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<XRSKDesgloseContr> Get()
        {
            XRSKDesgloseContr elem = new XRSKDesgloseContr();
            List<XRSKDesgloseContr> elemsList = new List<XRSKDesgloseContr>();

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

        [HttpGet("desglose/{company}/{referencia}")]
        public List<XRSKDesgloseContr> GetDesglose(string company, string referencia)
        {
            XRSKDesgloseContr elem = new XRSKDesgloseContr();
            List<XRSKDesgloseContr> elemsList = new List<XRSKDesgloseContr>();

            try
            {
                elemsList = elem.GetShortList(company, referencia);
            }
            catch (Exception e)
            {

                throw new XRSKException(e.Message);
            }

            return elemsList;
        }



        // GET api/<controller>/5
        [HttpGet("{key}")]
        public XRSKDesgloseContr Get(string DCPCodCIA, string DCPValorOrganizativo, double DCPRefXrisk, int DCPContador)
        {
            XRSKDesgloseContr elem = new XRSKDesgloseContr();
            try
            {
                elem.Find(DCPCodCIA, DCPValorOrganizativo, DCPRefXrisk, DCPContador);
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }

            return elem;
        }

        [HttpPost("filter")]
        public ActionResult<List<XRSKDesgloseContr>> GetFiltered(FilterModel filter)
        {
            //ClaimsPrincipal user = HttpContext.User;
            XRSKDesgloseContr entity = new XRSKDesgloseContr();
            List<XRSKDesgloseContr> elemsList = new List<XRSKDesgloseContr>();

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
        public ActionResult<XRSKDesgloseContr> Post(XRSKDesgloseContr elem)
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
        public IActionResult Delete(XRSKDesgloseContr elem)
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
