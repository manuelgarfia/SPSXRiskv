import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reporting',
  templateUrl: './reporting.component.html',
  styleUrls: ['./reporting.component.css']
})
export class ReportingComponent implements OnInit {

  constructor(private route: Router) { }

  ngOnInit(): void {

    window.open("http://xriskdev2018.cloudapp.net/Reports/report/XRISK/XRISK_STD_CLIENTE_EXP_es/12_PROYECCION/Proyeccion");

  }

}
