"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var xrskcontratossaldos = /** @class */ (function () {
    function xrskcontratossaldos(contrato) {
        this.CTACod = contrato.ctaCod;
        this.CTACodCIA = contrato.ctaCodCIA;
        this.CTATipoFecha = contrato.ctaTipoFecha;
        this.Fecha = new Date(contrato.fecha);
        this.Saldos = contrato.saldo;
    }
    return xrskcontratossaldos;
}());
exports.xrskcontratossaldos = xrskcontratossaldos;
//# sourceMappingURL=xrskcontratossaldos.model.js.map