/// <summary>
/// Code generated 26/10/2020 11:04:36 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKcfg_obj_cataleg_obj } from 'src/app/shared/models/xrskcfg_obj_cataleg_obj.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKcfg_obj_cataleg_objService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskcfg_obj_cataleg_obj";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKcfg_obj_cataleg_objService");
    return throwError(error.error);
  }

  getXRSKcfg_obj_cataleg_objList(): Observable<XRSKcfg_obj_cataleg_obj[]> {
    return this.http.get<XRSKcfg_obj_cataleg_obj[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKcfg_obj_cataleg_objFilter(filter: FilterHeader): Observable<XRSKcfg_obj_cataleg_obj[]> {
    return this.http.post<XRSKcfg_obj_cataleg_obj[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKcfg_obj_cataleg_obj(objecte: string): Observable<XRSKcfg_obj_cataleg_obj> {
    return this.http.get<XRSKcfg_obj_cataleg_obj>(this.myAppUrl + this.myApiUrl + "/key?objecte=" + objecte)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKcfg_obj_cataleg_obj> {
    return this.http.post<XRSKcfg_obj_cataleg_obj>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  delete(movimiento): Observable<XRSKcfg_obj_cataleg_obj> {
    return this.http.post<XRSKcfg_obj_cataleg_obj>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
}
