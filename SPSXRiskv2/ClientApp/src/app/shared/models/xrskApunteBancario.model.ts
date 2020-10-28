export interface XRSKApunteBancario {
  abcCodCIA: string;
  abcNumerador: number;
  abcCodCTA: string;
  abcBanco: string;
  abcOficina: string;
  abcFechOper: Date;
  abcFechVal: Date;
  abcCuenta: string;
  abcConCom: string;
  abcConPro: string;
  abcSigno: string;
  abcImporte: number;
  abcDocumento: string;
  abcRef1: string;
  abcRef2: string;
  abcTipConcil: string;
  abcRefConcil: number;
  abcFechConcil: Date;
  abcComple1: string;
  abcComple2: string;
  abcComple3: string;
  abcComple4: string;
  abcComple5: string;
  abcComple6: string;
  abcComple7: string;
  abcComple8: string;
  abcComple9: string;
  abcComple10: string;
  abcIncorporado: boolean;
  abcFechaRealConc: Date;
  abcHistorif: boolean;
  abcFechIntro: Date;
  abcCodUSR: string;
  abcFichEnt: string;
  abcLibreLogico1: boolean;
  abcLibreLogico2: boolean;
  abcLibreLogico3: boolean;
  abcLibreTexto1: string;
  abcLibreTexto2: string;
  abcLibreTexto3: string;

  // Propietats relacionades
  cidDescripcion: string
}


export class ApuntBancModel {
  abcCodCIA: string;
  abcNumerador: number;
  abcCodCTA: string;
  abcBanco: string;
  abcOficina: string;
  abcFechOper: Date;
  abcFechVal: Date;
  abcCuenta: string;
  abcConCom: string;
  abcConPro: string;
  abcSigno: string;
  abcImporte: number;
  abcDocumento: string;
  abcRef1: string;
  abcRef2: string;
  abcTipConcil: string;
  abcRefConcil: number;
  abcFechConcil: Date;
  abcComple1: string;
  abcComple2: string;
  abcComple3: string;
  abcComple4: string;
  abcComple5: string;
  abcComple6: string;
  abcComple7: string;
  abcComple8: string;
  abcComple9: string;
  abcComple10: string;
  abcIncorporado: boolean;
  abcFechaRealConc: Date;
  abcHistorif: boolean;
  abcFechIntro: Date;
  abcCodUSR: string;
  abcFichEnt: string;
  abcLibreLogico1: boolean;
  abcLibreLogico2: boolean;
  abcLibreLogico3: boolean;
  abcLibreTexto1: string;
  abcLibreTexto2: string;
  abcLibreTexto3: string;
  numcuenta: string;
  complementos: string;
  operacion: string;
}

export interface ApuntBancInformation {
  abcCodCIA: string;
  abcNumerador: number;
  abcCodCTA: string;
  abcBanco: string;
  abcOficina: string;
  abcCuenta: string;
  abcConCom: string;
  abcConPro: string;
  abcFechOper: Date;
  abcFechVal: Date;
  abcSigno: string;
  abcImporte: number;
  abcDocumento: string;
  abcRef1: string;
  abcRef2: string;
  abcTipConcil: string;
  abcRefConcil: number;
  abcIncorporado: boolean;
  abcFechaRealConc: Date;
}
