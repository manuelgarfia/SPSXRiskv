import { Component, OnInit } from '@angular/core';
//import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators'
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { XRSUserRegistration } from 'src/app/core/models/xrskuser.registration.model';

@Component({
  selector: 'app-register',
  templateUrl: './xrskregister.component.html',
  styleUrls: ['./xrskregister.component.css']
})
export class RegisterComponent implements OnInit {

  success: boolean;
  error: string;
  userRegistration: XRSUserRegistration = { username:'', name: '', email: '', password: '' };
  submitted: boolean = false;

  constructor(private authService: AuthenticationService) {

  }

  ngOnInit() {
  }

  onSubmit() {

    //this.spinner.show();

    this.authService.register(this.userRegistration)
      .pipe(finalize(() => {
        //this.spinner.hide();
      }))
      .subscribe(
        result => {
          if (result) {
            this.success = true;
          }
        },
        error => {

          // Check if error.error is an array
          
          if (error.error instanceof Array) {
            this.error = error.error[0].description;
          } else {
            if (typeof(error.error) != 'undefined') {
              this.error = error.error.substring(0,100);
            }
            if (typeof(error.error.description) != 'undefined') {
              this.error = error.error.description;
            }
          }
          

          //this.error = error;
          //this.error = error.error.message;
        });
  }
}
