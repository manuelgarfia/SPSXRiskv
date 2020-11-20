/// <summary>
/// Code generated 29/10/2020 9:44:31 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKxptm_leasings } from 'src/app/shared/models/xrskxptm_leasings.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKxptm_leasingsService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskxptm_leasings";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKxptm_leasingsService");
    return throwError(error.error);
  }

  getXRSKxptm_leasingsList(): Observable<XRSKxptm_leasings[]> {
    return this.http.get<XRSKxptm_leasings[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKxptm_leasingsFilter(filter: FilterHeader): Observable<XRSKxptm_leasings[]> {
    return this.http.post<XRSKxptm_leasings[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKxptm_leasings(cabid: number): Observable<XRSKxptm_leasings> {
    return this.http.get<XRSKxptm_leasings>(this.myAppUrl + this.myApiUrl + "/key?cabid="+cabid)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKxptm_leasings> {
    return this.http.post<XRSKxptm_leasings>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
  
  //Delete register
  delete(movimiento): Observable<XRSKxptm_leasings> {
    return this.http.post<XRSKxptm_leasings>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }  
}
