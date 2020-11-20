using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SPSXRiskv2.Models.Database;
using SPSXRiskv2.Models.Entities;

/// <summary>
/// Descripción breve de SPSFabricaContext
/// </summary>
namespace SPSXRiskv2.Models
{
    //public class XRSKDataContext : DbContext
    public class XRSKDataContext : IdentityDbContext<XRSKUser>
    {
        static XRSKDataContext()
        {
            //Database.SetInitializer<XRSKDataContext>(null);
        }
        //public XRSKDataContext() : base("XRisk")
        public XRSKDataContext()
        {
        }

        public virtual DbSet<Agrupacion> Agrupacion { get; set; }
        public virtual DbSet<CBVigentes> CBancariasVigentes { get; set; }
        public virtual DbSet<XPTMEscenario> XptmEscenario { get; set; }
        public virtual DbSet<XPTMEscenarioDetalle> XptmEscenarioDetalle { get; set; }
        public virtual DbSet<XPTMTipintd> XptmTipintd { get; set; }
        public virtual DbSet<AgrCondiciones> context_AgrCondiciones { get; set; }
        public virtual DbSet<Operacion> Operacion { get; set; }
        public virtual DbSet<Entidades> context_entidades { get; set; }
        public virtual DbSet<XPTMCalendario> XptmCalendario { get; set; }
        public virtual DbSet<CondicionesBancarias> CondicionesBancarias { get; set; }
        public virtual DbSet<Companyia> context_companyia { get; set; }
        public virtual DbSet<Contrapartidas> context_contrapartidas { get; set; }
        public virtual DbSet<ContratosSaldos> ContratosSaldos { get; set; }
        public virtual DbSet<ApunteBancario> ApunteBancario { get; set; }
        public virtual DbSet<MovimientoFisico> MovimientoFisico { get; set; }
        public virtual DbSet<MovFisicoExamples> MovFisicoExamples { get; set; }
        public virtual DbSet<MVFSimplificado> MVFSimplificado { get; set; }
        public virtual DbSet<Contratos> Contratos { get; set; }
        public virtual DbSet<CNCSituacion> CNCSituacion { get; set; }
        public virtual DbSet<FocUsuarios> FocUsuarios { get; set; }
        public virtual DbSet<FocUsuariosGrupos> FocUsuariosGrupos { get; set; }
        public virtual DbSet<SecurityObject> SecurityObject { get; set; }
        public virtual DbSet<ZPOSOperExcControl> ZPOSOperExcControl { get; set; }
        public virtual DbSet<BasesDatosGrupo> BasesDatosGrupo { get; set; }
        public virtual DbSet<Certezas> Certezas { get; set; }
        public virtual DbSet<Divisas> Divisas { get; set; }
        public virtual DbSet<carteraEfectos> carteraEfectos { get; set; }
        public virtual DbSet<DesgloseContr> DesgloseContr { get; set; }
        public virtual DbSet<Efectos> Efectos { get; set; }
        public virtual DbSet<ApunBancCSB_PSD2> ApunBancCSB_PSD2 { get; set; }
        public virtual DbSet<fac_relacion_ABCPSD2_Movfisico> fac_relacion_ABCPSD2_Movfisico { get; set; }
        public virtual DbSet<fac_clientes> fac_clientes { get; set; }
        public virtual DbSet<vw_fac_AsignarFacturaHeader> vw_fac_AsignarFacturaHeader { get; set; }
        public virtual DbSet<ConComun> ConComunCSB { get; set; }
        public virtual DbSet<Numerador> Numerador { get; set; }
        public virtual DbSet<Contratos_Renovacion> Contratos_Renovacion { get; set; }
        public virtual DbSet<exch_bancos_cuentapoliza> exch_bancos_cuentapoliza { get; set; }
        public virtual DbSet<ClavesPrevisiones> ClavesPrevisiones { get; set; }
        public virtual DbSet<GrupoCompanya> GrupoCompanya { get; set; }
        public virtual DbSet<xptm_prestamos> xptm_prestamos { get; set; }
        public virtual DbSet<xptm_instrumento_cuadro> xptm_instrumento_cuadro { get; set; }
        public virtual DbSet<xptm_prestamos_mvtos> xptm_prestamos_mvtos { get; set; }
        public virtual DbSet<xptm_movimientos> xptm_movimientos { get; set; }

        public virtual DbSet<cfg_obj_cataleg_obj> obj_cataleg_obj { get; set; }
        public virtual DbSet<xptm_leasings> xptm_leasings { get; set; }

        #region Menús
        public virtual DbSet<cfg_menu_tipus> cfg_menu_tipus { get; set; }
        public virtual DbSet<cfg_menu_grups> cfg_menu_grups { get; set; }
        public virtual DbSet<cfg_menu_objectes> cfg_menu_objectes { get; set; }
        public virtual DbSet<cfg_obj_cataleg_obj> cfg_obj_cataleg_obj { get; set; }
        public virtual DbSet<cfg_dl_etiquetas> cfg_dl_etiquetas { get; set; }
        public virtual DbSet<vw_cfg_menu_usuari> vw_cfg_menu_usuari { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Llamada al OnModelCreating de la base (IdentityDbContext)
            base.OnModelCreating(modelBuilder);

            // Los índices compuestos no se pueden hacer directamente en las clases.
            modelBuilder.Entity<Agrupacion>().HasKey(e => new { e.ACPGrupo, e.ACPNiv, e.ACPCod });

            modelBuilder.Entity<CNCSituacion>(cnc =>
            {
                cnc.HasNoKey();
                cnc.ToView("CNCSituacion");
                cnc.Property(v => v.CNCBancoNOImporte).HasColumnName("CNCBancoNOImporte");
                cnc.Property(v => v.CNCBancoNONum).HasColumnName("CNCBancoNONum");
                cnc.Property(v => v.CNCCodCIA).HasColumnName("CNCcodcia");
                cnc.Property(v => v.CNCCodCTA).HasColumnName("CNCCodCTA");
                cnc.Property(v => v.CNCGrupo).HasColumnName("CNCGrupo");
                cnc.Property(v => v.CNCValorOrganizativo).HasColumnName("CNCValorOrganizativo");
                cnc.Property(v => v.CNCXRContImporte).HasColumnName("CNCXRContImporte");
                cnc.Property(v => v.CNCXRContNum).HasColumnName("CNCXRContNum");
                cnc.Property(v => v.CNCXRProvImporte).HasColumnName("CNCXRProvImporte");
                cnc.Property(v => v.CNCXRProvNum).HasColumnName("CNCXRProvNum");
                cnc.Property(v => v.signo).HasColumnName("signo");
            });

            modelBuilder.Entity<FocUsuarios>(fu =>
            {
                fu.HasNoKey();
                fu.ToView("foc_usuarios");
                fu.Property(v => v.cabid).HasColumnName("cabid");
                fu.Property(v => v.usuari).HasColumnName("usuari");
                fu.Property(v => v.usuariZoom).HasColumnName("usuariZoom");
                fu.Property(v => v.paswrd).HasColumnName("paswrd");
                fu.Property(v => v.nombre).HasColumnName("nombre");
                fu.Property(v => v.idioma).HasColumnName("idioma");
                fu.Property(v => v.activo).HasColumnName("activo");
            });
            modelBuilder.Entity<carteraEfectos>(ce =>
            {
                ce.HasNoKey();
                ce.ToView("fac_resumencartera");
                ce.Property(v => v.codigocliente).HasColumnName("codigocliente");
                ce.Property(v => v.nombrecliente).HasColumnName("nombrecliente");
                ce.Property(v => v.Num).HasColumnName("Num");
                ce.Property(v => v.importe).HasColumnName("importe");

            });

            modelBuilder.Entity<FocUsuariosGrupos>(fug =>
            {
                fug.HasNoKey();
                fug.ToView("foc_usuariosgrupos");
                fug.Property(v => v.cabid).HasColumnName("cabid");
                fug.Property(v => v.usuari).HasColumnName("usuari");
                fug.Property(v => v.grup).HasColumnName("grup");
            });

            modelBuilder.Entity<BasesDatosGrupo>(bdg =>
            {
                bdg.HasNoKey();
                bdg.ToView("foc_basesdatosgrupo");
                bdg.Property(v => v.linid).HasColumnName("linid");
                bdg.Property(v => v.grup).HasColumnName("grup");
                bdg.Property(v => v.nombd).HasColumnName("nombd");
                bdg.Property(v => v.perfmenu).HasColumnName("perfmenu");
                bdg.Property(v => v.perfsql).HasColumnName("perfsql");
                bdg.Property(v => v.perfseg).HasColumnName("perfseg");
            });

            modelBuilder.Entity<CBVigentes>(eb =>
            {
                 eb.HasNoKey();
                 eb.ToView("CondBancarias_Vigentes");
                 eb.Property(v => v.CONCodACO).HasColumnName("CONCodACO");
                 eb.Property(v => v.CONFechaDesde).HasColumnName("CONFechaDesde");
                 eb.Property(v => v.CONFechaHasta).HasColumnName("CONFechaDesde");
                 eb.Property(v => v.CONCodCIA).HasColumnName("CONCodCIA");
                 eb.Property(v => v.CONCodENT).HasColumnName("CONCodENT");
                 eb.Property(v => v.CONCodCTA).HasColumnName("CONCodCTA");
                 eb.Property(v => v.CONCodOPE).HasColumnName("CONCodOPE");
                 eb.Property(v => v.CONIdCPT).HasColumnName("CONIdCPT");
            });

            modelBuilder.Entity<XPTMEscenarioDetalle>().HasKey(e => new { e.linid });
            modelBuilder.Entity<AgrCondiciones>().HasKey(e => new { e.ACOCod, e.ACOTipo });
            modelBuilder.Entity<Operacion>().HasKey(op => new { op.OPEGrupo, op.OPENiv, op.OPECod, op.OPENivTLI, op.OPECodTLI });
            modelBuilder.Entity<Entidades>().HasKey(ent => new { ent.ENTCod });
            modelBuilder.Entity<Companyia>().HasKey(cia => new { cia.CIACod });
            modelBuilder.Entity<Contrapartidas>().HasKey(cpt => new { cpt.CPTGrupo, cpt.CPTCod, cpt.CPTDescripcion });
            modelBuilder.Entity<ContratosSaldos>().HasKey(cs => new { cs.CTATipoFecha, cs.CTACodCIA, cs.CTACod, cs.Fecha });
            modelBuilder.Entity<ApunteBancario>().HasKey(ab => new { ab.ABCCodCIA, ab.ABCNumerador });
            modelBuilder.Entity<MovimientoFisico>().HasKey(mf => new { mf.MVFCodCIA, mf.MVFValorOrganizativo, mf.MVFRefXRisk });
            modelBuilder.Entity<MovFisicoExamples>().HasKey(mf => new { mf.MVFCodCIA, mf.MVFRefXRisk });
            modelBuilder.Entity<MVFSimplificado>().HasKey(ms => new { ms.cabid });
            modelBuilder.Entity<Contratos>().HasKey(con => new { con.ctacod, con.ctacodcia });
            modelBuilder.Entity<SecurityObject>().HasKey(so => new { so.codigo });
            modelBuilder.Entity<ZPOSOperExcControl>().HasKey(oec => new { oec.OXPCod });
            modelBuilder.Entity<Certezas>().HasKey(grado => new { grado.grado });
            modelBuilder.Entity<Divisas>().HasKey(d => new { d.DIVNiv, d.DIVCod });
            modelBuilder.Entity<DesgloseContr>().HasKey(dc => new { dc.DCPCodCIA, dc.DCPValorOrganizativo, dc.DCPRefXrisk, dc.DCPContador });
            modelBuilder.Entity<Efectos>().HasKey(ef => new { ef.id });
            modelBuilder.Entity<ApunBancCSB_PSD2>().HasKey(ap => new { ap.ABCNumerador, ap.ABCCodCIA});
            modelBuilder.Entity<fac_relacion_ABCPSD2_Movfisico>().HasKey(fr => new { fr.cabid});
            modelBuilder.Entity<fac_clientes>().HasKey(fc => new { fc.Codigo});
            modelBuilder.Entity<ConComun>().HasKey(cc => new { cc.CCCCod, cc.CCCNiv });
            modelBuilder.Entity<Numerador>().HasKey(num => new { num.NUMGrupo, num.NUMNiv });
            modelBuilder.Entity<Contratos_Renovacion>().HasKey(cr => new { cr.CTACod, cr.CTACodCIA, cr.CTAFechIniPer });
            modelBuilder.Entity<exch_bancos_cuentapoliza>().HasKey(ecb => new { ecb.cabid });
            modelBuilder.Entity<ClavesPrevisiones>().HasKey(cp => new {cp.PRVGrupoTes, cp.PRVClave });
            modelBuilder.Entity<GrupoCompanya>().HasKey(gc => new { gc.GRCCodGRT, gc.GRCCodCIA });
            modelBuilder.Entity<xptm_prestamos>().HasKey(pr => new { pr.cabid });
            modelBuilder.Entity<xptm_instrumento_cuadro>().HasKey(ic => new { ic.linid });
            modelBuilder.Entity<xptm_prestamos_mvtos>().HasKey(pm => new { pm.cabid });
            modelBuilder.Entity<xptm_movimientos>().HasKey(mv => new { mv.serid });
            modelBuilder.Entity<cfg_obj_cataleg_obj>().HasKey(co => new { co.objecte });
            modelBuilder.Entity<xptm_leasings>().HasKey(le => new { le.cabid });

            #region Menús
            modelBuilder.Entity<cfg_menu_tipus>().HasKey(mt => new { mt.tipusmenu, mt.usuari });
            modelBuilder.Entity<cfg_menu_grups>().HasKey(mg => new { mg.grup, mg.usuari });
            modelBuilder.Entity<cfg_menu_objectes>().HasKey(mo => new { mo.usuari, mo.grup, mo.objecte});
            modelBuilder.Entity<cfg_obj_cataleg_obj>().HasKey(ob => new { ob.objecte });
            modelBuilder.Entity<cfg_dl_etiquetas>().HasKey(et => new { et.etiqueta, et.idioma });
            modelBuilder.Entity<vw_cfg_menu_usuari>(mu =>
            {
                mu.HasNoKey();
                mu.ToView("vw_cfg_menu_usuari");
                mu.Property(v => v.usuari).HasColumnName("usuari");
                mu.Property(v => v.tipusmenu).HasColumnName("tipusmenu");
                mu.Property(v => v.ordreNivell1).HasColumnName("ordreNivell1");
                mu.Property(v => v.descripcioNivell1).HasColumnName("descripcioNivell1");
                mu.Property(v => v.idioma).HasColumnName("idioma");
                mu.Property(v => v.grup).HasColumnName("grup");
                mu.Property(v => v.ordreNivell2).HasColumnName("ordreNivell2");
                mu.Property(v => v.descripcioNivell2).HasColumnName("descripcioNivell2");
                mu.Property(v => v.objecte).HasColumnName("objecte");
                mu.Property(v => v.ordreNivell3).HasColumnName("ordreNivell3");
                mu.Property(v => v.tipusObjecte).HasColumnName("tipusObjecte");
                mu.Property(v => v.url).HasColumnName("url");
                mu.Property(v => v.seguretat).HasColumnName("seguretat");
                mu.Property(v => v.categoria).HasColumnName("categoria");
                mu.Property(v => v.idioma).HasColumnName("idioma");
                mu.Property(v => v.titolObjecte).HasColumnName("titolObjecte");
                mu.Property(v => v.descripcioObjecte).HasColumnName("descripcioObjecte");
            });
            #endregion

            modelBuilder.Entity<vw_fac_AsignarFacturaHeader>(af =>                                                               
            {
                af.HasNoKey();
                af.ToView("vw_fac_AsignarFacturaHeader");
                af.Property(v => v.ABCCodCIA).HasColumnName("ABCCodCIA");
                af.Property(v => v.ABCCodCTA).HasColumnName("ABCCodCTA");
                af.Property(v => v.CodDiv).HasColumnName("CodDiv");
                af.Property(v => v.ABCImporteSigno).HasColumnName("ABCImporteSigno");
                af.Property(v => v.ABCFechOper).HasColumnName("ABCFechOper");
                af.Property(v => v.ABCFechVal).HasColumnName("ABCFechVal");
                af.Property(v => v.ABCNumerador).HasColumnName("ABCNumerador");
                af.Property(v => v.MVFrefXrisk).HasColumnName("MVFrefXrisk");
                af.Property(v => v.Codigo).HasColumnName("Codigo");
                af.Property(v => v.Descripcion).HasColumnName("Descripcion");
                af.Property(v => v.ABCComple).HasColumnName("ABCComple");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(XRSKCredenciales.ConnectionString, options => options.EnableRetryOnFailure());
            optionsBuilder.UseSqlServer(XRSKCredenciales.ConnectionString);
        }
    }
}
