export interface XRSKMovimientoFisicoI {
  mvfGrupo:   string,
  mvfCodCIA:  string,
  mvfValorOrganizativo: string,
  mvfRefXRisk: number,
  mvfImBrDivisa: number,
  mvfSigImpNet: number,
  mvfImNetDiv: number,
  mvfCodGEN: string,
  mvfCodENT: string,
  mvfCodTLI: string,
  mvfCodCTA: string,
  mvfRef1SisExt: string,
  mvfAgrOpe: string,
  mvfCodOPE: string,
  mvfTipoOPE: string,
  mvfContAgrOPE: string,
  mvfContrapartidaOPE: boolean,
  mvfGradCert: string,
  mvfFechOperac: Date
  // Propiedades Relacionadas
  cidDescripcion: string
}

export class XRSKMovimientoFisico {
  mvfGrupo: string;
  mvfCodCIA: string;
  mvfValorOrganizativo: string;
  mvfRefXRisk: number;
  mvfImBrDivisa: number;
  mvfSigImpNet: number;
  mvfImNetDiv: number; /*Importe Neto*/
  mvfCodGEN: string;
  mvfCodENT: string;
  mvfCodTLI: string;
  mvfCodCTA: string;
  mvfCodCPT: string;
  mvfCodDIV: string;
  mvfGradCert: string;
  mvfCodOPE: string;
  mvfDescripcion: string;
  mvfRef1SisExt: string; /*Referencia*/
  mvfAgrOpe: string;
  mvfTipoOPE: string;
  mvfContAgrOPE: string;
  mvfConciliado: string;
  mvfContrapartidaOPE: boolean;
  mvfImpNetDivMN: number;/*Importe Mon-Grupo*/
  mvfCamBrImpu: number; /*Cambio Operación*/
  mvfCamNetCptMn: number;
  mvfImBrPtas: number; //Importe Operación
  mvfCodCPTDIV: string; //Divisa Operación
  mvfFechValor: Date;
  mvfFechConc: Date;
  mvfRefConc: number;
  mvfFechCont: Date;
  mvfRefCont: number;
  mvfFechIncor: Date;
  mvfRefIncor: number;
  mvfFechCert: Date;
  mvfRefCert: number;
  //3R TAB
  mvfCodTIntRef: number;
  mvfFechVto: Date;
  mvfSpread: number;
  mvfTipInt: number;
  //4T TAB
  mvfCodAOP: string;
  mvfCodGFL: string;
  mvfCodFLU: string;
  mvfCodACP: string;
  mvfFechImp: Date;
  mvfSisOrig: string;
  mvfCodIrcREF: string;
  mvfFechEstimada: string;
  mvfCodUSR: string;

  mvfFechOperac: Date;
  // Propiedades Relacionadas
  cidDescripcion: string;

  constructor() { };
}

export interface XRSKMovFisicoExamples {
  mvfCodCIA: string,
  mvfDescripcion: string,
  mvfFechOperac: Date,
  mvfRefXRisk: number,
}
