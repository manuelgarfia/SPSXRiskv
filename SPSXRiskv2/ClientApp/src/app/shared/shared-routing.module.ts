import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ModalComponent } from './components/modal/modal.component';
import { ModalZoomComponent } from './components/modal-zoom/modal-zoom.component';
import { ObjtoolbarComponent } from './components/objtoolbar/objtoolbar.component';


const routes: Routes = [

  { path: 'modal', component: ModalComponent },
  { path: 'modal-zoom', component: ModalZoomComponent },
  { path: 'toolbar', component: ObjtoolbarComponent }

]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppSharedRoutingModule { }
