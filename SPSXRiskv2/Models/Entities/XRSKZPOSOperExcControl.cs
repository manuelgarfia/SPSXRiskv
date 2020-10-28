using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.ViewModels;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKZPOSOperExcControl : XRSKEntity
    {
        #region Propiedades
        [JsonProperty("OPXCod")]
        public string OXPCod { get; set; }
        #endregion

        #region Constructores
        public XRSKZPOSOperExcControl()
        {

        }

        public XRSKZPOSOperExcControl(ZPOSOperExcControl item)
        {
            TOXRSKZPOSOperExcControl(item);
        }

        public XRSKZPOSOperExcControl(ZPOSOperExcControl item, XRSKDataContext db)
        {
            TOXRSKZPOSOperExcControl(item, db);
        }
        #endregion

        #region Funciones
        /// <summary>
        /// Gets the list of ZPOSOperExcControl elements
        /// </summary>
        /// <returns></returns>
        public List<XRSKZPOSOperExcControl> GetList()
        {
            List<XRSKZPOSOperExcControl> cncs = new List<XRSKZPOSOperExcControl>();
            XRSKDataContext db = new XRSKDataContext();

            List<ZPOSOperExcControl> items = db.ZPOSOperExcControl.ToList();

            foreach (ZPOSOperExcControl item in items)
            {
                cncs.Add(new XRSKZPOSOperExcControl(item));
            }

            return cncs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemsSelected"></param>
        /// <returns></returns>
        public List<XRSKZPOSOperExcControl> GetFilteredList(FilterModel filter)
        {
            XRSKDataContext db = new XRSKDataContext();

            var query = from x in
                        db.ZPOSOperExcControl
                        select x;

            List<ZPOSOperExcControl> items = query.ToList();

            return TOXRSKZPOSOperExcControl(items);
        }
        #endregion

        #region Support methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void TOXRSKZPOSOperExcControl(ZPOSOperExcControl item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKZPOSOperExcControl(item, db);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="db"></param>
        private void TOXRSKZPOSOperExcControl(ZPOSOperExcControl item, XRSKDataContext db)
        {
            OXPCod = item.OXPCod;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name=XRSKConstantes.FILTER_TYPE_ITEMS></param>
        /// <returns></returns>
        private List<XRSKZPOSOperExcControl> TOXRSKZPOSOperExcControl(List<ZPOSOperExcControl> items)
        {
            List<XRSKZPOSOperExcControl> cncList = new List<XRSKZPOSOperExcControl>();
            foreach (ZPOSOperExcControl item in items)
            {
                cncList.Add(new XRSKZPOSOperExcControl(item));
            }

            return cncList;
        }
        #endregion
    }
}
