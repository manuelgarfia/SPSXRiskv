import { Component, OnInit, ViewChild, ElementRef, ChangeDetectorRef, Input } from '@angular/core';
import { MdbTableDirective, MdbTablePaginationComponent, MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { FilterPipe } from 'src/app/shared/components/pipes/filter.pipe'
import { EntidadFilter } from 'src/app/shared/components/pipes/entidadFilter.pipe'
import { DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material/core';
import { AppDateAdapter, APP_DATE_FORMATS } from '../../../shared/format/format-datepicker';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ModalgridComponent } from 'src/app/shared/components/modalgrid/modalgrid.component';
import { ModalComponent } from 'src/app/shared/components/modal/modal.component';
import { MatSelectSearchComponent } from 'src/app/shared/components/mat-select-search/mat-select-search.component'
import { DropDownComponent } from 'src/app/shared/components/drop-down/drop-down.component'

import { XRSKCBVigentes } from 'src/app/shared/models/georgina.model';
import { agrcondicionesmodel } from '../../../shared/models/agrcondiciones.model';
import { operacionmodel } from '../../../shared/models/operacion.model';
import { entidadesmodel } from '../../../shared/models/entidadmodel';
import { ciamodel } from '../../../shared/models/ciamodel'
import { cptmodel } from '../../../shared/models/contrapartidas.model'
import { condicionesbancariasmodel } from '../../../shared/models/georginaclass.model'

import { XRSKCBVService } from 'src/app/shared/services/georgina.service';
import { XRSKAgrCondicionesService } from 'src/app/shared/services/AgrCondiciones.service';
import { XRSKOperacionService } from 'src/app/shared/services/operacion.service';
import { XRSKEntidadService } from '../../../shared/services/entidad.service';
import { XRSKCIAService } from '../../../shared/services/cia.service';
import { XRSKCptService } from '../../../shared/services/contrapartidas.service';
import { filtermodel } from '../../../shared/models/filtermodel';


@Component({
  selector: 'app-gforms',
  templateUrl: './gforms.component.html',
  styleUrls: ['./gforms.component.css'],
  providers: [
    { provide: DateAdapter, useClass: AppDateAdapter },
    { provide: MAT_DATE_LOCALE, useValue: 'es-ES' },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS }
  ]
})

export class GformsComponent implements OnInit {


  @ViewChild('table_ent') mdbTable_op: MdbTableDirective;
  @ViewChild('basicModal2', { static: true }) public contentmodal;
  @ViewChild('addModal', { static: true }) public add_modal;
  @ViewChild('alert', { static: true }) alert: ElementRef;
  @ViewChild('Progress') matProgress: ElementRef;

  constructor(private CBV_Service: XRSKCBVService,
    private agrcondiciones_service: XRSKAgrCondicionesService,
    private op_service: XRSKOperacionService,
    private ent_service: XRSKEntidadService,
    private cia_service: XRSKCIAService,
    private cpt_service: XRSKCptService,
    private edit_route: ActivatedRoute,
    private _snackbar: MatSnackBar,
    public modalservice: MDBModalService,
    private router: Router,
    private cdRef: ChangeDetectorRef) {

  }

  public itemsList: any[];
  public labelAutocomplete: string;
  public companyValue:string

  ngOnInit(): void {
    this.getCompanies();
    //this.getEntidades();
    this.CBV_Service.getCBVList();
    this.agrcondiciones_service.get_agrcondiciones_list();
    this.get_combo_agrcond();
    this.edit_route.params.subscribe(params => { this.param_edit = params['param_edit']; });
    this.get_edit_item();
    this.changeTitle();


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

  //Modal
  modalRef: MDBModalRef;
  modalTitle: string;
  public modalOptionsZoom: any;
  public modalOptions: any;

  //Variables CBV
  public new_cbv$: XRSKCBVigentes;
  public new_cbv: any = [];

  searchText: string = '';
  errorText: string = 'Hi ha un error!';

  //AgrCondiciones variables
  public agr_cond$: agrcondicionesmodel;
  public agr_list: any[];

  //Operacion variables
  public operaciones$: operacionmodel;
  public op_list: any[];

  //Entidades variables
  public entidades$: entidadesmodel;
  public entidades_list: any[];

  //Class
  public condiciones_bancarias: condicionesbancariasmodel = new condicionesbancariasmodel();
  add_cond_bancaria: condicionesbancariasmodel = new condicionesbancariasmodel();

  //Compañia
  public cia$: ciamodel;
  public cia_list: any[];
  //Contrapartidas
  public cpt$: cptmodel;
  public cpt_list: any[];

 //Pipe variables
  filterPosts = '';
  entidadFilter = '';

  //Original DataBase variables
  previous: any = [];
  previous_op: any = [];


  //EDITABLE
  param_edit: string;
  edit_mode: string = null;
  edit_item: any[];
  new_item: any;

  general_array: any = []; //modal array

  public cancelOperation: boolean = false;

  // Snack Bar
  durationInSeconds = 1;

  public validatingForm: FormGroup = new FormGroup({
    acogrupo: new FormControl(''),
    company: new FormControl('', [Validators.required, Validators.maxLength(3)]),
    entidad: new FormControl('', [Validators.required, Validators.maxLength(10)]),
    fechadesde: new FormControl(''),
    operacion: new FormControl('', [Validators.required]),
    cuenta: new FormControl('', [Validators.required]),
    operacionGastos: new FormControl('', [Validators.required]),
    contrapartida: new FormControl('', [Validators.required]),
    ivaCPT: new FormControl('', [Validators.required]),
  })


  //Validators input
  get input() { return this.validatingForm.get('company'); }
  get entidad_input() { return this.validatingForm.get('entidad'); }
  get operacion_input() { return this.validatingForm.get('operacion'); }
  get cuenta_input() { return this.validatingForm.get('cuenta'); }
  get gastos_input() { return this.validatingForm.get('operacionGastos'); }
  get cpt_input() { return this.validatingForm.get('contrapartida'); }
  get cptIVA_input() { return this.validatingForm.get('ivaCPT'); }


  set_modal(array) {
    this.general_array = array;
    this.set_entity(this.modalTitle);

    this.modalRef = this.modalservice.show(ModalgridComponent, this.modalOptionsZoom);

    this.modalRef.content.propagar.subscribe((item: any) => {
      if (item) {
        this.modal_item_row(item);
      }     
    });

  }

  modal_item_row(item) {
    switch (this.modalTitle) {
      case "Entidades":
        this.condiciones_bancarias.conCodENT = item.entCod;
        break;
      case "Operaciones":
        this.condiciones_bancarias.conCodOPE = item.opeCod;
        break;
      case "Compañias":
        this.condiciones_bancarias.conCodCIA = item.ciaCod;
        break;
      case "Contrapartidas":
        this.condiciones_bancarias.conCodCPT = item.cptGrupo;
    }

  }

  public propertyName: string;
  public propertyName2: string;
  public propertyDescription: string;

  set_entity(modalTitle) {

    switch (modalTitle) {
      case "Entidades":
        this.propertyName = "entCod";
        this.propertyName2 = "entDescripcion"
        this.propertyDescription = "Descripción Entidad";
        break;
      case "Operaciones":
        this.propertyName = "opeCod";
        this.propertyName2 = "opeDescripcion"
        this.propertyDescription = "Descripción Operación";
        break;
      case "Compañias":
        this.propertyName = "ciaCod";
        this.propertyName2 = "ciaDescripcion";
        this.propertyDescription = "Codigo Compañia";
        break;
      case "Contrapartidas":
        this.propertyName = "cptGrupo";
        this.propertyName2 = "cptDescripcion";
        this.propertyDescription = "Codigo Contrapartida";
    }

    this.set_modal_options();

  }

  set_modal_options() {

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

    if (accion == "save") {
      this.modalOptions.class = 'modal-notify modal-danger';
      this.modalOptions.data = {
        heading: 'Cuidado!',
        content: { heading: 'Guardando Agrupación', description: 'Se va a guardar!' },
        afirmative: 'Continuar',
        negative: 'Cancelar'
      };
    }else if (accion == "Cancelar") {
      this.modalOptions.class = 'modal-warning';
      this.modalOptions.data = {
        heading: 'WARNING',
        content: { heading: '', description: 'Seguro que quiere cancelar la operación?' },
        afirmative: 'Sí',
        negative: 'No'
      };
    } else {
      this.modalOptions.class = 'modal-warning';
      this.modalOptions.data = {
        heading: 'Warning!',
        content: { heading: '', description: 'Añadir nuevo registro?' },
        afirmative: 'Sí',
        negative: 'No'
      };
    }

    this.modalRef = this.modalservice.show(ModalComponent, this.modalOptions)

    this.modalRef.content.action.subscribe((confirm: any) => {
      if (confirm) {
        if (accion == "edit") {
          //this.save();
        }
        if (accion == "add") {
          this.add_item();
        }
        if (accion == "Cancelar") {
          this.router.navigate(['/georgina']);
        }
      }
    }
    );
  }

  //SNACK BAR
  openSnackBar(message: string, action: string) {
    this._snackbar.open(message, action, {
      duration: this.durationInSeconds * 3000,
    });
  }

  public itemValue: string;
  get_edit_item() {
    if (this.param_edit != null) {
      this.condiciones_bancarias = this.CBV_Service.get_item();
      this.itemValue = this.condiciones_bancarias.conCodCIA;
    }
  }

  receiveCIA(valorCIA) {
   // console.log(valorCIA);
    this.condiciones_bancarias.conCodCIA = valorCIA;
  }

  add_item() {
    this.add_cond_bancaria = this.set_add_item();
    this.add_condicion_bancaria(this.add_cond_bancaria);
  }

  set_add_item(): condicionesbancariasmodel {
    return this.condiciones_bancarias;
  }

  add_condicion_bancaria(cond_banc: condicionesbancariasmodel) {
    this.CBV_Service.saveXRSKCBV(cond_banc).subscribe(
      res => {
        this.get_cbv();
        this.openSnackBar("Registro insertado", "Ok");
        this.validatingForm.reset();
        this.add_modal.hide();
      },
      err => {
        this.showAlert();
      }
    );

  }

  title_name: string = null;
  warning_message: string;
  button_name: string;

  changeTitle() { 
    if (this.param_edit != null) {
      this.title_name = "Editar Condicion Bancaria";
      this.warning_message = "Guardar cambios?";
      this.button_name = "Guardar"

    } else {
      this.title_name = "Nueva Condicion Bancaria";
      this.warning_message = "Seguro que quieres añadir un nuevo registro?"
      this.button_name = "Añadir"
    }
  }


  //Get Grupo Condiciones List
  get_combo_agrcond(): void {
    this.agrcondiciones_service.get_agrcondiciones_list().subscribe(
      combo_agrcond => {
        this.agr_list = combo_agrcond as agrcondicionesmodel[];
        if (this.agr_list.length > 0) {
          this.agr_cond$ = this.agr_list[0];
        }
      },
      err => {
        this.errorText = err;
      }
    );
  }

  //Get Cia list
  get_cia(): void {

    this.modalTitle = "Compañias";
    this.cia_service.get_cia_list().subscribe(
      cia_list => {
        this.cia_list = cia_list as ciamodel[];
        if (this.cia_list.length > 0) {
          this.cia$ = this.cia_list[0];
        }
        this.set_modal(this.cia_list);
      },
      err => {
        this.errorText = err;
      }
    );
  }


  getCompanies(): void {
    this.cia_service.get_cia_filter().subscribe(
      cia_list => {
        this.cia_list = cia_list as filtermodel[];
        this.itemsList = this.cia_list;
        this.labelAutocomplete = "Compañia";
      },
      err => {
        this.errorText = err;
        this.showAlert();
      }
    );
  }

  getEntidades(): void {
    this.ent_service.get_entidades_filter().subscribe(
      entidadesList => {
        this.entidades_list = entidadesList as filtermodel[];
        this.itemsList = this.entidades_list;
        this.labelAutocomplete = "Entidad";
      },
      err => {
        this.errorText = err;
        this.showAlert();
      }
    );
  }

  //Get Entidades list
  get_cpt(): void {

    this.modalTitle = "Contrapartidas";

    this.cpt_service.get_cpt_list().subscribe(
      cpt_list => {
        this.cpt_list = cpt_list as cptmodel[];
        if (this.cpt_list.length > 0) {
          this.cpt$ = this.cpt_list[0];
        }
        this.set_modal(this.cpt_list);
      },
      err => {
        this.errorText = err;
      }
    );
  }

  //Get Entidades list
  get_entidades(): void {

    this.modalTitle = "Entidades"

    this.ent_service.get_entidades_list().subscribe(
      entidades_list => {
        this.entidades_list = entidades_list as entidadesmodel[];
        if (this.entidades_list.length > 0) {
          this.entidades$ = this.entidades_list[0];
        }
        this.set_modal(this.entidades_list);
      },
      err => {
        this.errorText = err;
      }
    );
  }

  //Get Operaciones list
  get_operaciones(): void {
    this.modalTitle = "Operaciones";

    this.op_service.get_operacion_list().subscribe(
      op_list => {
        this.op_list = op_list as operacionmodel[];
        if (this.op_list.length > 0) {
          this.operaciones$ = this.op_list[0];
        }

        this.set_modal(this.op_list);
      },
      err => {
        this.errorText = err;
      }
    );
  }

  //obtenir la llista CBV
  get_cbv(): void {
    this.CBV_Service.getCBVList().subscribe(
      new_cbv => {
        this.new_cbv = new_cbv as condicionesbancariasmodel[];
        if (this.new_cbv.length > 0) {
          this.new_cbv$ = this.new_cbv[0];
        }
      },
      err => {
        this.errorText = err;
      }
    );
  }


  showAlert() {
    this.alert.nativeElement.classList.remove('collapse');
    this.alert.nativeElement.classList.add('show');
  }

  closeAlert() {
    this.alert.nativeElement.classList.remove('show');
    this.alert.nativeElement.classList.add('collapse');
  }

  ngAfterViewInit() {
    this.cdRef.detectChanges();
  }

}
