import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ApplicationEvaluationParameterInfoComponent } from './application-evaluate-paramete-info.component';

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: ApplicationEvaluationParameterInfoComponent }
  ])],
  exports: [RouterModule]
})

export class ApplicationEvaluationParameterInfoRoutingModule { }
