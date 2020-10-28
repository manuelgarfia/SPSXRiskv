import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { XRSKpanelItem } from 'src/app/core/models/xrskmenuPanel.model';
import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';


@Injectable({
  providedIn: 'root'
})

export class XRSKPanelService {

  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/apppanel";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo AppPanelService");
    return throwError(error.error);
  }

  getAppPaneles(): Observable<XRSKpanelItem[]> {
    return this.http.get<XRSKpanelItem[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }

}
