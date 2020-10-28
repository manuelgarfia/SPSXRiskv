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
    //[ApiController]
    //[Route("api/[controller]")]
    //public class XRSKCarteraEfectosController
    //{
    //    [HttpGet]
    //    public List<XRSKCarteraEfectos> GetList()
    //    {
    //        List<XRSKCarteraEfectos> efectosList = new List<XRSKCarteraEfectos>();
    //        try
    //        {
    //            XRSKCarteraEfectos efectosItem = new XRSKCarteraEfectos();
    //            efectosList = efectosItem.GetList();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new XRSKException(ex.Message);
    //        }

    //        return efectosList;
    //    }

    //    [HttpGet("ResumenCLientes")]

    //    public List<XRSKCarteraEfectos> GetResumenList()
    //    {
    //        List<XRSKCarteraEfectos> efectosList = new List<XRSKCarteraEfectos>();
    //        try
    //        {
    //            XRSKCarteraEfectos efectosItem = new XRSKCarteraEfectos();
    //            efectosList = efectosItem.GetClienteList();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new XRSKException(ex.Message);
    //        }
    //        return efectosList;
    //    }

    //    [HttpPost("Detalle Cliente")]
    //    public List<XRSKCarteraEfectos> getDetalleList(string cliente)
    //    {
    //        List<XRSKCarteraEfectos> efectosList = new List<XRSKCarteraEfectos>();

    //        try
    //        {
    //            XRSKCarteraEfectos efectosItem = new XRSKCarteraEfectos();
    //            efectosList = efectosItem.GetListDatosCliente(cliente);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new XRSKException(ex.Message);
    //        }

    //        return efectosList;
    //    }

    //}
}
