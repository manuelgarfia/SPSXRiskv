import { Component, OnInit, ChangeDetectorRef } from '@angular/core';


/**
 * @title Configurable progress-bar
 */
@Component({
  selector: 'app-date-picker',
  templateUrl: './date-picker.component.html',
})
export class DatePickerComponent {

  constructor(private cdRef: ChangeDetectorRef) { }

  ngOnInit() {


  }

}
