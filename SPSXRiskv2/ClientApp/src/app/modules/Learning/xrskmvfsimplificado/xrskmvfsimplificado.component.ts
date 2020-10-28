import { Component, OnInit, ElementRef, ChangeDetectorRef, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { from } from 'rxjs';
import { MdbTableDirective, MdbTablePaginationComponent, ModalDirective, CollapseComponent, ModalModule, WavesModule, InputsModule } from 'angular-bootstrap-md';
import { MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { XRSKMvfSimplificadoService } from 'src/app/shared/services/xrskMvfSimplificado.service';
import { xrskmvfsimplificado, movsimplificado } from 'src/app/shared/models/XRSKMVFSimplificado.model'
import { xrskcontratos } from 'src/app/shared/models/xrskContratos.model';
import { XRSKCIAService } from '../../../shared/services/cia.service';
import { filtermodel, filtermodelArray } from '../../../shared/models/filtermodel';
import { DatePipe } from '@angular/common';
import { ModalComponent } from 'src/app/shared/components/modal/modal.component';
import { FilterHeader, FilterDetail } from 'src/app/shared/models/filtermodel';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, ThemePalette } from '@angular/material/core';
import { AppDateAdapter, APP_DATE_FORMATS } from 'src/app/shared/format/format-datepicker';
import { ciamodel } from '../../../shared/models/ciamodel';
import { ModalgridComponent } from 'src/app/shared/components/modalgrid/modalgrid.component';
import { XRSKContratosService } from '../../../shared/services/xrskContratos.service';
import { XRSKClavesPrevisionesService } from '../../../shared/services/xrskClavesPrevisiones.service';
import { clavesprevisionesmodelclass } from '../../../shared/models/clavesprevisiones.model';


@Component({
  selector: 'app-xrskmvfsimplificado',
  templateUrl: './xrskmvfsimplificado.component.html',
  styleUrls: ['./xrskmvfsimplificado.component.css'],
  providers: [
    { provide: DateAdapter, useClass: AppDateAdapter },
    { provide: DatePipe },
    { provide: MAT_DATE_LOCALE, useValue: 'es-ES' },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS }
  ]
})
export class XRSKMVFSimplificadoComponent {
  //@ViewChild(MdbTableDirective, { static: true }) mdbTable: MdbTableDirective;
  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  //@ViewChild('tableE1') mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild('alert', { static: true }) alert: ElementRef;
  @ViewChild('Progress') matProgress: ElementRef;
  @ViewChild('GridView') GridView: ElementRef;




  //variables
  public validatingForm: FormGroup = new FormGroup(
    {
      contrato: new FormControl(''),
      Fecha: new FormControl('')
    });

  get inputCompany() { return this.validatingForm.get('compañia'); }
  get inputContratos() { return this.validatingForm.get('contratos');}

  public mvfSimplificado: movsimplificado = new movsimplificado();
 // public mvfSimplificado2: movsimplificado = new movsimplificado();

   
  closeProgress() {
    //this.matProgress.nativeElement.classList.remove('show');
    //this.matProgress.nativeElement.classList.add('collapse');
  }
  showAlert() {
    //this.alert.nativeElement.classList.remove('collapse');
    //this.alert.nativeElement.classList.add('show');
    
  }

  // Declarations



  public movsimplificado: any = [];
  public modalOption: any;
  public previous: any = [];
  errorText: string = 'Hay un error';
  //public addNewRecord :string ="vista";
  public addNewRecord: boolean = false;

  public itemsList: any[];
  public labelAutocomplete: string;

  //MOdals

  modalTitle: string;
  modalRef: MDBModalRef;

  public modalOptionsZoom: any;
  public modalOptions: any;

  //Compañia
  public cia_list: any[];
  public contrat_list: any[];
  public claves_list: any[];
  public selectorCompanyias: filtermodelArray = new filtermodelArray();

  public mvfCodCIACtrl: FormControl = new FormControl();
  public mvfCodCIAFilterCtrl: FormControl = new FormControl();

  public selectedItems: string[] = [];
  public selectedFilter: FilterHeader = new FilterHeader();
  public movFisSimEdit: movsimplificado = new movsimplificado();
  public addMovFisSimpl: movsimplificado =new movsimplificado();

  general_array: any = []; //modal array

  // Constructor Area
  constructor(
    private xrskmvfSimplificadoService: XRSKMvfSimplificadoService,
    cdREF: ChangeDetectorRef,
    private modalService: MDBModalService,
    private cia_service: XRSKCIAService,
    private claves_service: XRSKClavesPrevisionesService,
    private contrat_service:XRSKContratosService,
    public datepipe: DatePipe) { }

  ngOnInit(): void {

    this.getXrskMvfSimplificadoList();
    //this.getContratos();

    //this.mvfSimplificado2.mvfCodCIA = '';
    
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
    }
  }

   
  set_modal(array) {
    this.general_array = array;
    this.set_entity(this.modalTitle);

    this.modalRef = this.modalService.show(ModalgridComponent, this.modalOptionsZoom);

    this.modalRef.content.propagar.subscribe((item: any) => {
      if (item) {
        this.modal_item_row(item);
      }
    });

  }

  modal_item_row(item) {
    switch (this.modalTitle) {
      case "Compañias":
        this.addMovFisSimpl.mvfCodCIA = item.ciaCod;
        break;
      case "Contratos":
        this.addMovFisSimpl.MVFCodCta = item.code;
        break;
      case "Claves Prevision":
        this.addMovFisSimpl.ClavePrevision = item.prvClave;
    }


  }

  public propertyName: string;
  public propertyName2: string;
  public propertyDescription: string;


  set_entity(modalTitle) {

    switch (modalTitle){

      case "Compañias":
        this.propertyName = "ciaCod";
        this.propertyName2 = "ciaDescripcion";
        this.propertyDescription = "Descripción Compañia";
        break;
      case "Contratos":
        this.propertyName = "code";
        this.propertyName2 = "description";
        this.propertyDescription = "Descripción Contrato";
        break;

      case "Claves Prevision":
        this.propertyName = "prvClave";
        this.propertyName2 = "description";
        this.propertyDescription="Clave Prevision"
    }
    this.set_modal_options();
  }

  set_modal_options()
  {
    this.modalOptionsZoom = {
      data: {
        heading: this.modalTitle,
        items: this.general_array,
        properties: [{ name: this.propertyName, label: "Código" }, { name: this.propertyName2, label: this.propertyDescription }]
      }
    };

  }

  //Basic modal

  openDialog(accion: string) {

    if (accion == "add") {
      this.modalOptions.class = 'modal-warning';
      this.modalOptions.data = {
        heading: 'Cuidado!',
        content: { heading: 'Guardando....', description: 'Se va a Añadir nuevo registro?!' },
        afirmative: 'Continuar',
        negative: 'Cancelar'
      };
    } else if (accion == "Cancelar") {
      this.modalOptions.class = 'modal-warning';
      this.modalOptions.data = {
        heading: 'WARNING',
        content: { heading: '', description: 'Seguro que quiere cancelar la operación?' },
        afirmative: 'Sí',
        negative: 'No'
      };
   
    }

    this.modalRef = this.modalService.show(ModalComponent, this.modalOptions)

    this.modalRef.content.action.subscribe((confirm: any) => {
      if (confirm) {
      
        if (accion == "add") {
          this.addItem();
        }
        if (accion == "Cancelar") {
          this.showHidePanels();
        }
      } 
    }
    );
  }



  addItem() {
    
    //this.addMovFisSimpl.MVFFechOperac;
    this.addMovFisSimpl.MVFFechImp = this.addMovFisSimpl.MVFFechOperac;
    this.addMovFisSimpl.MVFFechValor = this.addMovFisSimpl.MVFFechOperac;
    this.add_Mov_Fis_Simplifi(this.addMovFisSimpl);
    this.showHidePanels();
  }

  add_Mov_Fis_Simplifi(movimiento: movsimplificado) {
    this.xrskmvfSimplificadoService.saveXRSKMVFSimplificado(movimiento).subscribe(
      mov => {
        this.getXrskMvfSimplificadoList();

      }
    )
  }

  showHidePanels() {
    if (this.addNewRecord) {
      this.addNewRecord = false;
    } else {
      this.addNewRecord = true;
      this.getXrskMvfSimplificadoList();
    }
  }

  //Get List
  getXrskMvfSimplificadoList(): void {
    this.xrskmvfSimplificadoService.getXRSKMVFSimplificadoList().subscribe(
      movsimplificado => {
        this.movsimplificado = movsimplificado as xrskmvfsimplificado[];
        if (this.movsimplificado.length > 0) {
          this.mdbTable.setDataSource(this.movsimplificado);
          this.previous = this.mdbTable.getDataSource();
        }
      },
      err => {
        this.closeProgress();
        this.showAlert();
      }
    );
  }

  public itemValue: string;
 


  edit(item) {
    this.movFisSimEdit = Object.assign({}, item);
    this.addNewRecord = true;
    this.GridView.nativeElement.classList.remove('visible');
    this.GridView.nativeElement.classList.add('invisible');
  } //edit


  getContratos(): void {
      this.getContratosCIA(this.addMovFisSimpl.mvfCodCIA);
  }
  getClaves(): void {
    this.getClavesPrevision(this.addMovFisSimpl.mvfCodCIA);
  }

  getContratosCIA (mvfCodCIA: string): void {
    this.modalTitle = "Contratos";
    this.contrat_service.getXRSKContratos(mvfCodCIA).subscribe(
      contrat_list => {
        this.contrat_list = contrat_list as unknown as xrskcontratos[];
        if (this.contrat_list.length > 0) {
          this.set_modal(this.contrat_list);
        }

      },
      err => {
        this.errorText = err;
      }
    );
  }

  getClavesPrevision(mvfCodCIA: string): void {
    this.modalTitle = "Claves Prevision";
    this.claves_service.getClaves(mvfCodCIA).subscribe(
      claves_list => {
        this.claves_list = claves_list as clavesprevisionesmodelclass[];
        if (this.claves_list.length > 0) {

        }
        this.set_modal(this.claves_list);
      }
    )


  }


  getCia(): void {

    this.modalTitle = "Compañias";
    this.cia_service.get_cia_list().subscribe(
      cia_list => {
        this.cia_list = cia_list as ciamodel[];
        if (this.cia_list.length > 0) {
         
        }
        this.set_modal(this.cia_list);
      },
      err => {
        this.errorText = err;
      }
    );
  }





}
