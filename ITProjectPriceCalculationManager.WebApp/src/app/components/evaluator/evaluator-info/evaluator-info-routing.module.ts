import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { EvaluatorInfoComponent } from './evaluator-info.component';

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: EvaluatorInfoComponent }
  ])],
  exports: [RouterModule]
})
export class EvaluatorInfoRoutingModule { }
