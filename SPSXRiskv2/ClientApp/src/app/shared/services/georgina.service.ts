import { Injectable, Inject, OnInit, HostListener, ViewChild, ChangeDetectorRef, ElementRef } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

import { XRSKCBVigentes } from '../models/georgina.model'
import { filtermodel, sendFiltermodel, FilterHeader } from '../models/filtermodel'
import { condicionesbancariasmodel } from '../models/georginaclass.model'
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})

export class XRSKCBVService{

  myAppUrl: string;
  myApiUrl: string;
  url: string;

  public CBVig$: XRSKCBVigentes;
  public edit_item: XRSKCBVigentes;
  public condbancarias: condicionesbancariasmodel;
  public CBV: any = [];
  title_modal: string;
  modal_list: any[];
  arraytotal: any = [];

  constructor(public http: HttpClient,
              @Inject('BASE_URL') baseUrl: string,
              public router: Router) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/XRSKCBV";
  }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  getCBVList(): Observable<condicionesbancariasmodel[]> {
    this.CBV = this.http.get<condicionesbancariasmodel[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        catchError(this.handleError)
    );
    return this.CBV;
  }

  get_cbv() {
    return this.CBV;
  }

//Insert or Edit register
  saveXRSKCBV(cond_banc): Observable<XRSKCBVigentes> {
    return this.http.post<XRSKCBVigentes>(this.myAppUrl + this.myApiUrl + "/save", JSON.stringify(cond_banc), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  //Delete register
  deleteXRSKCBV(condicion_bancaria): Observable<condicionesbancariasmodel> {
    return this.http.post<condicionesbancariasmodel>(this.myAppUrl + this.myApiUrl + "/delete", JSON.stringify(condicion_bancaria), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }


  getXRSKFilter(items: FilterHeader): Observable<XRSKCBVigentes[]> {
    return this.http.post<XRSKCBVigentes[]>(this.myAppUrl + this.myApiUrl + "/filter" , JSON.stringify(items), this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

  //Edit register functions
  send_item(item) {
    this.get_editable_row(item);
  }

  get_editable_row(item): condicionesbancariasmodel {
    this.condbancarias = item as condicionesbancariasmodel;
    return this.condbancarias;
  }

  get_item() {
    return this.condbancarias;
  }

  //modal info
  modal_array: any;
  modal_info(item) {
    this.modal_array = item;
  }

  get_modal_info() {
    return this.modal_array;
  }

  errorNumber:number;
  errorString: string;
  //Handle Error
  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo Cuentas Bancarias Vigentes");
    return throwError(error);
    //return (this.errorNumber, this.errorString);
  }


}
