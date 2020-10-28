import { Component, OnInit, Inject, HostListener, ViewChild, ChangeDetectorRef, ElementRef } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { Observable } from 'rxjs';
import { from } from 'rxjs';
import { Jesus } from 'src/app/shared/models/jesus.model';
import { XRSKXptmEscenario } from 'src/app/shared/models/xrskXptmEscenario.model';
import { XRSKXptmTipintd } from 'src/app/shared/models/xrskXptmTipintd.model';
import { JesusService } from 'src/app/shared/services/jesus.service';
import { XRSKXptmEscenarioService } from 'src/app/shared/services/xrskXptmEscenario.service';
import { XRSKXptmTipintdService } from 'src/app/shared/services/xrskXptmTipintd.service';

import { MdbTableDirective, MdbTablePaginationComponent, MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { ModalComponent } from 'src/app/shared/components/modal/modal.component';
import { DateAdapter, MAT_DATE_FORMATS } from '@angular/material/core';
import { AppDateAdapter, APP_DATE_FORMATS } from 'src/app/shared/format/format-datepicker';


@Component({
  selector: 'app-jesus-navega',
  templateUrl: './jesus-navega.component.html',
  styleUrls: ['./jesus-navega.component.css']
})
export class JesusNavegaComponent implements OnInit {
  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild('alert', { static: true }) alert: ElementRef;

  public escenarioDetalle$: Jesus;
  public escenarioDetalles: any = [];

  searchText: string = '';
  errorText: string = 'Hay un error';
  previous: any = [];
  ambParametre: boolean = true;

  constructor(private jesusService: JesusService, private cdRef: ChangeDetectorRef) { }

  @HostListener('input') oninput() {
    this.searchItems();
  }

  ngOnInit(): void {
    this.getJesusList();
  }

  changeRadio(e) {
    this.getJesusList();
  }

  getJesusList(): void {
    this.jesusService.getJesusList().subscribe(
      escenarioDetalles => {
        this.escenarioDetalles = escenarioDetalles as Jesus[];
        if (this.escenarioDetalles.length > 0) {
          this.escenarioDetalle$ = this.escenarioDetalles[0];
        }
        this.mdbTable.setDataSource(this.escenarioDetalles);
        this.previous = this.mdbTable.getDataSource();
        //this.closeProgress();
      },
      err => {
        this.errorText = err;
        this.showAlert();
      }
    );
  }

  searchItems() {
    const prev = this.mdbTable.getDataSource();
    if (!this.searchText) {
      this.mdbTable.setDataSource(this.previous);
      this.escenarioDetalles = this.mdbTable.getDataSource();
    }
    if (this.searchText) {
      this.escenarioDetalles = this.mdbTable.searchLocalDataBy(this.searchText);
      this.mdbTable.setDataSource(prev);
    }
  }

  ngAfterViewInit() {
    this.mdbTablePagination.setMaxVisibleItemsNumberTo(10);

    this.mdbTablePagination.calculateFirstItemIndex();
    this.mdbTablePagination.calculateLastItemIndex();
    this.cdRef.detectChanges();
  }

  closeAlert() {
    this.alert.nativeElement.classList.remove('show');
    this.alert.nativeElement.classList.add('collapse');
  }

  showAlert() {
    this.alert.nativeElement.classList.remove('collapse');
    this.alert.nativeElement.classList.add('show');
  }
}
