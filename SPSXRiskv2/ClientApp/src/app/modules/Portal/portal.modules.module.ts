import { CommonModule } from '@angular/common';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { MatNativeDateModule } from '@angular/material/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AppSharedModule } from 'src/app/shared/shared.module';
import { AppPortalRoutingModule } from './portal-routing.module';
import { MaterialModule } from '../../material.module';

import { XRSKAgrupacionService } from 'src/app/shared/services/xrskagrupacion.service';
import { XRSKCBVService } from 'src/app/shared/services/georgina.service';
import { XRSKAgrCondicionesService } from 'src/app/shared/services/AgrCondiciones.service'
import { XRSKOperacionService } from 'src/app/shared/services/operacion.service';
import { XRSKMovimientoFisicoService } from 'src/app/shared/services/xrskMovimientoFisico.service';
import { XRSKMvfSimplificadoService } from 'src/app/shared/services/xrskMvfSimplificado.service';
import { XRSKUtilsService } from 'src/app/shared/services/xrskUtils.service';
import { ExcelService } from 'src/app/core/services/excel.service';

import { XrskPrestamosComponent} from 'src/app/modules/Portal/xrskPrestamos/xrskPrestamos.component'


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
    AppPortalRoutingModule,
    MDBBootstrapModule.forRoot()
  ],
  declarations: [
    XrskPrestamosComponent
  ],
  exports: [
    CommonModule,
    AppPortalRoutingModule,
  ],
  providers: [
    XRSKAgrupacionService,
    XRSKCBVService,
    XRSKAgrCondicionesService,
    XRSKOperacionService,
    XRSKMovimientoFisicoService,
    XRSKMvfSimplificadoService,
    XRSKUtilsService,
    ExcelService
  ]
})

export class AppPortalModule { }
