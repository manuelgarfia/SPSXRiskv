/// <summary>
/// Code generated 26/10/2020 11:07:17 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKvw_cfg_menu_usuari } from 'src/app/shared/models/xrskvw_cfg_menu_usuari.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKvw_cfg_menu_usuariService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskvw_cfg_menu_usuari";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKvw_cfg_menu_usuariService");
    return throwError(error.error);
  }

  getXRSKvw_cfg_menu_usuariList(): Observable<XRSKvw_cfg_menu_usuari[]> {
    return this.http.get<XRSKvw_cfg_menu_usuari[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKvw_cfg_menu_usuariFilter(filter: FilterHeader): Observable<XRSKvw_cfg_menu_usuari[]> {
    return this.http.post<XRSKvw_cfg_menu_usuari[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKvw_cfg_menu_usuari(): Observable<XRSKvw_cfg_menu_usuari> {
    return this.http.get<XRSKvw_cfg_menu_usuari>(this.myAppUrl + this.myApiUrl + "/key?)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKvw_cfg_menu_usuari> {
    return this.http.post<XRSKvw_cfg_menu_usuari>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  delete(movimiento): Observable<XRSKvw_cfg_menu_usuari> {
    return this.http.post<XRSKvw_cfg_menu_usuari>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
}
