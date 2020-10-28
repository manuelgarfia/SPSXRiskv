import { Component, OnInit, ViewChild, EventEmitter, Output, Input, SimpleChanges } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Observable, Subject, ReplaySubject } from 'rxjs';
import { MatSelect } from '@angular/material/select';
import { takeUntil, take, startWith, map } from 'rxjs/operators';

import { XRSKCIAService } from 'src/app/shared/services/cia.service';
import { ciamodel } from 'src/app/shared/models/ciamodel'
import { filtermodel } from '../../models/filtermodel';

export interface StateGroup {
  letter: string;
  names: string[];
}

@Component({
  selector: 'app-drop-down',
  templateUrl: './drop-down.component.html',
  styleUrls: ['./drop-down.component.css']
})
export class DropDownComponent implements OnInit {

  public list: any[];
  public item: string;
  //public itemValue: string;
  public label: string;
  public test: string = 'hola';

  searchForm: FormGroup;
  public filteredItems: ReplaySubject<filtermodel[]> = new ReplaySubject<filtermodel[]>(1);
  public filterControl: FormControl = new FormControl();

  private _onDestroy = new Subject<void>();


  @ViewChild('ciaSelect') ciaSelect: MatSelect;

  @Input() itemsList: any;
  @Input() AutocompleteLabel: string;
  @Input() itemValue: string;
  @Output() itemValueChange = new EventEmitter();


  constructor(private ciaservice: XRSKCIAService) { }

  ngOnInit(): void {
    this.getList();
  }

  ngOnChanges(changes: SimpleChanges) {
    if (this.itemsList != null) {
      this.label = this.AutocompleteLabel;
      this.test = this.itemValue;
      //this.itemValue = this.editValue;
      this.getList();
      console.log(this.itemValue);
    }
  }

  emitValue(value) {
    this.itemValueChange.emit(value);
   // this.item = value;
  }

  getList() {

    this.list = this.itemsList;

    if (this.list != null) {
      this.filteredItems.next(this.list.slice());
      this.filterControl.valueChanges
        .pipe(takeUntil(this._onDestroy))
        .subscribe(() => {
          this.filterItems();
        });
    }

  }

  private filterItems() {
    if (!this.list) {
      return;
    }

    let search = this.filterControl.value;
    if (!search) {
      this.filteredItems.next(this.list.slice());
      return;
    } else {
      search = search.toLowerCase();
    }

    this.filteredItems.next(
      this.list.filter(list => list.description.toLowerCase().indexOf(search) > -1)
    );
  }


  private setInitialValueT() {

    this.filteredItems
      .pipe(take(1), takeUntil(this._onDestroy))
      .subscribe(() => {
      });
  }

  ngAfterViewInit() {
    this.setInitialValueT();
    //this.itemValue = this.editValue;
  }

}
