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

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Authorize(Policy = "ValidUser")]
    [Route("api/[controller]")]
    public class XRSKContratosSaldosController : Controller
    {
      
        [HttpPost("filter")]
       public ActionResult<List<XRSKContratosSaldos>> getFilterListModal(FilterModel filter) 
        {
            ClaimsPrincipal user = HttpContext.User;
            XRSKContratosSaldos saldos = new XRSKContratosSaldos(user);
            List<XRSKContratosSaldos> movimientosList = new List<XRSKContratosSaldos>();


            try
            {
                movimientosList = saldos.GetFiltered(filter);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


            return movimientosList;


        }


        [HttpPost ("filter_Bar_Chart")]
        public ActionResult<List<XRSKContratosSaldos>> getFilterListCia(FilterModel filter)
        {
            ClaimsPrincipal user = HttpContext.User;
            XRSKContratosSaldos saldos = new XRSKContratosSaldos(user);
            List<XRSKContratosSaldos> contratosSaldosList = new List<XRSKContratosSaldos>();
            try
            {
                contratosSaldosList = saldos.GetFilteredCia(filter);

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            return contratosSaldosList;
        }

        [HttpGet("contratos/{company}/{contrato}")]
        public ActionResult<List<XRSKContratosSaldos>> getContratosSaldosList(string company, string contrato)
        {
            ClaimsPrincipal user = HttpContext.User;
            XRSKContratosSaldos saldos = new XRSKContratosSaldos(user);
            List<XRSKContratosSaldos> contratosSaldosList = new List<XRSKContratosSaldos>();
           // List<double> saldosList = new List<double>();

            try
            {
                contratosSaldosList = saldos.getContratosList(company, contrato);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return contratosSaldosList;
        }


        [HttpGet("saldos/{company}/{contrato}/{dateDesde}/{dateHasta}")]
        public ActionResult<List<XRSKContratosSaldos>> getContratosSaldosDateRange(string company, string contrato, string dateDesde, string dateHasta)
        {
            ClaimsPrincipal user = HttpContext.User;
            XRSKContratosSaldos saldos = new XRSKContratosSaldos(user);
            List<XRSKContratosSaldos> contratosSaldosList = new List<XRSKContratosSaldos>();
            // List<double> saldosList = new List<double>();

            try
            {
                contratosSaldosList = saldos.getContratosListDateRange(company, contrato, dateDesde, dateHasta);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return contratosSaldosList;
        }

    }

    }

