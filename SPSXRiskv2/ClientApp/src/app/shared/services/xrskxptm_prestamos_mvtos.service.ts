/// <summary>
/// Code generated 16/10/2020 10:06:55 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKxptm_prestamos_mvtos } from 'src/app/shared/models/xrskxptm_prestamos_mvtos.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKxptm_prestamos_mvtosService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskxptm_prestamos_mvtos";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKxptm_prestamos_mvtosService");
    return throwError(error.error);
  }

  getXRSKxptm_prestamos_mvtosList(): Observable<XRSKxptm_prestamos_mvtos[]> {
    return this.http.get<XRSKxptm_prestamos_mvtos[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKxptm_prestamos_mvtosFilter(filter: FilterHeader): Observable<XRSKxptm_prestamos_mvtos[]> {
    return this.http.post<XRSKxptm_prestamos_mvtos[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKxptm_prestamos_mvtos(cabid: number): Observable<XRSKxptm_prestamos_mvtos> {
    return this.http.get<XRSKxptm_prestamos_mvtos>(this.myAppUrl + this.myApiUrl + "/key?cabid=" + cabid)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKxptm_prestamos_mvtos> {
    return this.http.post<XRSKxptm_prestamos_mvtos>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  delete(movimiento): Observable<XRSKxptm_prestamos_mvtos> {
    return this.http.post<XRSKxptm_prestamos_mvtos>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
}
