export interface XRSKCBVigentes {
  cabid: number;
  CONCodACO: string;
  CONFechaDesde: Date | null;
  CONFechaHasta: Date | null;
  CONCodCIA: string,
  CONCodENT: string,
  CONCodCTA: string,
  CONCodOPE: string,
  opeDescripcion: string,
  CONIdCPT: number,
  CONMovGastos: boolean,
  CONCodGastosOPE: string,
  CONCodCPT: string,
  CONPorcentaje: number,
  CONimpMin: number,
  CONImpMax: number,
  CONFijo: number,
  CONCosteXefecto: boolean,
  CONTipoEfecto: string,
  CONInteresesDto: number,
  CONPorcentajeInteresDto: number,
  CONCalculoPorDivisa: boolean,
  CONNuevaCPTIVA: boolean,
  CONCodIVACPT: string,
  CONPorcentajeIVA: number,
  CONDesdeImporte: number,


}
