import { NgModule } from '@angular/core';
import { ApplicationRoutingModule } from './application-routing.module';
import { PrimeNgComponentsModule } from 'src/app/modules/primeng-components-module/primeng-components.module';

@NgModule({
  imports: [
    ApplicationRoutingModule,
    PrimeNgComponentsModule
  ]
})

export class ApplicationModule { }
