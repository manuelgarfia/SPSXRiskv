/// <summary>
/// Code generated 16/10/2020 10:06:38 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKxptm_instrumento_cuadro } from 'src/app/shared/models/xrskxptm_instrumento_cuadro.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKxptm_instrumento_cuadroService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskxptm_instrumento_cuadro";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKxptm_instrumento_cuadroService");
    return throwError(error.error);
  }

  getXRSKxptm_instrumento_cuadroList(): Observable<XRSKxptm_instrumento_cuadro[]> {
    return this.http.get<XRSKxptm_instrumento_cuadro[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKxptm_instrumento_cuadroFilter(filter: FilterHeader): Observable<XRSKxptm_instrumento_cuadro[]> {
    return this.http.post<XRSKxptm_instrumento_cuadro[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKxptm_instrumento_cuadro(linid: number): Observable<XRSKxptm_instrumento_cuadro> {
    return this.http.get<XRSKxptm_instrumento_cuadro>(this.myAppUrl + this.myApiUrl + "/key?linid=" + linid)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKxptm_instrumento_cuadro> {
    return this.http.post<XRSKxptm_instrumento_cuadro>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  delete(movimiento): Observable<XRSKxptm_instrumento_cuadro> {
    return this.http.post<XRSKxptm_instrumento_cuadro>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
}
