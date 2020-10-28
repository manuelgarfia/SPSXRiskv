import { Component, OnInit } from '@angular/core';
import { filtermodel, filtermodelArray } from 'src/app/shared/models/filtermodel';
import { FilterHeader, FilterDetail } from 'src/app/shared/models/filtermodel';
import { SideFilterComponent } from 'src/app/shared/components/side-filter/side-filter.component';
import { MDBModalRef, MDBModalService } from 'angular-bootstrap-md';

import { XRSKCIAService } from '../../../shared/services/cia.service';
import { XRSKEntidadService } from '../../../shared/services/entidad.service';
import { XRSKContratosService } from 'src/app/shared/services/xrskContratos.service';
import { contratossaldosservice } from '../../../shared/services/contratossaldos.service';
import { XRSKDivisasService } from '../../../shared/services/xrskDivisas.service';
import { XRSKexch_bancos_cuentapolizaService } from '../../../shared/services/xrskexch_bancos_cuentapoliza.service'
import { ActivatedRoute } from '@angular/router';
import { XRSKexch_bancos_cuentapoliza } from '../../../shared/models/xrskexch_bancos_cuentapoliza.model';
import { xrskcontratossaldos } from '../../../shared/models/xrskcontratossaldos.model';
import { map } from 'rxjs/operators';
import { DatePipe } from '@angular/common';
import { DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material/core';
import { AppDateAdapter, APP_DATE_FORMATS } from '../../../shared/format/format-datepicker';

@Component({
  selector: 'app-cuentas-credito',
  templateUrl: './cuentas-credito.component.html',
  styleUrls: ['./cuentas-credito.component.css'],
  providers: [
    [DatePipe]
  ]
})
export class CuentasCreditoComponent implements OnInit {

  constructor(private modalService: MDBModalService, private ciaService: XRSKCIAService, private contService: XRSKContratosService,
    private polizasService: XRSKexch_bancos_cuentapolizaService, private entService: XRSKEntidadService,
    private divisasService: XRSKDivisasService, private contratosService: contratossaldosservice, private ruta: ActivatedRoute,
    private datePipe: DatePipe) { }

  //Filter
  public selectorCompanyias: filtermodelArray = new filtermodelArray();
  public selectorEntidades: filtermodelArray = new filtermodelArray();
  public selectorContratos: filtermodelArray = new filtermodelArray();
  public selectorCertezas: filtermodelArray = new filtermodelArray();
  public selectorEstadosConciliacion: filtermodelArray = new filtermodelArray();

  public modalOptions: any;
  modalRef: MDBModalRef;

  // Preferencias
  preferences: any;
  public FechaDesde: Date;
  public FechaHasta: Date;
  public showDateSelection: Boolean;
  public selectedDateType: string;
  public selectedItems: string[] = [];
  public selectedFilter: FilterHeader = new FilterHeader();

  //from movFisico
  public company: string;
  public contrato: string;

  public polizas: XRSKexch_bancos_cuentapoliza = new XRSKexch_bancos_cuentapoliza();

  public saldos: any[] = [];
  public dateLabels: any[] = [];

  public dateDesde: Date;
  public dateHasta: Date;

  public contratosArray: xrskcontratossaldos[] = [];
  public chartReady: boolean = false;

  public chartType: string = 'line';

  public chartDatasets: Array<any> = [
    { data: '', label: 'Horas' },
  ];

  public chartLabels: Array<any> = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];

  public chartColors: Array<any> = [
    {
      backgroundColor: 'rgba(0, 0, 0, .0)',
      borderColor: 'rgba(0, 10, 130, .7)',
      borderWidth: 2,
    }
  ];

  public chartOptions: any = {
    responsive: true
  };

  public chartClicked(e: any): void { }
  public chartHovered(e: any): void { }

  public monthNames = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
    "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
  ];

  ngOnInit(): void {

    this.ruta.params.subscribe(params => {
      this.company = params['company'];
      this.contrato = params['contrato'];
    })

    this.getPreferences();

    // Obtención de datos para el filtro lateral
    this.getSelectorCompañias();
    this.getSelectorContratos();
    this.getSelectorEntidades();
    this.getSelectorDivisas();

    if (this.company != null) {
      this.getXRSKPolizas(this.company, this.contrato);
    }

    console.log(this.chartDatasets)
  }

  public secondView: boolean = false;

  onChangeClick() {
    this.secondView = !this.secondView;
  }

  getPreferences() {
    this.preferences = JSON.parse(localStorage.getItem('PolizasPreferences'));
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
    this.selectedFilter.add(new FilterDetail("Entidad", "banco", "items", null, null, null, null, null, null, null, null, null));  
    this.selectedFilter.add(new FilterDetail("Contrato", "cuentactble", "items", null, null, null, null, null, null, null, null, null));
    this.selectedFilter.add(new FilterDetail("Divisas", "divisas", "items", null, null, null, null, null, null, null, null, null));
    this.selectedFilter.add(new FilterDetail("Fecha Último extracto", "fechaultimoextracto", "date", "range", null, null, null, null, null, this.FechaDesde, this.FechaHasta, null));
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
          localStorage.setItem("PolizasPreferences", null);
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
    this.getXRSKCuentasCredito(this.selectedFilter);
    // Save Preferences
    this.savePreferences();
  }

  getXRSKCuentasCredito(filter: FilterHeader): void {

    this.polizasService.getXRSKexch_bancos_cuentapolizaFilter(filter).subscribe(
      polizas => {
        this.polizas = polizas as XRSKexch_bancos_cuentapoliza;
      },
      err => {
        console.log(err);
      }
    );
  }

  getXRSKPolizas(company: string, contrato: string) {
    this.polizasService.getXRSKexch_bancos_polizas(company, contrato).subscribe(
      polizas => {
        this.polizas = polizas as XRSKexch_bancos_cuentapoliza;
        this.getGraphicData(company, contrato);
      },
      err => {
        console.log(err);
      }
    );
  }

 
  getGraphicData(company: string, contrato: string) {
    this.contratosService.getXRSKContratosByCompany(company, contrato).pipe(
      map(x => x.map(v => new xrskcontratossaldos(v)))).subscribe(
      contratos => {
        this.contratosArray = contratos as xrskcontratossaldos[];
        this.getSaldoByMonth(this.contratosArray);
      },
      err => {
        console.log(err);
      }
    )

  }

  //Aquí se empiñona un mes en concreto
  getSaldoByMonth(contratosSaldos: xrskcontratossaldos[]) {

    this.saldos = [];
    this.dateLabels = [];
    this.chartDatasets = [];
    this.chartLabels = [];

    let saldo = 0;
    let fechaContrato: Date;
    var fechaCon;

    if (contratosSaldos.length > 31) {
      this.setGraphicLabel(contratosSaldos);
    } else{
      for (var i = 0; i < contratosSaldos.length; i++) {
        saldo = contratosSaldos[i].Saldos;
        fechaContrato = contratosSaldos[i].Fecha;
        fechaCon = this.datePipe.transform(fechaContrato, 'dd-MM-yyyy');
        this.saldos.push(saldo);
        this.dateLabels.push(fechaCon);
      }
      this.saldos.sort();
      this.chartDatasets = [{ data: this.saldos, label: 'Saldos' }]
      this.chartLabels = this.dateLabels;
    }
        
  }

  setGraphicLabel(contratosSaldos: xrskcontratossaldos[]) {

    let saldo: xrskcontratossaldos;
    var saldoY;

    let mes: number;
    let mesLabel: string;

    for (var i = 0; i < contratosSaldos.length; i++) {
      saldo = contratosSaldos[i];
      saldoY = contratosSaldos[i].Saldos;

      if (saldo.Fecha.getDate() == 1) {
        mes = saldo.Fecha.getMonth();
        mesLabel = this.monthNames[mes];
        this.dateLabels.push(mesLabel);
      } else {
        this.dateLabels.push('');
      }

      this.saldos.push(saldoY);
      this.saldos.sort();
      this.chartDatasets = [{ data: this.saldos, label: 'Saldos' }]

    }
    this.chartLabels = this.dateLabels;

  }


  getXRSKContratosByCompanyDateRange() {
    console.log(this.dateDesde, this.dateHasta);
    this.contratosService.getXRSKContratosByCompanyDateRange(this.polizas.empresa, this.polizas.codigo, this.dateDesde, this.dateHasta).pipe(
      map(x => x.map(v => new xrskcontratossaldos(v)))).subscribe(
        contratos => {
          this.contratosArray = contratos as xrskcontratossaldos[];
          this.getSaldoByMonth(this.contratosArray);
        },
        err => {
          console.log(err);
        }
      )
  }


  savePreferences() {
    this.preferences = { "selectedDateType": this.selectedDateType, "fromDate": this.FechaDesde, "toDate": this.FechaHasta, "filter": this.selectedFilter }
    localStorage.setItem('PolizasPreferences', JSON.stringify(this.preferences));
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

  getSelectorContratos() {
    this.contService.get_cia_filter().subscribe(
      contratos => {
        this.selectorContratos.detail = contratos as filtermodel[];
        this.selectedItems = this.selectedFilter.detail.find(x => x.entity == "cuentactble").values;
        if (this.selectedItems != null) {
          this.selectorContratos.markChecked(this.selectedItems);
        }
        this.selectedFilter.detail.find(x => x.entity == "cuentactble").content = this.selectorContratos.detail;
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
        this.selectedItems = this.selectedFilter.detail.find(x => x.entity == "banco").values;
        if (this.selectedItems != null) {
          this.selectorEntidades.markChecked(this.selectedItems);
        }
        this.selectedFilter.detail.find(x => x.entity == "banco").content = this.selectorEntidades.detail;
      },
      err => {
      }
    );
  }

  getSelectorDivisas(): void {
    this.divisasService.get_divisas_filter().subscribe(
      divisas => {
        this.selectorEntidades.detail = divisas as filtermodel[];
        this.selectedItems = this.selectedFilter.detail.find(x => x.entity == "divisas").values;
        if (this.selectedItems != null) {
          this.selectorEntidades.markChecked(this.selectedItems);
        }
        this.selectedFilter.detail.find(x => x.entity == "divisas").content = this.selectorEntidades.detail;
      },
      err => {
      }
    );
  }

}
