/// <summary>
/// Code generated 26/10/2020 11:04:27 by EFClassGenerator version 1.0.0.0
/// Template last modified 14/08/2020
/// </summary>

import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKcfg_menu_objectes } from 'src/app/shared/models/xrskcfg_menu_objectes.model';
import { FilterHeader, filtermodel } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKcfg_menu_objectesService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskcfg_menu_objectes";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKcfg_menu_objectesService");
    return throwError(error.error);
  }

  getXRSKcfg_menu_objectesList(): Observable<XRSKcfg_menu_objectes[]> {
    return this.http.get<XRSKcfg_menu_objectes[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKcfg_menu_objectesFilter(filter: FilterHeader): Observable<XRSKcfg_menu_objectes[]> {
    return this.http.post<XRSKcfg_menu_objectes[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKcfg_menu_objectes(usuari: string, grup: string, objecte: string): Observable<XRSKcfg_menu_objectes> {
    return this.http.get<XRSKcfg_menu_objectes>(this.myAppUrl + this.myApiUrl + "/key?usuari=" + usuari + "&grup=" + grup + "&objecte=" + objecte)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Insert or Edit register
  save(movimiento): Observable<XRSKcfg_menu_objectes> {
    return this.http.post<XRSKcfg_menu_objectes>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  delete(movimiento): Observable<XRSKcfg_menu_objectes> {
    return this.http.post<XRSKcfg_menu_objectes>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
}
