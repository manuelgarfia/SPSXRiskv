import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { XRSKxptm_prestamosService } from 'src/app/shared/services/xrskxptm_prestamos.service';
import { XRSKxptm_prestamos } from 'src/app/shared/models/xrskxptm_prestamos.model';
import { Router } from '@angular/router';
import { MdbTablePaginationComponent, MdbTableDirective, MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { DatePipe } from '@angular/common';
import { Observable } from 'rxjs';

import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { XRSKCIAService } from '../../../shared/services/cia.service';
import { XRSKEntidadService } from 'src/app/shared/services/entidad.service';
import { XRSKContratosService } from 'src/app/shared/services/xrskContratos.service';
import { contratossaldosservice } from '../../../shared/services/contratossaldos.service';
import { XRSKUtilsService } from '../../../shared/services/xrskUtils.service';

import { XRSKUser } from '../../../core/models/xrskuser.model';
import { stringmodel } from '../../../shared/models/stringmodel';
import { SideFilterComponent } from 'src/app/shared/components/side-filter/side-filter.component';
import { LoadingModalComponent } from '../../../shared/components/loading-modal/loading-modal.component';

import { filtermodelArray, FilterHeader, FilterDetail, filtermodel } from '../../../shared/models/filtermodel';
import { AlertsComponent } from '../../../shared/components/Alerts/AlertModal.component';


@Component({
  selector: 'app-xrsk-prestamos',
  templateUrl: './xrskPrestamos.component.html',
  styleUrls: ['./xrskPrestamos.component.css'],
  providers: [
    [DatePipe]
  ]
})
export class XrskPrestamosComponent implements OnInit {

  constructor(private prestamosService: XRSKxptm_prestamosService, private authService: AuthenticationService,
    private cdRef: ChangeDetectorRef, private datePipe: DatePipe, private modalService: MDBModalService,
    private ciaService: XRSKCIAService, private contService: XRSKContratosService, private utilsService: XRSKUtilsService,
    private entService: XRSKEntidadService, private ruta: Router
  ) { }

  //private utilsService: XRSKUtilsService

  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;

  public prestamos: any[] = [];
  public prestamosList: XRSKxptm_prestamos = new XRSKxptm_prestamos();

  public currentUserl$: Observable<XRSKUser>;
  public userString: string;
  public prestamoSeleccionado: string;

  public loaded: boolean = false;

  public todaysDate: string;
  public numPrestamosActivos: number;
  public totalDeudaViva: number;
  public numEmpresas: number;
  public numBancos: number;

  //Variables de los graficos
  public importesArray: any[] = [];
  public importeCirculoArray: any[] = [];
  public barrasLabels: any[] = [];
  public circuloLabels: any[] = [];

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
  public waringModalOptions: any;
  modalRef: MDBModalRef;

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
  
  ngOnInit(): void {
    this.formatDate();
    this.getPreferences();
    this.getSelectorCompañias();
    this.getSelectorEntidades();
    this.getPrestamos();
  }

  showAlerts() {

    this.waringModalOptions = {
      backdrop: false,
      keyboard: true,
      focus: true,
      show: true,
      ignoreBackdropClick: false,
      class: 'modal-dialog-scrollable modal-warning',
      animated: true,
    }

    this.modalRef = this.modalService.show(AlertsComponent, this.waringModalOptions);
  }

  formatDate() {
    var d = Date();
    this.todaysDate = this.datePipe.transform(d, 'dd/MM/yyyy');

  }

  selectLine(item) {
    if (item == 'Préstamos') {
      this.ruta.navigate(['/prestamos']);
    }

    if (item == 'Leasings') {
      this.ruta.navigate(['/leasings']);
    }
  }

  getPrestamos() {

    this.prestamosService.getXRSKxptm_prestamosList().subscribe(
      prestamos => {
        this.prestamos = prestamos as XRSKxptm_prestamos[];
        this.mdbTable.setDataSource(this.prestamosList);
        this.getSpecificInformation();
        this.loaded = true;
        this.showAlerts();
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
    this.getImportePorEmpresa();
    this.getImportePorEntidad();
  }

  getNumPrestActivos(): void {
    this.numPrestamosActivos = this.prestamos.length;
  }

  getTotalDeudaViva():void {

    this.totalDeudaViva = 0;

    for (let elemento of this.prestamos) {
      this.totalDeudaViva = this.totalDeudaViva + elemento.calculoCP;
    }
    this.totalDeudaViva = (-1) * this.totalDeudaViva;
  }

  public empresas: any[] = [];
  public importePorEntidad: any[] = [];
  public importePorEmpresa: any[] = [];

  getNumEmpresas() {
    this.empresas = this.prestamos.filter(
      (thing, i, arr) => arr.findIndex(t => t.empresa === thing.empresa) === i
    );

    this.numEmpresas = this.empresas.length;
  }



  getImportePorEmpresa(): void {

    var importes: number = 0;

    this.importePorEmpresa = this.prestamos.filter(
      (thing, i, arr) => arr.findIndex(t => t.empresa === thing.empresa) === i
    );

    for (let element of this.importePorEmpresa) {
      this.barrasLabels.push(element.empresa);
    }

    for (var i = 0; i <= this.barrasLabels.length; i++) {
      imp = [];
      importes = 0;
      var imp: any[] = this.prestamos.filter(x => x.empresa == this.barrasLabels[i])

      for (let elem of imp) {
        importes = importes + elem.calculoCP * (-1)
      }
      this.importesArray.push(importes);
    }

    this.chartDatasets = [{ data: this.importesArray, label: 'Deuda viva' }]
    this.chartLabels = this.barrasLabels;
   // this.chartColors = this.obtenerRandomColorRgbBars(this.numEmpresas);
  }

  getImportePorEntidad(): void {

    var importes: number = 0;

    this.importePorEntidad = this.prestamos.filter(
      (thing, i, arr) => arr.findIndex(t => t.entidad === thing.entidad) === i
    );

    this.numBancos = this.importePorEntidad.length;

    for (let element of this.importePorEntidad) {
      this.circuloLabels.push(element.entidad);
    }

    for (var i = 0; i <= this.circuloLabels.length; i++) {
      imp = [];
      importes = 0;
      var imp: any[] = this.prestamos.filter(x => x.entidad == this.circuloLabels[i])

      for (let elem of imp) {
        importes = importes + elem.calculoCP*(-1)
      }
      this.importeCirculoArray.push(importes);
    }

    this.chartDatasets2 = [{ data: this.importeCirculoArray, label: 'Deuda viva' }]
    this.chartLabels2 = this.circuloLabels;
  }

  onPrestamoClick(prestamo) {
    //this.currentUserl$ = this.authService.currentUserObs;
    this.prestamoSeleccionado = prestamo
    this.userString = "portal";
    window.open("http://" + "xriskdev2018.cloudapp.net/xrisktreasuryDEV/Desktop2016.aspx?user=" + this.userString + "&pwd=oys&dbms=DEV&targetObj=xptm_prestamos&cond=codser=" + this.prestamoSeleccionado);

    //var qsOpen = "user=" + this.userString + "&pwd=oys&dbms=DEV&targetObj=xptm_prestamos&cond=codser=" + this.prestamoSeleccionado;
    //var qsEncrypted: stringmodel;

    //this.utilsService.encrypt(qsOpen).subscribe(
    //  encrypted => {
    //    qsEncrypted = encrypted as stringmodel;
    //    //window.alert(qsEncrypted.cadena);
    //    //window.open("http://xriskdev2018.cloudapp.net/xrisktreasuryDEV/Desktop2016.aspx?enc=2mZ6SOuCLn0nS0zLX3Mx8vcGkFtKpsZsYM1LfPtHSiiJ9G0JRW0UDwmCWysaIOtaS1D4yxWQPlX+Ahmgmo0Rij//k+tsSEhAqiFWViA69HKGILy4lsRkdGRm77KGAHQwvdFN/S0MT5VsiaSbURD81+SrnaFmCkM0bk7/DCSlo4Yi2UfbcL2wEcZI+QsUioGoR2b+1ne1faphUOE5HWiQTg==");
    //    window.open("http://xriskdev2018.cloudapp.net/xrisktreasuryDEV/Desktop2016.aspx?" + qsEncrypted.cadena);
    //  },
    //  err => {
    //    console.log(err)
    //  }
    //)
  }

  public chartType: string = 'bar';

  public chartDatasets: Array<any> = [{ data: [65, 59, 80, 81, 56, 55, 40], label: 'My First dataset' }];

  public chartLabels: Array<any> = ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'];

  public chartColors: Array<any> = [
    {
      backgroundColor: [
        'rgba(255, 99, 132, 0.2)',
        'rgba(54, 162, 235, 0.2)',
        'rgba(255, 206, 86, 0.2)',
        'rgba(75, 192, 192, 0.2)',
        'rgba(153, 102, 255, 0.2)',
        'rgba(163, 15, 141, 0.2)',
        'rgba(163, 151, 15, 0.2)',
        'rgba(239, 78, 180, 0.2)',
        'rgba(86, 78, 239, 0.2)',
        'rgba(255, 159, 23, 0.2)',
        'rgba(148, 143, 245, 0.2)',
        'rgba(24, 227, 242, 0.2)',
        'rgba(255, 159, 94, 0.2)',
        'rgba(24, 242, 85, 0.2)',
        'rgba(242, 212, 24, 0.2)',
        'rgba(111, 242, 24, 0.2)',
        'rgba(24, 143, 242, 0.2)',
        'rgba(248, 163, 250, 0.2)',
      ],
      borderColor: [
        'rgba(255, 99, 132, 1)',
        'rgba(54, 162, 235, 1)',
        'rgba(255, 206, 86, 1)',
        'rgba(75, 192, 192, 1)',
        'rgba(153, 102, 255, 1)',
        'rgba(163, 15, 141, 1)',
        'rgba(163, 151, 15, 1)',
        'rgba(239, 78, 180, 1)',
        'rgba(86, 78, 239, 1)',
        'rgba(255, 159, 23, 1)',
        'rgba(148, 143, 245, 1)',
        'rgba(24, 227, 242, 1)',
        'rgba(255, 159, 94, 1)',
        'rgba(24, 242, 85, 1)',
        'rgba(242, 212, 24, 1)',
        'rgba(111, 242, 24, 1)',
        'rgba(24, 143, 242, 1)',
        'rgba(248, 163, 250, 1)',
      ],
      borderWidth: 2,
    }
  ];

  public chartOptions: any = {
    responsive: true
  };
  public chartClicked(e: any): void { }
  public chartHovered(e: any): void { }


  //CHART QUESITO
  public chartType2: string = 'doughnut';

  public chartDatasets2: Array<any> = [ { data: [300, 50, 100, 40, 120], label: 'My First dataset' }];

  public chartLabels2: Array<any> = ['Red', 'Green', 'Yellow', 'Grey', 'Dark Grey'];

  public chartColors2: Array<any> = [
    {
      backgroundColor: ['#F7464A', '#46BFBD', '#FDB45C', '#949FB1', '#4D5360', '#4D5365'],
      hoverBackgroundColor: ['#FF5A5E', '#5AD3D1', '#FFC870', '#A8B3C5', '#616774'],
      borderWidth: 2,
    }
  ];

  public chartOptions2: any = {
    responsive: true
  };
  public chartClicked2(e: any): void { }
  public chartHovered2(e: any): void { }


  // Obtenemos los colores para las barras en su formato expecífico
  public obtenerRandomColorRgbBars(numColors: number): any[] {
    var arrayRgb: any[] = [];
    var arrayRgbBack: any[] = [];
    var arrayRgbBorder: any[] = [];
    var orderWidth_2 = 0.2;
    var r, g, b: any;
    for (let i = 0; i < numColors; i++) {

      r = Math.floor(Math.random() * 255);
      g = Math.floor(Math.random() * 255);
      b = Math.floor(Math.random() * 255);



      arrayRgbBack.push("rgb(" + r + "," + g + "," + b + ")");
      arrayRgbBorder.push("rgb(" + (r / 2) + "," + g + "," + b + ")");
      //arrayRgb.push({ backgroundColor: "rgba(" + r + "," + g + "," + b + ")", borderColor: "rgb(" + (r / 2) + "," + g + "," + b + ")", orderWidth: 2 }); 
    }
    arrayRgb.push({ background: [arrayRgbBack], borderColor: [arrayRgbBorder], orderWidth: orderWidth_2 })

    return arrayRgb;

  }

  getPreferences() {
    this.preferences = JSON.parse(localStorage.getItem('PrestamosPreferences'));
    if (this.preferences != null) {
      //this.preferencesOn = true;
      //this.setTooltip();
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
          localStorage.setItem("PrestamosPreferences", null);
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

    this.prestamosService.getXRSKxptm_prestamosFilter(filter).subscribe(
      prestamos => {
        this.prestamos = prestamos as XRSKxptm_prestamos[];
        this.mdbTable.setDataSource(this.prestamosList);
      },
      err => {
        console.log(err);
      }
    );
  }

  savePreferences() {
    this.preferences = { "selectedDateType": this.selectedDateType, "fromDate": this.FechaDesde, "toDate": this.FechaHasta, "filter": this.selectedFilter }
    localStorage.setItem('PrestamosPreferences', JSON.stringify(this.preferences));
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
}
