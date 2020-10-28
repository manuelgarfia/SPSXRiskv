import { Injectable, Inject, OnInit, HostListener, ViewChild, ChangeDetectorRef, ElementRef } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { xrskcontratos } from 'src/app/shared/models/xrskContratos.model';

import { retry, catchError,map } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';
import { filtermodel } from '../models/filtermodel';

import { ciamodel } from '../models/ciamodel';

@Injectable({
  providedIn: 'root'
})
export class XRSKContratosService {

  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskcontratos";

  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKContratosService");
    return throwError(error.error);
  }

  getXRSKContratos(cia: string): Observable<filtermodel[]> {
    return this.http.get<xrskcontratos[]>(this.myAppUrl + this.myApiUrl + "/filter/" +  cia.toString())
      .pipe(
        map(o => o.map((sp): filtermodel => ({
          code: sp.ctacod + '',
          description: sp.ctadescripcion,
          checked:false
        }))),
          catchError(this.handleError)
      );
  }

  getXRSKContratosFilterList(): Observable<filtermodel[]> {
    return this.http.get<xrskcontratos[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        map(o => o.map((sp): filtermodel => ({
          code: sp.ctacod + '',
          description: sp.ctadescripcion,
          checked: false
        }))),
        catchError(this.handleError)
      );
  }

  get_cia_filter(): Observable<filtermodel[]> {
    return this.http.get<xrskcontratos[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        map(o => o.map((sp): filtermodel => ({
          code: sp.ctacod + '',
          description: sp.ctadescripcion,
          checked: false
        }))),
        catchError(this.handleError)
      );
  }
}
