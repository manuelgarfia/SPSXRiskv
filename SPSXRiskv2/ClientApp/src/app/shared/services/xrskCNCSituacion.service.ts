import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKCNCSituacion } from '../models/xrskCNCSituacion.model';
import { filtermodel, sendFiltermodel, FilterHeader } from '../models/filtermodel'

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKCNCSituacionService {

  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/XRSKCNCSituacion";    
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKCNCSituacionService");
    return throwError(error.error);
  }
  
  getXRSKCNCSituacionList(): Observable<XRSKCNCSituacion[]> {
    return this.http.get<XRSKCNCSituacion[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        catchError(this.handleError)
      );
  }

  getXRSKFilter(items: FilterHeader): Observable<XRSKCNCSituacion[]> {
    return this.http.post<XRSKCNCSituacion[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(items), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }
  
  //getXRSKCNCSituacion(ID: number): Observable<XRSKCNCSituacion> {
  //  return this.http.get<XRSKCNCSituacion>(this.myAppUrl + this.myApiUrl + "/key?ID=" + ID)
  //    .pipe(
  //      //retry(1),
  //      catchError(this.handleError)
  //    );
  //}

  //saveXRSKCNCSituacion(escenario): Observable<XRSKCNCSituacion> {
  //  return this.http.post<XRSKCNCSituacion>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(escenario), this.httpOptions)
  //    .pipe(
  //      catchError(this.handleError)
  //    );
  //}

  //deleteXRSKCNCSituacion(escenario): Observable<XRSKCNCSituacion> {
  //  return this.http.post<XRSKCNCSituacion>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(escenario), this.httpOptions)
  //    .pipe(
  //      catchError(this.handleError)
  //    );
  //}
}
