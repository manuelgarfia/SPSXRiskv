import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'src/app/core/modules/authorization/auth.guard';

import { XrskPrestamosComponent } from 'src/app/modules/Portal/xrskPrestamos/xrskPrestamos.component'


const routes: Routes = [

  { path: 'prestamos', component: XrskPrestamosComponent }
];                                          

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppPortalRoutingModule { }
