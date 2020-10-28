import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { stringmodel } from 'src/app/shared/models/stringmodel';
import { retry, catchError } from 'rxjs/operators';
import { async } from 'rxjs/internal/scheduler/async';


@Injectable({
  providedIn: 'root'
})

export class XRSKUtilsService {
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/Utils";
  }

  handleError(error: HttpErrorResponse) {
    console.log("Error Consumiendo XRSKUtilsService");
    return throwError(error.error);
  }

  encrypt(text: string): Observable<stringmodel> {
    return this.http.post<stringmodel>(this.myAppUrl + this.myApiUrl + "/encrypt/" + text, this.httpOptions)
      .pipe(
        //retry(1),
        catchError(this.handleError)
      );
  }
}
