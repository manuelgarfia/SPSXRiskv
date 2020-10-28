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
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { AppDateAdapter, APP_DATE_FORMATS } from 'src/app/shared/format/format-datepicker';

@Component({
  selector: 'app-jesus',
  styleUrls: ['./jesus.component.css'],
  templateUrl: './jesus.component.html',
  providers: [
    { provide: DateAdapter, useClass: AppDateAdapter },
    { provide: MAT_DATE_LOCALE, useValue: 'es-ES' },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS }
  ]
})

  //    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS }


export class JesusComponent {
  //@ViewChild(MdbTableDirective, { static: true }) mdbTable: MdbTableDirective;
  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  //@ViewChild('tableE1') mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild('alert', { static: true }) alert: ElementRef;
  @ViewChild('Progress') matProgress: ElementRef;

  public escenarios: XRSKXptmEscenario[];
  public tipos: XRSKXptmTipintd[];
  public escenarioDetalle$: Jesus;
  public escenarioDetalles: any = [];
  public delEscenarioDetalle: Jesus;
  public currentRow: number = -1;
  public currentRowChanged: boolean = false;

  editField: string;
  searchText: string = '';
  errorText: string = 'Hay un error';
  previous: any = [];
  loading: Boolean;

  color = 'primary';
  mode = 'indeterminate';
  value = 50;
  bufferValue = 75;

  public modalOptions: any;
  modalRef: MDBModalRef;
  modalResult: Boolean;

  constructor(private jesusService: JesusService, private cdRef: ChangeDetectorRef, private modalService: MDBModalService,
    private escenarioService: XRSKXptmEscenarioService, private tipintdService: XRSKXptmTipintdService) { }

  @HostListener('input') oninput() {
    this.searchItems();
  }

  ngOnInit() {
    this.loading = true;
    this.getEscenarios();
    this.getTipos();
    this.getJesusList();
  }

  refresh() {
    this.getJesusList();
  }

  add() {
    //this.escenarioDetalle$ = new Jesus();
    //this.escenarioDetalles.push(this.escenarioDetalle$);
    this.escenarioDetalles.splice(0, 0, {});
  }

  closeProgress() {
    this.matProgress.nativeElement.classList.remove('show');
    this.matProgress.nativeElement.classList.add('collapse');
  }

  showProgress() {
    this.matProgress.nativeElement.classList.remove('collapse');
    this.matProgress.nativeElement.classList.add('show');
  }

  closeAlert() {
    this.alert.nativeElement.classList.remove('show');
    this.alert.nativeElement.classList.add('collapse');
  }

  showAlert() {
    this.alert.nativeElement.classList.remove('collapse');
    this.alert.nativeElement.classList.add('show');
  }
   
  changeValue(id: number, property: string, value: any) {
    // Como si se hubiera clickado
    this.onRowClick(id)
    this.currentRow = id;
    this.currentRowChanged = true;
    this.editField = value;
    this.escenarioDetalles[id][property] = this.editField;
    console.log("Changing " + id + " property: " + property + " value:" + value);
  }

  updateList(id: number, property: string, value: any) {
    this.currentRow = id;
    const editField = value;
    this.escenarioDetalles[id][property] = editField;
  }

  onFocus(id: number) {
    if (id != this.currentRow) {
      console.log("Focus line: " + id);
      this.onRowClick(id);
    }
  }

  onRowClick(id: number) {
    console.log("RowClick " + id + " CurrentRow: " + this.currentRow + " CurrentRowChanged:" + this.currentRowChanged);
    if (id != this.currentRow && this.currentRowChanged) {
      const clickedRow = id;
      // Persistir la línea anterior
      this.save(this.escenarioDetalles[this.currentRow]);
      // Cambio de línea
      this.currentRow = id
      this.currentRowChanged = false;
    }
  }

  /*
  changeValue(id: number, property: string, event: any) {
    this.editField = event.target.textContent;
  }

  updateList(id: number, property: string, event: any) { 
    const editField = event.target.textContent;
    this.escenarioDetalles[id][property] = event.target.textContent;
    this.saveEscenarioDetalle(this.escenarioDetalles[id]);
  }
  */

  save(escenario: Jesus) {
    console.log("Saving " + escenario.linid);
    this.saveEscenarioDetalle(escenario);
  }

  remove(id: any) {
    this.deleteEscenarioDetalle(this.escenarioDetalles[id]);
  }

  saveEscenarioDetalle(escenario: Jesus) {
    this.showProgress();
    if (escenario.escenario != null && escenario.fecha != null && escenario.codtipoint != null) {
      this.jesusService.saveJesus(escenario).subscribe(
        res => {
          // Si grabamos correctamente volvemos a traer los registros
          this.getJesusList();
          //this.closeProgress();
        },
        err => {
          this.errorText = err;
          console.log("Error guardando " + err);
          this.closeProgress();
          this.showAlert();
        }
      );
    } else {
      this.errorText = "No hi pot haver camps buits";
      this.showAlert();
    }
  } 

  deleteEscenarioDetalle(escenario: Jesus) {
    //this.showProgress();
    this.jesusService.deleteJesus(escenario).subscribe(
      res => {
        // Si borramos correctamente volvemos a traer los registros
        this.getJesusList();
        this.reset();
        //this.closeProgress();
      },
      err => {
        this.errorText = err;
        //this.closeProgress();
        this.showAlert();
      }
    );
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
        this.closeProgress();
        this.loading = false;
      },
      err => {
        this.errorText = err;
        this.closeProgress();
        this.showAlert();

      }
    );
  }

  openDialog(accion: string, id: any) {
    if (accion == "remove") {
      this.modalOptions = {
        backdrop: true,
        keyboard: true,
        focus: true,
        show: false,
        ignoreBackdropClick: false,
        class: 'modal-notify modal-danger',
        containerClass: 'modal fade',
        animated: true,
        data: {
          heading: 'Esborrar',
          content: { heading: 'Esborrar detall', description: 'Està segur d\'esborrar aquest registre?' },
          afirmative: 'Esborrar',
          negative: 'Cancel·lar'
        }
      };
    }

    this.modalRef = this.modalService.show(ModalComponent, this.modalOptions);

    this.modalRef.content.action.subscribe((confirm: any) => {
      if (confirm) {
        this.remove(id);
        //if (accion == "filter") { }
        //if (accion == "reset") {
        //  //this.reset();
        //}
        //if (accion == "save") {
        //  //this.save();
        //}
        //if (accion == "add") {
        //  //this.add();
        //}
      }
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

  reset() {
    // Reset main entity
    this.escenarioDetalle$ = new Jesus();
  }

  getEscenarios() {

    this.escenarioService.getXRSKXptmEscenarioList().subscribe(
      escenarios => {
        this.escenarios = escenarios as XRSKXptmEscenario[];
      },
      err => {
        this.errorText = err;
        this.closeProgress();
        this.showAlert();

      }
    );


  }

  getTipos() {

    this.tipintdService.getXRSKXptmTipintdList().subscribe(
      tipos => {
        this.tipos = tipos as XRSKXptmTipintd[];
      },
      err => {
        this.errorText = err;
        this.closeProgress();
        this.showAlert();

      }
    );


  }


}


