import { CommonModule } from '@angular/common';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { MatNativeDateModule } from '@angular/material/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AppSharedModule } from 'src/app/shared/shared.module';
import { AppLearningRoutingModule } from './learning-routing.module';
import { MaterialModule } from '../../material.module';

import { XRSKAgrupacionComponent } from './xrskagrupacion/xrskagrupacion.component';
import { XRSKAgrupacionService } from 'src/app/shared/services/xrskagrupacion.service';
import { JesusComponent } from './jesus/jesus.component';
import { JesusNavegaComponent } from './jesus-navega/jesus-navega.component';
import { GeorginaComponent } from './georgina/georgina.component';
import { GformsComponent } from './gforms/gforms.component';
import { LearningHomeComponent } from './learning-home/learning-home.component'

import { XRSKCBVService } from 'src/app/shared/services/georgina.service';
import { XRSKAgrCondicionesService } from 'src/app/shared/services/AgrCondiciones.service'
import { XRSKOperacionService } from 'src/app/shared/services/operacion.service';
import { XRSKMovimientoFisicoService } from 'src/app/shared/services/xrskMovimientoFisico.service';
import { XRSKMvfSimplificadoService } from 'src/app/shared/services/xrskMvfSimplificado.service';
import { ExcelService } from 'src/app/core/services/excel.service';

import { XRSKCalendarioComponent } from './xrskcalendario/xrskcalendario.component';
import { XRSKXptmCalendarioService } from 'src/app/shared/services/xrskXptmCalendario.service';
import { TipoInteresComponent } from './tipo-interes/tipo-interes.component';
import { XRSKMovimientoFisicoComponent } from './xrsk-movimiento-fisico/xrsk-movimiento-fisico.component';
import { XRSKMVFSimplificadoComponent } from './xrskmvfsimplificado/xrskmvfsimplificado.component';
import { CNCSituacionComponent } from './cncsituacion/cncsituacion.component';
import { GraphicComponent } from './graphic/graphic.component';
import { UsersComponent } from './users/users.component';
import { UsersGroupsComponent } from './users-groups/users-groups.component';
import { SecurityObjectComponent } from './security-object/security-object.component';
import { ConcilManualComponent } from './concil-manual/concil-manual.component';
import { CardsComponent } from './cards/cards.component';
import { ApuntesBancariosComponent } from './apuntes-bancarios/apuntes-bancarios.component';
import { XrskCarteraEfectosComponent } from './xrsk-cartera-efectos/xrsk-cartera-efectos.component';
import { XriskDesgloseComponent } from './xrisk-desglose/xrisk-desglose.component';
import { AsignarFacturaComponent } from './asignar-factura/asignar-factura.component';
import { ReportingComponent } from './reporting/reporting.component';
import { SituacionComponent } from './situacion/situacion.component';
import { CuentasCreditoComponent } from './cuentas-credito/cuentas-credito.component';
//import { Error404Component } from 'src/app/core/components/error404/error404.component';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    MaterialModule,
    MatNativeDateModule,
    HttpClientModule,
    FormsModule,
    AppSharedModule,
    AppLearningRoutingModule,
    MDBBootstrapModule.forRoot()
  ],
  declarations: [
    XRSKAgrupacionComponent,
    JesusComponent,
    GeorginaComponent,
    GformsComponent,
    LearningHomeComponent,
    XRSKCalendarioComponent,
    JesusNavegaComponent,
    TipoInteresComponent,
    XRSKMovimientoFisicoComponent,
    XRSKMVFSimplificadoComponent,
    CNCSituacionComponent,
    GraphicComponent,
    UsersComponent,
    UsersGroupsComponent,
    SecurityObjectComponent,
    ConcilManualComponent,
    CardsComponent,
    ApuntesBancariosComponent,
    AsignarFacturaComponent,
    XrskCarteraEfectosComponent,
    ApuntesBancariosComponent,
    XriskDesgloseComponent,
    ReportingComponent,
    SituacionComponent,
    CuentasCreditoComponent
  ],
  exports: [
    CommonModule,
    AppLearningRoutingModule,
    XRSKAgrupacionComponent,
    GformsComponent,
    XRSKCalendarioComponent
  ],
  providers: [
    XRSKAgrupacionService,
    XRSKCBVService,
    XRSKAgrCondicionesService,
    XRSKOperacionService,
    XRSKXptmCalendarioService,
    XRSKMovimientoFisicoService,
    XRSKMvfSimplificadoService,
    ExcelService
  ]
})

export class AppLearningModule { }
