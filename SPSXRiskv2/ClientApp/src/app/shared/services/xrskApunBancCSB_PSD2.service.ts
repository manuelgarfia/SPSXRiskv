/// <summary>
/// Code generated 14/09/2020 11:48:55 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKApunBancCSB_PSD2 } from 'src/app/shared/models/xrskApunBancCSB_PSD2.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKApunBancCSB_PSD2Service {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskApunBancCSB_PSD2";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKApunBancCSB_PSD2Service");
    return throwError(error.error);
  }

  getXRSKApunBancCSB_PSD2List(): Observable<XRSKApunBancCSB_PSD2[]> {
    return this.http.get<XRSKApunBancCSB_PSD2[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKApunBancCSB_PSD2Filter(filter: FilterHeader): Observable<XRSKApunBancCSB_PSD2[]> {
    return this.http.post<XRSKApunBancCSB_PSD2[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKApunBancCSB_PSD2(ABCNumerador: number, ABCCodCIA: string): Observable<XRSKApunBancCSB_PSD2> {
    return this.http.get<XRSKApunBancCSB_PSD2>(this.myAppUrl + this.myApiUrl + "/key?ABCNumerador=" + ABCNumerador + "&ABCCodCIA=" + ABCCodCIA)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKApunBancCSB_PSD2> {
    return this.http.post<XRSKApunBancCSB_PSD2>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  delete(movimiento): Observable<XRSKApunBancCSB_PSD2> {
    return this.http.post<XRSKApunBancCSB_PSD2>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
}
