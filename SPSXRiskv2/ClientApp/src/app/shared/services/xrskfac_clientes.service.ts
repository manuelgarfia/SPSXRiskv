/// <summary>
/// Code generated 14/09/2020 12:15:26 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKfac_clientes } from 'src/app/shared/models/xrskfac_clientes.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKfac_clientesService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskfac_clientes";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKfac_clientesService");
    return throwError(error.error);
  }

  getXRSKfac_clientesList(): Observable<XRSKfac_clientes[]> {
    return this.http.get<XRSKfac_clientes[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getfac_clientesList(cliente): Observable<XRSKfac_clientes[]> {
    return this.http.get<XRSKfac_clientes[]>(this.myAppUrl + this.myApiUrl + "/facturas/"+ cliente.toString())
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKfac_clientesFilter(filter: FilterHeader): Observable<XRSKfac_clientes[]> {
    return this.http.post<XRSKfac_clientes[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKfac_clientes(Codigo: string): Observable<XRSKfac_clientes> {
    return this.http.get<XRSKfac_clientes>(this.myAppUrl + this.myApiUrl + "/key?Codigo="+Codigo)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKfac_clientes> {
    return this.http.post<XRSKfac_clientes>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
  
  //Delete register
  delete(movimiento): Observable<XRSKfac_clientes> {
    return this.http.post<XRSKfac_clientes>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }  
}
