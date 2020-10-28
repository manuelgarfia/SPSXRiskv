import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { Error404Component } from './core/components/error404/error404.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  //{ path: 'jesus', component: JesusComponent },
 // { path: 'georgina', component: GeorginaComponent },
//  { path: 'gforms', component: GformsComponent },
  //{ path: '**', redirectTo: '/' }
  { path: '404', component: Error404Component },
  { path: '**', redirectTo: '404' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
