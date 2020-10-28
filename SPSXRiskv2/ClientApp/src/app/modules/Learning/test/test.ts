import { Component, OnInit,  Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-test',
  templateUrl: './test.html',
})

export class TestComponent implements OnInit {

    ngOnInit(): void {

  }

  @Output() propagar = new EventEmitter();

  onClick() {
    this.propagar.emit('hola');
  }
}
