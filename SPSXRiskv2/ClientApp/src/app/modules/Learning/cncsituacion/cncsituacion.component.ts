import { Component, OnInit, Inject, HostListener, ViewChild, ChangeDetectorRef, ElementRef, Output, EventEmitter } from '@angular/core';
import { MdbTableDirective, MdbTablePaginationComponent, MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { Observable } from 'rxjs';
import { from } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

import { condicionesbancariasmodel } from 'src/app/shared/models/georginaclass.model'
import { EntidadFilter } from 'src/app/shared/components/pipes/entidadFilter.pipe'
import { entidadesmodel } from 'src/app/shared/models/entidadmodel';
import { filtermodel, sendFiltermodel, FilterDetail, FilterHeader, filtermodelArray } from 'src/app/shared/models/filtermodel';
import { SideFilterComponent } from 'src/app/shared/components/side-filter/side-filter.component'
import { XRSKCIAService } from 'src/app/shared/services/cia.service';
import { XRSKCNCSituacion } from '../../../shared/models/xrskCNCSituacion.model';
import { XRSKCNCSituacionService } from 'src/app/shared/services/xrskCNCSituacion.service';
import { XRSKContratosService } from 'src/app/shared/services/xrskContratos.service';
import { XRSKEntidadService } from 'src/app/shared/services/entidad.service';
import { XRSKOperacionService } from 'src/app/shared/services/operacion.service';

@Component({
  selector: 'app-cncsituacion',
  templateUrl: './cncsituacion.component.html',
  styleUrls: ['./cncsituacion.component.css']
})

export class CNCSituacionComponent implements OnInit {
  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild('alert', { static: true }) alert: ElementRef;
  @ViewChild('Progress') progress: ElementRef;

  color = 'primary';
  mode = 'indeterminate';
  value = 50;
  bufferValue = 75;

  //Definimos la variable Compañia para otorgarle un valor concreto.
  public cia: string = '100';
  public ciaList: any[];
  public componentCNC: any = [];
  public contratosList: any[];
  //Modal
  modalRef: MDBModalRef;
  public modalOptions: any;
  public panels: any;
  //Tooltip
  public preferencesOn: boolean = false;
  public selectorCompanyias: filtermodelArray = new filtermodelArray();
  public selectedCias: string[] = [];
  public selectedFilter: FilterHeader = new FilterHeader();
  public selectedItems: string[] = [];

  errorText: string = 'Está en proceso!';
  previous: any = [];
  preferences: any;
  tooltipPreferences: any = [];

  //
  constructor(private cncService: XRSKCNCSituacionService,
              public ciaService: XRSKCIAService,
              public contratosService: XRSKContratosService,
              public modalservice: MDBModalService) { }

  ngOnInit(): void {
    this.getPreferences();
    this.getCNCListComponent();
    this.getCompanyies();
    this.getContratos(this.cia);
  }

  //Filter
  onFilterClick() {
    if (this.selectedCias != null) {
      this.selectorCompanyias.markChecked(this.selectedCias);
    }

    this.panels = [
      {
        title: 'Compañias',
        type: 'items',
        subtype: null,
        compareType: null,
        import: null,
        importMax: null,
        from: null,
        to: null,
        content: this.selectorCompanyias.detail
      },
      {
        title: 'Contratos',
        type: 'items',
        subtype: null,
        compareType: null,
        import: null,
        importMax: null,
        from: null,
        to: null,
        content: this.contratosList
      }
    ];

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
        items: this.panels,
      }
    }

    //S'obre el modal
    this.modalRef = this.modalservice.show(SideFilterComponent, this.modalOptions);

    this.modalRef.content.sendItems.subscribe(((items: any) => {
      if (items) {
        this.panels = items;
        this.selectedCias = [];

        // Ejemplo de conversión a cadena
        for (let panel of this.panels) {
          this.selectedItems = [];
          var panelContent = panel.content as filtermodel[];

          if (panel.type === "items") {
            var panelFiltered = panelContent.filter(x => x.checked == true);
            for (let item of panelFiltered) {
              this.selectedCias.push(item.code);
              this.selectedItems.push(item.code);
            }
          }

          this.selectedFilter.add(new FilterDetail(panel.title, panel.title, panel.type, null, this.selectedItems, null, null, null, null, null, null, null));
        }

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

  //
  filterXRSK(selectedItems: FilterHeader) {
    this.cncService.getXRSKFilter(selectedItems).subscribe(
      cncFiltered => {
        this.componentCNC = cncFiltered as XRSKCNCSituacion[];
        this.mdbTable.setDataSource(this.componentCNC);
        this.previous = this.mdbTable.getDataSource();
      },
      err => {
        this.showAlert();
      }
    );
  }

  //Companyies
  getCompanyies(): void {
    this.ciaService.get_cia_filter().subscribe(
      ciaList => {
        this.selectorCompanyias.detail = ciaList as filtermodel[];
        this.ciaList["title"] = "Compañias";
      },
      err => {
        this.errorText = err;
        this.showAlert();
      }
    );
  }

  //Get Contratos list
  getContratos(cia: string): void {
    // Quitamos compañía porque es la que diga la seguridad del usuario.
    this.contratosService.get_cia_filter().subscribe(
      contratosList => {
        this.contratosList = contratosList as filtermodel[];
        this.contratosList["title"] = "Contratos";
      },
      err => {
        this.errorText = err;
        this.showAlert();
      }
    );
  }

  //Preferences
  getPreferences() {
    this.preferences = JSON.parse(localStorage.getItem('CNCPreferences'));
    if (this.preferences != null) {
      this.preferencesOn = true;
      this.setTooltip();
      this.selectedCias = this.preferences.selectedCias;
      this.filterXRSK(this.preferences.filter);
    } else {
      //this.FechaHasta = new Date();
      //this.FechaDesde = new Date();
      //this.FechaDesde.setDate(this.FechaHasta.getDate() - 30);
    }
  }

  setTooltip() {
    this.tooltipPreferences = this.preferences.filter.detail;
  }

  savePreferences() {
    this.preferences = { selectedCias: this.selectedCias, filter: this.selectedFilter }
    localStorage.setItem('CNCPreferences', JSON.stringify(this.preferences));
  }

  // Get "Situación de conciliación" list
  getCNCListComponent(): void {
    this.cncService.getXRSKCNCSituacionList().subscribe(
      componentCNC => {
        this.componentCNC = componentCNC as XRSKCNCSituacion[];
        this.mdbTable.setDataSource(this.componentCNC);
        this.previous = this.mdbTable.getDataSource();
        //this.cbv_list_filtered = this.previous;
        this.closeProgress();
      },
      err => {
        this.errorText = err;
        this.showAlert();
        this.closeProgress();
      }
    );
  }

  closeProgress() {
    this.progress.nativeElement.classList.remove('show');
    this.progress.nativeElement.classList.add('collapse');
  }

  showProgress() {
    this.progress.nativeElement.classList.remove('collapse');
    this.progress.nativeElement.classList.add('show');
  }

  //
  showAlert() {
    this.alert.nativeElement.classList.remove('collapse');
    this.alert.nativeElement.classList.add('show');
  }

  //
  closeAlert() {
    this.alert.nativeElement.classList.remove('show');
    this.alert.nativeElement.classList.add('collapse');
  }
}
