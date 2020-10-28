import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material.module';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AppSharedRoutingModule } from './shared-routing.module';
import { ModalComponent } from './components/modal/modal.component';
import { ObjtoolbarComponent } from './components/objtoolbar/objtoolbar.component';
import { FilterPipe } from './components/pipes/filter.pipe';
import { EntidadFilter } from './components/pipes/entidadFilter.pipe';
import { ModalgridComponent } from './components/modalgrid/modalgrid.component';
import { ModalZoomComponent } from './components/modal-zoom/modal-zoom.component';
import { MatSelectSearchComponent } from './components/mat-select-search/mat-select-search.component';
import { DropDownComponent } from './components/drop-down/drop-down.component';
import { SideFilterComponent } from './components/side-filter/side-filter.component';
import { LoadingModalComponent } from './components/loading-modal/loading-modal.component';
import { ProgressInformationComponent } from './components/progress-information/progress-information.component';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    AppSharedRoutingModule,
    MDBBootstrapModule
  ],
  declarations: [
    ModalComponent,
    ObjtoolbarComponent,
    FilterPipe,
    EntidadFilter,
    ModalgridComponent,
    ModalZoomComponent,
    MatSelectSearchComponent,
    DropDownComponent,
    SideFilterComponent,
    LoadingModalComponent,
    ProgressInformationComponent,
  ],
  entryComponents: [
    ModalComponent,
    ObjtoolbarComponent,
    FilterPipe,
    EntidadFilter,
    ModalgridComponent,
    MatSelectSearchComponent,
    DropDownComponent,
    SideFilterComponent,
    LoadingModalComponent,
    ProgressInformationComponent,
  ],    
  exports: [
    CommonModule,
    RouterModule, 
    ObjtoolbarComponent,
    FilterPipe,
    EntidadFilter,
    MatSelectSearchComponent,
    DropDownComponent,
    SideFilterComponent,
    LoadingModalComponent,
    ProgressInformationComponent,
  ]
})

export class AppSharedModule { }
