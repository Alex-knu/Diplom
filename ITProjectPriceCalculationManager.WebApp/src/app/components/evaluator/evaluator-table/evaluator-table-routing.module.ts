import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { EvaluatorTableComponent } from './evaluator-table.component';

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: EvaluatorTableComponent }
  ])],
  exports: [RouterModule]
})

export class EvaluatorTableRoutingModule { }
