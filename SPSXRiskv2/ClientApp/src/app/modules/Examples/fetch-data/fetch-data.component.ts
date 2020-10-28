import { Component, OnInit, Inject, HostListener, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MdbTableDirective } from 'angular-bootstrap-md';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent{


  @ViewChild(MdbTableDirective, { static: false }) mdbTable: MdbTableDirective;
  searchText: string = '';
  previous: string;


  public forecasts: WeatherForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
      var a = JSON.stringify(result);
      this.mdbTable.setDataSource(a);
      this.mdbTable.dataSourceChange();
      this.init();
      //this.mdbTable.setDataSource(this.forecasts);
      this.previous = this.mdbTable.getDataSource();
    }, error => console.error(error));

  }

  @HostListener('input') oninput() {
    this.searchItems();
  }

  init() {

    this.mdbTable.setDataSource(this.forecasts);
    this.previous = this.mdbTable.getDataSource(); 
  }
  searchItems() {
    const prev = this.mdbTable.getDataSource();
    if (!this.searchText) {
      this.mdbTable.setDataSource(this.previous);
      this.forecasts = this.mdbTable.getDataSource();
    }
    if (this.searchText) {
      this.forecasts = this.mdbTable.searchLocalDataBy(this.searchText);
      this.mdbTable.setDataSource(prev);
    }

  }


}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
