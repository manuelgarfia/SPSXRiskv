import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKDesgloseContr, XRSKDesglose } from 'src/app/shared/models/xrskDesgloseContr.model';
import { conComunCSB } from 'src/app/shared/models/xriskConComunCSB.model';
import { XRSKMovimientoFisico } from 'src/app/shared/models/xrskMovimientoFisico.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKConComunCSBService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskconcomun";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKConComunCSB");
    return throwError(error.error);
  }

  getXRSKConComunCSB(): Observable<conComunCSB[]> {
    return this.http.get<conComunCSB[]>(this.myAppUrl + this.myApiUrl)
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

}
