using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKCNCSituacionController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<XRSKCNCSituacion> Get()
        {
            XRSKCNCSituacion cnc = new XRSKCNCSituacion();
            List<XRSKCNCSituacion> cncList = new List<XRSKCNCSituacion>();

            try
            {
                cncList = cnc.GetList();
            }
            catch (Exception e)
            {
               throw new XRSKException(e.Message);
              //  throw new XRSKException("No se ha podido conectar al servidor!");
            }

            return cncList;
        }

        // DELETE api/<controller>/5
        //[HttpPost("delete")]
        //public IActionResult Delete(XRSKCNCSituacion cnc)
        //{
        //    try
        //    {
        //        cnc.delete();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //    return Ok();
        //}

        // POST api/<controller>
        //[HttpPost("save")]
        //public ActionResult<XRSKCNCSituacion> Post(XRSKCNCSituacion cnc)
        //{
        //    try
        //    {
        //        cnc.save();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //    return cnc;
        //}

        // POST api/<controller>
        [HttpPost("filter")]
        public ActionResult<List<XRSKCNCSituacion>> GetFiltered(FilterModel filter)
        {
            XRSKCNCSituacion cnc = new XRSKCNCSituacion();
            List<XRSKCNCSituacion> filteredList = new List<XRSKCNCSituacion>();

            try
            {
                filteredList = cnc.GetFilteredList(filter);
            }
            catch (Exception e)
            {
                throw new XRSKException(e.Message);
            }

            return filteredList;
        }
    }
}
