import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ApplicationEvaluationComponent } from './application-evaluation.component';

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: ApplicationEvaluationComponent }
  ])],
  exports: [RouterModule]
})

export class ApplicationEvaluationRoutingModule { }
