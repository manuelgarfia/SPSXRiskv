import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-progress-information',
  templateUrl: './progress-information.component.html',
  styleUrls: ['./progress-information.component.css']
})
export class ProgressInformationComponent implements OnInit {

  constructor(private route: Router) { }

  public loaded: boolean = true;

  ngOnInit(): void {
    this.showProgres();
  } 

  showProgres() {
    setTimeout(() => {
      this.loaded = true;
      this.route.navigate(['posicion']);
    }, 4000);
    
  }

}
