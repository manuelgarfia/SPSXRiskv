/// <summary>
/// Code generated 14/08/2020 11:09:12 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKDivisas } from 'src/app/shared/models/xrskDivisas.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError, map } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKDivisasService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskDivisas";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKDivisasService");
    return throwError(error.error);
  }

  getXRSKDivisasList(): Observable<XRSKDivisas[]> {
    return this.http.get<XRSKDivisas[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKDivisasFilter(filter: FilterHeader): Observable<XRSKDivisas[]> {
    return this.http.post<XRSKDivisas[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKDivisas(DIVNiv: string, DIVCod: string): Observable<XRSKDivisas> {
    return this.http.get<XRSKDivisas>(this.myAppUrl + this.myApiUrl + "/key?DIVNiv=" + DIVNiv + "&DIVCod=" + DIVCod)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKDivisas> {
    return this.http.post<XRSKDivisas>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  delete(movimiento): Observable<XRSKDivisas> {
    return this.http.post<XRSKDivisas>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }


  get_divisas_filter(): Observable<filtermodel[]> {
    return this.http.get<XRSKDivisas[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        map(o => o.map((sp): filtermodel => ({
          code: sp.DIVCod + '',
          description: sp.DIVDescripcion,
          checked: false
        }))),
        catchError(this.handleError)
      );
  }
}
