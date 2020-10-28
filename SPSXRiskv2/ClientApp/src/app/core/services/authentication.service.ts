import { Injectable, Inject } from '@angular/core';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { XRSKUser } from '../models/xrskuser.model';
import { map, catchError } from 'rxjs/operators';
import { XRSKPanelService } from 'src/app/core/services/panel.service';

import { usersmodel, usersgroupmodel, securityObjectModel} from 'src/app/shared/models/usersmodel'
import { XRSKpanelItem } from '../models/xrskmenuPanel.model';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private loggedIn = new BehaviorSubject<boolean>(false);
  private currentUserSubject: BehaviorSubject<XRSKUser>;
  public currentUser: Observable<XRSKUser>;

  private panelesValue: BehaviorSubject<XRSKpanelItem[]>;

  myAppUrl: string;
  myApiUrl: string;
  url: string;

  constructor(private readonly http: HttpClient, private panelService: XRSKPanelService,  @Inject('BASE_URL') baseUrl: string) {
    this.currentUserSubject = new BehaviorSubject<XRSKUser>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();

    this.panelesValue = <BehaviorSubject<XRSKpanelItem[]>>new BehaviorSubject([]);

    this.myAppUrl = baseUrl;
    this.myApiUrl = "api/auth";

    if (JSON.parse(localStorage.getItem('currentUser')) != null) {
      this.loggedIn.next(true);
    }

    if (JSON.parse(localStorage.getItem('xrskPaneles')) != null) {
      this.panelesValue.next(JSON.parse(localStorage.getItem('xrskPaneles')));
    }

  }

  public get currentUserValue(): XRSKUser {
    return this.currentUserSubject.value;
  }

  public get currentPwd(): XRSKUser {
    return null;
  }

  public get isLoggedIn() {
    return this.loggedIn.asObservable();
  }

  public get currentUserObs() {
    return this.currentUserSubject.asObservable();
  }

  login(username: string, password: string) {
    return this.http.post<any>('/api/auth/login', { username, password })
      .pipe(map(user => {
        // login successful if there's a jwt token in the response
        if (user && user.token) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUserSubject.next(user);
          this.loggedIn.next(true);
          this.getAppPaneles();
          //this.router.navigate(['/']);
        }

        return user;
      }));
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.setItem('currentUser',null);
    this.loggedIn.next(false);
    this.currentUserSubject.next(null);
    this.panelesValue.next(null);
  }

  register(userRegistration: any) {
    //return this.http.post('/api/auth', userRegistration).pipe(catchError(this.handleError));
    return this.http.post('/api/auth/register', userRegistration)
      .pipe();
  }

  getUser(): Observable<usersmodel[]> {
    return this.http.get<usersmodel[]>(this.myAppUrl + this.myApiUrl +"/users")
      .pipe(
        catchError(this.handleError)
      );
  }

  getUserGroups(): Observable<usersgroupmodel[]> {
    return this.http.get<usersgroupmodel[]>(this.myAppUrl + this.myApiUrl + "/usergroup")
      .pipe(
        catchError(this.handleError)
      );
  }

  getSecurityObject(): Observable<securityObjectModel[]> {
    return this.http.get<securityObjectModel[]>(this.myAppUrl + this.myApiUrl + "/securityObject")
      .pipe(
        catchError(this.handleError)
      );
  }

  getUserName() {
    return this.currentUserValue.username;
  }

  public get panelesObs() {
    return this.panelesValue.asObservable();
  }

  getAppPaneles(): void {

    this.panelService.getAppPaneles().subscribe(
      paneles => {
        this.panelesValue.next(paneles);
        localStorage.setItem('xrskPaneles', JSON.stringify(paneles));
      },
      err => {
        console.log(err);
      }
    );
  }

  //Handle Error
  handleError(error: HttpErrorResponse) {
    console.log("Error");
    return throwError(error.error);
  }

}
