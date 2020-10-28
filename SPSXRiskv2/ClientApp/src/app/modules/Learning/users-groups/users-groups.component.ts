import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { usersgroupmodel } from 'src/app/shared/models/usersmodel';
import { MdbTableDirective, MdbTablePaginationComponent } from 'angular-bootstrap-md';

@Component({
  selector: 'app-users-groups',
  templateUrl: './users-groups.component.html',
  styleUrls: ['./users-groups.component.css']
})
export class UsersGroupsComponent implements OnInit {

  public usersgroupsList: any[] = [];
  public errorText: string;

  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit(): void {
    this.getGroupsUsers();
  }

  getGroupsUsers(): void {
    this.authenticationService.getUserGroups().subscribe(users => {
      this.usersgroupsList = users as usersgroupmodel[];
      this.mdbTable.setDataSource(this.usersgroupsList);
    },
      err => {
        this.errorText = err;
        // this.showAlert();
      }
    );
  }

}
