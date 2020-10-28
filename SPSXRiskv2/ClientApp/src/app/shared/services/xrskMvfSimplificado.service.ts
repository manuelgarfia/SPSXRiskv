import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { xrskmvfsimplificado} from '../models/XRSKMVFSimplificado.model'
import { catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class XRSKMvfSimplificadoService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskmvfsimplificado";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo xrskmvfsimplificadoService");
    return throwError(error.error);
  }

  getXRSKMVFSimplificadoList(): Observable<xrskmvfsimplificado[]> {
    return this.http.get<xrskmvfsimplificado[]>(this.myAppUrl + this.myApiUrl +"/no_filter")
      .pipe(
        
        catchError(this.handleError)
      );
  }

  saveXRSKMVFSimplificado(movimientos): Observable<xrskmvfsimplificado>{
    return this.http.post<xrskmvfsimplificado>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimientos), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
  // This method will be useful in the near future.

  //getXRSKMVFSimplificadoDateList(): Observable<xrskmvfsimplificado[]> {
  //  return this.http.get<xrskmvfsimplificado[]>(this.myAppUrl + this.myApiUrl + "/dateRange/"+ desde.getDate() + "/" + desde.getMonth() + "/" + desde.getFullYear() + "/" + hasta.getDate() + "/" + hasta.getMonth() + "/" + hasta.getFullYear())
  //    .pipe(
  //      catchError(this.handleError)
  //    );

  //}













}
