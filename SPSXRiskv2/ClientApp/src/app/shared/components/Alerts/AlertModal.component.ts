import { Component, OnInit, ViewChild, Output, EventEmitter, HostListener } from '@angular/core';
import { MDBModalRef, MdbTableDirective } from 'angular-bootstrap-md';
import { XRSKCBVService } from 'src/app/shared/services/georgina.service'
import { Template } from '@angular/compiler/src/render3/r3_ast';

@Component({
  selector: 'app-alerts',
  templateUrl: './AlertModal.component.html',
  styleUrls: ['./AlertModal.component.css']
})
export class AlertsComponent implements OnInit {

  constructor(public modalRef: MDBModalRef) {}

  ngOnInit() {

  }
}
