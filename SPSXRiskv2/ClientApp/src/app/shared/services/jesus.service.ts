import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Jesus } from '../models/jesus.model';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class JesusService {

  myAppUrl: string;
  myApiUrl: string;
  url: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/XRSKXptmEscenarioDetalle";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo JesusService");
    return throwError(error.error);
  }

  getJesusList(): Observable<Jesus[]> {
    return this.http.get<Jesus[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getJesus(fecha: Date, codtipoint: string, escenario: string): Observable<Jesus> {
    return this.http.get<Jesus>(this.myAppUrl + this.myApiUrl + "/key?fecha=" + fecha + "&codtipoint=" + codtipoint + "&escenario=" + escenario)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  saveJesus(escenarioDetalle): Observable<Jesus> {
    return this.http.post<Jesus>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(escenarioDetalle), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  deleteJesus(escenarioDetalle): Observable<Jesus> {
    return this.http.post<Jesus>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(escenarioDetalle), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
}
