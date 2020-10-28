export interface xrskmvfsimplificado {
  cabid: number,
  ClavePrevision: string,
  mvfCodCIA: string,
  MVFRefXrisk: number,
  MVFCodCta: string,
  MVFRef1SisExt: string,
  MVFAgrOpe: string,
  MVFCodOPE: string,
  MVFCodCPT: string,
  MVFCuentaContableCPT: string,
  MVFDescripcion: string,
  MVFSisOrig: string,
  MVFCodITFLIT: string,
  MVFRefLoteLIT: string,
  MVFCodUSR: string,
  MVFFechImp: Date,
  MVFFechOperac: Date,
  MVFFechValor: Date,
  MVFCodDIV: string,
  MVFCodCPTDIV: string,
  MVFSigno: number,
  MVFImporte: number,
  MVFGradCert: string
  // Propiedades Relacionadas
  cidDescripcion: string
}

export class movsimplificado {
  cabid: number;
  ClavePrevision: string;
  mvfCodCIA: string;
  MVFRefXrisk: number;
  MVFCodCta: string;
  MVFRef1SisExt: string;
  MVFAgrOpe: string;
  MVFCodOPE: string;
  MVFCodCPT: string;
  MVFCuentaContableCPT: string;
  MVFDescripcion: string;
  MVFSisOrig: string;
  MVFImporte: number;
  MVFFechImp: Date;
  MVFFechOperac: Date;
  MVFFechValor: Date;
}
