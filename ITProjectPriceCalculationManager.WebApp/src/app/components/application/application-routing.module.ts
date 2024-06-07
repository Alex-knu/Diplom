import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    RouterModule.forChild([
      { path: 'application-table', loadChildren: () => import('./application-table/application-table-routing.module').then(m => m.ApplicationTableRoutingModule) },
      { path: 'application-info', loadChildren: () => import('./application-info/application-info-routing.module').then(m => m.ApplicationInfoRoutingModule) },
      { path: 'application-evaluation', loadChildren: () => import('./application-evaluation/application-evaluation-routing.module').then(m => m.ApplicationEvaluationRoutingModule) },
      { path: 'application-evaluate-paramete-info', loadChildren: () => import('./application-evaluate-paramete-info/application-evaluate-paramete-info-routing.module').then(m => m.ApplicationEvaluationParameterInfoRoutingModule) },
      { path: 'application-evaluate-paramete-table', loadChildren: () => import('./application-evaluate-paramete-table/application-evaluate-paramete-table-routing.module').then(m => m.ApplicationEvaluationParameterTableRoutingModule) },
      { path: 'application-evaluation-parameter-table', loadChildren: () => import('./application-evaluation-paramete-info/application-evaluation-parameter-info.module').then(m => m.ApplicationEvaluationParameterDetalesRoutingModule) },
      { path: '**', redirectTo: '/notfound' }
    ])],
  exports: [RouterModule]
})

export class ApplicationRoutingModule { }
