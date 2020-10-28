import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { ConciliacionModel } from '../models/conciliacion.model';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKConciliacionService {

  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/XRSKConciliacion";    
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKConciliacionService");
    return throwError(error.error);
  }

  executeOperation(items: ConciliacionModel): Observable<number> {
    return this.http.post<number>(this.myAppUrl + this.myApiUrl + "/ejecutar", JSON.stringify(items), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //getXRSKConciliacionList(): Observable<ConciliacionModel[]> {
    //return this.http.get<XRSKCNCSituacion[]>(this.myAppUrl + this.myApiUrl)
    //  .pipe(
    //    catchError(this.handleError)
    //  );
  //}

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
