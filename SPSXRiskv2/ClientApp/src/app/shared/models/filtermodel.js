"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var filtermodel = /** @class */ (function () {
    function filtermodel() {
    }
    return filtermodel;
}());
exports.filtermodel = filtermodel;
var filtermodelArray = /** @class */ (function () {
    function filtermodelArray() {
        this.detail = [];
    }
    filtermodelArray.prototype.markChecked = function (values) {
    };
    return filtermodelArray;
}());
exports.filtermodelArray = filtermodelArray;
var sendFiltermodel = /** @class */ (function () {
    function sendFiltermodel() {
        this.code = [];
        this.entidades = [];
    }
    ;
    return sendFiltermodel;
}());
exports.sendFiltermodel = sendFiltermodel;
var FilterHeader = /** @class */ (function () {
    function FilterHeader() {
        this.detail = [];
    }
    FilterHeader.prototype.add = function (_detail) {
        // index es el índice del elemento de filtro por si ya existe
        var previous = this.detail.filter(function (x) { return x.entity === _detail.entity; });
        if (previous.length != 0) {
            var index = this.detail.indexOf(previous[0]);
            this.detail[index] = _detail;
        }
        else {
            // Si no existe lo creamos
            this.detail.push(_detail);
        }
    };
    return FilterHeader;
}());
exports.FilterHeader = FilterHeader;
var FilterDetail = /** @class */ (function () {
    function FilterDetail(_entity, _type, _values, _charValue, _decValue, _from, _to) {
        this.entity = _entity;
        this.type = _type;
        this.values = _values;
        this.charValue = _charValue;
        this.decValue = _decValue;
        this.from = _from;
        this.to = _to;
    }
    ;
    return FilterDetail;
}());
exports.FilterDetail = FilterDetail;
//# sourceMappingURL=filtermodel.js.map