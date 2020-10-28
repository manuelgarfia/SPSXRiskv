/// <summary>
/// Code generated 29/09/2020 13:11:57 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKContratos_Renovacion } from 'src/app/shared/models/xrskContratos_Renovacion.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKContratos_RenovacionService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskContratos_Renovacion";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKContratos_RenovacionService");
    return throwError(error.error);
  }

  getXRSKContratos_RenovacionList(): Observable<XRSKContratos_Renovacion[]> {
    return this.http.get<XRSKContratos_Renovacion[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKContratos_RenovacionFilter(filter: FilterHeader): Observable<XRSKContratos_Renovacion[]> {
    return this.http.post<XRSKContratos_Renovacion[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKContratos_Renovacion(CTACod: string, CTACodCIA: string, CTAFechIniPer: Date): Observable<XRSKContratos_Renovacion> {
    return this.http.get<XRSKContratos_Renovacion>(this.myAppUrl + this.myApiUrl + "/key?CTACod=" + CTACod + "&CTACodCIA=" + CTACodCIA + "&CTAFechIniPer=" + CTAFechIniPer)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKContratos_Renovacion> {
    return this.http.post<XRSKContratos_Renovacion>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  delete(movimiento): Observable<XRSKContratos_Renovacion> {
    return this.http.post<XRSKContratos_Renovacion>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
}
