import { Component, OnInit, ViewChild, Output, EventEmitter, HostListener } from '@angular/core';
import { MDBModalRef, MdbTableDirective } from 'angular-bootstrap-md';

@Component({
  selector: 'app-popUpComponent',
  templateUrl: './procesosPopUp.component.html',
  styleUrls: ['./procesosPopUp.component.css']
})
export class popUpComponent implements OnInit {

  constructor(public modalRef: MDBModalRef) { }

  ngOnInit() {

  }
}
