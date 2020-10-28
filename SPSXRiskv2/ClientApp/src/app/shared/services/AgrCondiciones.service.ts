import { Injectable, Inject, OnInit, HostListener, ViewChild, ChangeDetectorRef, ElementRef } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { XRSKCBVigentes } from '../models/georgina.model';
import { agrcondicionesmodel } from '../models/agrcondiciones.model';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';
import { MdbTableDirective, MdbTablePaginationComponent, CollapseComponent } from 'angular-bootstrap-md';

@Injectable({
  providedIn: 'root'
})

export class XRSKAgrCondicionesService {

  myAppUrl: string;
  myApiUrl: string;
  url: string;

  searchText: string = '';
  errorText: string = 'Hay un error';
  previous: any = [];


  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/XRSKAgrCondiciones";
  }


  get_agrcondiciones_list(): Observable<agrcondicionesmodel[]> {
    return this.http.get<agrcondicionesmodel[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        catchError(this.handleError)
      );
  }


  //Handle Error
  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo Cuentas Bancarias Vigentes");
    return throwError(error.error);
  }

}
