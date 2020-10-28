import { Component, OnInit, HostListener, ViewChild, ChangeDetectorRef, ElementRef } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
//import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { from } from 'rxjs';
import { MdbTableDirective, MdbTablePaginationComponent, ModalDirective, CollapseComponent, ModalModule, WavesModule, InputsModule } from 'angular-bootstrap-md';
import { XRSKXptmCalendario } from 'src/app/shared/models/xrskxptmcalendario.model';
import { XRSKXptmCalendarioService } from 'src/app/shared/services/xrskXptmCalendario.service';
import { MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { ModalComponent } from 'src/app/shared/components/modal/modal.component';
import { animate, state, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-xrskcendario',
  templateUrl: './xrskcalendario.component.html',
  styleUrls: ['./xrskcalendario.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0', display: 'none' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})

export class XRSKCalendarioComponent {
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
  expandedElement: XRSKXptmCalendario | null;
  headElements = ['Id', 'Código', 'Descripción', 'Lunes', 'Martes', 'Miércoles', 'Jueves',
    'Viernes', 'Sábado','Domingo'];

  public objectName: string;
  public modalOptions: any;
  public deleteCalendario: XRSKXptmCalendario = new XRSKXptmCalendario();
  public calendario$: XRSKXptmCalendario;
  public calendario_list: any = [];
  searchText: string = '';
  errorText: string = 'Hay un error';
  previous: any = [];

  // Progress Bar values

  color = 'primary';
  mode = 'indeterminate';
  value = 50;
  bufferValue = 75;
  currentState = 'collapsed';


  //public agrupaciones: Observable<XRSKAgrupacion[]>;
  //public agrupaciones: XRSKAgrupacion[];

  constructor(private calendarioService: XRSKXptmCalendarioService, private cdRef: ChangeDetectorRef, private modalService: MDBModalService) {
    
  }

  @HostListener('input') oninput() {
    this.searchItems();
  }

  changeState(item) {
    if (item != this.calendario$) {
      this.currentState = 'collapsed';
    }
    this.currentState = this.currentState === 'collapsed' ? 'expanded' : 'collapsed';
    this.calendario$ = item;
  }


  ngOnInit() {

    this.objectName = "Calendario de Festivos";

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
        heading: 'Warning desde Calendario',
        content: { heading: 'Content heading', description: 'Content description' },
        afirmative: 'Sí',
        negative: 'No'
      }

    };

    this.getXRSKCalendarioList();

    this.validatingForm = new FormGroup({
      maxLength: new FormControl(null, [Validators.required, Validators.maxLength(5)])
    });

  }

  get input() { return this.validatingForm.get('maxLength'); }

  refresh() {
    this.showProgress();

    this.getXRSKCalendarioList();
  }
  
  find(cabid: number) {
    this.getXRSKCalendario(cabid);
  }

  delete(cabid: number) {

    this.deleteCalendario.cabid = cabid;
    this.deleteXRSKAgrupacion(this.deleteCalendario);
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
    this.saveXRSKCalendario(this.calendario$);
  }

  reset() {
    // Reset main entity
    this.calendario$ = new XRSKXptmCalendario();
  }

  save() {
    this.saveXRSKCalendario(this.calendario$);
  }

  findDetails(item) {
    return this.calendario_list.filter(x => x.cabid === item.cabid);
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
  getXRSKCalendarioList(): void {

    this.calendarioService.getXRSKXptmCalendarioList().subscribe(
      calendario_list => {
        this.calendario_list = calendario_list as XRSKXptmCalendario[];
        if (this.calendario_list.length > 0) {
            // No actualizamos primer registro
            //this.agrupacion$ = this.agrupaciones[0];
          }
          this.mdbTable.setDataSource(this.calendario_list);
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
  getXRSKCalendario(cabid: number): void {
    this.calendarioService.getXRSKXptmCalendario(cabid).subscribe(
      calendario => {
        this.calendario$ = calendario;
        this.closeProgress();
      },
      err => {
        this.showAlert(err);
      }
    );
  }

  saveXRSKCalendario(calendario: XRSKXptmCalendario) {
    this.showProgress();
    this.calendarioService.saveXRSKXptmCalendario(calendario).subscribe(
      res => {
        // Si grabamos correctamente volvemos a traer los registros
        this.getXRSKCalendarioList;
        this.closeProgress();
      },
      err => {
        this.closeProgress();
        this.showAlert(err);
      }
    );

  }

  deleteXRSKAgrupacion(calendario: XRSKXptmCalendario) {
    this.showProgress();
    this.calendarioService.deleteXRSKXptmCalendario(calendario).subscribe(
      res => {
        // Si borramos correctamente volvemos a traer los registros
        this.getXRSKCalendarioList();
        this.reset();
        this.closeProgress();
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
      this.calendario_list = this.mdbTable.getDataSource();
    }
    if (this.searchText) {
      this.calendario_list = this.mdbTable.searchLocalDataBy(this.searchText);
      this.mdbTable.setDataSource(prev);
    }

  }

  ngAfterViewInit() {
    this.mdbTablePagination.setMaxVisibleItemsNumberTo(10);

    this.mdbTablePagination.calculateFirstItemIndex();
    this.mdbTablePagination.calculateLastItemIndex();
    this.cdRef.detectChanges();
  }

}

export interface ExpandRow {
  name: string;
  position: number;
  weight: number;
  symbol: string;
  description: string;
}
