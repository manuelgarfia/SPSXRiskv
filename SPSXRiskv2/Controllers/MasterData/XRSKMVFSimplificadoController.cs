using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Common;
using SPSXRiskv2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPSXRiskv2.Controllers.MasterData
{
    [ApiController]
    [Route("api/[controller]")]

    public class XRSKMVFSimplificadoController :Controller
    {
        [HttpGet("no_filter")]


        public List<XRSKMVFSimplificado> Get()
        {
            XRSKMVFSimplificado simplificado = new XRSKMVFSimplificado();
            List<XRSKMVFSimplificado> simplificado_list = new List<XRSKMVFSimplificado>();
            try
            {
                simplificado_list = simplificado.GetList();
            }
            catch (Exception ex)
            {
                throw new XRSKException(ex.Message);
            }
            return simplificado_list;
        }


        // POST api/<controller>
        [HttpPost("save")]
        public ActionResult<XRSKMVFSimplificado> Post(XRSKMVFSimplificado movimiento)
        {

            try
            {
                movimiento.save();
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return movimiento;
        }

    }
}
