import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    RouterModule.forChild([
      { path: 'application-table', loadChildren: () => import('./application-table/application-table-routing.module').then(m => m.ApplicationTableRoutingModule) },
      { path: 'application-info', loadChildren: () => import('./application-info/application-info-routing.module').then(m => m.ApplicationInfoRoutingModule) },
      { path: 'application-evaluation', loadChildren: () => import('./application-evaluation/application-evaluation-routing.module').then(m => m.ApplicationEvaluationRoutingModule) },
      { path: '**', redirectTo: '/notfound' }
    ])],
  exports: [RouterModule]
})

export class ApplicationRoutingModule { }
