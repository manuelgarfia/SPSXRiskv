import { NgModule, CUSTOM_ELEMENTS_SCHEMA, LOCALE_ID } from '@angular/core';
import { MatNativeDateModule, DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AppRoutingModule } from './app-routing.module';
import { MaterialModule } from './material.module';
import { AppModulesModule } from './modules/app.modules.module';
import { AppExamplesModule } from './modules/examples/examples.modules.module';
import { AppSharedModule } from './shared/shared.module';
import { AppCoreModule } from './core/core.module';

import { errorInterceptorProvider} from 'src/app/core/modules/authorization/error.interceptor';
import { jwtInterceptorProvider} from 'src/app/core/modules/authorization/jwt.interceptor';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { Error404Component } from './core/components/error404/error404.component';
import localeEs from '@angular/common/locales/es';
import { registerLocaleData } from '@angular/common';
import { APP_DATE_FORMATS, AppDateAdapter } from './shared/format/format-datepicker';
registerLocaleData(localeEs, 'es');

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    Error404Component
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    MatNativeDateModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    AppModulesModule,
    AppExamplesModule,
    AppSharedModule,
    AppCoreModule,
    AppRoutingModule,
    MDBBootstrapModule.forRoot()
  ],
  providers: [
    jwtInterceptorProvider,
    errorInterceptorProvider,
    { provide: LOCALE_ID, useValue: 'es' },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS },
    { provide: MAT_DATE_LOCALE, useValue: 'es' },
    { provide: DateAdapter, useClass: AppDateAdapter }
  ],
  bootstrap: [AppComponent],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class AppModule { }
