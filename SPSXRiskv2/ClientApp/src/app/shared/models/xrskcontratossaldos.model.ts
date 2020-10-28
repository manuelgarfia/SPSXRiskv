export class xrskcontratossaldos{
  CTACod: string;
  CTACodCIA: string;
  CTATipoFecha: string;
  Fecha: Date;
  Saldos: number;
  constructor(contrato) {
    this.CTACod = contrato.ctaCod;
    this.CTACodCIA = contrato.ctaCodCIA;
    this.CTATipoFecha = contrato.ctaTipoFecha;
    this.Fecha = new Date(contrato.fecha);
    this.Saldos = contrato.saldo;
  }

}

export interface xrskcontratossaldosI {
  CTACod: string,
  CTACodCIA: string,
  CTATipoFecha: string,
  Fecha: Date,
  Saldos: number
}

