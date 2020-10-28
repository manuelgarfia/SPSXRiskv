import { Component, OnInit, ViewChild, ElementRef, ChangeDetectorRef } from '@angular/core';
import { XRSKEfectosService } from "src/app/shared/services/xrskEfectos.service"
import { carteraefectos, carteraEfectosClass } from "src/app/shared/models/carteraefectos.model"
import { XRSKEfectos } from "src/app/shared/models/xrskEfectos.model"
import { MdbTablePaginationComponent, MdbTableDirective } from 'angular-bootstrap-md';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, ThemePalette } from '@angular/material/core';
import { AppDateAdapter, APP_DATE_FORMATS } from 'src/app/shared/format/format-datepicker';





@Component({
  selector: 'app-xrsk-cartera-efectos',
  templateUrl: './xrsk-cartera-efectos.component.html',
  styleUrls: ['./xrsk-cartera-efectos.component.css'],
  providers: [
    { provide: DateAdapter, useClass: AppDateAdapter },
    { provide: MAT_DATE_LOCALE, useValue: 'es-ES' },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS }
  ]
})
export class XrskCarteraEfectosComponent implements OnInit {

  @ViewChild('tableEl') mdbtable: MdbTableDirective;
  @ViewChild('tableEl2') mdbtable2: MdbTableDirective;

  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild('mdbTablePagination2', { static: true }) mdbTablePagination2: MdbTablePaginationComponent;

  @ViewChild('GridView') GridView: ElementRef;



  //Variables

  public efectosResumen: any[] = [];
  public efectosDetalle: any[] = [];
  public previous: any = [];
  public previous2: any = [];
  //Recolección de datos del grid
  public efectosPick: carteraEfectosClass = new carteraEfectosClass();

  public selectedRowItem: carteraEfectosClass;

  //Constructor Area

  constructor(private XRSKEfectos: XRSKEfectosService, private cdRef: ChangeDetectorRef) {
  }

  ngOnInit(): void {
    this.getEfectosClienteResumen();
    //this.getEfectosClienteDetalle();
    
  }

  getEfectosClienteResumen(): void {
    this.XRSKEfectos.getXRSKEfectosClienteResumen().subscribe(
      efectosResumen => {
        this.efectosResumen = efectosResumen as carteraefectos[];
        this.mdbtable.setDataSource(this.efectosResumen);
      },
      err => {
        console.log(err);
      }
    )
  }

  edit(resumen) {
    this.onRowClick(resumen);
    this.efectosPick = Object.assign({}, resumen);
    this.getEfectosClienteDetalle();
    
  }

  getEfectosClienteDetalle(): void {
    
    this.XRSKEfectos.getXRSKEfectosCliente(this.efectosPick.codigocliente).subscribe(
      efectosDetalle => {
        this.efectosDetalle = efectosDetalle as XRSKEfectos[];
        this.mdbtable2.setDataSource(this.efectosDetalle);
      }
    )

  }
  ngAfterViewInit(): void {
    this.mdbTablePagination.setMaxVisibleItemsNumberTo(5);

    this.mdbTablePagination.calculateFirstItemIndex();
    this.mdbTablePagination.calculateLastItemIndex();

    this.mdbTablePagination2.setMaxVisibleItemsNumberTo(5);

    this.mdbTablePagination2.calculateFirstItemIndex();
    this.mdbTablePagination2.calculateLastItemIndex();
    this.cdRef.detectChanges();
  }

  onRowClick(item) {
    this.selectedRowItem = item;
  }

 
}
