import { Component, OnInit, HostListener, ViewChild, ChangeDetectorRef, ElementRef } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
//import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { from } from 'rxjs';
import { MdbTableDirective, MdbTablePaginationComponent, ModalDirective, CollapseComponent, ModalModule, WavesModule, InputsModule } from 'angular-bootstrap-md';
import { XRSKAgrupacion } from 'src/app/shared/models/xrskagrupacion.model';
import { XRSKAgrupacionService } from 'src/app/shared/services/xrskagrupacion.service';
import { MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { ModalComponent } from 'src/app/shared/components/modal/modal.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-xrskagrupacion',
  templateUrl: './xrskagrupacion.component.html',
  styleUrls: ['./xrskagrupacion.component.css']
})

export class XRSKAgrupacionComponent {
  //@ViewChild(MdbTableDirective, { static: true }) mdbTable: MdbTableDirective;
  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  //@ViewChild('tableE1') mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild('alert', { static: true }) alert: ElementRef;
  @ViewChild('Progress') matProgress: ElementRef;

  //#basicModal

  validatingForm: FormGroup;
  modalRef: MDBModalRef;
  modalResult: Boolean;
  
  public objectName: string;
  public modalOptions: any;
  public deleteAgrupacion :XRSKAgrupacion = new XRSKAgrupacion();
  public agrupacion$: XRSKAgrupacion;
  public agrupaciones: any = [];
  searchText: string = '';
  errorText: string = 'Hay un error';
  previous: any = [];

  // Progress Bar values
  color = 'primary';
  mode = 'indeterminate';
  value = 50;
  bufferValue = 75;

  // Snack Bar

  durationInSeconds = 1;

  //public agrupaciones: Observable<XRSKAgrupacion[]>;
  //public agrupaciones: XRSKAgrupacion[];

  constructor(private agrupacionService: XRSKAgrupacionService, private cdRef: ChangeDetectorRef, private modalService: MDBModalService, private _snackBar: MatSnackBar) {
    
  }

  @HostListener('input') oninput() {
    this.searchItems();
  }

  ngOnInit() {

    this.objectName = "Agrupaciones de Contrapartidas";

    this.modalOptions = {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: false,
      ignoreBackdropClick: true,
      class: 'modal-notify modal-warning',
      containerClass: 'modal fade top',
      animated: true,
      data: {
        heading: 'Warning desde Agrupación',
        content: { heading: 'Content heading', description: 'Content description' },
        afirmative: 'Sí',
        negative: 'No'
      }

    };

    this.getXRSKAgrupacionList();

    this.validatingForm = new FormGroup({
      maxLength: new FormControl(null, [Validators.required, Validators.maxLength(5)])
    });

  }

  get input() { return this.validatingForm.get('maxLength'); }

  refresh() {
    this.showProgress();

    this.getXRSKAgrupacionList();
  }
  
  find(ACPGrupo:string, ACPNiv: string, ACPCod: string) {
    this.getXRSKAgrupacion(ACPGrupo, ACPNiv, ACPCod);
  }

  delete(ACPGrupo: string, ACPNiv: string, ACPCod: string) {

    this.deleteAgrupacion.acpCod = ACPCod;
    this.deleteAgrupacion.acpGrupo = ACPGrupo;
    this.deleteAgrupacion.acpNiv = ACPNiv;
    this.deleteXRSKAgrupacion(this.deleteAgrupacion);
  }
  
  closeAlert() {
    this.alert.nativeElement.classList.remove('show');
    this.alert.nativeElement.classList.add('collapse');
  }

  showAlert(alert: string) {
    this.errorText = alert;
    this.alert.nativeElement.classList.remove('collapse');
    this.alert.nativeElement.classList.add('show');
  }

  closeProgress() {
    this.matProgress.nativeElement.classList.remove('show');
    this.matProgress.nativeElement.classList.add('collapse');
  }

  showProgress() {
    this.matProgress.nativeElement.classList.remove('collapse');
    this.matProgress.nativeElement.classList.add('show');
  }

  add() {
    this.saveXRSKAgrupacion(this.agrupacion$);
  }

  reset() {
    // Reset main entity
    this.agrupacion$ = new XRSKAgrupacion();
  }

  save() {
    this.saveXRSKAgrupacion(this.agrupacion$);
  }
   
  openDialog(accion: string){

    if (accion == "save") {
      this.modalOptions.class = 'modal-notify modal-danger';
      this.modalOptions.data = {
        heading: 'Cuidado!',
        content: { heading: 'Guardando Agrupación', description: 'Se va a guardar!' },
        afirmative: 'Continuar',
        negative: 'Cancelar'
      };
    } else {
      this.modalOptions.class = 'modal-notify modal-warning';
      this.modalOptions.data = {
        heading: 'Warning desde Agrupación',
        content: { heading: 'Content heading', description: 'Content description' },
        afirmative: 'Sí',
        negative: 'No'
      };
    }

    this.modalRef = this.modalService.show(ModalComponent, this.modalOptions);
    
    this.modalRef.content.action.subscribe((confirm: any) => {
      if (confirm) {
          if (accion == "filter") { }
          if (accion == "reset") { 
            this.reset();
          }
          if (accion == "save") {
            this.save();
          }
          if (accion == "add") {
            this.add();
          }
        }
      }
    );
    
  } 

  // Get List for Table
  getXRSKAgrupacionList(): void {
     
    this.agrupacionService.getXRSKAgrupacionList().subscribe(
        agrupaciones => {
          this.agrupaciones = agrupaciones as XRSKAgrupacion[];
        if (this.agrupaciones.length > 0) {
            // No actualizamos primer registro
            //this.agrupacion$ = this.agrupaciones[0];
          }
          this.mdbTable.setDataSource(this.agrupaciones);
          this.previous = this.mdbTable.getDataSource();
        this.closeProgress();
        },
      err => {
        this.closeProgress();
        this.showAlert(err);
       
      }
    );
  }

  // Get Record for Form View  
  getXRSKAgrupacion(ACPGrupo: string, ACPNiv: string, ACPCod: string): void {
    this.agrupacionService.getXRSKAgrupacion(ACPGrupo, ACPNiv, ACPCod).subscribe(
      agrupacion => {
        this.agrupacion$ = agrupacion;
        this.closeProgress();
      },
      err => {
        this.showAlert(err);
      }
    );
  }
  
  saveXRSKAgrupacion(agrupacion: XRSKAgrupacion) {
    this.showProgress();
    this.agrupacionService.saveXRSKAgrupacion(agrupacion).subscribe(
      res => {
        // Si grabamos correctamente volvemos a traer los registros
        this.getXRSKAgrupacionList();
        this.closeProgress();
        this.openSnackBar("OK", "save");
      },
      err => {
        this.closeProgress();
        this.showAlert(err);
      }
    );

  }

  deleteXRSKAgrupacion(agrupacion: XRSKAgrupacion) {
    this.showProgress();
    this.agrupacionService.deleteXRSKAgrupacion(agrupacion).subscribe(
      res => {
        // Si borramos correctamente volvemos a traer los registros
        this.getXRSKAgrupacionList();
        this.reset();
        this.closeProgress();
        this.openSnackBar("OK", "delete");
      },
      err => {
        this.closeProgress();
        this.showAlert(err);
      }
    );

  }
  

  // Local search in table
  searchItems() {
    const prev = this.mdbTable.getDataSource();
    if (!this.searchText) {
      this.mdbTable.setDataSource(this.previous);
      this.agrupaciones = this.mdbTable.getDataSource();
    }
    if (this.searchText) {
      this.agrupaciones = this.mdbTable.searchLocalDataBy(this.searchText);
      this.mdbTable.setDataSource(prev);
    }

  }

  ngAfterViewInit() {
    this.mdbTablePagination.setMaxVisibleItemsNumberTo(10);

    this.mdbTablePagination.calculateFirstItemIndex();
    this.mdbTablePagination.calculateLastItemIndex();
    this.cdRef.detectChanges();
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: this.durationInSeconds*1000,
    });
  }

}
