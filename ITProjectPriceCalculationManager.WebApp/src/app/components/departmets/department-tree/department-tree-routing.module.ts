import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DepartmentTreeComponent } from './department-tree.component';

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: DepartmentTreeComponent }
  ])],
  exports: [RouterModule]
})

export class DepartmentTreeRoutingModule { }
