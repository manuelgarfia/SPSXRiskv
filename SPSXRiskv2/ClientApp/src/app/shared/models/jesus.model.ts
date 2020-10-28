import { DecimalPipe } from "@angular/common";

export class Jesus {
  linid: number;
  fecha: Date;
  codtipoint: string;
  escenario: string;
  pctinteres: number;
  user_created: string;
  date_created: Date;
  user_updated: string;
  date_updated: Date;

  constructor() {
    this.linid = 0;
    this.fecha = new Date();
    this.codtipoint = "-";
    this.escenario = "-";
    this.pctinteres = 0;
    this.date_created = new Date();
    this.user_created = "angular";
    this.user_updated = "angular";
    this.date_updated = new Date();

  }
}
