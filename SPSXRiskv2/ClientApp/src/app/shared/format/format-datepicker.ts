import { NativeDateAdapter } from '@angular/material/core';
import { MatDateFormats } from '@angular/material/core';
import { Injectable } from '@angular/core';
import { DatePipe, getLocaleFirstDayOfWeek } from '@angular/common';
@Injectable()
export class AppDateAdapter extends NativeDateAdapter {

  format(date: Date, displayFormat: Object): string {
    if (displayFormat === 'input') {
      let day: string = date.getDate().toLocaleString();
      day = +day < 10 ? '0' + day : day;
      let month: string = (date.getMonth() + 1).toString();
      month = +month < 10 ? '0' + month : month;
      let year = date.getFullYear();
      return `${day}-${month}-${year}`;
    }
    const options = { weekday: 'long', year: 'numeric', month: 'short', day: 'numeric' };
    return new DatePipe(this.locale).transform(date, 'EEE d \'DE\' MMM \'DE\' y');
    //return date.toLocaleDateString("es-ES", options);
  }

  parse(value: any): Date | null {
    if ((typeof value === 'string') && (value.indexOf('-') > -1)) {
      const str = value.split('-');

      const year = Number(str[2]);
      const month = Number(str[1]) - 1;
      const date = Number(str[0]);

      return new Date(year, month, date);
    }
    const timestamp = typeof value === 'number' ? value : Date.parse(value);
    return isNaN(timestamp) ? null : new Date(timestamp);
  }

  getFirstDayOfWeek() {
    //return 1;
    return getLocaleFirstDayOfWeek(this.locale);
  }

  //format(date: Date, displayFormat: Object): string {
  //  if (displayFormat === 'input') {
  //    let day: string = date.getDate().toString();
  //    day = +day < 10 ? '0' + day : day;
  //    let month: string = (date.getMonth() + 1).toString();
  //    month = +month < 10 ? '0' + month : month;
  //    let year = date.getFullYear();
  //    return `${day}-${month}-${year}`;
  //  }
  //  return date.toDateString();
  //}
}
export const APP_DATE_FORMATS: MatDateFormats = {
  parse: {
    dateInput: { month: 'long', year: 'numeric', day: 'numeric' },
  },
  display: {
    dateInput: 'input',
    monthYearLabel: { year: 'numeric', month: 'numeric' },
    dateA11yLabel: { year: 'numeric', month: 'long', day: 'numeric'
    },
    monthYearA11yLabel: { year: 'numeric', month: 'long' },
  }
};
