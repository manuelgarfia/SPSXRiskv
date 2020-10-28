import { Component, OnInit, ViewChild } from '@angular/core';
import { XRSKMovimientoFisicoService } from '../../../shared/services/xrskMovimientoFisico.service';
import { filtermodel, sendFiltermodel, FilterDetail, FilterHeader, filtermodelArray } from 'src/app/shared/models/filtermodel';
import { MdbTablePaginationComponent, MdbTableDirective, MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { XRSKMovFisicoExamples } from '../../../shared/models/xrskMovimientoFisico.model';
import { SideFilterComponent } from 'src/app/shared/components/side-filter/side-filter.component'

@Component({
  selector: 'app-mov-fisico-examples',
  templateUrl: './mov-fisico-examples.component.html',
  styleUrls: ['./mov-fisico-examples.component.css']
})
export class MovFisicoExamplesComponent implements OnInit {

  public itemsMovFisico: filtermodelArray = new filtermodelArray();
  public itemsList: any[] = [];
  public previous: any = [];
  public panels: any;
  public modalOptions: any;
  modalRef: MDBModalRef;

  public selectedItems: string[] = [];
  public selectedFilter: FilterHeader = new FilterHeader();
  public selectedCias: string[] = [];
  public selectorCompañias: filtermodelArray = new filtermodelArray();
  FechaDesde: Date;
  FechaHasta: Date;
  preferences: any;
  public selectedDateType: string;

  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;

  constructor(private movfisicoService: XRSKMovimientoFisicoService,
    public modalservice: MDBModalService,
    private movimientoFisicoService: XRSKMovimientoFisicoService) { }


  ngOnInit(): void {
    this.getPreferences();
    this.filterXRSK(this.selectedFilter);
  }

  getPreferences() {
    this.preferences = JSON.parse(localStorage.getItem('ExamplesPreferences'));
    if (this.preferences != null) {
     // this.preferencesOn = true;
     // this.setTooltip();
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
    this.selectedFilter.add(new FilterDetail("Descripción", "MVFDescripcion", "string", "contains", null, "P", null, null, null, null, null, null));
    this.selectedFilter.add(new FilterDetail("F.Operacion", "MVFFechOperac", "date", "range", null, null, null, null, null, this.FechaDesde, this.FechaHasta, null));
    this.selectedFilter.add(new FilterDetail("Referencia XRisk", "MVFRefXRisk", "string", "contains", null, "", null, null, null, null, null, null));
  }

  //getItemsList(): void {
  //  this.movfisicoService.getXRSKMovFisicoExamplesList().subscribe(
  //    itemsList => {
  //      this.itemsList = itemsList as XRSKMovFisicoExamples[];
  //      this.mdbTable.setDataSource(this.itemsList);
  //      this.previous = this.mdbTable.getDataSource();
  //    },
  //    err => {
  //      //this.errorText = err;
  //      //this.showAlert();
  //    }
  //  );
  //}

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

  savePreferences() {
    this.preferences = { "selectedDateType": this.selectedDateType, "fromDate": this.FechaDesde, "toDate": this.FechaHasta, "filter": this.selectedFilter }
    localStorage.setItem('ExamplesPreferences', JSON.stringify(this.preferences));
  }

  filterXRSK(selectedItems: FilterHeader) {
    this.movimientoFisicoService.getXRSKMovFisicoExamplesList(selectedItems).subscribe(
      itemsList => {
        this.itemsList = itemsList as XRSKMovFisicoExamples[];
        this.mdbTable.setDataSource(this.itemsList);
        this.previous = this.mdbTable.getDataSource();
      },
      err => {
        //this.showAlert();
      }
    );
  }

}
