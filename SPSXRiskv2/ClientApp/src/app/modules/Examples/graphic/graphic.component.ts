import { DatePipe } from '@angular/common';
import { Component, OnInit, HostListener, ViewChild, ChangeDetectorRef, ElementRef } from '@angular/core';
import { MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { ModalComponent } from 'src/app/shared/components/modal/modal.component';

import { xrskcontratos } from 'src/app/shared/models/xrskContratos.model';
import { xrskcontratossaldos } from 'src/app/shared/models/xrskcontratossaldos.model';
import { XRSKCIAService } from 'src/app/shared/services/cia.service';

import { contratossaldosservice } from 'src/app/shared/services/contratossaldos.service';
import { XRSKContratosService } from 'src/app/shared/services/xrskContratos.service';
import { filtermodel, filtermodelArray } from 'src/app/shared/models/filtermodel';
import { FilterHeader, FilterDetail } from 'src/app/shared/models/filtermodel';

import { SideFilterComponent } from 'src/app/shared/components/side-filter/side-filter.component'
import { match } from 'assert';

import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, MatDateFormats } from '@angular/material/core';
import { AppDateAdapter, APP_DATE_FORMATS } from 'src/app/shared/format/format-datepicker';



@Component({
  selector: 'app-graphic',
  templateUrl: './graphic.component.html',
  styleUrls: ['./graphic.component.css'],
  providers: [
    { provide: DateAdapter, useClass: AppDateAdapter },
    { provide: MAT_DATE_LOCALE, useValue: 'es-ES' },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS }
    , { provide: DatePipe }
  ]

})
export class GraphicComponent {

  @ViewChild('alert', { static: true }) alert: ElementRef;
  @ViewChild('Progress') matProgress: ElementRef;

  modalRef: MDBModalRef;


  //Variables
  public contratossaldos$: xrskcontratossaldos;
  public contratossaldos: any = [];
  public contSaldosCia: any = [];
  public contratos_list: any = [];
  public entidades_list: any[];
  errorText: string = 'Hay un error';
  preferences: any;
  public panels: any;
  public modalOptions: any;
  tooltipPreferences: any = [];

  public showDateSelection: boolean;
  public showDateSelection2: boolean;
  public selectedDateType: string;
  public FechaDesde: Date;
  public FechaHasta: Date;
  public Fecha: Date;
  public selectorContratos: filtermodelArray = new filtermodelArray();
  public selectedContratos: any[] = [];
  public selectorCompañias: filtermodelArray = new filtermodelArray();
  public selectedCompañias: string[] = [];
  public selectedItems: string[] = []
  public contratos: string[] = [];
  //Definimos la variable Compañia para otorgarle un valor concreto.

  public maxLinePanel: Boolean = false;
  public maxBarPanel: Boolean = false;

  // Progress Bar values
  color = 'primary';
  mode = 'indeterminate';
  value = 50;
  bufferValue = 75;
  isCompleted: boolean = false;


  //Data Set Char type Line y Type Vertical bar
  public chartDatasetsLine: Array<any> = [{ data: '', label: '' }];
  public chartDatasetsBar: Array<any> = [{ data: '', label: '' }];

  public chartColorsLine: Array<any>;
  // Label Set Line y Type Vertical bar
  public chartLabelsLine: Array<any> = [];
  public chartLabelsBar: Array<any> = [];
  public chartColorsBars: Array<any> = [];

  public selectedFilter: FilterHeader = new FilterHeader();
  public selectedFechaCiaFilter: FilterHeader = new FilterHeader();

  public arrayFechas: Array<any> = [];


  //Prueba
  public modalOptions2: any;


  constructor(private xrskcontratossaldos: contratossaldosservice, private xrskcontratos: XRSKContratosService, private cdRef: ChangeDetectorRef,

    private modalService: MDBModalService, public datepipe: DatePipe, public ciaService: XRSKCIAService
  ) { } //




  ngOnInit(): void {


    this.getPreferences();

    this.getSelectorCompañias();
    this.getSelectorContratos();

    //  this.modalOptions2 = {
    //    backdrop: true,
    //    keyboard: true,
    //    focus: true,
    //    show: false,
    //    ignoreBackdropClick: true,
    //    class: 'modal-dialog modal-sm modal-notify modal-danger',
    //    containerClass: 'fade top',
    //    animated: true,
    //    data: {
    //      heading: 'Warning',
    //      content: { heading: 'Content heading', description: 'Content description' },
    //      afirmative: 'Sí',
    //      negative: 'No'
    //    }
    //  };

  }
  //





  refresh() {
    this.showProgress();
    //this.getXRSKMovimientosLisRange(this.selectedFilter);
    //this.getXRSKMovimientosList();
  }

  closeProgress() {
    this.matProgress.nativeElement.classList.remove('show');
    this.matProgress.nativeElement.classList.add('collapse');
  }

  showProgress() {
    this.matProgress.nativeElement.classList.remove('collapse');
    this.matProgress.nativeElement.classList.add('show');
  }

  // Nos traemos los datos de los contratos para una Compañía
  getSelectorContratos() {
    this.xrskcontratos.get_cia_filter().subscribe(
      contratos => {
        this.selectorContratos.detail = contratos as filtermodel[];
        this.selectedItems = this.selectedFilter.detail.find(x => x.entity == "ctaCod").values;
        if (this.selectedItems != null) {
          this.selectorContratos.markChecked(this.selectedItems);

        }
        this.selectedFilter.detail.find(x => x.entity == "ctaCod").content = this.selectorContratos.detail;
      },
      err => {
        this.errorText = err;
        this.showAlert(this.errorText);
      }
    );
  }

  // Selector de compañias para el Filter Modal

  getSelectorCompañias(): void {
    this.ciaService.get_cia_filter().subscribe(
      cia_list => {
        this.selectorCompañias.detail = cia_list as filtermodel[];
        this.selectedItems = this.selectedFilter.detail.find(x => x.entity == "MVFCodCIA").values;
        if (this.selectedItems != null) {
          this.selectorCompañias.markChecked(this.selectedItems);
        }
        this.selectedFilter.detail.find(x => x.entity == "MVFCodCIA").content = this.selectorCompañias.detail;
      },
      err => {
        this.errorText = err;
        this.showAlert(this.errorText);
      }
    );
  }

  // Guardamos Preferencias
  public savePreferences() {
    this.preferences = { "selectedDateType": this.selectedDateType, "fromDate": this.FechaDesde, "toDate": this.FechaHasta, "filter": this.selectedFilter }
    localStorage.setItem('Graphics', JSON.stringify(this.preferences));
  }


  // Persistencia de los datos ya almacenados 
  getPreferences() {
    this.preferences = JSON.parse(localStorage.getItem('Graphics'));
    if (this.preferences != null) {
      this.selectedDateType = this.preferences.selectedDateType;
      this.FechaDesde = new Date(this.preferences.fromDate);
      this.FechaHasta = new Date(this.preferences.toDate);
      this.selectedCompañias = this.preferences.selectedCompañias;
      // this.selectedFechaCiaFilter = this.preferences.selectedFechaCiaFilter;
      Object.assign(this.selectedFilter, this.preferences.filter);


    } else {
      this.selectedDateType = "O";  // Operación
      this.FechaHasta = new Date();
      this.FechaDesde = new Date();
      this.Fecha = new Date();
      this.FechaDesde.setDate(this.FechaHasta.getDate() - 30);
      this.setDefaultFilter();
    }
  }


  public setDefaultFilter() {
    this.selectedFilter.add(new FilterDetail("Compañías", "MVFCodCIA", "items", null, null, null, null, null, null, null, null, null));
    this.selectedFilter.add(new FilterDetail("F.Operacion", "MVFFechOperac", "date", "range", null, null, null, null, null, this.FechaDesde, this.FechaHasta, null));
    this.selectedFilter.add(new FilterDetail("Contratos", "ctaCod", "items", null, null, null, null, null, null, null, null, null));
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
  // Método para crear el Bar Chart con Compañía y Fecha trayendo el saldo.

  getContratosSaldosCiaFechaList(myFiltro: FilterHeader): void {
    this.xrskcontratossaldos.getXRSKContratosSaldosRangedList(myFiltro).subscribe(
      contrSaldosCia => {
        this.contSaldosCia = contrSaldosCia as xrskcontratossaldos[];
        if (this.contSaldosCia.length > 0) {
          this.getDataCia(this.contSaldosCia);
        }
        this.isCompleted = false;
      },
      err => {
        this.showAlert(err);
        this.isCompleted = false;
      }

    );
  }



  // Traemos con el nuevo método del Filter Model los datos del service
  getContratosSaldosRangedList(myfiltro: FilterHeader, contratos: string[]): void {   //contrato: string[]
    this.xrskcontratossaldos.getXRSKContratosSaldosListNewFilterDateRange(myfiltro).subscribe(
      contratossaldos => {
        this.contratossaldos = contratossaldos as xrskcontratossaldos[];
        if (this.contratossaldos.length > 0) {

          this.getData(this.contratossaldos, this.selectedContratos);
        }
        this.isCompleted = false;
      },
      err => {
        this.isCompleted = false;
        this.showAlert(err);
      }
    );
  }
  //ESTO ES UNA PRUEBA



  filterClick() {
    if (this.selectedCompañias != null) {
      this.selectorCompañias.markChecked(this.selectedCompañias);
      this.selectorContratos.markChecked(this.selectedContratos);
      //this.closeProgress();
    }

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

    //Recibimos los datos elegidos desde el modal component
    this.modalRef.content.sendItems.subscribe((items: any) => {
      if (items) {
        this.selectedFilter.detail = items;

        this.doSelection(items);
      }
    }
    );
  }

  // Nos comunicamos con el service para que traiga los datos desde la  Api
  doSelection(items: any) {
    // Actualizar los datos

    for (let i = 0; i < items.length; i++) {
      if (items[i].title == 'Contratos') {
        this.selectedContratos = items[i].values
      }
    }
    this.isCompleted = true;
    this.getContratosSaldosRangedList(this.selectedFilter, this.selectedContratos);
    this.getContratosSaldosCiaFechaList(this.selectedFilter);
    // Save Preferences
    this.savePreferences();
    // Cerrar la selección

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



  // Seccion dedicada a procesar datos traidos desde el servicio
  public getData(datos: any[], contratosseleccionados: any[]): void {//Obtenemos Datos para el Chart Line
    var arrayAux = new Array();
    var arrayAuxDate = new Array();
    this.chartDatasetsLine = [];
    var contratos: any;

    contratos = contratosseleccionados.sort();

    for (let i = 0; i < contratosseleccionados.length; i++) {
      arrayAux = this.orderArrayContrato(datos.sort(), contratos[i]);
      this.chartDatasetsLine.push({ data: arrayAux, label: 'Datos del Contrato:' + contratos[i] });
    }

    //for (let j = 0; j < datos.length / contratos.length; j++) {

    //  arrayAuxDate.push(this.datepipe.transform(datos[j].fecha, 'dd/MM/yyyy'));

    //}

    arrayAuxDate = this.arrayFechas;
    this.chartLabelsLine = arrayAuxDate;
    this.chartColorsLine = this.obtenerRandomColorRgb(contratos.length);

  }

  //Método para el Bar Chart 

  public getDataCia(datos: any[]): void {

    var arrayAux = new Array();
    var arrayAuxCia = new Array();
    this.chartDatasetsBar = [];

    for (let i = 0; i < datos.length; i++) {
      arrayAux.push(datos[i].saldo);
      arrayAuxCia.push(datos[i].ctaCod);
    }
    this.chartDatasetsBar.push({ data: arrayAux, label: "Saldos por Fecha y Compañía" })
    this.chartLabelsBar = arrayAuxCia;
    //this.chartColorsBars = this.obtenerRandomColorRgbBars(arrayAuxCia.length);
    this.chartColorsBars = [
      {
        backgroundColor: [
          'rgba(255, 99, 132, 0.2)',
          'rgba(54, 162, 235, 0.2)',
          'rgba(255, 206, 86, 0.2)',
          'rgba(75, 192, 192, 0.2)',
          'rgba(153, 102, 255, 0.2)',
          'rgba(255, 159, 64, 0.2)',
          'rgba(255, 99, 132, 0.2)',
          'rgba(54, 162, 235, 0.2)',
          'rgba(255, 206, 86, 0.2)',
          'rgba(75, 192, 192, 0.2)'
        ],
        borderColor: [
          'rgba(255,99,132,1)',
          'rgba(54, 162, 235, 1)',
          'rgba(255, 206, 86, 1)',
          'rgba(75, 192, 192, 1)',
          'rgba(153, 102, 255, 1)',
          'rgba(255, 159, 64, 1)',
          'rgba(255,99,132,1)',
          'rgba(54, 162, 235, 1)',
          'rgba(255, 206, 86, 1)',
          'rgba(75, 192, 192, 1)',
          'rgba(153, 102, 255, 1)'
        ],
        borderWidth: 2,
      }
    ];

  }

  //Método que devuelve el array correspondiente para cada Contrato.
  public orderArrayContrato(datos: any[], contratos: string): any[] {
    var arrayContratos = new Array();
    this.arrayFechas = [];
    for (let j = 0; j < datos.length; j++) {
      if (datos[j].ctaCod === contratos) {
        arrayContratos.push(datos[j].saldo);
        this.arrayFechas.push(this.datepipe.transform(datos[j].fecha, 'dd/MM/yyyy'));
      }
    }

    return arrayContratos;

  }





  //Declaramos los tipos de Charts que tenemos en nuestra pagina
  public chartTypeLine: string = 'line';
  public chartTypeBar: string = 'bar';

  //Declaración de los valores de nuestros Charts


  public chartOptionsLine: any = {
    responsive: true
  };
  public chartOptionsBar: any = {
    responsive: true
  };
  public chartClicked(e: any): void { }
  public chartHovered(e: any): void { }

  public obtenerRandomColorRgb(numColors: number): any[] {

    var arrayRgb: any; //= [{ backgroundColor: '', borderColor:'', orderWidth:''}]
    for (let i = 0; i < numColors; i++) {

      var r = Math.floor(Math.random() * 255);
      var g = Math.floor(Math.random() * 255);
      var b = Math.floor(Math.random() * 255);
      arrayRgb.push({ backgroundColor: "rgb(" + r + "," + g + "," + b + ")", borderColor: "rgb(" + (r / 2) + "," + g + "," + b + ")", orderWidth: 2 });

    }

    return arrayRgb;

  }
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



}
