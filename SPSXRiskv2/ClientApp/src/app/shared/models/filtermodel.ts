export class filtermodel {
  code: any;
  description: any;
  checked: boolean;
}

export class filtermodelArray {
  public detail: filtermodel[];

  constructor() {
    this.detail = [];
  }

  markChecked(values: string[]) {

    this.detail.forEach(x => {

      if (values.includes(x.code)) {
        x.checked = true;
      }
    });


  }
}

export class sendFiltermodel {
  code: any[];
  entidades: any[];
  title: any;

  constructor() {
    this.code = [];
    this.entidades = [];
  };



}
export class FilterHeader {
  public detail: FilterDetail[];

  constructor() {
    this.detail = [];
  }

  add(_detail: FilterDetail) {
    // index es el índice del elemento de filtro por si ya existe
    var previous = this.detail.filter(x => x.entity === _detail.entity);
    if (previous.length != 0) {
      var index = this.detail.indexOf(previous[0]);
      this.detail[index] = _detail;
    } else {
      // Si no existe lo creamos
      this.detail.push(_detail);
    }
  }

  remove(entity: string) {
    this.detail = this.detail.filter(x => x.entity !== entity);
  }
}

export class FilterDetail {
  public title: string;
  public entity: string;
  public type: string;
  public subtype: string;
  public values: string[];
  public charValue: string;
  public decValue: number;
  public importMax: number;
  public compareType: any;
  public from: Date;
  public to: Date;
  public content: any;
  constructor(_title: string, _entity: string, _type: string, _subtype: string, _values: string[], _charValue: string, _decValue: number,
    _importMax: number, _compareType: any, _from: Date, _to: Date, _content: any) {
    this.title = _title;
    this.entity = _entity;
    this.type = _type;
    this.subtype = _subtype;
    this.values = _values;
    this.charValue = _charValue;
    this.decValue = _decValue;
    this.importMax = _importMax;
    this.compareType = _compareType;
    this.from = _from;
    this.to = _to;
    this.content = _content;
  };
  }
