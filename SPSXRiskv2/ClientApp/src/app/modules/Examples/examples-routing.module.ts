import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CounterComponent } from './counter/counter.component';
import { SearchTableComponent } from './search-table/search-table.component';
import { DatePickerComponent } from './date-picker/date-picker.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ProgressBarComponent } from './progress-bar/progress-bar.component';
import { SnackBarComponent } from './snack-bar/snack-bar-component';
import { ModalDialogComponent } from './modal-dialog/modal-dialog.component';
import { MovFisicoExamplesComponent } from './mov-fisico-examples/mov-fisico-examples.component'



const routes: Routes = [
  { path: 'counter', component: CounterComponent },
  { path: 'searchExample', component: SearchTableComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'date-picker', component: DatePickerComponent },
  { path: 'progress-bar', component: ProgressBarComponent },
  { path: 'snack-bar', component: SnackBarComponent },
  { path: 'modal-dialog', component: ModalDialogComponent },
  { path: 'filterExamples', component: MovFisicoExamplesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppExamplesRoutingModule { }
