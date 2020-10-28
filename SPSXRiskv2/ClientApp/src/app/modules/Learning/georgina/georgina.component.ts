import { Component, OnInit, Inject, HostListener, ViewChild, ChangeDetectorRef, ElementRef, Output, EventEmitter, Input } from '@angular/core';
import { MdbTableDirective, MdbTablePaginationComponent, MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { Observable } from 'rxjs';
import { from } from 'rxjs';
import { EntidadFilter } from 'src/app/shared/components/pipes/entidadFilter.pipe';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SideFilterComponent } from 'src/app/shared/components/side-filter/side-filter.component';
import { ModalgridComponent } from 'src/app/shared/components/modalgrid/modalgrid.component';
import { ModalComponent } from 'src/app/shared/components/modal/modal.component';
import { LoadingModalComponent } from 'src/app/shared/components/loading-modal/loading-modal.component';


import { entidadesmodel } from 'src/app/shared/models/entidadmodel';
import { filtermodel, sendFiltermodel, FilterDetail, FilterHeader, filtermodelArray } from 'src/app/shared/models/filtermodel';
import { condicionesbancariasmodel } from 'src/app/shared/models/georginaclass.model'
import { XRSKCBVService } from 'src/app/shared/services/georgina.service';
import { XRSKOperacionService } from 'src/app/shared/services/operacion.service';
import { XRSKEntidadService } from 'src/app/shared/services/entidad.service';
import { XRSKCIAService } from 'src/app/shared/services/cia.service';
import { XRSKCBVigentes } from '../../../shared/models/georgina.model';
import { ExcelService } from 'src/app/core/services/excel.service';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { XRSKUser } from 'src/app/core/models/xrskuser.model';
import { Router } from '@angular/router';


@Component({
  selector: 'app-georgina',
  templateUrl: './georgina.component.html',
  styleUrls: ['./georgina.component.css']
})


export class GeorginaComponent implements OnInit {

  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild('alert', { static: true }) alert: ElementRef;
  @ViewChild('Progress') matProgress: ElementRef;
  @ViewChild('loader', { static: false }) loader: ElementRef;


  constructor(private CBV_Service: XRSKCBVService,
    private op_service: XRSKOperacionService,
    private ent_service: XRSKEntidadService,
    private cdRef: ChangeDetectorRef,
    private _snackbar: MatSnackBar,
    private router: Router,
    public modalservice: MDBModalService,
    public ciaService: XRSKCIAService,
    public excelService: ExcelService,
    private authService: AuthenticationService) { }

        public gForm: FormGroup = new FormGroup({
        entidad_checked: new FormArray([]),
  })

  public user: string;

  public selectedRowIds: Set<XRSKCBVigentes> = new Set<XRSKCBVigentes>();
  public selectedRowItem: XRSKCBVigentes;

  //Loader
  public loaded: boolean = false;

  //Condiciones Bancarias variables
  public CBV_vig_component: condicionesbancariasmodel = new condicionesbancariasmodel();
  public component_cbv: any = [];

  //Original DataSet variables
  previous: any = [];
  previous_ent: any = [];

  //Entidades variables
  public entidades$: entidadesmodel;
  public entidades_list: any[];
  array_entidades: any[] = [];
  checked_entidades: any[] = [];
  public cia_list: any[];
  FechaDesde: Date;
  FechaHasta: Date;
  //Open and close Accordion
  panelOpenState = false;
  //Pipe values
  entidadFilter = '';
  //Show and hide variables
  public show: boolean = false;
  checks_array: any[] = [];
  //Save Entidad checkbox value
  public entidad_selected: string;
  public cbv_list_filtered: any[];

  //Delete register
  public deleteCBV: condicionesbancariasmodel = new condicionesbancariasmodel();;
  table_checks: any[] = [];

  //Auxiliars
  searchText: string = '';
  errorText: string = 'Está en proceso!';
  // Snack Bar
  durationInSeconds = 1;
  //Tooltip
  public preferencesOn: boolean = false;

  //Modal
  modalRef: MDBModalRef;
  modalPreferences: MDBModalRef;
  loadingModalRef: MDBModalRef;
  public modalOptions: any;
  public panels: any;
  public itemTitle: any;
  public itemEvent: any;
  public titleArray: string[] = [];
  public filterItem = new sendFiltermodel();

  public selectedItems: string[] = [];
  public selectedFilter: FilterHeader = new FilterHeader();
  public selectedCias: string[] = [];
  public selectorCompañias: filtermodelArray = new filtermodelArray();
  public selectorEntidades: filtermodelArray = new filtermodelArray();

  //Preferences
  preferences: any;
  tooltipPreferences: any = [];
  tooltipValues: any[] = [];
  selectedEntidad: string;
  exportControl = new FormControl();
  public selectedDateType: string;
  public selectOptions: any[] = ["Exportar a Excel", "Exportar a Csv", "Exportar a PDF"];

  ngOnInit(): void {
    this.get_cia();
    this.getSelectorEntidades();
   // this.showLoader();
    this.getPreferences();
    this.filterXRSK(this.selectedFilter);
   // this.closeLoader();
    this.op_service.get_operacion_list();
    this.get_entidades();
  }

  //Export Excel
  exportAsXLSX(option: string): void {
    if (option == 'Exportar a Excel') {
      this.excelService.exportAsExcelFile(this.component_cbv, 'sample');
    }
  }

  //Preferences
  getPreferences() {
    this.preferences = JSON.parse(localStorage.getItem('CBVPreferences'));
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
    this.selectedFilter.add(new FilterDetail("Entidades", "MVFEntCod", "items", null, null, "", null, null, null, null, null, null));
  }


  PreferencesArray: any[] = [];
  PreferenceLabel: string;
  PreferenceOption: string;

  public savePreferenceArray() {
    this.PreferencesArray.push(this.preferences);
    localStorage.setItem('PreferencesList', JSON.stringify(this.PreferencesArray));
  }

  setTooltip() {
    this.tooltipPreferences = this.preferences.filter.detail;
  }

  savePreferences() {
    this.preferences = { "selectedDateType": this.selectedDateType, "fromDate": this.FechaDesde, "toDate": this.FechaHasta, "filter": this.selectedFilter }
    localStorage.setItem('CBVPreferences', JSON.stringify(this.preferences));
  }

  //Filter
  onFilterClick() {

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
        items: this.selectedFilter.detail
      }
    }

    //S'obre el modal
    this.modalRef = this.modalservice.show(SideFilterComponent, this.modalOptions);

    this.modalRef.content.confirmAction.subscribe((number: any) => {
      switch (number) {
        case "1":
          localStorage.setItem("CBVPreferences", null);
          break;
        case "2":
          this.modalRef.hide();
          this.SetPreferenceName();
          this.savePreferenceArray();
          break;
        case "3":
          this.modalRef.hide();
          this.PreferenceLabel = 'Preferencias guardadas';
          this.preferencesModal();
          break;
      }
    })

    this.modalRef.content.sendItems.subscribe(((items: any) => {
      if (items) {
        this.selectedFilter.detail = items;
        this.fetchSelection();
      }
    }));

  }


  fetchSelection() {
    // Actualizar los datos
    this.filterXRSK(this.selectedFilter);
    // Save Preferences
    this.savePreferences();
  }

  preferencePanel: any[] = [{
    name: 'PREFERENCIAS',
    items: this.PreferencesArray,
  }];

  preferencesModal() {

    this.PreferencesArray = JSON.parse(localStorage.getItem('PreferencesList'));
    this.modalOptions = {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: true,
      ignoreBackdropClick: false,
      class: 'modal-dialog',
      animated: true,
      data: {
        heading: this.PreferenceLabel,
        items: this.preferencePanel,
      },
    }
    this.modalRef = this.modalservice.show(ModalgridComponent, this.modalOptions);

  }

  SetPreferenceName() {

    this.modalOptions = {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: true,
      ignoreBackdropClick: false,
      class: 'modal-dialog',
      animated: true,
      data: {
        heading: 'Guardar Preferencia',
        content: "guardar",
        afirmative: 'Sí',
        negative: 'No'
      },
    }

    this.modalRef = this.modalservice.show(ModalComponent, this.modalOptions);
  }


  filterXRSK(selectedItems: FilterHeader) {
    this.CBV_Service.getXRSKFilter(selectedItems).subscribe(
      cbv_filtered => {
        this.component_cbv = cbv_filtered as XRSKCBVigentes[];
        this.loaded = true;
        this.mdbTable.setDataSource(this.component_cbv);
        this.previous = this.mdbTable.getDataSource();
      },
      err => {
        if (err.status == 403) {
          this.router.navigate(['/Error']);
        }
        this.showAlert();
        this.errorText = err;
      }
    );
  }

  //Remove Item from Entidades Array
  removeItemFromArr(arr, item) {
    var i = arr.indexOf(item);
    arr.splice(i, 1);
  }

  //Show and Hide buttons
  ShowAndHide(item, event) {
    this.show = !this.show;
    this.deleteCBV = item;

    if (event.checked) {
      this.table_checks.push(this.deleteCBV);// es guarda l'item a l'array
    } else {
      this.removeItemFromArr(this.table_checks, this.deleteCBV);
    }

    //mantenir el botó a la vista
    if (this.table_checks.length >= 1) {
      this.show = true;
    }

  }


  //Get Cond. bancarias list
  get_CBV_List_component(): void {
    this.CBV_Service.getCBVList().subscribe(
      component_cbv => {
        this.component_cbv = component_cbv as condicionesbancariasmodel[];
        if (this.component_cbv.length > 0) {
          this.CBV_vig_component = this.component_cbv[0];
        }
        this.mdbTable.setDataSource(this.component_cbv);
        this.previous = this.mdbTable.getDataSource();
        this.cbv_list_filtered = this.previous;
      },
      err => {
        this.errorText = err;
        this.showAlert();
      }
    );
  }

  getSelectorEntidades(): void {
    this.ent_service.get_entidades_filter().subscribe(
      ent_list => {

        this.selectorEntidades.detail = ent_list as filtermodel[];
        this.selectedItems = this.selectedFilter.detail.find(x => x.entity == "MVFEntCod").values;
        if (this.selectedItems != null) {
          this.selectorEntidades.markChecked(this.selectedItems);
        }
        this.selectedFilter.detail.find(x => x.entity == "MVFEntCod").content = this.selectorEntidades.detail;

      },
      err => {
        this.errorText = err;
        this.showAlert();
      }
    );
  }

  get_cia(): void {
    this.ciaService.get_cia_filter().subscribe(
      cia_list => {
        this.selectorCompañias.detail = cia_list as filtermodel[];
        this.selectedItems = this.selectedFilter.detail.find(x => x.entity == "MVFCodCIA").values;
        if (this.selectedItems != null) {
          this.selectorEntidades.markChecked(this.selectedItems);
        }
        this.selectedFilter.detail.find(x => x.entity == "MVFCodCIA").content = this.selectorCompañias.detail;
      },
      err => {
        this.errorText = err;
        this.showAlert();
      }
    );
  }

  //Get Entidades list
  get_entidades(): void {
    this.ent_service.get_entidades_filter().subscribe(
      entidades_list => {
        this.entidades_list = entidades_list as filtermodel[];
        this.entidades_list["title"] = "Entidades";
      },
      err => {
        this.errorText = err;
        this.showAlert();
      }
    );
  }

  //Select register to delete
  onDeleteClick() {
    for (let item of this.table_checks) {
      this.deleteXRSKAgrupacion(item);
    }

    for (let list_item of this.table_checks) {
      this.removeItemFromArr(this.table_checks, list_item)
    }

    this.show = false;
  }


  //Delete register
  deleteXRSKAgrupacion(cond_banc: condicionesbancariasmodel) {
    this.CBV_Service.deleteXRSKCBV(cond_banc).subscribe(
      res => {
        this.get_CBV_List_component();
        this.reset();
        this.openSnackBar("Registro eliminado", "delete");
      },
      err => {
        this.errorText = err;
        this.showAlert();
      }
    );

  }

//EDIT REGISTER
  onEditClick(item: condicionesbancariasmodel) {
    this.CBV_Service.send_item(item);
  }

  //SNACK BAR
  openSnackBar(message: string, action: string) {
    this._snackbar.open(message, action, {
      duration: this.durationInSeconds * 3000,
    });
  }


  onRowClick(item) {
    this.selectedRowItem = item;

    if (!this.selectedRowIds.has(this.selectedRowItem)) {
      this.selectedRowIds.add(this.selectedRowItem);
    }
    else {
      this.selectedRowIds.delete(this.selectedRowItem);
    }
  }

  rowIsSelected(id: XRSKCBVigentes) {
    return this.selectedRowIds.has(id);
  }

  reset() {
    // Reset main entity
  //  this.CBV_vig_component$ = new XRSKCBVigentes();
  }

  closeAlert() {
    this.alert.nativeElement.classList.remove('show');
    this.alert.nativeElement.classList.add('collapse');
  }

  showAlert() {
    this.alert.nativeElement.classList.remove('collapse');
    this.alert.nativeElement.classList.add('show');
  }

  showLoader() {
   // this.loader.nativeElement.classList.remove('collapse');
    this.loader.nativeElement.classList.add('show');
  }

  closeLoader() {
    this.loader.nativeElement.classList.remove('show');
    this.loader.nativeElement.classList.add('collapse');
  }


}
