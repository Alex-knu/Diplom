import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ApplicationEvaluationParameterDetailsComponent } from './application-evaluation-parameter-info.component';

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: ApplicationEvaluationParameterDetailsComponent }
  ])],
  exports: [RouterModule]
})

export class ApplicationEvaluationParameterDetalesRoutingModule { }
