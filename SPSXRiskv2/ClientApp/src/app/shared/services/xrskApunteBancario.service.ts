import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKApunteBancario, ApuntBancInformation, ApuntBancModel } from 'src/app/shared/models/xrskApunteBancario.model';
import { FilterHeader } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';
import { filtermodel } from '../models/filtermodel';

@Injectable({
  providedIn: 'root'
})

export class XRSKApunteBancarioService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskapuntebancario";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKApunteBancarioService");
    return throwError(error.error);
  }

  getXRSKApunteBancarioList(): Observable<XRSKApunteBancario[]> {
    return this.http.get<XRSKApunteBancario[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKApunteBancarioClassList(): Observable<ApuntBancInformation[]> {
    return this.http.get<ApuntBancInformation[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //getXRSKApunteBancarioListDateRange(desde: Date, hasta: Date, cias: string[]): Observable<XRSKApunteBancario[]> {
  //  return this.http.get<XRSKApunteBancario[]>(this.myAppUrl + this.myApiUrl + "/dateRange/" + desde.toDateString() + "/" + hasta.toDateString() + "/" + cias.toString())
  //    .pipe(
  //      //retry(1),
  //      catchError(this.handleError)
  //    );
  //}

  //getXRSKApunteBancarioFilter(filter: FilterHeader): Observable<XRSKApunteBancario[]> {
  //  return this.http.post<XRSKApunteBancario[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
  //    .pipe(
  //      //retry(1),
  //      catchError(this.handleError)
  //    );
  //}

  getPendingConcilFilter(filter: FilterHeader): Observable<XRSKApunteBancario[]> {
    return this.http.post<XRSKApunteBancario[]>(this.myAppUrl + this.myApiUrl + "/provconcil", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKApunteBancario(ABCCodCIA: string, ABCNumerador: number): Observable<XRSKApunteBancario> {
    return this.http.get<XRSKApunteBancario>(this.myAppUrl + this.myApiUrl + "/key?ABCCodCIA=" + ABCCodCIA + "&ABCNumerador=" + ABCNumerador)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getProcessInformation(): Observable<ApuntBancInformation[]> {
    return this.http.get<ApuntBancInformation[]>(this.myAppUrl + this.myApiUrl +'/cardInformation')
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }
}
