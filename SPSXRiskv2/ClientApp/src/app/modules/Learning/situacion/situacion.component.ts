import { Component, OnInit, ViewChild } from '@angular/core';

import { XRSKApunBancCSB_PSD2, XRSKApunBancCSBPSD2 } from '../../../shared/models/xrskApunBancCSB_PSD2.model';
import { XRSKApunBancCSB_PSD2Service } from '../../../shared/services/xrskApunBancCSB_PSD2.service';
import { MdbTablePaginationComponent, MdbTableDirective } from 'angular-bootstrap-md';
import { ModalgridComponent } from 'src/app/shared/components/modalgrid/modalgrid.component';
import { XRSKfac_clientes } from '../../../shared/models/xrskfac_clientes.model';
import { XRSKEfectos } from '../../../shared/models/xrskEfectos.model';
import { XRSKfac_clientesService } from '../../../shared/services/xrskfac_clientes.service';
import { XRSKEfectosService } from '../../../shared/services/xrskEfectos.service';

@Component({
  selector: 'app-situacion',
  templateUrl: './situacion.component.html',
  styleUrls: ['./situacion.component.css']
})
export class SituacionComponent implements OnInit {

  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;

  constructor(private apunBancService: XRSKApunBancCSB_PSD2Service,
    private efectosService: XRSKEfectosService) { }

  apunBanc: any[] = [];
  facClientesRelacionados: any[] = [];
  facClientesAsignados: any[] = [];

  relacionados: any[] = [];
  pendientes: any[] = [];
  asignados: any[] = [];


  ngOnInit(): void {
    this.getapunBancList();
  }

  getapunBancList() {
    this.apunBancService.getXRSKApunBancCSB_PSD2List().subscribe(
      apunBanc => {
        this.apunBanc = apunBanc as XRSKApunBancCSB_PSD2[];
        this.apunBancRows();
        this.getFacClientesRelacionados();
      },
      err => {
        console.log(err);
      }
    );
  }

  apunBancRows() {

    this.relacionados = this.apunBanc.filter(x => x.ABCNumerador == 1000001);
    this.pendientes = this.apunBanc.filter(x => x.ABCNumerador == 1000002 || x.ABCNumerador == 1000003);
    this.asignados = this.apunBanc.filter(x => x.ABCNumerador == 1000000);
  }


  //FAC CLIENTES

  numero: number;
  numeroAsignado: number;
  getFacClientesRelacionados() {

    //Part de Relacionados
    for (let elem of this.relacionados) {
      this.numero = elem.ABCNumerador;
    }

    this.efectosService.getXRSKEfectosCienteList(this.numero).subscribe(
      facClientesRelacionados => {
        this.facClientesRelacionados = facClientesRelacionados as XRSKEfectos[];
      },
      err => {
        console.log(err);
      }
    );

    //Part de Asignados
    for (let elem of this.asignados) {
      this.numeroAsignado = elem.ABCNumerador;
    }

    this.efectosService.getXRSKEfectosCienteList(this.numeroAsignado).subscribe(
      facClientesAsignados => {
        this.facClientesAsignados = facClientesAsignados as XRSKEfectos[];
      },
      err => {
        console.log(err);
      }
    );

  }

  set_modal_options() {

    //this.modalOptionsZoom = {
    //  data: {
    //    heading: 'Clientes',
    //    items: this.general_array,
    //    properties: [{ name: this.propertyName, label: "Código" }, { name: this.propertyName2, label: this.propertyDescription }]
    //  }
    //};

  }
}
