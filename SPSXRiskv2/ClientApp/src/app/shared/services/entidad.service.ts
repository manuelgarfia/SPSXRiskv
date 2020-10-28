import { Injectable, Inject, OnInit, HostListener, ViewChild, ChangeDetectorRef, ElementRef } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';
import { MdbTableDirective, MdbTablePaginationComponent, CollapseComponent } from 'angular-bootstrap-md';

import { entidadesmodel, IFilter } from '../models/entidadmodel';
import { filtermodel } from '../models/filtermodel'

@Injectable({
  providedIn: 'root'
})

export class XRSKEntidadService {

  myAppUrl: string;
  myApiUrl: string;
  url: string;

  searchText: string = '';
  errorText: string = 'Hay un error';
  previous: any = [];


  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/XRSKEntidad";
  }


  get_entidades_list(): Observable<entidadesmodel[]> {
    return this.http.get<entidadesmodel[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        catchError(this.handleError)
      );
  }


  get_entidades_filter(): Observable<filtermodel[]> {
    return this.http.get<entidadesmodel[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        map(o => o.map((sp): filtermodel => ({
          code: sp.entCod + '',
          description: sp.entDescripcion,
          checked: false
        }))),
        catchError(this.handleError)
      );
  }


  //Handle Error
  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo Cuentas Bancarias Vigentes");
    return throwError(error.error);
  }

}
