import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'src/app/core/modules/authorization/auth.guard';

import { XrskPrestamosComponent } from 'src/app/modules/Portal/xrskPrestamos/xrskPrestamos.component';
import { XrskLeasingsComponent } from 'src/app/modules/Portal/xrskLeasings/xrskLeasings.component';
import { XrskPortalProcesos } from 'src/app/modules/Portal/xrskPortalProcesos/xrskPortalProcesos.component';


const routes: Routes = [

  { path: 'prestamos', component: XrskPrestamosComponent },
  { path: 'leasings', component: XrskLeasingsComponent },
  { path: 'procesos', component: XrskPortalProcesos },
];                                          

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppPortalRoutingModule { }
