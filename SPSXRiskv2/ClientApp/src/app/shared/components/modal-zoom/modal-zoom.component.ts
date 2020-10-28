import { Component, OnInit, HostListener, ViewChild,EventEmitter, Output, ChangeDetectorRef } from '@angular/core';
import { MDBModalRef } from 'angular-bootstrap-md';
import { MdbTableDirective, MdbTablePaginationComponent, TableModule, ModalDirective, CollapseComponent, ModalModule, WavesModule, InputsModule } from 'angular-bootstrap-md';


@Component({
  selector: 'app-modal-zoom',
  templateUrl: './modal-zoom.component.html',
  styleUrls: ['./modal-zoom.component.css'] 
})
export class ModalZoomComponent {

  @ViewChild('tableEl') mdbTable: MdbTableDirective;
  @ViewChild(MdbTablePaginationComponent, { static: false }) mdbTablePagination: MdbTablePaginationComponent;
 

  heading: string;
  afirmative: string; 
  negative: string;
  elements: any[];
  items: any[];
  properties: any[];

  searchText: string = '';
  previous: any[];


  @Output() action = new EventEmitter();

  constructor(public modalRef: MDBModalRef, public cdRef: ChangeDetectorRef) { }

  @HostListener('input') oninput() {
    this.searchItems();
  }

   
  ngOnInit(): void {
    var j = 1;
    this.elements = this.items;
  }

  aceptar() {
    this.action.emit(true);
    this.modalRef.hide();
  }

  cancelar() {   
    this.action.emit(false);
    this.modalRef.hide();
  }

  // Local search in table
  searchItems() {
    const prev = this.mdbTable.getDataSource();
    if (!this.searchText) {
      this.mdbTable.setDataSource(this.previous);
      this.elements = this.mdbTable.getDataSource();
    }
    if (this.searchText) {
      this.elements = this.mdbTable.searchLocalDataBy(this.searchText);
      this.mdbTable.setDataSource(prev);
    }

  }

  ngAfterViewInit() {
    this.previous = this.elements;
    this.mdbTable.setDataSource(this.elements);
    this.elements = this.mdbTable.getDataSource();

    this.mdbTablePagination.setMaxVisibleItemsNumberTo(5);

    this.mdbTablePagination.calculateFirstItemIndex();
    this.mdbTablePagination.calculateLastItemIndex();
    this.cdRef.detectChanges();
  }
  
}
