import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKAgrupacion } from 'src/app/shared/models/xrskagrupacion.model';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKAgrupacionService {

  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskagrupacion";    
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKAgrupacionService");
    return throwError(error.error);
  }
  
  getXRSKAgrupacionList(): Observable<XRSKAgrupacion[]> {
    return this.http.get<XRSKAgrupacion[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }
  
  
  getXRSKAgrupacion(ACPGrupo: string, ACPNiv:string, ACPCod:string): Observable<XRSKAgrupacion> {
    return this.http.get<XRSKAgrupacion>(this.myAppUrl + this.myApiUrl + "/key?ACPGrupo=" + ACPGrupo + "&ACPNiv=" + ACPNiv + "&ACPCod=" + ACPCod)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  saveXRSKAgrupacion(agrupacion): Observable<XRSKAgrupacion> {
    return this.http.post<XRSKAgrupacion>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(agrupacion), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  deleteXRSKAgrupacion(agrupacion): Observable<XRSKAgrupacion> {
    return this.http.post<XRSKAgrupacion>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(agrupacion), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
  


}
