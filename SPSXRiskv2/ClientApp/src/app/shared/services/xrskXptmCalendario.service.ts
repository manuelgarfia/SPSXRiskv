import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKXptmCalendario } from 'src/app/shared/models/xrskxptmcalendario.model';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKXptmCalendarioService {

  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskXptmCalendario";    
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKAgrupacionService");
    return throwError(error.error);
  }

  getXRSKXptmCalendarioList(): Observable<XRSKXptmCalendario[]> {
    return this.http.get<XRSKXptmCalendario[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }
  
  
  getXRSKXptmCalendario(cabid:number): Observable<XRSKXptmCalendario> {
    return this.http.get<XRSKXptmCalendario>(this.myAppUrl + this.myApiUrl + "/key?cabid=" + cabid)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  saveXRSKXptmCalendario(calendario): Observable<XRSKXptmCalendario> {
    return this.http.post<XRSKXptmCalendario>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(calendario), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  deleteXRSKXptmCalendario(calendario): Observable<XRSKXptmCalendario> {
    return this.http.post<XRSKXptmCalendario>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(calendario), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
  


}
