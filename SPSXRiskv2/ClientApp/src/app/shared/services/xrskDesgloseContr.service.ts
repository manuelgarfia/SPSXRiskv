/// <summary>
/// Code generated 14/09/2020 9:34:15 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKDesgloseContr, XRSKDesglose } from 'src/app/shared/models/xrskDesgloseContr.model';
import { XRSKMovimientoFisico } from 'src/app/shared/models/xrskMovimientoFisico.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKDesgloseContrService {
  myAppUrl: string;
  myApiUrl: string;

  public desgloseRow: XRSKDesglose = new XRSKDesglose();
  public movimiento: XRSKMovimientoFisico = new XRSKMovimientoFisico();

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskDesgloseContr";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKDesgloseContrService");
    return throwError(error.error);
  }

  getXRSKDesgloseContrList(): Observable<XRSKDesgloseContr[]> {
    return this.http.get<XRSKDesgloseContr[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKDesgloseList(company: string, referencia: number): Observable<XRSKDesgloseContr[]> {
    return this.http.get<XRSKDesgloseContr[]>(this.myAppUrl + this.myApiUrl + '/desglose/' + company.toString() + '/' + referencia.toString())
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKDesgloseContrFilter(filter: FilterHeader): Observable<XRSKDesgloseContr[]> {
    return this.http.post<XRSKDesgloseContr[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKDesgloseContr(DCPCodCIA: string, DCPValorOrganizativo: string, DCPRefXrisk: number, DCPContador: number): Observable<XRSKDesgloseContr> {
    return this.http.get<XRSKDesgloseContr>(this.myAppUrl + this.myApiUrl + "/key?DCPCodCIA=" + DCPCodCIA + "&DCPValorOrganizativo=" + DCPValorOrganizativo + "&DCPRefXrisk=" + DCPRefXrisk + "&DCPContador=" + DCPContador)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKDesgloseContr> {
    return this.http.post<XRSKDesgloseContr>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  delete(movimiento): Observable<XRSKDesgloseContr> {
    return this.http.post<XRSKDesgloseContr>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }


  desgloseFromMovFisico(item, movimiento) {
    this.desgloseRow = item as XRSKDesglose;
    this.movimiento = movimiento;
    return this.desgloseRow;
  }

  desgloseFromService() {
    return this.desgloseRow;
  }

  movimientoFromService() {
    return this.movimiento;
  }
}
