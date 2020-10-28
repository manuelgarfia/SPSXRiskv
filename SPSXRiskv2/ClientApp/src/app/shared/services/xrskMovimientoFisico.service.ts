import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKMovimientoFisico, XRSKMovFisicoExamples} from 'src/app/shared/models/xrskMovimientoFisico.model';
import { FilterHeader } from 'src/app/shared/models/filtermodel';

import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';
import { filtermodel } from '../models/filtermodel';

@Injectable({
  providedIn: 'root'
})

export class XRSKMovimientoFisicoService {

  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/xrskmovimientofisico";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKMovimientoFisicoService");
    return throwError(error.error);
  }

  getXRSKMovimientoFisicoList(): Observable<XRSKMovimientoFisico[]> {
    return this.http.get<XRSKMovimientoFisico[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKMovimientoFisicoRegister(cia, reference): Observable<XRSKMovimientoFisico> {
    return this.http.get<XRSKMovimientoFisico>(this.myAppUrl + this.myApiUrl +"/register/"+ cia.toString() + "/" + reference.toString())
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKMovFisicoExamplesList(filter: FilterHeader): Observable<XRSKMovFisicoExamples[]> {
    return this.http.post<XRSKMovFisicoExamples[]>(this.myAppUrl + this.myApiUrl + "/examples", JSON.stringify(filter), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  getXRSKMovimientoFisicoListDateRange(desde: Date, hasta: Date, cias: string[]): Observable<XRSKMovimientoFisico[]> {
    return this.http.get<XRSKMovimientoFisico[]>(this.myAppUrl + this.myApiUrl + "/dateRange/" + desde.toDateString() + "/" + hasta.toDateString() + "/" + cias.toString())
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKMovimientoFisicoFilter(filter: FilterHeader): Observable<XRSKMovimientoFisico[]> {
    return this.http.post<XRSKMovimientoFisico[]>(this.myAppUrl + this.myApiUrl + "/filter", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getProvisorisConcilFilter(filter: FilterHeader): Observable<XRSKMovimientoFisico[]> {
    return this.http.post<XRSKMovimientoFisico[]>(this.myAppUrl + this.myApiUrl + "/provconcil", JSON.stringify(filter), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  getXRSKMovimientoFisico(MVFCodCIA: string, MVFValorOrganizativo: string, MVFRefXRisk: number): Observable<XRSKMovimientoFisico> {
    return this.http.get<XRSKMovimientoFisico>(this.myAppUrl + this.myApiUrl + "/key?MVFCodCIA=" + MVFCodCIA + "&MVFValorOrganizativo=" + MVFValorOrganizativo + "&MVFRefXRisk=" + MVFRefXRisk)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  save(movimiento): Observable<XRSKMovimientoFisico> {
    return this.http.post<XRSKMovimientoFisico>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(movimiento), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }


}
