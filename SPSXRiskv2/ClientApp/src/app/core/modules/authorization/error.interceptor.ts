import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
	providedIn: 'root'
})
export class ErrorInterceptor implements HttpInterceptor {

  error: any;

	constructor(private authenticationService: AuthenticationService, private router: Router) { }

	intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		return next.handle(request).pipe(catchError((err: HttpErrorResponse) => {
			if (err.status === 401) {
				this.authenticationService.logout();
				//location.reload(true);
        this.router.navigate(['/login']);
			}

			//const error = err.error.message || err.statusText;
      
			return throwError(err);
		}))
	}
}

export const errorInterceptorProvider = {
	provide: HTTP_INTERCEPTORS,
	useClass: ErrorInterceptor,
	multi: true
};
