import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AppExamplesModule } from './examples/examples.modules.module';
import { AppLearningModule } from './learning/learning.modules.module';
import { AppPortalModule } from './portal/portal.modules.module';

@NgModule({
  imports: [
    CommonModule,
    AppExamplesModule,
    AppLearningModule,
    AppPortalModule
  ],
  declarations: [
  ],
  exports: [
    CommonModule,
    AppExamplesModule,
    AppLearningModule,
    AppPortalModule
  ]
})

export class AppModulesModule { }
