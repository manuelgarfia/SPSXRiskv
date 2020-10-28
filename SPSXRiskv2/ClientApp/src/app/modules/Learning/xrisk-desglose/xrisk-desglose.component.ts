import { Component, OnInit } from '@angular/core';
import { XRSKDesgloseContrService } from 'src/app/shared/services/xrskDesgloseContr.service';
import { XRSKDesglose, XRSKDesgloseContr } from 'src/app/shared/models/xrskDesgloseContr.model';
import { XRSKMovimientoFisico } from 'src/app/shared/models/xrskMovimientoFisico.model';
import { DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material/core';
import { AppDateAdapter, APP_DATE_FORMATS } from '../../../shared/format/format-datepicker';

@Component({
  selector: 'app-xrisk-desglose',
  templateUrl: './xrisk-desglose.component.html',
  styleUrls: ['./xrisk-desglose.component.css'],
  providers: [
    { provide: DateAdapter, useClass: AppDateAdapter },
    { provide: MAT_DATE_LOCALE, useValue: 'es-ES' },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS }
  ]
})
export class XriskDesgloseComponent implements OnInit {

  constructor(private desgloseService: XRSKDesgloseContrService) { }

  public desgloseRow: XRSKDesglose = new XRSKDesglose();
  public movimiento: XRSKMovimientoFisico = new XRSKMovimientoFisico();
  public desglose: any[] = [];

  ngOnInit(): void {
    this.getDesgloseRow();
  }

  getDesgloseRow() {
    this.desgloseRow = this.desgloseService.desgloseFromService();
    this.getDesglose(this.desgloseRow.DCPCodCIA, this.desgloseRow.DCPRefXrisk);
    this.movimiento = this.desgloseService.movimientoFromService();
  }

  //Desglose
  getDesglose(company: string, referencia: number) {
    this.desgloseService.getXRSKDesgloseList(company, referencia).subscribe(
      apunBanc => {
        this.desglose = apunBanc as XRSKDesgloseContr[];
        // this.mdbTable.setDataSource(this.apunBanc);
      },
      err => {
        console.log(err);
      }
    );
  }

  onDesgloseGrid(item) {
    this.desgloseRow = item;
  }

}
