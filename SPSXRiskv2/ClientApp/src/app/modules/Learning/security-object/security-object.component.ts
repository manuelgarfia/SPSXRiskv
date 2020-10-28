import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { securityObjectModel } from 'src/app/shared/models/usersmodel';
import { MdbTableDirective, MdbTablePaginationComponent } from 'angular-bootstrap-md';


@Component({
  selector: 'app-security-object',
  templateUrl: './security-object.component.html',
  styleUrls: ['./security-object.component.css']
})
export class SecurityObjectComponent implements OnInit {

  public secObjList: any[] = [];
  public errorText: string;

  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit(): void {
    this.getSecurityObjects();
  }

  getSecurityObjects(): void {
    this.authenticationService.getSecurityObject().subscribe(so => {
      this.secObjList = so as securityObjectModel[];
      this.mdbTable.setDataSource(this.secObjList);
    },
      err => {
        this.errorText = err;
        // this.showAlert();
      }
    );
  }

}
