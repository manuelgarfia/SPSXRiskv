import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { usersmodel } from 'src/app/shared/models/usersmodel';
import { MdbTableDirective, MdbTablePaginationComponent } from 'angular-bootstrap-md';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  public usersList: any[] = [];
  public errorText: string;

  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(): void {
    this.authenticationService.getUser().subscribe(users =>{
      this.usersList = users as usersmodel[];
      this.mdbTable.setDataSource(this.usersList);
    },
      err => {
        this.errorText = err;
       // this.showAlert();
      }
    );
  }

}
