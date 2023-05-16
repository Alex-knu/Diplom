import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    RouterModule.forChild([
      { path: 'department-tree', loadChildren: () => import('./department-tree/department-tree-routing.module').then(m => m.DepartmentTreeRoutingModule) },
      //{ path: 'application-info', loadChildren: () => import('./application-info/application-info-routing.module').then(m => m.ApplicationInfoRoutingModule) },
      { path: '**', redirectTo: '/notfound' }
    ])],
  exports: [RouterModule]
})

export class DepartmentRoutingModule { }
