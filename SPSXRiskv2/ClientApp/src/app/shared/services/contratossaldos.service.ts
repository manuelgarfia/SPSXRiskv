import { Injectable, Inject, OnInit, HostListener, ViewChild, ChangeDetectorRef, ElementRef } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { xrskcontratossaldos } from '../models/xrskcontratossaldos.model';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';
import { filtermodel, FilterHeader } from '../models/filtermodel';

@Injectable({
  providedIn: 'root'
})

export class contratossaldosservice {
  //Declaración de Variables
   myAppUrl: string;
   myApiUrl: string;
 

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/XRSKContratosSaldos";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Conectado Con ContratosSaldos");
    return throwError(error.error);
  }

  



  getXRSKContratosSaldosListNewFilterDateRange(filter: FilterHeader): Observable<xrskcontratossaldos[]> {
    return this.http.post<xrskcontratossaldos[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
  getXRSKContratosSaldosRangedList(filter: FilterHeader): Observable<xrskcontratossaldos[]> {
    return this.http.post<xrskcontratossaldos[]>(this.myAppUrl + this.myApiUrl + "/filter_Bar_Chart", JSON.stringify(filter), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  getXRSKContratosByCompany(company: string, contrato: string): Observable<xrskcontratossaldos[]> {
    return this.http.get<xrskcontratossaldos[]>(this.myAppUrl + this.myApiUrl + "/contratos/" + company.toString() + '/' + contrato.toString())
      .pipe(
        catchError(this.handleError)
      );
  }


  getXRSKContratosByCompanyDateRange(company: string, contrato: string, dateDesde: Date, dateHasta: Date): Observable<xrskcontratossaldos[]> {
    return this.http.get<xrskcontratossaldos[]>(this.myAppUrl + this.myApiUrl + "/saldos/" + company.toString() + '/' + contrato.toString() + '/' + dateDesde.toDateString() + '/' + dateHasta.toDateString())
      .pipe(
        catchError(this.handleError)
      );
  }

}
