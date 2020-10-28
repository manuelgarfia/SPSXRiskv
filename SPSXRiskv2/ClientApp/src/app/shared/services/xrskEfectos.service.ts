/// <summary>
/// Code generated 15/09/2020 10:54:28 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKEfectos } from 'src/app/shared/models/xrskEfectos.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';
import { xrskcarteraEfectos } from './xrskCarteraEfectos.service';
import { carteraefectos } from '../models/carteraefectos.model';

@Injectable({
  providedIn: 'root'
})

export class XRSKEfectosService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskEfectos";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKEfectosService");
    return throwError(error.error);
  }

  getXRSKEfectosList(): Observable<XRSKEfectos[]> {
    return this.http.get<XRSKEfectos[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKEfectosCienteList(cliente): Observable<XRSKEfectos[]> {
    return this.http.get<XRSKEfectos[]>(this.myAppUrl + this.myApiUrl + "/facturas/" + cliente.toString())
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKEfectosFilter(filter: FilterHeader): Observable<XRSKEfectos[]> {
    return this.http.post<XRSKEfectos[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKEfectos(id: number): Observable<XRSKEfectos> {
    return this.http.get<XRSKEfectos>(this.myAppUrl + this.myApiUrl + "/key?id=" + id)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKEfectosCliente(cliente: string): Observable<XRSKEfectos[]> {
    return this.http.get<XRSKEfectos[]>(this.myAppUrl + this.myApiUrl + "/cliente?id=" + cliente)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKEfectosMovimiento(movimiento: number): Observable<XRSKEfectos[]> {
    return this.http.get<XRSKEfectos[]>(this.myAppUrl + this.myApiUrl + "/movimiento?id=" + movimiento)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }
  getXRSKEfectosClienteResumen(): Observable<carteraefectos[]> {
    return this.http.get<carteraefectos[]>(this.myAppUrl + this.myApiUrl + "/ResumenCLientes")
      .pipe(
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKEfectos> {
    return this.http.post<XRSKEfectos>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  delete(movimiento): Observable<XRSKEfectos> {
    return this.http.post<XRSKEfectos>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
}
