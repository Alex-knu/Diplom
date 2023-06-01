import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DepartmentInfoComponent } from './department-info.component';

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: DepartmentInfoComponent }
  ])],
  exports: [RouterModule]
})

export class DepartmentInfoRoutingModule { }
