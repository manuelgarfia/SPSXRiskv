import { Injectable, Inject, OnInit, HostListener, ViewChild, ChangeDetectorRef, ElementRef } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { carteraefectos } from '../models/carteraefectos.model';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';
import { filtermodel, FilterHeader } from '../models/filtermodel';

@Injectable({
  providedIn: 'root'
})

export class xrskcarteraEfectos {

  //Declaración de Variables
  myAppUrl: string;
  myApiUrl: string;


  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/XRSKCarteraEfectos";

  }



  handleError(error: HttpErrorResponse) {
    console.log("Error Conectado Con Cartera de Efectos ");
    return throwError(error.error);
  }

  getXRSKCarteraEfectosList(): Observable<carteraefectos[]> {

    return this.http.get<carteraefectos[]>(this.myAppUrl + this.myApiUrl)
      .pipe(

        catchError(this.handleError)
      );
  }

}
