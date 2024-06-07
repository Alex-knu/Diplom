import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ApplicationEvaluationParameterDetalesComponent } from './application-evaluation-parameter-info.component';

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: ApplicationEvaluationParameterDetalesComponent }
  ])],
  exports: [RouterModule]
})

export class ApplicationEvaluationParameterDetalesRoutingModule { }
