/// <summary>
/// Code generated 14/09/2020 13:21:34 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKvw_fac_AsignarFacturaHeader } from 'src/app/shared/models/xrskvw_fac_AsignarFacturaHeader.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKvw_fac_AsignarFacturaHeaderService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskvw_fac_AsignarFacturaHeader";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKvw_fac_AsignarFacturaHeaderService");
    return throwError(error.error);
  }

  getXRSKvw_fac_AsignarFacturaHeaderList(): Observable<XRSKvw_fac_AsignarFacturaHeader[]> {
    return this.http.get<XRSKvw_fac_AsignarFacturaHeader[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKvw_fac_AsignarFacturaHeaderFilter(filter: FilterHeader): Observable<XRSKvw_fac_AsignarFacturaHeader[]> {
    return this.http.post<XRSKvw_fac_AsignarFacturaHeader[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKvw_fac_AsignarFacturaHeader(ABCNumerador: number): Observable<XRSKvw_fac_AsignarFacturaHeader> {
    return this.http.get<XRSKvw_fac_AsignarFacturaHeader>(this.myAppUrl + this.myApiUrl + "/key?ABCNumerador=" + ABCNumerador)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKvw_fac_AsignarFacturaHeader> {
    return this.http.post<XRSKvw_fac_AsignarFacturaHeader>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  delete(movimiento): Observable<XRSKvw_fac_AsignarFacturaHeader> {
    return this.http.post<XRSKvw_fac_AsignarFacturaHeader>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
}
