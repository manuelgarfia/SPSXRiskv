using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;
using SPSXRiskv2.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using SPSXRiskv2.Models.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/// <summary>
/// Code generated 15/09/2020 10:54:28 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKEfectosController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<XRSKEfectos> Get()
        {
            XRSKEfectos elem = new XRSKEfectos();
            List<XRSKEfectos> elemsList = new List<XRSKEfectos>();

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

        [HttpGet("facturas/{cliente}")]
        public List<XRSKEfectos> GetFacturasCliente(string cliente)
        {
            XRSKEfectos elem = new XRSKEfectos();
            List<XRSKEfectos> elemsList = new List<XRSKEfectos>();

            try
            {
                elemsList = elem.GetListEfectosCliente(cliente);
            }
            catch (Exception e)
            {

                throw new XRSKException(e.Message);
            }

            return elemsList;
        }


        [HttpGet("efectos/{cliente}")]
        public List<XRSKEfectos> GetEfectosCliente()
        {
            XRSKEfectos elem = new XRSKEfectos();
            List<XRSKEfectos> elemsList = new List<XRSKEfectos>();

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
        public XRSKEfectos Get(int id)
        {
            XRSKEfectos elem = new XRSKEfectos();
            try
            {
                elem.Find(id);
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }

            return elem;
        }

        // GET api/<controller>/5
        [HttpGet("cliente")]
        public List<XRSKEfectos> GetCliente(string id)
        {
            XRSKEfectos entity = new XRSKEfectos();
            List<XRSKEfectos> elemsList = new List<XRSKEfectos>();
            try
            {
                elemsList = entity.GetCliente(id);
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }

            return elemsList;
        }

        [HttpGet("ResumenCLientes")]

        public List<carteraEfectos> GetResumenList()
        {
            List<carteraEfectos> efectosList = new List<carteraEfectos>();
            try
            {
                XRSKEfectos efectosItem = new XRSKEfectos();
                efectosList = efectosItem.GetClienteList();
            }
            catch (Exception ex)
            {
                throw new XRSKException(ex.Message);
            }
            return efectosList;
        }

        [HttpGet("movimiento")]
        public List<XRSKEfectos> GetMovimiento(int id)
        {
            XRSKEfectos entity = new XRSKEfectos();
            List<XRSKEfectos> elemsList = new List<XRSKEfectos>();
            try
            {
                elemsList = entity.GetMovimiento(id);
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }

            return elemsList;
        }

        [HttpPost("filter")]
        public ActionResult<List<XRSKEfectos>> GetFiltered(FilterModel filter)
        {
            //ClaimsPrincipal user = HttpContext.User;
            XRSKEfectos entity = new XRSKEfectos();
            List<XRSKEfectos> elemsList = new List<XRSKEfectos>();

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
        public ActionResult<XRSKEfectos> Post(XRSKEfectos elem)
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
        public IActionResult Delete(XRSKEfectos elem)
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
