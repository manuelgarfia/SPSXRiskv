import { Component, Input, Output, OnInit, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-object-toolbar',
  templateUrl: './objtoolbar.component.html',
  styleUrls: ['./objtoolbar.component.css']
})
export class ObjtoolbarComponent implements OnInit {

  public _objectName: string;

  @Input()
  set objectName(objectName: string) {
    this._objectName = (objectName && objectName.trim()) || '<no name set>';
  }

  @Output()
  add = new EventEmitter();
  @Output()
  reset = new EventEmitter();
  @Output()
  save = new EventEmitter();
  @Output()
  refresh = new EventEmitter();
  @Output()
  filter = new EventEmitter();

  get objectName(): string { return this._objectName; }

  constructor() { }

  ngOnInit(): void {
  }

  _reset(): void {
    this.reset.emit();
  }  
  _refresh():void {
    this.refresh.emit();
  }
  _add():void {
    this.add.emit();
  }
  _save(): void {
    this.save.emit();
  }
  _filter(): void {
    this.filter.emit();
  }

}
