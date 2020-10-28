import { Component, OnInit, ChangeDetectorRef } from '@angular/core';


/**
 * @title Configurable progress-bar
 */
@Component({
  selector: 'app-progress',
  templateUrl: './progress-bar.component.html',
  styleUrls: ['./progress-bar.component.css'],
})
export class ProgressBarComponent {

  color = 'primary';
  mode = 'indeterminate';
  value = 50;
  bufferValue = 75;

}
