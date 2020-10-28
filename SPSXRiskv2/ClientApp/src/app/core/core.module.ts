import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material.module';
import { AppAuthorizationModule } from './modules/authorization/authorization.module';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { AppSharedModule } from 'src/app/shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule,
    AppAuthorizationModule,
    MDBBootstrapModule,
    AppSharedModule
  ],
  declarations: [
    NavMenuComponent,
    SidenavComponent
  ],
  entryComponents: [],
  exports: [
    NavMenuComponent,
    SidenavComponent,
    RouterModule,
  ],
})

export class AppCoreModule { }
