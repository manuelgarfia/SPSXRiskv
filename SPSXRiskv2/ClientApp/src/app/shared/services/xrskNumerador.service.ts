/// <summary>
/// Code generated 28/09/2020 12:07:03 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKNumerador } from 'src/app/shared/models/xrskNumerador.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKNumeradorService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskNumerador";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKNumeradorService");
    return throwError(error.error);
  }

  getXRSKNumeradorList(): Observable<XRSKNumerador[]> {
    return this.http.get<XRSKNumerador[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKNumeradorFilter(filter: FilterHeader): Observable<XRSKNumerador[]> {
    return this.http.post<XRSKNumerador[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKNumerador(NUMGrupo: string, NUMNiv: string): Observable<XRSKNumerador> {
    return this.http.get<XRSKNumerador>(this.myAppUrl + this.myApiUrl + "/key?NUMGrupo=" + NUMGrupo + "&NUMNiv=" + NUMNiv)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKNumerador> {
    return this.http.post<XRSKNumerador>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  delete(movimiento): Observable<XRSKNumerador> {
    return this.http.post<XRSKNumerador>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
}
