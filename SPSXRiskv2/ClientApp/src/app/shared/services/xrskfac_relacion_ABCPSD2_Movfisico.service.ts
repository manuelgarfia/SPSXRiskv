/// <summary>
/// Code generated 14/09/2020 11:54:07 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKfac_relacion_ABCPSD2_Movfisico } from 'src/app/shared/models/xrskfac_relacion_ABCPSD2_Movfisico.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKfac_relacion_ABCPSD2_MovfisicoService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskfac_relacion_ABCPSD2_Movfisico";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKfac_relacion_ABCPSD2_MovfisicoService");
    return throwError(error.error);
  }

  getXRSKfac_relacion_ABCPSD2_MovfisicoList(): Observable<XRSKfac_relacion_ABCPSD2_Movfisico[]> {
    return this.http.get<XRSKfac_relacion_ABCPSD2_Movfisico[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKfac_relacion_ABCPSD2_MovfisicoFilter(filter: FilterHeader): Observable<XRSKfac_relacion_ABCPSD2_Movfisico[]> {
    return this.http.post<XRSKfac_relacion_ABCPSD2_Movfisico[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKfac_relacion_ABCPSD2_Movfisico(cabid: number): Observable<XRSKfac_relacion_ABCPSD2_Movfisico> {
    return this.http.get<XRSKfac_relacion_ABCPSD2_Movfisico>(this.myAppUrl + this.myApiUrl + "/key?cabid=" + cabid)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKfac_relacion_ABCPSD2_Movfisico> {
    return this.http.post<XRSKfac_relacion_ABCPSD2_Movfisico>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  delete(movimiento): Observable<XRSKfac_relacion_ABCPSD2_Movfisico> {
    return this.http.post<XRSKfac_relacion_ABCPSD2_Movfisico>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
}
