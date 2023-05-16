import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PrimeNgComponentsModule } from 'src/app/modules/primeng-components-module/primeng-components.module';
import { DepartmentRoutingModule } from './department-routing.module';

@NgModule({
  imports: [
    CommonModule,
    DepartmentRoutingModule,
    PrimeNgComponentsModule
  ]
})

export class DepartmentModule { }
