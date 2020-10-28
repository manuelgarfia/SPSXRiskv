import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material.module';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AppAuthorizationRoutingModule } from './authorization.routing.module';

import { LoginComponent } from './components/xrsklogin/xrsklogin.component';
import { RegisterComponent } from './components/xrskregister/xrskregister.component';
import { ErrorInterceptor, errorInterceptorProvider } from './error.interceptor';
import { JwtInterceptor, jwtInterceptorProvider } from './jwt.interceptor';
import { AppSharedModule } from 'src/app/shared/shared.module';


@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    AppAuthorizationRoutingModule,
    MDBBootstrapModule,
    AppSharedModule
  ],
  declarations: [
    LoginComponent,
    RegisterComponent
  ],
  providers: [
    jwtInterceptorProvider,
    errorInterceptorProvider
  ], exports: [
    LoginComponent,
    RegisterComponent
  ]

})
export class AppAuthorizationModule { }
