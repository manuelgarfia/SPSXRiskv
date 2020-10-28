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
using System.Linq.Expressions;

namespace SPSXRiskv2.Controllers.MasterData
{
        [ApiController]
        [Route("api/[controller]")]
        public class XRSKCertezasController
        {
            [HttpGet]
            public List<XRSKCertezas> GetList()
            {
                List<XRSKCertezas> certezasList = new List<XRSKCertezas>();
                try
                {
                    XRSKCertezas certezasItem = new XRSKCertezas();
                    certezasList = certezasItem.GetList();
                }
                catch(Exception ex)
                {
                    throw new XRSKException(ex.Message);
                }

                return certezasList;
            }
        }
}
