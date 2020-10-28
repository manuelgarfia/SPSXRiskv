import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public notLogged: boolean = false;

  constructor() { };

  ngOnInit() {
    this.onLogin();
  }

  onLogin() {

    this.notLogged = true;

    if (JSON.parse(localStorage.getItem('currentUser')) != null) {
      this.notLogged = false;
    }

  }
}
