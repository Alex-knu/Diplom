import { NgModule } from '@angular/core';
import { PrimeNgComponentsModule } from 'src/app/modules/primeng-components-module/primeng-components.module';
import { DepartmentRoutingModule } from './department-routing.module';

@NgModule({
  imports: [
    DepartmentRoutingModule,
    PrimeNgComponentsModule
  ]
})

export class DepartmentModule { }
