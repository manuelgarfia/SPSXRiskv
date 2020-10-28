import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-tipo-interes',
  templateUrl: './tipo-interes.component.html',
  styleUrls: ['./tipo-interes.component.css']
})
export class TipoInteresComponent implements OnInit {

  tipusInteres: Array<Object>;
  tipusInteresCode: String;
  tipusInteresSelected: Object;

  constructor(private ruta: ActivatedRoute, private _location: Location) {
    this.tipusInteres = [
      { codigo: 'E12M', descri: 'Euribor 1 año' },
      { codigo: 'E12MC0', descri: 'Euribor 1 año Clausula 0' },
      { codigo: 'E1M', descri: 'Euribor 1 mes' },
      { codigo: 'E1MC0', descri: 'Euribor 1 mes Clausula 0' },
      { codigo: 'E2M', descri: 'Euribor 2 meses' },
      { codigo: 'E2MC0', descri: 'Euribor 2 meses Clausula 0' },
      { codigo: 'E3M', descri: 'Euribor 3 meses' },
      { codigo: 'E3MC0', descri: 'Euribor 3 meses Clausula 0' },
      { codigo: 'E4M', descri: 'Euribor 4 meses' },
      { codigo: 'E4MC0', descri: 'Euribor 4 meses Clausula 0' },
      { codigo: 'E6M', descri: 'Euribor 6 meses' },
      { codigo: 'E6MC0', descri: 'Euribor 6 meses Clausula 0' },
      { codigo: 'E9M', descri: 'Euribor 9 meses' },
      { codigo: 'E9MC0', descri: 'Euribor 9 meses Clausula 0' },
      { codigo: 'EONIA', descri: 'Euribor 1 día' },
      { codigo: 'EONIAC0', descri: 'Euribor 1 día Clausula 0' },
      { codigo: 'INT0', descri: 'Interes 0' },
      { codigo: 'INTEURNEG', descri: 'INTERESES EUROS NEGATIVO' },
      { codigo: 'INTEURPOL', descri: 'INTERESES EUROS POLIZA DE CREDITO' },
      { codigo: 'INTEURPOS', descri: 'INTERESES EUROS POSITIVO' },
      { codigo: 'INTUSDNEG', descri: 'INTERESES DOLARES NEGATIVO' },
      { codigo: 'INTUSDPOS', descri: 'INTERESES DOLARES POSITIVO' },
      { codigo: 'IRPH-CAJAS', descri: 'IRPH-CAJAS 3' },
      { codigo: 'USDLIB', descri: 'USD Libor' },
      { codigo: 'USDLIB12M', descri: 'USD Libor 12 meses' },
      { codigo: 'USDLIB1M', descri: 'USD Libor 1 mes' },
      { codigo: 'USDLIB2M', descri: 'USD Libor 2 meses' },
      { codigo: 'USDLIB3M', descri: 'USD Libor 3 meses' },
      { codigo: 'USDLIB6M', descri: 'USD Libor 6 meses' },
      { codigo: 'USDLIB9M', descri: 'USD Libor 9 meses' }
    ]
  }

  ngOnInit(): void {
    this.ruta.params.subscribe(params => {
      this.tipusInteresCode = params['tipusInteresCode'];
      this.tipusInteresSelected = this.trobarTipusInteres();
    })
  }

  hiHaParametre() {
    return this.tipusInteresCode != null;
  }

  filtrarPerCodi(tipusInteres) {
    return tipusInteres.codigo == this;
  }

  trobarTipusInteres() {
    return this.tipusInteres.filter(this.filtrarPerCodi, this.tipusInteresCode)[0];
  }

  backClicked() {
    this._location.back();
  }
}
