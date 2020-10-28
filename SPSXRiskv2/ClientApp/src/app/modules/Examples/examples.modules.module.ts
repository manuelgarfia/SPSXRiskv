import { CommonModule } from '@angular/common';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { MatNativeDateModule } from '@angular/material/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { MaterialModule } from 'src/app/material.module';
import { AppExamplesRoutingModule } from './examples-routing.module';
import { WavesModule } from 'angular-bootstrap-md';
import { ChartsModule } from 'angular-bootstrap-md';


import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SearchTableComponent } from './search-table/search-table.component';
import { DatePickerComponent } from './date-picker/date-picker.component';
import { CounterComponent } from './counter/counter.component';
import { ProgressBarComponent } from './progress-bar/progress-bar.component';
import { ModalDialogComponent } from './modal-dialog/modal-dialog.component';
import { SnackBarComponent } from './snack-bar/snack-bar-component';
import { MovFisicoExamplesComponent } from './mov-fisico-examples/mov-fisico-examples.component';


@NgModule({
  imports: [
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    MaterialModule,
    MatNativeDateModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    AppExamplesRoutingModule,
    MDBBootstrapModule.forRoot(),
    WavesModule,
    ChartsModule,
  ],
  declarations: [
    SearchTableComponent,
    DatePickerComponent,
    FetchDataComponent,
    CounterComponent,
    ProgressBarComponent,
    SnackBarComponent,
    ModalDialogComponent,
    MovFisicoExamplesComponent,
   
  ],
  exports: [
    CommonModule,
    AppExamplesRoutingModule,
    CounterComponent,
    ModalDialogComponent,
  ]
})

export class AppExamplesModule { }
