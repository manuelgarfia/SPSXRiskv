using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Models.Entities;
using SPSXRiskv2.Models.Procesos;
using SPSXRiskv2.ViewModels;
using System;
using System.Collections.Generic;

namespace SPSXRiskv2.Controllers.Tesoreria
{
    [ApiController]
    [Authorize(Policy = "ValidUser")]
    [Route("api/[controller]")]
    public class XRSKConciliacionController : Controller
    {
        public XRSKConciliacionController()
        {
        }

        [HttpPost("ejecutar")]
        public ActionResult<Double> ExecutarOperacio(ConciliacionModel concilModel)
        {
            XRSKMovimientoFisico movimientos = new XRSKMovimientoFisico();
            XRSKApunteBancario apunts = new XRSKApunteBancario();
            double referencia = -1;

            try
            {
                // Obtención de los provisorios y de los bancarios seleccionados
                List<XRSKMovimientoFisico> movimientosList = movimientos.GetFiltered(concilModel.Movimientos);
                List<XRSKApunteBancario> apuntesList = apunts.GetFiltered(concilModel.Apuntes);

                // Realizar la operación solicitada
                XRSKConciliacion conciliacion = new XRSKConciliacion(HttpContext.User, concilModel.Companyia, concilModel.Operacion, movimientosList, apuntesList);
                referencia = conciliacion.Execute();

                // Guardar los provisorios y los bancarios procesados en una transacción
                // Ref.: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-resilient-entity-framework-core-sql-connections
                //XRSKDataContext db = new XRSKDataContext();

                //var strategy = db.Database.CreateExecutionStrategy();

                //using (strategy.ExecuteAsync(async () =>
                //{
                //    using (var transaction = db.Database.BeginTransaction())
                //    {
                //        try
                //        {
                //            movimientos.save(db, movimientosList);
                //            apunts.save(db, apuntesList);
                //            transaction.Commit();
                //        }
                //        catch (Exception transExcept)
                //        {
                //            transaction.Rollback();
                //            throw transExcept;
                //        }
                //    }
                //})) ;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return referencia;
        }
    }
}
