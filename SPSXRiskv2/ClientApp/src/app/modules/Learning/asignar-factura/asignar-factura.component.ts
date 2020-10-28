import { Component, OnInit, ViewChild, ElementRef, ChangeDetectorRef, Input, HostListener } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppDateAdapter, APP_DATE_FORMATS } from '../../../shared/format/format-datepicker';
import { DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material/core';
import { MdbTableDirective, MdbTablePaginationComponent, MDBModalRef, MDBModalService } from 'angular-bootstrap-md';

import { ModalComponent } from 'src/app/shared/components/modal/modal.component';

import { filtermodel, filtermodelArray, FilterHeader, FilterDetail } from 'src/app/shared/models/filtermodel';
//import { ConciliacionModel, MovimientosDetailModel, ApuntesDetailModel } from 'src/app/shared/models/conciliacion.model';
//import { XRSKConciliacionService } from 'src/app/shared/services/xrskConciliacion.service';
//import { XRSKApunteBancario } from 'src/app/shared/models/xrskApunteBancario.model';
//import { XRSKApunteBancarioService } from 'src/app/shared/services/xrskApunteBancario.service';
//import { XRSKMovimientoFisico } from 'src/app/shared/models/xrskMovimientoFisico.model';
//import { XRSKMovimientoFisicoService } from 'src/app/shared/services/xrskMovimientoFisico.service';
import { XRSKvw_fac_AsignarFacturaHeaderService } from '../../../shared/services/xrskvw_fac_AsignarFacturaHeader.service';
import { XRSKvw_fac_AsignarFacturaHeader } from 'src/app/shared/models/xrskvw_fac_AsignarFacturaHeader.model';
import { XRSKEfectosService } from '../../../shared/services/xrskEfectos.service';
import { XRSKEfectos } from 'src/app/shared/models/xrskEfectos.model';

@Component({
  selector: 'app-asignar-factura',
  templateUrl: './asignar-factura.component.html',
  styleUrls: ['./asignar-factura.component.css'],
  providers: [
    { provide: DateAdapter, useClass: AppDateAdapter },
    { provide: MAT_DATE_LOCALE, useValue: 'es-ES' },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS }
  ]
})

export class AsignarFacturaComponent implements OnInit {
  //@ViewChild('ProgressProv') matProgressProv: ElementRef;
  //@ViewChild('ProgressBanc') matProgressBanc: ElementRef;
  //@ViewChild('tableEl') mdbTableProv: MdbTableDirective;
  //@ViewChild('tableE2') mdbTableApunt: MdbTableDirective;

  color = 'primary';
  mode = 'indeterminate';
  value = 50;
  bufferValue = 75;

  title: string = "";
  ttOperacion: string = "";

  currentABCNumerador: number;
  public asignarFactura: XRSKvw_fac_AsignarFacturaHeader;
  public efectos: any = [];
  public efectoSelected: XRSKEfectos;
  efectosSelected: Set<XRSKEfectos> = new Set<XRSKEfectos>();

  totalFacturas: number = 0;
  diferenciaFacturas: number = 0;

    // Finestra modal
  public modalOptions: any;
  modalRef: MDBModalRef;

  // Gestió de la botonera
  public showBtnAsignar: boolean = false;
  public showBtnCompensar: boolean = false;
  public showBtnRelacionar: boolean = false;

  // Preferències
  public selectedFilter: FilterHeader = new FilterHeader();

  // Constructor
  constructor(private ruta: ActivatedRoute,
    private _location: Location,
    private modalService: MDBModalService,
    private asigFacturaService: XRSKvw_fac_AsignarFacturaHeaderService,
    private efectosService: XRSKEfectosService,
    private router: Router) { }

  // Init method
  ngOnInit(): void {
    this.title = "Asignar facturas";

    this.ruta.params.subscribe(params => {
      this.currentABCNumerador = params['ABCNumerador'];
    })

    this.getApunt();
  }

  //@HostListener('input') oninput() {
  //  this.searchProvisoris();
  //  this.searchApunts();
  //}

  getApunt() {
    this.asigFacturaService.getXRSKvw_fac_AsignarFacturaHeader(this.currentABCNumerador).subscribe(
      apunt => {
        this.asignarFactura = apunt as XRSKvw_fac_AsignarFacturaHeader;
        this.diferenciaFacturas = apunt.ABCImporteSigno;
        this.getEfectosCliente(apunt.Codigo);
     },
      err => {
        //this.showAlert(err);
      }
    );
  }

  getEfectosCliente(codigo: string) {
    this.efectosService.getXRSKEfectosCliente(codigo).subscribe(
      efectos => {
        this.efectos = efectos as XRSKEfectos[];
        this.SeleccionarEfectosRecuperados();
      },
      err => {
        //this.showAlert(err);
      }
    );
  }

  SeleccionarEfectosRecuperados() {
    for (let item of this.efectos) {
      if (item.mvfrefxrisk == this.asignarFactura.MVFrefXrisk)
        this.EfectoRowClick(item);
    }
  }

  EfectoRowClick(item) {
    this.efectoSelected = item;
    if (!this.efectosSelected.has(this.efectoSelected)) {
      this.efectosSelected.add(this.efectoSelected);
      this.totalFacturas += this.efectoSelected.Importe;
      this.diferenciaFacturas -= this.efectoSelected.Importe;
    } else {
      this.efectosSelected.delete(this.efectoSelected);
      this.totalFacturas -= this.efectoSelected.Importe;
      this.diferenciaFacturas += this.efectoSelected.Importe;
    }

    //this.GestionaBotonera();
  }

  EfectoIsSelected(id: XRSKEfectos) {
    return this.efectosSelected.has(id);
  }

  goToMovFisico() {
    this.router.navigate(['xrskmovimientofisico/false/2157/290']);
  }

  Asignar() {
  }

  Compensar() {
  }

  Relacionar() {
  }
}
