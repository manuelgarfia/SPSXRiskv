using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Models.Entities;
using SPSXRiskv2.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace SPSXRiskv2.Controllers.Tesoreria
{
    [ApiController]
    [Authorize(Policy = "ValidUser")]
    [Route("api/[controller]")]
    public class XRSKApunteBancarioController: Controller
    {
        public XRSKApunteBancarioController()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult<List<XRSKApunteBancario>> Get()
        {
            //Get AgrCondiciones
            XRSKApunteBancario apuntes = new XRSKApunteBancario();
            List<XRSKApunteBancario> apuntesList = new List<XRSKApunteBancario>();

            try
            {
                apuntesList = apuntes.GetList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return apuntesList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="ciasArray"></param>
        /// <returns></returns>
        [HttpGet("dateRange/{from}/{to}/{ciasArray}")]
        public ActionResult<List<XRSKApunteBancario>> GetDateRange(string from, string to, string ciasArray)
        {
            DateTime fromDate = DateTime.Parse(from);
            DateTime toDate = DateTime.Parse(to);
            
            // Conversión de array de Elementos
            string[] Compañias = ciasArray.Split(",");

            XRSKApunteBancario apuntes = new XRSKApunteBancario();
            List<XRSKApunteBancario> apuntesList = new List<XRSKApunteBancario>();

            try
            {
                //apuntesList = apuntes.GetFiltered(fromDate, toDate, Compañias);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return apuntesList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public ActionResult<List<XRSKApunteBancario>> GetFiltered(FilterModel filter)
        {
            XRSKApunteBancario apuntes = new XRSKApunteBancario();
            List<XRSKApunteBancario> apuntesList = new List<XRSKApunteBancario>();

            try
            {
                //apuntesList = apuntes.GetFiltered(filter);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return apuntesList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("provconcil")]
        public ActionResult<List<XRSKApunteBancario>> GetProvisorisConcilFiltered(FilterModel filter)
        {
            ClaimsPrincipal user = HttpContext.User;
            XRSKApunteBancario apuntes = new XRSKApunteBancario(user);
            List<XRSKApunteBancario> apuntesList = new List<XRSKApunteBancario>();

            try
            {
                apuntesList = apuntes.GetConciliacionFiltered(filter);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return apuntesList;
        }

        [HttpGet("cardInformation")]
        public ActionResult<List<object>> numApunBanc()
        {
            XRSKApunteBancario apuntBanc = new XRSKApunteBancario();

            List<object> listOfApuntBanc = new List<object>();

            try
            {
                listOfApuntBanc = apuntBanc.getCardInfo();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return listOfApuntBanc;
        }
    }
}
