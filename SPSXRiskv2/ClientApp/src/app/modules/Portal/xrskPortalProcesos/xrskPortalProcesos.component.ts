import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { MdbTablePaginationComponent, MdbTableDirective, MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { DatePipe } from '@angular/common';
import { Observable } from 'rxjs';
import { popUpComponent } from 'src/app/shared/components/ProcesosPopUp/procesosPopUp.component';

@Component({
  selector: 'app-xrsk-portal-procesos',
  templateUrl: './xrskPortalProcesos.component.html',
  styleUrls: ['./xrskPortalProcesos.component.css'],
  providers: [
    [DatePipe]
  ]
})
export class XrskPortalProcesos implements OnInit {

  constructor(private modalservice: MDBModalService) { }

  public modalOptions: any;
  modalRef: MDBModalRef;

  ngOnInit() {

  }

  hello() {
    var j = 9;
  }

  blueButtonClick() {
    var i = 0;

    this.modalOptions = {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: true,
      ignoreBackdropClick: false,
      class: 'modal-dialog-scrollable modal-warning modal-lg',
      animated: true,
    }

    this.modalRef = this.modalservice.show(popUpComponent, this.modalOptions);
  }


  redButtonClick(buttonName) {
    switch (buttonName) {
      case "bancos":
        //window.open("http://xriskdev2018.cloudapp.net/xrisktreasuryDEV/DetailListView.aspx?dbms=DEV&obj=fxr_ApunBancCSB&query=ABCCodCTA%3dBKT000250+AND+ABCFechVal%3e%3d2016-01-08+AND+ABCFechVal%3c%3d2016-01-15&modo=lista");
        window.open("http://xriskdemos2018.cloudapp.net/XRiskTreasuryN2020/DetailListView.aspx?user=xrisk&pwd=oys&dbms=DEV&obj=fxr_ApunBancCSB&query=ABCCodCIA%3dy01+AND+ABCCodCTA%3dCAICTY01&modo=lista");
        break;
      case "ERP":
        //window.open("http://xriskdev2018.cloudapp.net/xrisktreasuryDEV/DetailListView.aspx?dbms=DEV&obj=xrisk_MovFisico&query=MVFCodCIA%3d250+AND+MVFCodENT%3dBKT+AND+MVFGradCert%3dP&modo=lista");
        window.open("http://xriskdemos2018.cloudapp.net/XRiskTreasuryN2020/DetailListView.aspx?user=xrisk&pwd=oys&dbms=DEV&obj=xrisk_MovFisico&query=MVFCodCIA%3dY01+AND+MVFCodCTA%3dCAICTY01+AND+MVFGradCert%3dP&modo=lista");
        break;
      case "conciliados":
        //window.open("http://xriskdev2018.cloudapp.net/xrisktreasuryDEV/DetailListView.aspx?dbms=DEV&obj=xrisk_MovFisico&query=MVFGradCert%3dC&modo=lista");
        window.open("http://xriskdemos2018.cloudapp.net/XRiskTreasuryN2020/DetailListView.aspx?user=xrisk&pwd=oys&dbms=DEV&obj=xrisk_MovFisico&query=MVFCodCIA%3dY01+AND+MVFCodCTA%3dCAICTY01+AND+MVFGradCert%3dC&modo=lista");
        break;
      case "revision":
        //window.open("http://xriskdev2018.cloudapp.net/xrisktreasuryDEV/CNCSituacionPosicion.aspx?dbms=DEV&obj=fxr_CNCSituacion&query=CNCCodCIA%3d250");
        window.open("http://xriskdev2018.cloudapp.net/xrisktreasuryDEV/Desktop2016.aspx?user=xrisk&pwd=oys&dbms=DEV&targetObj=fxr_CNCSituacion&query=CNCCodCIA%3d250");
        break;
      case "incorporados":
        //window.open("http://xriskdev2018.cloudapp.net/xrisktreasuryDEV/DetailListView.aspx?dbms=DEV&obj=xrisk_MovFisico&query=MVFCodCIA%3d250+AND+MVFCodENT%3dBKT+AND+MVFConciliado%3dIA&modo=lista");
        window.open("http://xriskdemos2018.cloudapp.net/XRiskTreasuryN2020/DetailListView.aspx?user=xrisk&pwd=oys&dbms=DEV&obj=xrisk_MovFisico&query=MVFCodCIA%3dY01+AND+MVFConciliado%3dIA&modo=lista");
        break;
    }
  }
}
