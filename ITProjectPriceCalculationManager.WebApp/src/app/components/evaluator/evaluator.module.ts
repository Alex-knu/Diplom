import { NgModule } from '@angular/core';
import { EvaluatorRoutingModule } from './evaluator-routing.module';
import { PrimeNgComponentsModule } from 'src/app/modules/primeng-components-module/primeng-components.module';

@NgModule({
  imports: [
    EvaluatorRoutingModule,
    PrimeNgComponentsModule
  ]
})

export class EvaluatorModule { }
