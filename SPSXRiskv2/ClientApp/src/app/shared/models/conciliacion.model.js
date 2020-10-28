"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ConciliacionModel = /** @class */ (function () {
    function ConciliacionModel(_companyia, _operacion) {
        this.companyia = _companyia;
        this.companyia = _companyia;
        this.operacion = _operacion;
        this.movimientos = [];
        this.apuntes = [];
    }
    ConciliacionModel.prototype.addMovimiento = function (_movimiento) {
        var previous = this.movimientos.filter(function (x) { return x.cia === _movimiento.cia && x.referencia === _movimiento.referencia; });
        if (previous.length != 0) {
            var index = this.movimientos.indexOf(previous[0]);
            this.movimientos[index] = _movimiento;
        }
        else {
            // Si no existe lo creamos
            this.movimientos.push(_movimiento);
        }
    };
    ConciliacionModel.prototype.addApunte = function (_apunte) {
        var previous = this.apuntes.filter(function (x) { return x.cia === _apunte.cia && x.referencia === _apunte.referencia; });
        if (previous.length != 0) {
            var index = this.apuntes.indexOf(previous[0]);
            this.apuntes[index] = _apunte;
        }
        else {
            // Si no existe lo creamos
            this.apuntes.push(_apunte);
        }
    };
    return ConciliacionModel;
}());
exports.ConciliacionModel = ConciliacionModel;
var MovimientosDetailModel = /** @class */ (function () {
    function MovimientosDetailModel(_cia, _referencia) {
        this.cia = _cia;
        this.referencia = _referencia;
    }
    ;
    return MovimientosDetailModel;
}());
exports.MovimientosDetailModel = MovimientosDetailModel;
var ApuntesDetailModel = /** @class */ (function () {
    function ApuntesDetailModel(_cia, _referencia) {
        this.cia = _cia;
        this.referencia = _referencia;
    }
    ;
    return ApuntesDetailModel;
}());
exports.ApuntesDetailModel = ApuntesDetailModel;
//# sourceMappingURL=conciliacion.model.js.map