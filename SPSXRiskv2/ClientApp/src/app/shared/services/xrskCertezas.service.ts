import { Injectable, Inject, OnInit, HostListener, ViewChild, ChangeDetectorRef, ElementRef } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, map } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';
import { MdbTableDirective, MdbTablePaginationComponent, CollapseComponent } from 'angular-bootstrap-md';
import { filtermodel } from '../models/filtermodel';
import { xrskcertezas } from 'src/app/shared/models/xrskCertezas.model';
@Injectable({
  providedIn: 'root'
})
export class xrskCertezas {

  myAppUrl: string;
  myApiUrl: string;
  url: string;

  searchText: string = '';
  errorText: string = 'Hay un error';
  previous: any = [];

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKCertezas");
    return throwError(error.error);
  }

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/XRSKCertezas";
  }


  get_certezas_filter(): Observable<filtermodel[]> {
    return this.http.get<xrskcertezas[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        map(o => o.map((sp): filtermodel => ({
          code: sp.grado,
          description: sp.descripcion,
          checked: false
        }))),
        catchError(this.handleError)
      );
  }


}
