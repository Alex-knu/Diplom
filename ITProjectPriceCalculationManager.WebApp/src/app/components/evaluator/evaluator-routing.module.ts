import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    RouterModule.forChild([
      { path: 'evaluator-table', loadChildren: () => import('./evaluator-table/evaluator-table-routing.module').then(m => m.EvaluatorTableRoutingModule) },
      { path: 'evaluator-info', loadChildren: () => import('./evaluator-info/evaluator-info-routing.module').then(m => m.EvaluatorInfoRoutingModule) },
      { path: '**', redirectTo: '/notfound' }
    ])],
  exports: [RouterModule]
})

export class EvaluatorRoutingModule { }
