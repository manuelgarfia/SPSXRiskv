/// <summary>
/// Code generated 07/10/2020 12:52:21 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKOperacion } from '../models/xrskOperacion.model';
import { FilterHeader, filtermodel } from '../models/filtermodel';

import { retry, catchError, map } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKOperacionService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskOperacion";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKOperacionService");
    return throwError(error.error);
  }

  getXRSKOperacionList(): Observable<XRSKOperacion[]> {
    return this.http.get<XRSKOperacion[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKOperacionFiltro(): Observable<filtermodel[]> {
    return this.http.get<XRSKOperacion[]>(this.myAppUrl + this.myApiUrl + "/filter")
      .pipe(
        map(o => o.map((sp): filtermodel => ({
          code: sp.OPECod,
          description: sp.OPEDescripcion,
          checked: false
        }))),
        catchError(this.handleError)
      );
  }

  getXRSKOperacionFilter(filter: FilterHeader): Observable<XRSKOperacion[]> {
    return this.http.post<XRSKOperacion[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKOperacion(OPEGrupo: string, OPENiv: string, OPECod: string, OPENivTLI: string, OPECodTLI: string): Observable<XRSKOperacion> {
    return this.http.get<XRSKOperacion>(this.myAppUrl + this.myApiUrl + "/key?OPEGrupo="+OPEGrupo+"&OPENiv="+OPENiv+"&OPECod="+OPECod+"&OPENivTLI="+OPENivTLI+"&OPECodTLI="+OPECodTLI)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(operacion): Observable<XRSKOperacion> {
    return this.http.post<XRSKOperacion>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(operacion), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
  
  //Delete register
  delete(operacion): Observable<XRSKOperacion> {
    return this.http.post<XRSKOperacion>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(operacion), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }  
}
