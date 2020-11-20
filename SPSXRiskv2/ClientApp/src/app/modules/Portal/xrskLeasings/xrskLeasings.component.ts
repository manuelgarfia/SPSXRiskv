import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';

import { Router } from '@angular/router';
import { MdbTablePaginationComponent, MdbTableDirective, MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { DatePipe } from '@angular/common';
import { Observable } from 'rxjs';

import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { XRSKxptm_leasingsService } from '../../../shared/services/xrskxptm_leasings.service';
import { XRSKCIAService } from '../../../shared/services/cia.service';
import { XRSKEntidadService } from 'src/app/shared/services/entidad.service';
import { XRSKContratosService } from 'src/app/shared/services/xrskContratos.service';
import { contratossaldosservice } from '../../../shared/services/contratossaldos.service';
import { XRSKUtilsService } from '../../../shared/services/xrskUtils.service';

import { XRSKUser } from '../../../core/models/xrskuser.model';
import { stringmodel } from '../../../shared/models/stringmodel';
import { SideFilterComponent } from 'src/app/shared/components/side-filter/side-filter.component';
import { LoadingModalComponent } from '../../../shared/components/loading-modal/loading-modal.component'
import { filtermodelArray, FilterHeader, FilterDetail, filtermodel } from '../../../shared/models/filtermodel';
import { XRSKxptm_leasings } from '../../../shared/models/xrskxptm_leasings.model';



@Component({
  selector: 'app-xrsk-leasings',
  templateUrl: './xrskLeasings.component.html',
  styleUrls: ['./xrskLeasings.component.css'],
  providers: [
    [DatePipe]
  ]
})
export class XrskLeasingsComponent implements OnInit {

  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;

  constructor(
    private datePipe: DatePipe,
    private leasingsService: XRSKxptm_leasingsService,
    private cdRef: ChangeDetectorRef,
    private modalService: MDBModalService,
    private ciaService: XRSKCIAService,
    private entService: XRSKEntidadService,
    private ruta: Router
  ) { };

  public loaded: boolean = false;
  public todaysDate: string;

  public leasings: any[] = [];

  //Seleccion de línea
  public lineas: any[] = [
    {
      linea: 'Préstamos',
      id: 'prestamos',
    },
    {
      linea: 'Leasings',
      id: 'id2',
    }
  ]


  //Filter
  public selectorCompanyias: filtermodelArray = new filtermodelArray();
  public selectorEntidades: filtermodelArray = new filtermodelArray();
  public selectorContratos: filtermodelArray = new filtermodelArray();
  public selectorCertezas: filtermodelArray = new filtermodelArray();
  public selectorEstadosConciliacion: filtermodelArray = new filtermodelArray();

  // Preferencias
  preferences: any;
  public FechaDesde: Date;
  public FechaHasta: Date;
  public showDateSelection: Boolean;
  public selectedDateType: string;
  public selectedItems: string[] = [];
  public selectedFilter: FilterHeader = new FilterHeader();

  public modalOptions: any;
  modalRef: MDBModalRef;

  //3 primeras cajitas
  public numLeasings: number;
  public totalDeudaViva: number;
  public empresas: any[] = [];
  public numEmpresas: number;
  public bancos: any[] = [];
  public numBancos: number;

  ngOnInit() {
    this.refreshPage();
    this.formatDate();
    this.getLeasings();
    this.getPreferences();
    this.getSelectorCompañias();
    this.getSelectorEntidades();
  }

  refreshPage() {
    this.ruta.navigate(['/leasings']);
  }

  formatDate() {
    var d = Date();
    this.todaysDate = this.datePipe.transform(d, 'dd/MM/yyyy');

  }

  getLeasings() {

    this.leasingsService.getXRSKxptm_leasingsList().subscribe(
      leasings => {
        this.leasings = leasings as XRSKxptm_leasings[];
        this.mdbTable.setDataSource(this.leasings);
        this.getSpecificInformation();
        this.loaded = true;
      },
      err => {
        console.log(err)
      }
    )
  }

  getSpecificInformation() {
    this.getNumPrestActivos();
    this.getTotalDeudaViva();
    this.getNumEmpresas();
    this.getNumBancos();
    //this.getImportePorEmpresa();
    //this.getImportePorEntidad();
  }

  getNumPrestActivos(): void {
    this.numLeasings = this.leasings.length;
  }

  getTotalDeudaViva(): void {
    this.totalDeudaViva = 0;
    for (let elemento of this.leasings) {
      this.totalDeudaViva = this.totalDeudaViva + elemento.calculoCP;
    }
    this.totalDeudaViva = (-1) * this.totalDeudaViva;
  }

  getNumEmpresas() {
    this.empresas = this.leasings.filter(
      (thing, i, arr) => arr.findIndex(t => t.empresa === thing.empresa) === i
    );
    this.numEmpresas = this.empresas.length;
  }

  getNumBancos() {
    this.bancos = this.leasings.filter(
      (thing, i, arr) => arr.findIndex(t => t.entidad === thing.entidad) === i
    );
    this.numBancos = this.empresas.length;
  }

  onPowerBI() {
    window.open("https://app.powerbi.com/groups/4cc1a832-bf73-459d-994d-6e20e72adb55/reports/3781705c-44cc-484e-a0d7-d7349d436eeb/ReportSectionec0822a108ae5aab4978?noSignUpCheck=1");
  }

  onReporting() {
    window.open("http://xriskdev2018.cloudapp.net/Reports/report/XRISK/XRISK_STD_CLIENTE_EXP_es/07_DEUDAS/0702_SituacionPrestamos");
  }

  ngAfterViewInit() {
    this.mdbTablePagination.setMaxVisibleItemsNumberTo(5);
    this.mdbTablePagination.calculateFirstItemIndex();
    this.mdbTablePagination.calculateLastItemIndex();
    this.cdRef.detectChanges();
  }

  selectLine(item) {
    if (item == 'Préstamos') {
      this.ruta.navigate(['/prestamos']);
    }

    if (item == 'Leasings') {
      this.ruta.navigate(['/leasings']);
    }
  }

  //Filtro
  getPreferences() {
    this.preferences = JSON.parse(localStorage.getItem('LeasingsPreferences'));
    if (this.preferences != null) {
      this.selectedDateType = this.preferences.selectedDateType;
      this.FechaDesde = new Date(this.preferences.fromDate);
      this.FechaHasta = new Date(this.preferences.toDate);
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
    this.selectedFilter.add(new FilterDetail("Compañías", "empresa", "items", null, null, null, null, null, null, null, null, null));
    this.selectedFilter.add(new FilterDetail("Entidad", "entidad", "items", null, null, null, null, null, null, null, null, null));
    this.selectedFilter.add(new FilterDetail("Fecha Inicio", "fecha1cuota", "date", "range", null, null, null, null, null, this.FechaDesde, this.FechaHasta, null));
  }

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

    //Es reben els items seleccionats del checkbox
    this.modalRef.content.sendItems.subscribe((items: any) => {
      if (items) {
        this.selectedFilter.detail = items;
        this.fetchSelection();
      }
    }
    );


    this.modalRef.content.confirmAction.subscribe((number: any) => {
      switch (number) {
        case "1":
          localStorage.setItem("LeasingsPreferences", null);
          break;
        case "2":
          this.modalRef.hide();
          break;
        case "3":
          this.modalRef.hide();
          break;
      }
    })
  }

  fetchSelection() {
    // Actualizar los datos
    this.getXRSKFilteredPrestamos(this.selectedFilter);
    // Save Preferences
    this.savePreferences();
  }

  getXRSKFilteredPrestamos(filter: FilterHeader): void {

    this.leasingsService.getXRSKxptm_leasingsFilter(filter).subscribe(
      prestamos => {
        this.leasings = prestamos as XRSKxptm_leasings[];
        this.mdbTable.setDataSource(this.leasings);
      },
      err => {
        console.log(err);
      }
    );
  }

  savePreferences() {
    this.preferences = { "selectedDateType": this.selectedDateType, "fromDate": this.FechaDesde, "toDate": this.FechaHasta, "filter": this.selectedFilter }
    localStorage.setItem('LeasingsPreferences', JSON.stringify(this.preferences));
  }

  getSelectorCompañias(): void {
    this.ciaService.get_cia_filter().subscribe(
      cia_list => {
        this.selectorCompanyias.detail = cia_list as filtermodel[];

        this.selectedItems = this.selectedFilter.detail.find(x => x.entity == "empresa").values;
        if (this.selectedItems != null) {
          this.selectorCompanyias.markChecked(this.selectedItems);
        }
        this.selectedFilter.detail.find(x => x.entity == "empresa").content = this.selectorCompanyias.detail;

      },
      err => {
        console.log(err);
      }
    );
  }

  getSelectorEntidades(): void {
    this.entService.get_entidades_filter().subscribe(
      ent_list => {

        this.selectorEntidades.detail = ent_list as filtermodel[];
        this.selectedItems = this.selectedFilter.detail.find(x => x.entity == "entidad").values;
        if (this.selectedItems != null) {
          this.selectorEntidades.markChecked(this.selectedItems);
        }
        this.selectedFilter.detail.find(x => x.entity == "entidad").content = this.selectorEntidades.detail;

      },
      err => {
        console.log(err);
      }
    );
  }

}
