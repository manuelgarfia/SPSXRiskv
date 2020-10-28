import { Injectable, Inject, OnInit, HostListener, ViewChild, ChangeDetectorRef, ElementRef } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, map } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';
import { MdbTableDirective, MdbTablePaginationComponent, CollapseComponent } from 'angular-bootstrap-md';
import { clavesprevisionesmodelclass } from '../models/clavesprevisiones.model';


@Injectable({
  providedIn: 'root'
})

export class XRSKClavesPrevisionesService {
  myAppUrl: string;
  myApiUrl: string;
  url: string;

  searchText: string = '';
  errorText: string = 'Hay un error';
  previous: any = [];


  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/XRSKClavesPrevisiones";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Conectado Con ClavesPrevisiones");
    return throwError(error.error);
  }ª

  getClaves(cia: string): Observable<clavesprevisionesmodelclass[]> {

    return this.http.get<clavesprevisionesmodelclass[]>(this.myAppUrl + this.myApiUrl + "/cia/" + cia.toString())
      .pipe(
        catchError(this.handleError)
      );
  }

 
  }

