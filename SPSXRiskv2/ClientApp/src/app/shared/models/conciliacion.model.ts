export class ConciliacionModel {
  public companyia: string;
  public operacion: string;
  public movimientos: MovimientosDetailModel[];
  public apuntes: ApuntesDetailModel[];

  constructor(_companyia: string, _operacion: string) {
    this.companyia = _companyia;
    this.companyia = _companyia;
    this.operacion = _operacion;
    this.movimientos = [];
    this.apuntes = [];
  }

  addMovimiento(_movimiento: MovimientosDetailModel) {
    var previous = this.movimientos.filter(x => x.cia === _movimiento.cia && x.referencia === _movimiento.referencia);
    if (previous.length != 0) {
      var index = this.movimientos.indexOf(previous[0]);
      this.movimientos[index] = _movimiento;
    } else {
      // Si no existe lo creamos
      this.movimientos.push(_movimiento);
    }
  }

  addApunte(_apunte: ApuntesDetailModel) {
    var previous = this.apuntes.filter(x => x.cia === _apunte.cia && x.referencia === _apunte.referencia);
    if (previous.length != 0) {
      var index = this.apuntes.indexOf(previous[0]);
      this.apuntes[index] = _apunte;
    } else {
      // Si no existe lo creamos
      this.apuntes.push(_apunte);
    }
  }
}

export class MovimientosDetailModel {
  public cia: string;
  public referencia: number;

  constructor(_cia: string, _referencia: number) {
    this.cia = _cia;
    this.referencia = _referencia;
  };
}

export class ApuntesDetailModel {
  public cia: string;
  public referencia: number;

  constructor(_cia: string, _referencia: number) {
    this.cia = _cia;
    this.referencia = _referencia;
  };
}
