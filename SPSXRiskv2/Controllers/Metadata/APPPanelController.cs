using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPSXRiskv2.Common.Metadata;


namespace SPSXRiskv2.Controllers.Metadata
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class APPPanelController: Controller
    {
        public APPPanelController()
        {
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<PanelItem>> Get()
        {
            PanelItem panel = new PanelItem();
            List<PanelItem> panelList = new List<PanelItem>();

            try
            {
                panelList = panel.getPaneles(User);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return panelList;
        }

    }
}
