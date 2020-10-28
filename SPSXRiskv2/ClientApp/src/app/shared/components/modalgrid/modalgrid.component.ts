import { Component, OnInit, ViewChild, Output, EventEmitter, HostListener } from '@angular/core';
import { MDBModalRef, MdbTableDirective } from 'angular-bootstrap-md';
import { XRSKCBVService } from 'src/app/shared/services/georgina.service'
import { Template } from '@angular/compiler/src/render3/r3_ast';

@Component({
  selector: 'app-modalgrid',
  templateUrl: './modalgrid.component.html',
  styleUrls: ['./modalgrid.component.css']
})
export class ModalgridComponent implements OnInit {

  @ViewChild('table_ent') modal_mdb: MdbTableDirective;
  @Output() propagar = new EventEmitter();

  constructor(public modalRef: MDBModalRef, public cbv_service: XRSKCBVService) { }

  modal_title: string;
  modal_list: any[];
  search_item = '';
  public modalOptionsZoom: any;
  properties: any;
  heading: string;
  items: any[];
  row: any;
  searchText: string;
  previous: any[];
  elements: any[];

  templateName: boolean = false;
  ZoomTemplate: boolean = true;

  public changeColor: {};

  ngOnInit(): void {
    this.elements = this.items;
    this.selectTypeTable();
  }

  selectTypeTable() {
    for (let item of this.items) {
      if (item.name == "PREFERENCIAS")
        this.ZoomTemplate = false;
    }
  }


  onClickRow(item) {
    this.row = item;
  }

  onConfirm() {
    this.propagar.emit(this.row);
    this.modalRef.hide();
  }

  @HostListener('input') oninput() {
    this.searchItems();
  }

  searchItems() {
    const prev = this.modal_mdb.getDataSource();
    this.items = this.elements;
    if (!this.searchText) {
      this.modal_mdb.setDataSource(this.previous);
      this.items = this.modal_mdb.getDataSource();
    }
    if (this.searchText) {
      this.items = this.modal_mdb.searchLocalDataBy(this.searchText);
      this.modal_mdb.setDataSource(prev);
    }

  }

  ngAfterViewInit() {
    if (this.ZoomTemplate == true) {
      this.previous = this.elements;
      this.modal_mdb.setDataSource(this.elements);
      this.elements = this.modal_mdb.getDataSource();
    }
  }

}
