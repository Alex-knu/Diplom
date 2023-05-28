import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ApplicationEvaluationGroupComponent } from './application-evaluation-group.component';

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: ApplicationEvaluationGroupComponent }
  ])],
  exports: [RouterModule]
})
export class ApplicationEvaluationGroupRoutingModule { }
