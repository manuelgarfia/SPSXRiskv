import { Component, OnInit, HostListener, ViewChild, AfterViewInit, ChangeDetectorRef} from '@angular/core';
import { MdbTableDirective, MdbTablePaginationComponent } from 'angular-bootstrap-md';

@Component({
  selector:
    'search-table', templateUrl: './search-table.component.html'
})
export class SearchTableComponent {
  @ViewChild(MdbTablePaginationComponent, { static: true }) mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild(MdbTableDirective, { static: true }) mdbTable: MdbTableDirective;
  elements: any = [];
  previous: any = [];
  headElements = ['ID', 'First', 'Last', 'Handle'];
  searchText: string = '';
  //previous: string;
  constructor(private cdRef: ChangeDetectorRef) { }

  @HostListener('input') oninput() {
    this.searchItems();
  }
  ngOnInit() {
    for (let i = 1; i <= 15; i++) {
      this.elements.push({
        id: i.toString(), first: 'Wpis ' + i, last: 'Last ' + i, handle: 'Handle ' + i
      });
    }
    this.mdbTable.setDataSource(this.elements);
    this.elements = this.mdbTable.getDataSource();
    this.previous =this.mdbTable.getDataSource();
  }

  ngAfterViewInit() {
    
    this.mdbTablePagination.setMaxVisibleItemsNumberTo(5);

    this.mdbTablePagination.calculateFirstItemIndex();
    this.mdbTablePagination.calculateLastItemIndex();
    this.cdRef.detectChanges();
    
  }

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
}
