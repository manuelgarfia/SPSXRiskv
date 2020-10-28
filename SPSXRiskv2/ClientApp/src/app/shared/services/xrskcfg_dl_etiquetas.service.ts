/// <summary>
/// Code generated 26/10/2020 11:05:11 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKcfg_dl_etiquetas } from 'src/app/shared/models/xrskcfg_dl_etiquetas.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKcfg_dl_etiquetasService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskcfg_dl_etiquetas";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKcfg_dl_etiquetasService");
    return throwError(error.error);
  }

  getXRSKcfg_dl_etiquetasList(): Observable<XRSKcfg_dl_etiquetas[]> {
    return this.http.get<XRSKcfg_dl_etiquetas[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKcfg_dl_etiquetasFilter(filter: FilterHeader): Observable<XRSKcfg_dl_etiquetas[]> {
    return this.http.post<XRSKcfg_dl_etiquetas[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKcfg_dl_etiquetas(etiqueta: object, idioma: string): Observable<XRSKcfg_dl_etiquetas> {
    return this.http.get<XRSKcfg_dl_etiquetas>(this.myAppUrl + this.myApiUrl + "/key?etiqueta=" + etiqueta + "&idioma=" + idioma)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKcfg_dl_etiquetas> {
    return this.http.post<XRSKcfg_dl_etiquetas>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  delete(movimiento): Observable<XRSKcfg_dl_etiquetas> {
    return this.http.post<XRSKcfg_dl_etiquetas>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
}
