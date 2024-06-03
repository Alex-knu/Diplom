import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ApplicationEvaluationParameterTableComponent } from './application-evaluate-paramete-table.component';

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: ApplicationEvaluationParameterTableComponent }
  ])],
  exports: [RouterModule]
})

export class ApplicationEvaluationParameterTableRoutingModule { }
