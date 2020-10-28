using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;
using SPSXRiskv2.Models.Database;
using System.Collections.Generic;
using System;

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]
    public class XRSKAgrCondicionesController : Controller
    {

        //  [HttpGet]
        public List<XSRKAgrCondiciones> Get()
        {

            //Get AgrCondiciones
            XSRKAgrCondiciones agrcondiciones = new XSRKAgrCondiciones();
            List<XSRKAgrCondiciones> agrcondiciones_list = new List<XSRKAgrCondiciones>();

            try
            {
                agrcondiciones_list = agrcondiciones.GetList();
            }
            catch (Exception ex)
            {
                throw new XRSKException(ex.Message);
            }


            return agrcondiciones_list;
        }

        [HttpGet]
        public List<XSRKAgrCondiciones> get_acogrupo()
        {
            XSRKAgrCondiciones agrcondiciones = new XSRKAgrCondiciones();
            XSRKAgrCondiciones agrcondiciones_list = new XSRKAgrCondiciones();
            List<XSRKAgrCondiciones> agr_list = new List<XSRKAgrCondiciones>();

            try
            {
                agr_list = agrcondiciones.GetList();

                var res_list = agr_list.Where(item => item.ACOTipo == "CONBAN");

                return res_list.ToList();
                //  agrcondiciones_list = agrcondiciones.Find("CONBAN");


            }
            catch (Exception ex)
            {
                throw new XRSKException(ex.Message);
            }

            // return res_list.ToList();
        }

    }

}
