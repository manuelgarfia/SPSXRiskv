/// <summary>
/// Code generated 29/09/2020 13:11:41 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKexch_bancos_cuentapoliza } from 'src/app/shared/models/xrskexch_bancos_cuentapoliza.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKexch_bancos_cuentapolizaService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskexch_bancos_cuentapoliza";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKexch_bancos_cuentapolizaService");
    return throwError(error.error);
  }

  getXRSKexch_bancos_cuentapolizaList(): Observable<XRSKexch_bancos_cuentapoliza[]> {
    return this.http.get<XRSKexch_bancos_cuentapoliza[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKexch_bancos_polizas(company: string, contrato: string): Observable<XRSKexch_bancos_cuentapoliza> {
    return this.http.get<XRSKexch_bancos_cuentapoliza>(this.myAppUrl + this.myApiUrl + '/polizas/' + company.toString() + '/' + contrato.toString())
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKexch_bancos_cuentapolizaFilter(filter: FilterHeader): Observable<XRSKexch_bancos_cuentapoliza> {
    return this.http.post<XRSKexch_bancos_cuentapoliza>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKexch_bancos_cuentapoliza(cabid: number): Observable<XRSKexch_bancos_cuentapoliza> {
    return this.http.get<XRSKexch_bancos_cuentapoliza>(this.myAppUrl + this.myApiUrl + "/key?cabid=" + cabid)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKexch_bancos_cuentapoliza> {
    return this.http.post<XRSKexch_bancos_cuentapoliza>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  delete(movimiento): Observable<XRSKexch_bancos_cuentapoliza> {
    return this.http.post<XRSKexch_bancos_cuentapoliza>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
}
