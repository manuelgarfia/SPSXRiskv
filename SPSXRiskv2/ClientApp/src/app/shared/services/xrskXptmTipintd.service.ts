import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKXptmTipintd } from 'src/app/shared/models/xrskXptmTipintd.model';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKXptmTipintdService {

  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskXptmTipintd";    
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKXptmTipintdService");
    return throwError(error.error);
  }
  
  getXRSKXptmTipintdList(): Observable<XRSKXptmTipintd[]> {
    return this.http.get<XRSKXptmTipintd[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }
  
  
  getXRSKXptmTipintd(ID: number): Observable<XRSKXptmTipintd> {
    return this.http.get<XRSKXptmTipintd>(this.myAppUrl + this.myApiUrl + "/key?ID=" + ID)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  saveXRSKXptmTipintd(tipo): Observable<XRSKXptmTipintd> {
    return this.http.post<XRSKXptmTipintd>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(tipo), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  deleteXRSKXptmTipintd(tipo): Observable<XRSKXptmTipintd> {
    return this.http.post<XRSKXptmTipintd>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(tipo), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
  


}
