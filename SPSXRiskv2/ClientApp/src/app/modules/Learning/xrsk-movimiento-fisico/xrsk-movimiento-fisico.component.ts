import { Component, OnInit, HostListener, ViewChild, ChangeDetectorRef, ElementRef } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { from } from 'rxjs';
import { MdbTableDirective, MdbTablePaginationComponent, ModalDirective, CollapseComponent, ModalModule, WavesModule, InputsModule } from 'angular-bootstrap-md';
import { XRSKMovimientoFisico } from 'src/app/shared/models/xrskMovimientoFisico.model';
import { XRSKDesgloseContr } from 'src/app/shared/models/xrskDesgloseContr.model';
import { operacionmodel } from '../../../shared/models/operacion.model';
import { XRSKEfectos } from 'src/app/shared/models/xrskEfectos.model';
import { cptmodel } from '../../../shared/models/contrapartidas.model';

import { filtermodel, filtermodelArray } from 'src/app/shared/models/filtermodel';
import { FilterHeader, FilterDetail } from 'src/app/shared/models/filtermodel';
import { SideFilterComponent } from 'src/app/shared/components/side-filter/side-filter.component';

import { XRSKMovimientoFisicoService } from 'src/app/shared/services/xrskMovimientoFisico.service';
import { XRSKCIAService } from 'src/app/shared/services/cia.service';
import { XRSKEntidadService } from 'src/app/shared/services/entidad.service';
import { XRSKContratosService } from 'src/app/shared/services/xrskContratos.service';
import { XRSKOperacionService } from 'src/app/shared/services/operacion.service';
import { xrskCertezas } from 'src/app/shared/services/xrskCertezas.service';
import { ExcelService } from 'src/app/core/services/excel.service';
import { XRSKDesgloseContrService } from 'src/app/shared/services/xrskDesgloseContr.service'
import { XRSKEfectosService } from '../../../shared/services/xrskEfectos.service';
import { XRSKCptService } from '../../../shared/services/contrapartidas.service';

import { MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { ModalComponent } from 'src/app/shared/components/modal/modal.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, ThemePalette } from '@angular/material/core';
import { AppDateAdapter, APP_DATE_FORMATS } from 'src/app/shared/format/format-datepicker';
import { Router, ActivatedRoute } from '@angular/router';
import { ModalgridComponent } from '../../../shared/components/modalgrid/modalgrid.component';



@Component({
  selector: 'app-xrsk-movimiento-fisico',
  templateUrl: './xrsk-movimiento-fisico.component.html',
  styleUrls: ['./xrsk-movimiento-fisico.component.css'],
  providers: [
    { provide: DateAdapter, useClass: AppDateAdapter },
    { provide: MAT_DATE_LOCALE, useValue: 'es-ES' },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS }
  ]

})
export class XRSKMovimientoFisicoComponent {
  //@ViewChild(MdbTableDirective, { static: true }) mdbTable: MdbTableDirective;
  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  //@ViewChild('tableE1') mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild('alert', { static: true }) alert: ElementRef;
  @ViewChild('Progress') matProgress: ElementRef;
  @ViewChild('GridView') GridView: ElementRef;

  //#basicModal

  validatingForm: FormGroup;
  modalRef: MDBModalRef;
  modalResult: Boolean;  

  public objectName: string;
  public modalOptions: any;
  public movimiento$: XRSKMovimientoFisico;
  public movimientos: any = [];
  public movimientoEdit: XRSKMovimientoFisico;
  public movFisicoEdit: XRSKMovimientoFisico = new XRSKMovimientoFisico();
  public selectorCompanyias: filtermodelArray = new filtermodelArray();
  public selectorEntidades: filtermodelArray = new filtermodelArray();
  public selectorContratos: filtermodelArray = new filtermodelArray();
  public selectorCertezas: filtermodelArray = new filtermodelArray();
  public selectorEstadosConciliacion: filtermodelArray = new filtermodelArray();

  // Preferencias
  public FechaDesde: Date;
  public FechaHasta: Date;
  public showDateSelection: Boolean;
  public selectedDateType: string;
  //public selectedCompañias: string[] = [];
  public selectedItems: string[] = [];
  public selectedFilter: FilterHeader = new FilterHeader();

  searchText: string = '';
  errorText: string = 'Hay un error';
  previous: any = [];
  preferences: any;

  // JCS Webinar (Després esborrar)
  esEfectos: boolean = true;
  public efectos: any[] = [];

  // Progress Bar values
  color = 'primary';
  mode = 'indeterminate';
  value = 50;
  bufferValue = 75;

  // Snack Bar
  durationInSeconds = 1;

  //Tooltip
  public preferencesOn: boolean = false;
  tooltipPreferences: any = [];

  public selectOptions: any[] = ["Exportar a Excel", "Exportar a Csv", "Exportar a PDF"];
  public compareSign: string;
  public import: number;

  // Mode
  editMode: boolean = false;
  viewMode: boolean = false;
  background: ThemePalette = "primary";
  public itemValue: string;

  //Pintar Rows
  public selectedRowIds: Set<XRSKMovimientoFisico> = new Set<XRSKMovimientoFisico>();
  public selectedRowItem: XRSKMovimientoFisico;

  //Desglose
  public desglose: any[] = [];

  //de apuntes bancarios a movfisico
  public referencia: number;
  public company: string;

  //MODALS
  public modalTitle: string;
  public modalOptionsZoom: any;
  public modalItems: any = []; //modal array
  public propertyName: string;
  public propertyName2: string;
  public propertyDescription: string;

  public operaciones: any[] = [];
  public contrapartidas: any[] = [];

  public mvfCodCIACtrl: FormControl = new FormControl();
  public mvfCodCIAFilterCtrl: FormControl = new FormControl();

  public gradoCerteza: any[] = ['C', 'A', 'P'];

  constructor(private movimientoFisicoService: XRSKMovimientoFisicoService, private cdRef: ChangeDetectorRef, private modalService: MDBModalService,
    public ciaService: XRSKCIAService, public entService: XRSKEntidadService, private certService: xrskCertezas, private contService: XRSKContratosService,
    private _snackBar: MatSnackBar, public excelService: ExcelService, private desgloseService: XRSKDesgloseContrService, private route: Router,
    private efectosService: XRSKEfectosService, private ruta: ActivatedRoute, private operacionService: XRSKOperacionService, private cptService: XRSKCptService) {

  }

  @HostListener('input') oninput() {
    this.searchItems();
  }

  ngOnInit() {

    this.getPreferences();

    this.ruta.params.subscribe(params => {
      this.editMode = params['editMode'];
      this.referencia = params['mvfRefXrisk'];
      this.company = params['mvfCodCIA']
    })

    if (this.referencia != null) {
      this.getRegister();
      this.getDesglose(this.company, this.referencia);
      this.getEfectosMovimiento(this.referencia);
    }

    this.objectName = "Movimientos Físicos";
    this.showDateSelection = false;
    //this.editMode = false;
    

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

    
    // Obtención de los datos a partir de objeto de filtro (Leido de preferencias o de modal de filtro)

    // Obtención de datos para el filtro lateral
    this.getSelectorCompañias();
    this.getSelectorEntidades();
    this.getSelectorContratos();
    this.getSelectorCertezas();
    this.getSelectorEstadosConciliacion();

    this.validatingForm = new FormGroup({
      mvfCodCIACtrl: new FormControl(null, [Validators.required]),
      mvfImBrDivisa: new FormControl(null, [Validators.required, Validators.min(0), Validators.max(999999)]),
    }); 
  }

  get input() { return this.validatingForm.get('maxLength'); }

  refresh() {
    this.showProgress();
    this.getXRSKMovimientosLisRange(this.selectedFilter);
  }

  closeAlert() {
    this.alert.nativeElement.classList.remove('show');
    this.alert.nativeElement.classList.add('collapse');
  }

  itemCreateClick() {
    this.editMode = true;
    this.GridView.nativeElement.classList.remove('visible');
    this.GridView.nativeElement.classList.add('invisible');
  }

  update(val: number) {
    this.movFisicoEdit.mvfImNetDiv = val;
    //this.cdMsgChange.emit(this.cdMsg);
  }

  goToPolizas() {
    this.route.navigate(['polizas/' + this.movFisicoEdit.mvfCodCIA + '/' + this.movFisicoEdit.mvfCodCTA]);
  }

  formEditSubmit() {

    this.validatingForm.controls;
    if (this.validatingForm.invalid) {
      this.validatingForm.setErrors({ ...this.validatingForm.errors, 'yourErrorName': true });
      return;
    }

    this.editMode = false;
    this.GridView.nativeElement.classList.remove('invisible');
    this.GridView.nativeElement.classList.add('visible');

  }

  cancelSubmitClick() {
    this.editMode = false;
  }

  edit(movimiento) {
    this.onRowClick(movimiento);
    this.movFisicoEdit = Object.assign({}, movimiento);
    this.getDesglose(this.movFisicoEdit.mvfCodCIA, this.movFisicoEdit.mvfRefXRisk);
    this.editMode = true;
    this.viewMode = false;//campos editables
  } //edit

  view(movimiento) {
    this.onRowClick(movimiento);
    this.movFisicoEdit = Object.assign({}, movimiento);
    this.getDesglose(this.movFisicoEdit.mvfCodCIA, this.movFisicoEdit.mvfRefXRisk);
    this.viewMode = true;
    this.editMode = true;
  } //edit

  onRowClick(item) {
    this.selectedRowItem = item;

    //Si ja hi ha un seleccionat, seleccionar el nou registre
    if (this.selectedRowIds != null) {
      for (let item of this.selectedRowIds) {
        this.selectedRowIds.delete(item);
      }
    }

    if (!this.selectedRowIds.has(this.selectedRowItem)) {
      this.selectedRowIds.add(this.selectedRowItem);
    }
    else {
      this.selectedRowIds.delete(this.selectedRowItem);
    }
  }

  rowIsSelected(id: XRSKMovimientoFisico) {
    return this.selectedRowIds.has(id);
  }


  receiveCIA(valorCIA) {
    console.log(valorCIA);
    this.movimientoEdit.mvfCodCIA = valorCIA;
  }


  exportAsXLSX(option: string): void {
    if (option == 'Exportar a Excel') {
      this.excelService.exportAsExcelFile(this.movimientos, 'sample');
    }
  }

  showAlert(alert: string) {
    this.errorText = alert;
    this.alert.nativeElement.classList.remove('collapse');
    this.alert.nativeElement.classList.add('show');
  }

  closeProgress() {
  //  this.matProgress.nativeElement.classList.remove('show');
  //  this.matProgress.nativeElement.classList.add('collapse');
  }

  showProgress() {
    this.matProgress.nativeElement.classList.remove('collapse');
    this.matProgress.nativeElement.classList.add('show');
  }

  openDialog(accion: string) {

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
        // Pendiente
      }
    }
    );

  }

  toggleDateSelection() {
    if (this.showDateSelection==true) {
      this.showDateSelection = false;
    } else {
      this.showDateSelection = true;
    }
  }

  doDateSelection() {

    this.selectedFilter.add(new FilterDetail("F.Operacion", "MVFFechOperac", "date","range", null, null, null,null,null, this.FechaDesde, this.FechaHasta, null));
    // Obtener los datos
    this.fetchSelection();

    // Cerrar la selección
    this.toggleDateSelection();
  }

  // Save Preferences

  savePreferences() {
    this.preferences = { "selectedDateType": this.selectedDateType, "fromDate": this.FechaDesde, "toDate": this.FechaHasta, "filter": this.selectedFilter }
    localStorage.setItem('MVFPreferences', JSON.stringify(this.preferences));
  }

  getPreferences() {
    this.preferences = JSON.parse(localStorage.getItem('MVFPreferences'));
    if (this.preferences != null) {
      this.preferencesOn = true;
      this.setTooltip();
      this.selectedDateType = this.preferences.selectedDateType;
      this.FechaDesde = new Date(this.preferences.fromDate);
      this.FechaHasta = new Date(this.preferences.toDate);
      //this.selectedCompañias = this.preferences.selectedCompañias;
      // Asignación de un objeto de LocalStorage a una clase tipada con métodos. Si no se hace así no reconoce el tipo y declara un Object genérico en lugar de FilterHeader
      Object.assign(this.selectedFilter, this.preferences.filter);

    } else {
      this.selectedDateType = "O";  // Operación
      this.FechaHasta = new Date();
      this.FechaDesde = new Date();
      this.FechaDesde.setDate(this.FechaHasta.getDate() - 30);
      // Si no hubiera preferencias hacemos un filtro basado en la selección por defecto del componente.
      this.setDefaultFilter();
    }
  }

  public setDefaultFilter() {

    this.selectedFilter.add(new FilterDetail("Compañías", "MVFCodCIA", "items", null, null, null, null, null, null, null, null, null));
    this.selectedFilter.add(new FilterDetail("F.Operacion", "MVFFechOperac", "date", "range", null, null, null, null, null, this.FechaDesde, this.FechaHasta, null));
    this.selectedFilter.add(new FilterDetail("Importe Divisa", "MVFImBrDivisa", "number", ">=", null, null, 0, null, null, null, null, null));
    this.selectedFilter.add(new FilterDetail("Entidad", "MVFCodENT", "items", null, null, null, null, null, null, null, null, null));    
    this.selectedFilter.add(new FilterDetail("Referencia XRisk", "MVFRefXRisk", "string", "contains", null, "", null, null, null, null, null, null));
    this.selectedFilter.add(new FilterDetail("Contrato", "MVFCodCTA", "items", null, null, null, null, null, null, null, null, null));
    this.selectedFilter.add(new FilterDetail("Grado de Certeza", "MVFGradCert", "items", null, null, null, null, null, null, null, null, null));
    this.selectedFilter.add(new FilterDetail("Estado", "MVFConciliado", "items", null, null, null, null, null, null, null, null, null));
  }

  setTooltip() {
    this.tooltipPreferences = this.preferences.filter.detail;
  }

  // Get List for Table
  getXRSKMovimientosLisRange(filter: FilterHeader): void {

    this.movimientoFisicoService.getXRSKMovimientoFisicoFilter(filter).subscribe(
      movimientos => {
        this.movimientos = movimientos as XRSKMovimientoFisico[];
        if (this.movimientos.length > 0) {
        }
        this.mdbTable.setDataSource(this.movimientos);
        this.previous = this.mdbTable.getDataSource();
        this.closeProgress();
      },
      err => {
        this.closeProgress();
        this.showAlert(err);

      }
    );
  }

  add() {
    //this.saveXRSKAgrupacion(this.agrupacion$);
  }

  reset() {
    // Reset main entity
    //this.agrupacion$ = new XRSKAgrupacion();
  }

  save() {
    //this.saveXRSKAgrupacion(this.agrupacion$);
  }

  //Filter
  filterClick() {
    
    this.modalOptions = {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: true,
      ignoreBackdropClick: false,
      class: 'modal-full-height modal-dialog-scrollable modal-right',
      animated: true,
      data: {
        heading: 'Filtro',
        items: this.selectedFilter.detail,
      }
    }

    this.modalRef = this.modalService.show(SideFilterComponent, this.modalOptions);

    this.modalRef.content.confirmAction.subscribe((number: any) => {
      switch (number) {
        case "1":
          localStorage.setItem("MVFPreferences", null);
          break;
        case "2":
          this.modalRef.hide();
          break;
        case "3":
          this.modalRef.hide();
          break;
      }
    })

    //Es reben els items seleccionats del checkbox
    this.modalRef.content.sendItems.subscribe((items: any) => {
      if (items) {

        this.selectedFilter.detail = items;
        this.fetchSelection();
      }
    }
    );
  }

  fetchSelection() {
    // Actualizar los datos
    this.getXRSKMovimientosLisRange(this.selectedFilter);
    // Save Preferences
    this.savePreferences();
  }

  getSelectorCompañias(): void {
    this.ciaService.get_cia_filter().subscribe(
      cia_list => {
        this.selectorCompanyias.detail = cia_list as filtermodel[];

        this.selectedItems = this.selectedFilter.detail.find(x => x.entity == "MVFCodCIA").values;
        if (this.selectedItems != null) {
          this.selectorCompanyias.markChecked(this.selectedItems);
        }
        this.selectedFilter.detail.find(x => x.entity == "MVFCodCIA").content = this.selectorCompanyias.detail;

      },
      err => {
        this.errorText = err;
        this.showAlert(this.errorText);
      }
    );
  }

  getSelectorEntidades(): void {
    this.entService.get_entidades_filter().subscribe(
      ent_list => {

        this.selectorEntidades.detail = ent_list as filtermodel[];
        this.selectedItems = this.selectedFilter.detail.find(x => x.entity == "MVFCodENT").values;
        if (this.selectedItems != null) {
          this.selectorEntidades.markChecked(this.selectedItems);
        }
        this.selectedFilter.detail.find(x => x.entity == "MVFCodENT").content = this.selectorEntidades.detail;

      },
      err => {
        this.errorText = err;
        this.showAlert(this.errorText);
      }
    );
  }

  // Nos traemos los datos de los contratos para una Compañía
  getSelectorContratos() {
    this.contService.get_cia_filter().subscribe(
      contratos => {
        this.selectorContratos.detail = contratos as filtermodel[];
        this.selectedItems = this.selectedFilter.detail.find(x => x.entity == "MVFCodCTA").values;
        if (this.selectedItems != null) {
          this.selectorContratos.markChecked(this.selectedItems);
        }
        this.selectedFilter.detail.find(x => x.entity == "MVFCodCTA").content = this.selectorContratos.detail;
      },
      err => {
        this.errorText = err;
        this.showAlert(this.errorText);
      }
    );
  }

  getSelectorCertezas() {

    this.certService.get_certezas_filter().subscribe(
      certezas => {
        this.selectorCertezas.detail = certezas as filtermodel[];
        this.selectedItems = this.selectedFilter.detail.find(x => x.entity == "MVFGradCert").values;
        if (this.selectedItems != null) {
          this.selectorCertezas.markChecked(this.selectedItems);
        }
        this.selectedFilter.detail.find(x => x.entity == "MVFGradCert").content = this.selectorCertezas.detail;
      },
      err => {
        this.errorText = err;
        this.showAlert(this.errorText);
      }
    )

    //this.selectorCertezas.detail = [{ code: 'A', description: 'Contabilizado', checked: false },
    //  { code: 'C', description: 'Cierto', checked: false },
    //  { code: 'P', description: 'Provisorio', checked: false },
    //  { code: 'R', description: 'Relacionado', checked: false },
    //  { code: 'S', description: 'Estimado', checked: false },
    //  { code: 'W', description: 'W', checked: false },
    //] as filtermodel[];
    
  }

  getSelectorEstadosConciliacion() {

    this.selectorEstadosConciliacion.detail = [{ code: 'PE', description: 'Pendiente', checked: false },
      { code: 'A3', description: 'A3', checked: false },
      { code: 'DE', description: 'DE', checked: false },
      { code: 'CO', description: 'CO', checked: false },
      { code: 'A2', description: 'A2', checked: false },
      { code: 'MA', description: 'MA', checked: false },
      { code: 'IM', description: 'IM', checked: false },
      { code: 'IA', description: 'IA', checked: false },
      { code: 'A1', description: 'A1', checked: false },
      { code: 'G1', description: 'G1', checked: false },
      { code: 'G3', description: 'G3', checked: false },
    ] as filtermodel[];
    this.selectedItems = this.selectedFilter.detail.find(x => x.entity == "MVFConciliado").values;
    if (this.selectedItems != null) {
      this.selectorEstadosConciliacion.markChecked(this.selectedItems);
    }
    this.selectedFilter.detail.find(x => x.entity == "MVFConciliado").content = this.selectorEstadosConciliacion.detail;
  }

  getEfectosMovimiento(movimiento: number) {
    this.efectosService.getXRSKEfectosMovimiento(movimiento).subscribe(
      efectos => {
        this.efectos = efectos as XRSKEfectos[];
      },
      err => {
        //this.showAlert(err);
      }
    );
  }

  // Local search in table
  searchItems() {
    const prev = this.mdbTable.getDataSource();
    if (!this.searchText) {
      this.mdbTable.setDataSource(this.previous);
      this.movimientos = this.mdbTable.getDataSource();
    }
    if (this.searchText) {
      this.movimientos = this.mdbTable.searchLocalDataBy(this.searchText);
      this.mdbTable.setDataSource(prev);
    }

  }

  ngAfterViewInit() {

    this.getXRSKMovimientosLisRange(this.selectedFilter);

    this.mdbTablePagination.setMaxVisibleItemsNumberTo(8);

    this.mdbTablePagination.calculateFirstItemIndex();
    this.mdbTablePagination.calculateLastItemIndex();
    this.cdRef.detectChanges();
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: this.durationInSeconds * 1000,
    });
  }

  //Desglose
  getDesglose(company:string, referencia: number) {
    this.desgloseService.getXRSKDesgloseList(company, referencia).subscribe(
      apunBanc => {
        this.desglose = apunBanc as XRSKDesgloseContr[];
       // this.mdbTable.setDataSource(this.apunBanc);
      },
      err => {
        console.log(err);
      }
    );
  }


  onRowDesglose(item) {
    this.desgloseService.desgloseFromMovFisico(item, this.movFisicoEdit);
    this.route.navigate(['desglose']);
  }

  getRegister() {

    this.movimientoFisicoService.getXRSKMovimientoFisicoRegister(this.company, this.referencia).subscribe(
      movFisicoReg => {
        this.movFisicoEdit = movFisicoReg as XRSKMovimientoFisico;
      },
      err => {
        console.log(err);
      }

    )
  }

  //MODALS

  getOperacion() {
    this.modalTitle = "Operaciones";

    this.operacionService.get_operacion_list().subscribe(
      op_list => {
        this.operaciones = op_list as operacionmodel[];
        this.propertyName = "opeCod";
        this.propertyName2 = "opeDescripcion"
        this.propertyDescription = "Descripción Operación";
        this.set_modal_options(this.operaciones);
        this.openModal();

      },
      err => {
        this.errorText = err;
      }
    );
  }

  getContrapartida() {
    this.modalTitle = "Contrapartida";

    this.cptService.get_cpt_list().subscribe(
      contrapartidas => {
        this.contrapartidas = contrapartidas as cptmodel[];
        this.propertyName = "cptGrupo";
        this.propertyName2 = "cptDescripcion"
        this.propertyDescription = "Codigo Contrapartida";
        this.set_modal_options(this.contrapartidas);
        this.openModal();
      },
      err => {
        this.errorText = err;
      }
    );
  }

  openModal() {
    this.modalRef = this.modalService.show(ModalgridComponent, this.modalOptionsZoom);
    this.modalRef.content.propagar.subscribe((item: any) => {
      if (item) {
        this.modal_item_row(item);
      }
    });
  }


  set_modal_options(array) {
    this.modalItems = array;
    this.modalOptionsZoom = {
      data: {
        heading: this.modalTitle,
        items: this.modalItems,
        properties: [{ name: this.propertyName, label: "Código" }, { name: this.propertyName2, label: this.propertyDescription }]
      }
    };
  }

  modal_item_row(item) {
    switch (this.modalTitle) {
      case "Operaciones":
        this.movFisicoEdit.mvfCodOPE = item.opeCod;
        break;
    }
  }

}
