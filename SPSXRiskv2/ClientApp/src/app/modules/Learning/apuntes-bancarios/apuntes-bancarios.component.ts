import { Component, OnInit, ViewChild } from '@angular/core';
import { XRSKApunteBancarioService } from '../../../shared/services/xrskApunteBancario.service';
import { MdbTableDirective, MdbTablePaginationComponent, ModalDirective } from 'angular-bootstrap-md';
import { MAT_DATE_LOCALE, MAT_DATE_FORMATS, DateAdapter } from '@angular/material/core';
import { APP_DATE_FORMATS, AppDateAdapter } from '../../../shared/format/format-datepicker';
import { Router } from '@angular/router';

import { conComunCSB, conComun } from '../../../shared/models/xriskConComunCSB.model';
import { XRSKApunBancCSB_PSD2, XRSKApunBancCSBPSD2 } from '../../../shared/models/xrskApunBancCSB_PSD2.model';
import { XRSKApunteBancario, ApuntBancInformation, ApuntBancModel } from 'src/app/shared/models/xrskApunteBancario.model';
import { XRSKConComunCSBService } from '../../../shared/services/xrskConComunCSB.service';
import { XRSKApunBancCSB_PSD2Service } from '../../../shared/services/xrskApunBancCSB_PSD2.service';

import { ProgressInformationComponent } from '../../../shared/components/progress-information/progress-information.component'

@Component({
  selector: 'app-apuntes-bancarios',
  templateUrl: './apuntes-bancarios.component.html',
  styleUrls: ['./apuntes-bancarios.component.css'],
  providers: [
    { provide: DateAdapter, useClass: AppDateAdapter },
    { provide: MAT_DATE_LOCALE, useValue: 'es-ES' },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS }
  ]
})
export class ApuntesBancariosComponent implements OnInit {

  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;

  constructor(private apunBancService: XRSKApunteBancarioService,
    private conComunService: XRSKConComunCSBService,
    private apunBancPSD2Service: XRSKApunBancCSB_PSD2Service,
  private route: Router) { }

  public apunBanc: any[] = [];
  public conComun: any[] = [];
  public editMode: boolean = false;
  public apunteBancario: XRSKApunBancCSBPSD2 = new XRSKApunBancCSBPSD2();
  public seeDetail: boolean = true;

  public operacion: string;

  public loaded: boolean = false;

  ngOnInit(): void {
    this.editMode = false;
    this.getApunBanc_PSD2();
    this.getConComun();
  }

  showProgressInformation() {
    this.loaded = true;
    setTimeout(() => {
      this.loaded = false;
    }, 8000);
  }

  getApunBanc() {
    this.apunBancService.getXRSKApunteBancarioList().subscribe(
      apunBanc => {
        this.apunBanc = apunBanc as XRSKApunteBancario[];
        this.mdbTable.setDataSource(this.apunBanc);
      },
      err => {
        console.log(err);
      }
    );
  }

  getApunBanc_PSD2() {
    this.apunBancPSD2Service.getXRSKApunBancCSB_PSD2List().subscribe(
      apunBancPSD2 => {
        this.apunBanc = apunBancPSD2 as XRSKApunBancCSB_PSD2[];
        this.mdbTable.setDataSource(this.apunBanc);
      },
      err => {
        console.log(err);
      }
    );
  }

  getConComun() {
    this.conComunService.getXRSKConComunCSB().subscribe(
      conComun => {
        this.conComun = conComun as conComunCSB[];
      },
      err => {
        console.log(err);
      }
    );
  }

  edit(apunte) {
    this.apunteBancario = Object.assign({}, apunte);
    this.editMode = true;
  } //edit

  cancelSubmitClick() {
    this.editMode = false;
  }

  verDetalle() {
    this.seeDetail = !this.seeDetail;
  }

  generarMovimiento() {
    this.route.navigate(['asignar-factura/1000002'])
  }

  ngAfterViewInit() {
    this.mdbTablePagination.setMaxVisibleItemsNumberTo(8);
    this.mdbTablePagination.calculateFirstItemIndex();
    this.mdbTablePagination.calculateLastItemIndex();
  }

}
