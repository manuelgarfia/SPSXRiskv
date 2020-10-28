import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKXptmEscenario } from 'src/app/shared/models/xrskXptmEscenario.model';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})

export class XRSKXptmEscenarioService {

  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskXptmEscenario";    
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKXptmEscenarioService");
    return throwError(error.error);
  }
  
  getXRSKXptmEscenarioList(): Observable<XRSKXptmEscenario[]> {
    return this.http.get<XRSKXptmEscenario[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }
  
  
  getXRSKXptmEscenario(ID: number): Observable<XRSKXptmEscenario> {
    return this.http.get<XRSKXptmEscenario>(this.myAppUrl + this.myApiUrl + "/key?ID=" + ID)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  saveXRSKXptmEscenario(escenario): Observable<XRSKXptmEscenario> {
    return this.http.post<XRSKXptmEscenario>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(escenario), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  deleteXRSKXptmEscenario(escenario): Observable<XRSKXptmEscenario> {
    return this.http.post<XRSKXptmEscenario>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(escenario), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
  


}
