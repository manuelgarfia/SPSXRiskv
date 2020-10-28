using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Common;
using SPSXRiskv2.ViewModels;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SPSXRiskv2.Controllers.Tesoreria
{
    [ApiController]
    [Authorize(Policy = "ValidUser")]
    [Route("api/[controller]")]
    public class XRSKMovimientoFisicoController: Controller
    {
        public XRSKMovimientoFisicoController()
        {
            int j = 1;
        }

        [HttpGet]
        public ActionResult<List<XRSKMovimientoFisico>> Get()
        {
            //Get AgrCondiciones
            XRSKMovimientoFisico movimientos = new XRSKMovimientoFisico();
            List<XRSKMovimientoFisico> movimientosList = new List<XRSKMovimientoFisico>();

            try
            {
                movimientosList = movimientos.GetList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return movimientosList;
        }

        [HttpGet("register/{cia}/{reference}")]
        public ActionResult<XRSKMovimientoFisico> GetRegister(string cia, string reference)
        {
            //Get AgrCondiciones
            XRSKMovimientoFisico movimiento = new XRSKMovimientoFisico();

            try
            {
               // movimiento = movimiento.GetListCompanyRef(cia, reference);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return movimiento;
        }

        [HttpGet("dateRange/{from}/{to}/{ciasArray}")]
        //public ActionResult<List<XRSKMovimientoFisico>> GetDateRange(int Fdd, int Fmm, int Fyy, int Tdd, int Tmm, int Tyy, string fecha)
        public ActionResult<List<XRSKMovimientoFisico>> GetDateRange(string from, string to, string ciasArray)
        {
            DateTime fromDate = DateTime.Parse(from);
            DateTime toDate = DateTime.Parse(to);
            
            // Conversión de array de Elementos
            string[] Compañias = ciasArray.Split(",");

            XRSKMovimientoFisico movimientos = new XRSKMovimientoFisico();
            List<XRSKMovimientoFisico> movimientosList = new List<XRSKMovimientoFisico>();

            try
            {
                //movimientosList = movimientos.GetFiltered(fromDate, toDate, Compañias);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return movimientosList;
        }

        [HttpPost("filter")]
        public ActionResult<List<XRSKMovimientoFisico>> GetFiltered(FilterModel filter)
        {
            ClaimsPrincipal user = HttpContext.User;
            XRSKMovimientoFisico movimientos = new XRSKMovimientoFisico(user);
            List<XRSKMovimientoFisico> movimientosList = new List<XRSKMovimientoFisico>();

            try
            {
                movimientosList = movimientos.GetFiltered(filter);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return movimientosList;
        }

        [HttpPost("provconcil")]
        public ActionResult<List<XRSKMovimientoFisico>> GetProvisorisConcilFiltered(FilterModel filter)
        {
            XRSKMovimientoFisico movimientos = new XRSKMovimientoFisico();
            List<XRSKMovimientoFisico> movimientosList = new List<XRSKMovimientoFisico>();

            try
            {
                movimientosList = movimientos.GetConciliacionFiltered(filter);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return movimientosList;
        }

        [HttpPost("examples")]
        public ActionResult<List<XRSKMovFisicoExamples>> GetExamples(FilterModel filter)
        {
            //Get AgrCondiciones
            XRSKMovFisicoExamples movimientos = new XRSKMovFisicoExamples();
            List<XRSKMovFisicoExamples> movimientosList = new List<XRSKMovFisicoExamples>();

            try
            {
                movimientosList = movimientos.GetExamplesList(filter);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return movimientosList;
        }

        // POST api/<controller>
        [HttpPost("save")]
        //public void Post([FromBody]string value)
        public ActionResult<XRSKMovimientoFisico> Post(XRSKMovimientoFisico movimientoFisico)
        {
            ClaimsPrincipal user = HttpContext.User;
            // TO DO: Ver como pasarle las credenciales a una entidad que ya nos viene!!!!!!!!
            XRSKMovimientoFisico movimientos = new XRSKMovimientoFisico(user);

            try
            {
                movimientoFisico.save();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return movimientoFisico;
        }

    }
}
