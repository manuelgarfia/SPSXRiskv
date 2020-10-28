import { Location, DatePipe } from '@angular/common';
import { Component, HostListener, OnInit, ViewChild, ElementRef, LOCALE_ID } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { MDBModalRef, MDBModalService, MdbTableDirective } from 'angular-bootstrap-md';

import { ModalComponent } from '../../../shared/components/modal/modal.component';
import { SideFilterComponent } from '../../../shared/components/side-filter/side-filter.component';
import { filtermodel, filtermodelArray, FilterHeader, FilterDetail } from '../../../shared/models/filtermodel';
import { ConciliacionModel, MovimientosDetailModel, ApuntesDetailModel } from '../../../shared/models/conciliacion.model';
import { XRSKApunteBancario } from '../../../shared/models/xrskApunteBancario.model';
import { XRSKMovimientoFisico } from '../../../shared/models/xrskMovimientoFisico.model';

import { XRSKConciliacionService } from '../../../shared/services/xrskConciliacion.service';
import { XRSKApunteBancarioService } from '../../../shared/services/xrskApunteBancario.service';
import { XRSKMovimientoFisicoService } from '../../../shared/services/xrskMovimientoFisico.service';
import { XRSKOperacionService } from '../../../shared/services/xrskOperacion.service';

@Component({
  selector: 'app-concil-manual',
  templateUrl: './concil-manual.component.html',
  styleUrls: ['./concil-manual.component.css'],
  providers: [
    { provide: LOCALE_ID, useValue: 'es' },
    [DatePipe]
  ],
})

export class ConcilManualComponent implements OnInit {
  @ViewChild('ProgressProv') matProgressProv: ElementRef;
  @ViewChild('ProgressBanc') matProgressBanc: ElementRef;
  @ViewChild('tableEl') mdbTableProv: MdbTableDirective;
  @ViewChild('tableE2') mdbTableApunt: MdbTableDirective;

  color = 'primary';
  mode = 'indeterminate';
  value = 50;
  bufferValue = 75;

  title: string = "";
  ttOperacion: string = "";

  //-------------------------------------
  // VENTANA MODAL
  //-------------------------------------
  public modalOptions: any;
  modalRef: MDBModalRef;

  //-------------------------------------
  // FILTROS Y ASOCIADOS
  //-------------------------------------
  public preferencesAOn: boolean = false;
  public preferencesPOn: boolean = false;
  tooltipPreferencesA: any = [];
  tooltipPreferencesP: any = [];
  public selectedFilterA: FilterHeader = new FilterHeader();
  public selectedFilterP: FilterHeader = new FilterHeader();
  preferencesA: any;
  preferencesP: any;
  public FechaADesde: Date;
  public FechaAHasta: Date;
  public FechaPDesde: Date;
  public FechaPHasta: Date;
  public selectorOperaciones: filtermodelArray = new filtermodelArray();
  public selectedItems: string[] = [];

  //-------------------------------------
  // VARIABLES DE PROVISORIS
  //-------------------------------------
  public provisoris: XRSKMovimientoFisico[] = [];
  public provisoriSelected: XRSKMovimientoFisico;
  provisorisSelected: Set<XRSKMovimientoFisico> = new Set<XRSKMovimientoFisico>();
  previousProvisoris: any = [];
  provisorisSelectedAmount: number = 0;
  searchTextProvisoris: string = "";
  loadingProv: Boolean;

  //-------------------------------------
  // VARIABLES DE BANCARIS
  //-------------------------------------
  public apunts: any = [];
  public apuntSelected: XRSKApunteBancario;
  apuntsSelected: Set<XRSKApunteBancario> = new Set<XRSKApunteBancario>();
  previousApunts: any = [];
  apuntsSelectedAmount: number = 0;
  searchTextApunts: string = "";
  loadingBanc: Boolean;

  //-------------------------------------
  // VARIABLES DE RELACIÓ DE PROVISORIS I BANCARIS
  //-------------------------------------
  provisoriAmountDiff: number = 0;
  refConcil: number = 0;
  toDo: ConciliacionModel;

  //-------------------------------------
  // GESTIÓ DE LA BOTONERA
  //-------------------------------------
  public showBtnCompensar: boolean = false;
  public showBtnConciliar: boolean = false;
  public showBtnIncorporar: boolean = false;
  public showBtnRelacionar: boolean = false;

  //-------------------------------------
  // PARÀMETRES
  //-------------------------------------
  public selectedCIA: string[] = [];
  public selectedCTA: string[] = [];

  //-------------------------------------
  // PREFERÈNCIES
  //-------------------------------------
  public selectedFilter: FilterHeader = new FilterHeader();

  //-------------------------------------
  // CONSTRUCTOR
  //-------------------------------------
  constructor(private ruta: ActivatedRoute,
    private _location: Location,
    private modalService: MDBModalService,
    private movFisicoService: XRSKMovimientoFisicoService,
    private apBancarioService: XRSKApunteBancarioService,
    private concilService: XRSKConciliacionService,
    private operacionService: XRSKOperacionService,
    private datePipe: DatePipe,
    private router: Router) { }

  //-------------------------------------
  // INIT METHOD
  //-------------------------------------
  ngOnInit(): void {
    this.title = this.isPantallaCertificacio() ? "Certificación manual" : "Conciliación manual";
    this.ttOperacion = this.isPantallaCertificacio() ? "Certificar" : "Conciliar";

    this.loadingProv = true;
    this.loadingBanc = true;

    this.getPreferences();
    this.getSelectorOperaciones();

    this.ruta.params.subscribe(params => {
      this.selectedCIA.push(params['codCIA']);
      this.selectedCTA.push(params['codCTA']);
    })

    this.getProvisoris(new FilterHeader());
    this.getBancaris(new FilterHeader());
  }

  @HostListener('input') oninput() {
    this.searchProvisoris();
    this.searchApunts();
  }

  isPantallaCertificacio(): boolean {
    return this.router.url.indexOf("certificar") > 0;
  }

  closeProgress(progress: ElementRef) {
    progress.nativeElement.classList.remove('show');
    progress.nativeElement.classList.add('collapse');
  }

  showProgress(progress: ElementRef) {
    progress.nativeElement.classList.remove('collapse');
    progress.nativeElement.classList.add('show');
  }

  //-------------------------------------
  // PROVISORIOS
  //-------------------------------------
  getProvisoris(filter: FilterHeader) {
    filter.add(new FilterDetail("Compañias", "Compañias", "items", null, this.selectedCIA, null, null, null, null, null, null, null));
    filter.add(new FilterDetail("Contratos", "Contratos", "items", null, this.selectedCTA, null, null, null, null, null, null, null));

    this.movFisicoService.getProvisorisConcilFilter(filter).subscribe(
      provisoris => {
        this.provisoris = provisoris as XRSKMovimientoFisico[];
        if (this.provisoris.length > 0) {
        }

        this.mdbTableProv.setDataSource(this.provisoris);
        this.previousProvisoris = this.mdbTableProv.getDataSource();
        this.closeProgress(this.matProgressProv);
      },
      err => {
        this.closeProgress(this.matProgressProv);
        //this.showAlert(err);
      }
    );

    filter.remove("Compañias");
    filter.remove("Contratos");
  }

  // Exemple d'origen: https://stackblitz.com/edit/angular-5k2kgl?file=src%2Fapp%2Fapp.component.html
  ProvisoriRowClick(item) {
    this.provisoriSelected = item;
    if (!this.provisorisSelected.has(this.provisoriSelected)) {
      this.provisorisSelected.add(this.provisoriSelected);
      this.provisorisSelectedAmount += this.provisoriSelected.mvfImNetDiv * this.provisoriSelected.mvfSigImpNet;
    } else {
      this.provisorisSelected.delete(this.provisoriSelected);
      this.provisorisSelectedAmount -= this.provisoriSelected.mvfImNetDiv * this.provisoriSelected.mvfSigImpNet;
    }

    this.GestionaBotonera();
  }

  ProvisoriIsSelected(id: XRSKMovimientoFisico) {
    return this.provisorisSelected.has(id);
  }

  searchProvisoris() {
    const prev = this.mdbTableProv.getDataSource();
    if (!this.searchTextProvisoris) {
      this.mdbTableProv.setDataSource(this.previousProvisoris);
      this.provisoris = this.mdbTableProv.getDataSource();
    }
    if (this.searchTextProvisoris) {
      //this.provisoris = this.mdbTableProv.searchLocalDataBy(this.searchTextProvisoris);
      //this.mdbTableProv.setDataSource(prev);
      this.provisoris = this.provisoris.filter(
        x => this.datePipe.transform(x.mvfFechOperac, 'dd/MM/yyyy').includes(this.searchTextProvisoris)
          || x.mvfCodOPE.toLowerCase().includes(this.searchTextProvisoris)
          || x.mvfImNetDiv.toString().includes(this.searchTextProvisoris)
          || x.mvfDescripcion.toLowerCase().includes(this.searchTextProvisoris));
    }
  }

  //-------------------------------------
  // APUNTES BANCARIOS
  //-------------------------------------
  getBancaris(filter: FilterHeader) {
    filter.add(new FilterDetail("Compañias", "Compañias", "items", null, this.selectedCIA, null, null, null, null, null, null, null));
    filter.add(new FilterDetail("Contratos", "Contratos", "items", null, this.selectedCTA, null, null, null, null, null, null, null));

    this.apBancarioService.getPendingConcilFilter(filter).subscribe(
      apunts => {
        this.apunts = apunts as XRSKApunteBancario[];
        if (this.apunts.length > 0) {
        }
        this.loadingBanc = false;
        this.mdbTableApunt.setDataSource(this.apunts);
        this.previousApunts = this.mdbTableApunt.getDataSource();
        this.closeProgress(this.matProgressBanc);
      },
      err => {
        this.closeProgress(this.matProgressBanc);
        //this.showAlert(err);
      }
    );

    filter.remove("Compañias");
    filter.remove("Contratos");
  }

  ApuntRowClick(item) {
    this.apuntSelected = item;
    if (!this.apuntsSelected.has(this.apuntSelected)) {
      this.apuntsSelected.add(this.apuntSelected);
      this.apuntsSelectedAmount += ((this.apuntSelected.abcSigno == "1") ? -1 : 1) * this.apuntSelected.abcImporte;
    } else {
      this.apuntsSelected.delete(this.apuntSelected);
      this.apuntsSelectedAmount -= ((this.apuntSelected.abcSigno == "1") ? -1 : 1) * this.apuntSelected.abcImporte;
    }

    this.GestionaBotonera();
  }

  ApuntIsSelected(id: XRSKApunteBancario) {
    return this.apuntsSelected.has(id);
  }

  searchApunts() {
    const prev = this.mdbTableApunt.getDataSource();
    if (!this.searchTextApunts) {
      this.mdbTableApunt.setDataSource(this.previousApunts);
      this.apunts = this.mdbTableApunt.getDataSource();
    }
    if (this.searchTextApunts) {
      //this.apunts = this.mdbTableApunt.searchLocalDataBy(this.searchTextApunts);
      //this.mdbTableApunt.setDataSource(prev);
      this.apunts = this.apunts.filter(
        x => this.datePipe.transform(x.abcFechOper, 'dd/MM/yyyy').includes(this.searchTextApunts)
          || x.abcOficina.toLowerCase().includes(this.searchTextApunts)
          || x.abcCuenta.toLowerCase().includes(this.searchTextApunts)
          || x.abcImporte.toString().includes(this.searchTextApunts));
    }
  }

  //-------------------------------------
  // BOTONERA
  //-------------------------------------
  GestionaBotonera() {
    this.provisoriAmountDiff = this.Arrodonir(this.provisorisSelectedAmount) - this.Arrodonir(this.apuntsSelectedAmount);
    this.showBtnConciliar = this.provisoriAmountDiff == 0 && this.apuntsSelected.size > 0 && this.provisorisSelected.size > 0;
    this.showBtnRelacionar = this.provisoriAmountDiff != 0 && this.apuntsSelected.size > 0 && this.provisorisSelected.size > 0;
    this.showBtnCompensar = this.provisoriAmountDiff == 0
      && ((this.apuntsSelected.size > 0 && this.provisorisSelected.size == 0) || (this.apuntsSelected.size == 0 && this.provisorisSelected.size > 0));
    this.showBtnIncorporar = this.provisoriAmountDiff != 0 && this.apuntsSelected.size > 0 && this.provisorisSelected.size == 0;
  }

  GoBack() {
    this._location.back();
  }

  //-------------------------------------
  // FILTROS
  //-------------------------------------
  getPreferences() {
    this.getPreferencesA();
    this.getPreferencesP();
  }

  getPreferencesA() {
    this.preferencesA = JSON.parse(localStorage.getItem('ABCConcilPreferences'));
    if (this.preferencesA != null) {
      this.preferencesAOn = true;
      this.setTooltipA();
      this.FechaADesde = new Date(this.preferencesA.fromDate);
      this.FechaAHasta = new Date(this.preferencesA.toDate);
      //this.selectedCompañias = this.preferences.selectedCompañias;
      // Asignación de un objeto de LocalStorage a una clase tipada con métodos. Si no se hace así no reconoce el tipo y declara un Object genérico en lugar de FilterHeader
      Object.assign(this.selectedFilterA, this.preferencesA.filter);

    } else {
      this.FechaAHasta = new Date();
      this.FechaADesde = new Date();
      this.FechaADesde.setDate(this.FechaAHasta.getDate() - 30);
      // Si no hubiera preferencias hacemos un filtro basado en la selección por defecto del componente.
      this.setDefaultFilterA();
    }
  }

  getPreferencesP() {
    this.preferencesP = JSON.parse(localStorage.getItem('MVFConcilPreferences'));
    if (this.preferencesP != null) {
      this.preferencesPOn = true;
      this.setTooltipP();
      this.FechaPDesde = new Date(this.preferencesP.fromDate);
      this.FechaPHasta = new Date(this.preferencesP.toDate);
      //this.selectedCompañias = this.preferences.selectedCompañias;
      // Asignación de un objeto de LocalStorage a una clase tipada con métodos. Si no se hace así no reconoce el tipo y declara un Object genérico en lugar de FilterHeader
      Object.assign(this.selectedFilterP, this.preferencesP.filter);

    } else {
      this.FechaPHasta = new Date();
      this.FechaPDesde = new Date();
      this.FechaPDesde.setDate(this.FechaPHasta.getDate() - 30);
      // Si no hubiera preferencias hacemos un filtro basado en la selección por defecto del componente.
      this.setDefaultFilterP();
    }
  }

  setTooltipA() {
    this.tooltipPreferencesA = this.preferencesA.filter.detail;
  }

  setTooltipP() {
    this.tooltipPreferencesP = this.preferencesP.filter.detail;
  }

  public setDefaultFilterP() {
    this.selectedFilterP.add(new FilterDetail("Operación", "MVFCodOPE", "items", null, null, null, null, null, null, null, null, null));
    this.selectedFilterP.add(new FilterDetail("F. Operación", "MVFFechOperac", "date", "range", null, null, null, null, null, this.FechaPDesde, this.FechaPHasta, null));
    this.selectedFilterP.add(new FilterDetail("F. Valor", "MVFFechValor", "date", "range", null, null, null, null, null, this.FechaPDesde, this.FechaPHasta, null));
    this.selectedFilterP.add(new FilterDetail("Importe", "MVFImNetDiv", "number", ">=", null, null, 0, null, null, null, null, null));
    this.selectedFilterP.add(new FilterDetail("Descripción", "MVFDescripcion", "string", "contains", null, "", null, null, null, null, null, null));
  }

  public setDefaultFilterA() {
    this.selectedFilterA.add(new FilterDetail("C. Común", "ABCConCom", "string", "equals", null, "", null, null, null, null, null, null));
    this.selectedFilterA.add(new FilterDetail("C. Propio", "ABCConPro", "string", "equals", null, "", null, null, null, null, null, null));
    this.selectedFilterA.add(new FilterDetail("F. Operación", "ABCFechOper", "date", "range", null, null, null, null, null, this.FechaADesde, this.FechaAHasta, null));
    this.selectedFilterA.add(new FilterDetail("F. Valor", "ABCFechVal", "date", "range", null, null, null, null, null, this.FechaADesde, this.FechaAHasta, null));
    this.selectedFilterA.add(new FilterDetail("Importe", "ABCImporte", "number", ">=", null, null, 0, null, null, null, null, null));
    this.selectedFilterA.add(new FilterDetail("Descripción", "ABCComple1", "string", "contains", null, "", null, null, null, null, null, null));
  }

  onFilterPClick() {
    this.modalOptions = {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: true,
      ignoreBackdropClick: false,
      class: 'modal-full-height modal-dialog-scrollable modal-right',
      animated: true,
      data: {
        heading: 'Filtro provisorios',
        items: this.selectedFilterP.detail,
      }
    }

    this.modalRef = this.modalService.show(SideFilterComponent, this.modalOptions);

    this.modalRef.content.confirmAction.subscribe((number: any) => {
      switch (number) {
        case "1":
          localStorage.setItem("MVFConcilPreferences", null);
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
        this.selectedFilterP.detail = items;
        this.getProvisoris(this.selectedFilterP);
        this.preferencesP = { "fromDate": this.FechaPDesde, "toDate": this.FechaPHasta, "filter": this.selectedFilterP }
        localStorage.setItem('MVFConcilPreferences', JSON.stringify(this.preferencesP));
      }
    }
    );
  }

  onFilterAClick() {
    this.modalOptions = {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: true,
      ignoreBackdropClick: false,
      class: 'modal-full-height modal-dialog-scrollable modal-right',
      animated: true,
      data: {
        heading: 'Filtro apuntes',
        items: this.selectedFilterA.detail,
      }
    }

    this.modalRef = this.modalService.show(SideFilterComponent, this.modalOptions);

    this.modalRef.content.confirmAction.subscribe((number: any) => {
      switch (number) {
        case "1":
          localStorage.setItem("ABCConcilPreferences", null);
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
        this.selectedFilterA.detail = items;
        this.getBancaris(this.selectedFilterA);
        this.preferencesA = { "fromDate": this.FechaADesde, "toDate": this.FechaAHasta, "filter": this.selectedFilterA }
        localStorage.setItem('ABCConcilPreferences', JSON.stringify(this.preferencesA));
      }
    }
    );
  }

  //-------------------------------------
  // SELECTORES FILTROS
  //-------------------------------------
  getSelectorOperaciones() {
    this.operacionService.getXRSKOperacionFiltro().subscribe(
      operaciones => {
        this.selectorOperaciones.detail = operaciones as filtermodel[];
        this.selectedItems = this.selectedFilterP.detail.find(x => x.entity == "MVFCodOPE").values;
        if (this.selectedItems != null) {
          this.selectorOperaciones.markChecked(this.selectedItems);
        }
        this.selectedFilterP.detail.find(x => x.entity == "MVFCodOPE").content = this.selectorOperaciones.detail;
      },
      err => {
        //this.errorText = err;
        //this.showAlert(this.errorText);
      }
    );
  }

  //-------------------------------------
  // OPERACIONES
  //-------------------------------------
  ConciliarCertificar() {
    this.RealizarOperacion(this.isPantallaCertificacio() ? "Certificar" : "Conciliar");
  }

  Relacionar() {
    this.RealizarOperacion("Relacionar");
  }

  Compensar() {
    this.RealizarOperacion("Compensar");
  }

  Incorporar() {
    this.openDialog("Incorporar", "Pendiente");
  }

  RealizarOperacion(codigo: string) {
    this.toDo = new ConciliacionModel(this.selectedCIA[0], codigo);
    for (let ps of this.provisorisSelected) {
      this.toDo.addMovimiento(new MovimientosDetailModel(ps.mvfCodCIA, ps.mvfRefXRisk));
    }
    for (let ap of this.apuntsSelected) {
      this.toDo.addApunte(new ApuntesDetailModel(ap.abcCodCIA, ap.abcNumerador));
    }

    this.concilService.executeOperation(this.toDo).subscribe(
      refConcil => {
        this.refConcil = refConcil as number;
        this.openDialog(codigo, "Operación realizada con código " + this.Arrodonir(this.refConcil));
        this.getProvisoris(this.selectedFilterP);
        this.getBancaris(this.selectedFilterA);
        this.provisorisSelected.clear();
        this.apuntsSelected.clear();
        this.provisorisSelectedAmount = 0;
        this.apuntsSelectedAmount = 0;
        //this.componentCNC = cncFiltered as XRSKCNCSituacion[];
        //this.mdbTable.setDataSource(this.componentCNC);
        //this.previous = this.mdbTable.getDataSource();
      },
      err => {
        //this.showAlert();
      }
    );
  }

  //-------------------------------------
  // SOPORTE
  //-------------------------------------
  openDialog(heading: string, description: string) {
    this.modalOptions = {
      backdrop: true,
      keyboard: true,
      focus: true,
      show: false,
      ignoreBackdropClick: false,
      class: 'modal-notify',
      containerClass: 'modal fade',
      animated: true,
      data: {
        heading: heading,
        content: { description: description },
        afirmative: 'Aceptar',
      }
    };

    this.modalRef = this.modalService.show(ModalComponent, this.modalOptions);
  }

  Arrodonir(valor: number) {
    return Math.round((valor + Number.EPSILON) * 100) / 100;
  }
}
