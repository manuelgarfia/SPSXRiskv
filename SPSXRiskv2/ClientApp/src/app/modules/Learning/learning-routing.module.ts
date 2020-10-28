import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'src/app/core/modules/authorization/auth.guard';

import { AsignarFacturaComponent } from './asignar-factura/asignar-factura.component';
import { CNCSituacionComponent } from './cncsituacion/cncsituacion.component';
import { ConcilManualComponent } from './concil-manual/concil-manual.component';
import { GeorginaComponent } from './georgina/georgina.component';
import { GformsComponent } from './gforms/gforms.component';
import { GraphicComponent } from './graphic/graphic.component';
import { JesusComponent } from './jesus/jesus.component';
import { JesusNavegaComponent } from './jesus-navega/jesus-navega.component';
import { LearningHomeComponent } from './learning-home/learning-home.component'
import { TipoInteresComponent } from './tipo-interes/tipo-interes.component';
import { UsersComponent } from './users/users.component'
import { UsersGroupsComponent } from './users-groups/users-groups.component';
import { SecurityObjectComponent } from './security-object/security-object.component'
import { XRSKAgrupacionComponent } from './xrskagrupacion/xrskagrupacion.component';
import { XRSKCalendarioComponent } from './xrskcalendario/xrskcalendario.component';
import { XRSKMVFSimplificadoComponent } from './xrskmvfsimplificado/xrskmvfsimplificado.component';
import { XRSKMovimientoFisicoComponent } from './xrsk-movimiento-fisico/xrsk-movimiento-fisico.component';
import { Error404Component } from 'src/app/core/components/error404/error404.component';
import { CardsComponent } from './cards/cards.component'

import { ApuntesBancariosComponent } from './apuntes-bancarios/apuntes-bancarios.component';
import { XrskCarteraEfectosComponent } from './xrsk-cartera-efectos/xrsk-cartera-efectos.component';
import { XriskDesgloseComponent } from './xrisk-desglose/xrisk-desglose.component';
import { ReportingComponent } from './reporting/reporting.component';
import { SituacionComponent } from './situacion/situacion.component';
import { CuentasCreditoComponent } from './cuentas-credito/cuentas-credito.component';


const routes: Routes = [
  { path: 'asignar-factura/:ABCNumerador', component: AsignarFacturaComponent },
  { path: 'cncsituacion', component: CNCSituacionComponent },
  { path: 'certificar/:codCIA/:codCTA', component: ConcilManualComponent },
  { path: 'conciliar/:codCIA/:codCTA', component: ConcilManualComponent },
  { path: 'georgina', component: GeorginaComponent, canActivate: [AuthGuard] },
  { path: 'gforms', component: GformsComponent },
  { path: 'gforms/:param_edit', component: GformsComponent },
  { path: 'graphic', component: GraphicComponent },
  { path: 'jesus', component: JesusComponent },
  { path: 'jesus-navega', component: JesusNavegaComponent },
  { path: 'learning-home', component: LearningHomeComponent },
  { path: 'tipoint', component: TipoInteresComponent },
  { path: 'tipoint/:tipusInteresCode', component: TipoInteresComponent },
  { path: 'users', component: UsersComponent },
  { path: 'usersGroups', component: UsersGroupsComponent },
  { path: 'xrskagrupacion', component: XRSKAgrupacionComponent, canActivate: [AuthGuard] },
  { path: 'xrskcalendario', component: XRSKCalendarioComponent },
  { path: 'xrskmovimientofisico', component: XRSKMovimientoFisicoComponent },
  { path: 'xrskmovimientofisico/:editMode/:mvfRefXrisk/:mvfCodCIA', component: XRSKMovimientoFisicoComponent },
  { path: 'xrskmvfsimplificado', component: XRSKMVFSimplificadoComponent },
  { path: 'usersGroups', component: UsersGroupsComponent },
  { path: 'securityObjects', component: SecurityObjectComponent },
  { path: 'ActivitySummary', component: CardsComponent },
  { path: 'ApuntesBancarios', component: ApuntesBancariosComponent },
  { path: 'Error', component: Error404Component },
  { path: 'carteraEfectos', component: XrskCarteraEfectosComponent },
  { path: 'desglose', component: XriskDesgloseComponent },
  { path: 'reporting', component: ReportingComponent },
  { path: 'posicion', component: SituacionComponent },
  { path: 'polizas', component: CuentasCreditoComponent },
  { path: 'polizas/:company/:contrato', component: CuentasCreditoComponent },
];                                          

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppLearningRoutingModule { }
