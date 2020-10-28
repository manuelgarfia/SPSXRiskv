using SPSXRiskv2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPSXRiskv2.Models.Entities
{
    public class XRSKClavesPrevisiones: XRSKEntity
    {


        #region Propiedades
        public string GRCGrupo { get; set; }

        public string GRCNiv { get; set; }
        public string GRCCodGRT { get; set; }
        public string GRCCodCIA { get; set; }
        public string PRVGrupoTes { get; set; }
        public string PRVClave { get; set; }
        public string PRVCodOPE { get; set; }
        public string PRVCodCPT { get; set; }
        public int PRVSigno { get; set; }
        public bool? PRVEnlaceERP { get; set; }
        public bool? PRVRemanente { get; set; }
        #endregion

        #region Construnctors
        public XRSKClavesPrevisiones()
        {

        }// Constructor sin parámetros
        public XRSKClavesPrevisiones(string _GRCGrupo, string _GRCNiv, string _GRCCodGRT, string _GRCCodCIA, 
                                     string _PRVGrupoTes, string _PRVClave, string _PRVCodOPE, string _PRVCodCPT, 
                                     int _PRVSigno,  bool? _PRVEnlaceERP, bool? _PRVRemanente)
        {
            GRCGrupo = _GRCGrupo;
            GRCNiv = _GRCNiv;
            GRCCodGRT = _GRCCodGRT;
            GRCCodCIA = _GRCCodCIA;
            PRVGrupoTes = _PRVGrupoTes;
            PRVClave = _PRVClave;
            PRVCodOPE = _PRVCodOPE;
            PRVCodCPT = _PRVCodCPT;
            PRVSigno = _PRVSigno;
            PRVEnlaceERP = _PRVEnlaceERP;
            PRVRemanente = _PRVRemanente;



        }

        public  XRSKClavesPrevisiones(XRSKClavesPrevisiones item)
        {
            TOXRSKClavesPrevisiones(item);


        }

        

        #endregion

        #region Private Methods



        private void TOXRSKClavesPrevisiones(XRSKClavesPrevisiones item)
        {
            XRSKDataContext db = new XRSKDataContext();
            TOXRSKClavesPrevisiones(item, db);
        }

        private void TOXRSKClavesPrevisiones(XRSKClavesPrevisiones item, XRSKDataContext db)
        {
            GRCGrupo = item.GRCGrupo;
            GRCNiv = item.GRCNiv;
            GRCCodGRT = item.GRCCodGRT;
            GRCCodCIA = item.GRCCodCIA;
            PRVGrupoTes = item.PRVGrupoTes;
            PRVClave = item.PRVClave;
            PRVCodOPE = item.PRVCodOPE;
            PRVCodCPT = item.PRVCodCPT;
            PRVSigno = item.PRVSigno;
            PRVEnlaceERP = item.PRVEnlaceERP;
            PRVRemanente = item.PRVRemanente;
        }
        #endregion 

        #region Public Methods
            public List<XRSKClavesPrevisiones> GetList(string cia)
        {
            List<XRSKClavesPrevisiones> items = new List<XRSKClavesPrevisiones>();
            XRSKDataContext db = new XRSKDataContext();
            var query = (from claves in db.ClavesPrevisiones
                         join grupo in db.GrupoCompanya
                         on claves.PRVGrupoTes equals grupo.GRCCodGRT
                         where grupo.GRCCodCIA.Contains(cia)
                         select new XRSKClavesPrevisiones
                         {
                             PRVClave = claves.PRVClave
                         }).ToList();
            //var query = from x in db.GrupoCompanya
            //            select new XRSKClavesPrevisiones {PRVClave= x.GRCCodCIA} ;
            //items = query.ToList();


            return query;

        }
        #endregion
    }
}
