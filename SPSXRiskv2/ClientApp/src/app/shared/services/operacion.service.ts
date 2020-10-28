import { Injectable, Inject, OnInit, HostListener, ViewChild, ChangeDetectorRef, ElementRef } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { operacionmodel } from '../models/operacion.model';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';
import { MdbTableDirective, MdbTablePaginationComponent, CollapseComponent } from 'angular-bootstrap-md';

@Injectable({
  providedIn: 'root'
})

export class XRSKOperacionService {

  myAppUrl: string;
  myApiUrl: string;
  url: string;

  searchText: string = '';
  errorText: string = 'Hay un error';
  previous: any = [];


  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/XRSKOperacion";
  }

  get_operacion_list(): Observable<operacionmodel[]> {
    return this.http.get<operacionmodel[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        catchError(this.handleError)
      );
  }


  //Handle Error
  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo Operacion");
    return throwError(error.error);
  }

}
